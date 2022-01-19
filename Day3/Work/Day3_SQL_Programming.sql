-- follow-along exercise
-- day3 19/01/2022

use Northwind

begin
declare
	@num int,
	@dob datetime
	
	set @num = 12
	set @dob = '01-02-2000'

	print 'Hello World!'
	print @dob
	
	if @num < 20
		print cast(@num as varchar) + ' is less than 20'

	while @num < 20
	begin
		print @num
		set @num = @num + 1
	end
end

-- ===========================================================================================

-- procedures
create proc proc_PrintResult (@score int)
as
begin
	if (@score>70)
		print 'Pass'
	else
		print 'Fail'
end

exec proc_PrintResult 60, 'Tim'

alter proc proc_PrintResult (@score int,
							 @name varchar(20))
as
begin
	print 'Hello ' + @name
	if (@score>70)
		print 'Pass'
	else
		print 'Fail'
end

-- ===========================================================================================

create proc proc_CalculateTax (@amount float,
							   @tax float out)
as
begin
	set @tax = @amount * 0.7
end

declare @tax float
exec proc_CalculateTax 10000, @tax out
print 'Your tax amount is ' + cast(@tax as varchar)

-- ===========================================================================================

select * from Customers

alter proc proc_PrintPayable (@orderNum varchar(5))
as
begin
	declare
		@custName varchar(20),
		@gross float,
		@discount float,
		@fright float,
		@netPrice float

		set @custName = (select ContactName
						 from Customers
						 where CustomerID = (select CustomerID
											 from Orders
											 where OrderID = @orderNum))
		set @gross = (select sum(unitprice*quantity)
					  from [Order Details]
					  where OrderID = @orderNum)
		set @discount = (select sum(Discount)
						 from [Order Details]
						 where OrderID = @orderNum)
		if(@discount>0)
			set @gross = @gross -( @gross*@discount/100 )
		set @fright = (select Freight 
					   from Orders 
					   where OrderID = @orderNum)
		set @netPrice = @gross + @fright

		print 'Hello ' + @custName
		print 'Gross amount: $'+cast(@gross as varchar)
		print 'Freight amount: $'+cast(@fright as varchar)
		print '-------------------------'
		print 'Net Price: $'+ cast(@netPrice as varchar)
end

exec proc_PrintPayable '10248'

-- ===========================================================================================

-- procedure pros
-- - increase performace
-- - more secure when comes to passing data from front end to the back end
-- - extra level of enscapsulation (database architecture is only known to the db person)
-- - reduce complication

-- ===========================================================================================

create proc proc_FetchAllCustomers
as
  select * from Customers

exec proc_FetchAllCustomers

-- ===========================================================================================
-- transactions
-- rollback - undo all dml queries from 'begin tran'
-- used for consistency and automation

create table tblSimple
	(f1 int primary key,
	 f2 varchar(20))

create proc proc_InsertIntoSimple(@f1 int,
								  @f2 varchar(20))
as
  insert into tblSimple values(@f1, @f2)

exec proc_InsertIntoSimple 101,'Hello'

select * from tblSimple

create table tblStatus
	(f1 int primary key,
	 msg varchar(20))

begin tran
   insert into tblSimple values(103,'Check hello')
   insert into tblStatus values(103,'Success')
   if((select count(f1) from tblSimple where f2 = 'Check hello')>0)
      rollback
   else
     commit

alter proc proc_Transaction(@f1 int,@f2 varchar(20))
as
begin
    begin tran
	declare @count int
	set @count = (select count(f1) from tblSimple where f2 = @f2)
	   insert into tblSimple values(@f1,@f2)
	   insert into tblStatus values(@f1,'Success')
	   if(@count>0)
		  rollback
	   else
		 commit
end

exec proc_Transaction 105,'NewHello'

select * from tblSimple
select * from tblStatus

-- ===========================================================================================
-- create a stored procedure that will calculate the total salary
-- take input of basic, dearness allowance (da), house rent allowance (hra), deductions and number of leaves
-- if number of leave is more than 2, deduct the day for the extra days and calculate the nett salary

-- basic + da +

use Northwind

create proc proc_TotalSalary (@basic float,
							  @da float,
							  @hra float,
							  @deductions float,
							  @leaves int)
as
begin
	declare
		@total float,
		@perDay float,
		@deductible int
	
	set @total = @basic + @da + @hra - @deductions
	set @perDay = @total / 30

	if @leaves > 2
		set @total = @total - (@perDay * (@leaves - 2))
	
	print 'Basic pay: $' + cast(@basic as varchar)
	print 'Dearness allowance: $' + cast(@da as varchar)
	print 'House rent allowance: $' + cast(@hra as varchar)
	print 'Deductions: $' + cast(@deductions as varchar)
	print 'No. of leaves: ' + cast(@leaves as varchar) + ' day(s)'
	print '------------------------------------'
	print 'Total salary: $' + cast(@total as varchar)
end

exec proc_TotalSalary 5000, 100, 1000, 200, 2

-- ===========================================================================================
-- functions

alter function fn_Sample (@num int)
returns varchar(20)
as
begin
	declare @output varchar(20),
			@total int
	set @total = @num * @num
	set @output = 'total '
	return @output + cast(@total as varchar)
end

select dbo.fn_Sample(10) 

-- ===========================================================================================

create function fn_CalSalTable (@basic float,
								@da float, 
								@hra float, 
								@deduction float, 
								@numLeaves int)
returns @SalTable table(GrossAmount float,
						LeaveDeductions float,
						NetAmount float)
as
begin
	declare
		@nettSalary float,
		@grossSalary float

	set @grossSalary = @basic + @da + @hra - @deduction

	if(@numLeaves > 2)
		begin
			declare @perDaySal float
			set @perDaySal = @grossSalary / 30
			set @nettSalary = @grossSalary - ((@numLeaves -2)*@perDaySal)
			insert into @SalTable values(@grossSalary, ((@numLeaves -2)*@perDaySal), @nettSalary)
		end
	else
		begin
		   set @nettSalary = @grossSalary
		   insert into @SalTable values(@grossSalary, 0, @nettSalary)
		end
	return
end

select * from dbo.fn_CalSalTable(10000, 5000, 3000, 1500, 4)

-- ===========================================================================================
-- triggers

create trigger trg_InsertCheck
on tblSimple
for update
as
begin
	print 'Table updated!'
end

select * from tblSimple
update tblSimple set f2 = 'entry1' where f1 = 101
insert into tblSimple values (102, 'entry2')

-- ===========================================================================================

create table account
(accno		int primary key,
 balance	float)

create table trans
(tranno		int primary key,
 fromacc	int references account(accno),
 toacc		int references account(accno),
 amount		float,
 status		varchar(100))

insert into account values(101,5000)
insert into account values(102,1000)
insert into account values(103,10000)


create trigger trg_Transact
on trans
for insert
as
begin
     declare @bal float,
			 @check float,
			 @credit float

	 set @bal = (select balance from account where accno =(select fromacc from inserted))
	 set @credit = (select amount from inserted)
	 set @check = @bal - (select amount from inserted)

	 if(@check < 500)
		update trans set status = 'Failed' where tranno = (select tranno from inserted)
	 else
		 begin
		   update account set balance = @check 
						  where accno = (select fromacc from inserted)
		   update account set balance = balance + @credit 
						  where accno = (select toacc from inserted)
		   update trans set status = 'Success' 
						where tranno = (select tranno from inserted)
		 end
end

select * from account
select * from trans

insert into trans values(3,101,102,3100,null)

-- ===========================================================================================
-- cursors

declare 
@account int,
@Balance float

DECLARE cur_account CURSOR FOR select * from account

OPEN cur_account

FETCH NEXT FROM cur_account INTO @account,@balance

while(@@FETCH_STATUS =0)
begin
   print 'Account number : '+ cast(@account as varchar(20))
   print 'Account Balance : '+ cast(@Balance as varchar(20))
   print '-----------------------------------'
  
	   declare @amount float, @status varchar(20)
	   DECLARE cur_tran CURSOR FOR select amount,status from trans where fromacc = @account

	   OPEN cur_tran

	   FETCH NEXT FROM cur_tran INTO @amount,@status
	    
	   while(@@FETCH_STATUS =0)
	   begin
		   print '               Amount transffered : '+ cast(@amount as varchar(20))
		   print '               Transaction status : '+ @status
		   print '-----------------------------------'
		   FETCH NEXT FROM cur_tran INTO @amount,@status
	   end 

	   CLOSE cur_tran
	   DEALLOCATE cur_tran
   FETCH NEXT FROM cur_account INTO @account,@balance
end

CLOSE cur_account
DEALLOCATE cur_account
