--select database
use master

--create database
create database DB_Day1

--select database
use DB_Day1

--create tables
create table DEPARTMENT
(D_DeptName		varchar(20) primary key,
 DeptFloor		int,
 DeptPhone		varchar(2))

create table EMPLOYEE
(EmpNum			int identity(1,1) primary key,
 EmpName		varchar(20) not null,
 Salary			float,
 E_DeptName		varchar(20) references DEPARTMENT(D_DeptName),
 BossNum		int references EMPLOYEE(EmpNum))

alter table DEPARTMENT
add MgrID int references EMPLOYEE(EmpNum)

create table ITEM
(I_ItemName		varchar(50) primary key,
 ItemType		varchar(1) check(itemType in ('B', 'C', 'E', 'F', 'N', 'R')),
 ItemColor		varchar(20))

create table SALES
(SalesNum		int identity(101,1) primary key,
 SaleQty		int,
 S_ItemName		varchar(50) references ITEM(I_ItemName) not null,
 S_DeptName		varchar(20) references DEPARTMENT(D_DeptName) not null)


sp_Help SALES

--====================================================================================

--insert data
insert into DEPARTMENT(D_DeptName, DeptFloor, DeptPhone) values('Management', 5, '34')
insert into DEPARTMENT(D_DeptName, DeptFloor, DeptPhone) values('Books', 1, '81')
insert into DEPARTMENT(D_DeptName, DeptFloor, DeptPhone) values('Clothes', 2, '24')
insert into DEPARTMENT(D_DeptName, DeptFloor, DeptPhone) values('Equipment', 3, '57')
insert into DEPARTMENT(D_DeptName, DeptFloor, DeptPhone) values('Furniture', 4, '14')
insert into DEPARTMENT(D_DeptName, DeptFloor, DeptPhone) values('Navigation', 1, '41')
insert into DEPARTMENT(D_DeptName, DeptFloor, DeptPhone) values('Recreation', 2, '29')
insert into DEPARTMENT(D_DeptName, DeptFloor, DeptPhone) values('Accounting', 5, '35')
insert into DEPARTMENT(D_DeptName, DeptFloor, DeptPhone) values('Purchasing', 5, '36')
insert into DEPARTMENT(D_DeptName, DeptFloor, DeptPhone) values('Personnel', 5, '37')
insert into DEPARTMENT(D_DeptName, DeptFloor, DeptPhone) values('Marketing', 5, '38')


insert into EMPLOYEE values('Alice', 75000, 'Management', null)
insert into EMPLOYEE values('Ned', 45000, 'Marketing', 1)
insert into EMPLOYEE values('Andrew', 25000, 'Marketing', 2)
insert into EMPLOYEE values('Clare', 22000, 'Marketing', 2)
insert into EMPLOYEE values('Todd', 38000, 'Accounting', 1)
insert into EMPLOYEE values('Nancy', 22000, 'Accounting', 5)
insert into EMPLOYEE values('Brier', 43000, 'Purchasing', 1)
insert into EMPLOYEE values('Sarah', 56000, 'Purchasing', 7)
insert into EMPLOYEE values('Sophile', 35000, 'Personnel', 1)
insert into EMPLOYEE values('Sanjay', 15000, 'Navigation', 3)
insert into EMPLOYEE values('Rita', 15000, 'Books', 4)
insert into EMPLOYEE values('Gigi', 16000, 'Clothes', 4)
insert into EMPLOYEE values('Maggie', 11000, 'Clothes', 4)
insert into EMPLOYEE values('Paul', 15000, 'Equipment', 3)
insert into EMPLOYEE values('James', 15000, 'Equipment', 3)
insert into EMPLOYEE values('Pat', 15000, 'Furniture', 3)
insert into EMPLOYEE values('Mark', 15000, 'Recreation', 3)


update DEPARTMENT set MgrID = 1 where D_DeptName = 'Management'
update DEPARTMENT set MgrID = 4 where D_DeptName = 'Books'
update DEPARTMENT set MgrID = 4 where D_DeptName = 'Clothes'
update DEPARTMENT set MgrID = 3 where D_DeptName = 'Equipment'
update DEPARTMENT set MgrID = 3 where D_DeptName = 'Furniture'
update DEPARTMENT set MgrID = 3 where D_DeptName = 'Navigation'
update DEPARTMENT set MgrID = 4 where D_DeptName = 'Recreation'
update DEPARTMENT set MgrID = 5 where D_DeptName = 'Accounting'
update DEPARTMENT set MgrID = 7 where D_DeptName = 'Purchasing'
update DEPARTMENT set MgrID = 9 where D_DeptName = 'Personnel'
update DEPARTMENT set MgrID = 2 where D_DeptName = 'Marketing'


insert into ITEM values('Pocket Knife-Nile', 'E', 'Brown')
insert into ITEM values('Pocket Knife-Avon', 'E', 'Brown')
insert into ITEM values('Compass', 'N', null)
insert into ITEM values('Geo positioning system', 'N', null)
insert into ITEM values('Elephant Polo stick', 'R', 'Bamboo')
insert into ITEM values('Camel Saddle', 'R', 'Brown')
insert into ITEM values('Sextant', 'N', null)
insert into ITEM values('Map Measure', 'N', null)
insert into ITEM values('Boots-snake proof', 'C', 'Green')
insert into ITEM values('Pith Helmet', 'C', 'Khaki')
insert into ITEM values('Hat-polar Explorer', 'C', 'White')
insert into ITEM values('Exploring in 10 Easy Lessons', 'B', null)
insert into ITEM values('Hammock', 'F', 'Khaki')
insert into ITEM values('How to win Foreign Friends', 'B', null)
insert into ITEM values('Map case', 'E', 'Brown')
insert into ITEM values('Safari Chair', 'F', 'Khaki')
insert into ITEM values('Safari cooking kit', 'F', 'Khaki')
insert into ITEM values('Stetson', 'C', 'Black')
insert into ITEM values('Tent - 2 person', 'F', 'Khaki')
insert into ITEM values('Tent - 8 person', 'F', 'Khaki')


insert into SALES values(2, 'Boots-snake proof', 'Clothes')
insert into SALES values(1, 'Pith Helmet', 'Clothes')
insert into SALES values(1, 'Sextant', 'Navigation')
insert into SALES values(3, 'Hat-polar Explorer', 'Clothes')
insert into SALES values(5, 'Pith Helmet', 'Equipment')
insert into SALES values(2, 'Pocket Knife-Nile', 'Clothes')
insert into SALES values(3, 'Pocket Knife-Nile', 'Recreation')	
insert into SALES values(1, 'Compass', 'Navigation'	)
insert into SALES values(2, 'Geo positioning system', 'Navigation')
insert into SALES values(5, 'Map Measure', 'Navigation')
insert into SALES values(1, 'Geo positioning system', 'Books')
insert into SALES values(1, 'Sextant', 'Books')
insert into SALES values(3, 'Pocket Knife-Nile', 'Books')
insert into SALES values(1, 'Pocket Knife-Nile', 'Navigation')
insert into SALES values(1, 'Pocket Knife-Nile', 'Equipment')
insert into SALES values(1, 'Sextant', 'Clothes')
insert into SALES values(1, 'Sextant', 'Equipment')
insert into SALES values(1, 'Sextant', 'Recreation')
insert into SALES values(1, 'Sextant', 'Furniture')
insert into SALES values(1, 'Pocket Knife-Nile', 'Furniture')
insert into SALES values(1, 'Exploring in 10 easy lessons', 'Books')
insert into SALES values(1, 'How to win foreign friends', 'Books')
insert into SALES values(1, 'Compass', 'Books')
insert into SALES values(1, 'Pith Helmet', 'Books')
insert into SALES values(1, 'Elephant Polo stick', 'Recreation')
insert into SALES values(1, 'Camel Saddle', 'Recreation')


--====================================================================================

select * from DEPARTMENT
select * from EMPLOYEE
select * from ITEM
select * from SALES
