use myDB

-- create table
create table Employee (
userid		int identity(101,1) primary key,
name		varchar(20),
age			int)

-- procedures
-- 1
create proc proc_AddEmp( @name varchar(50),
						 @age int)
as
begin
  insert into Employee (name, age) values(@name, @age)
end

-- 2
create proc proc_UpdateEmp(@id int, @age int)
as
begin
  update Employee set age = @age where userid = @id
end

-- 3
create proc proc_GetEmpById(@id int)
as
begin
  Select * from Employee where userid = @id
end

-- 4
create proc proc_GetAllEmp
as
begin
  select userid, name, age
  from Employee
end

-- 5
create proc proc_RemoveEmp(@id int)
as
begin
	delete from Employee
	where userid = @id
end

-- exec proc
proc_AddEmp 'John Doe', 38
proc_UpdateEmp 101, 40
proc_GetEmpById 101
proc_GetAllEmp
proc_RemoveEmp 101