-- follow-along practice
-- day2 18/1/2022

use Northwind

select * from Products

select * from Products
where SupplierID > 5
and SupplierID < 10

select * from Products
where SupplierID = 15
or UnitsInStock < 5

select * from Products
where ProductName like '%Tofu%'

select * from Products
where ProductName like '_on%'

select avg(UnitPrice) Average from Products
where SupplierID in (2,6,9)

select * from INFORMATION_SCHEMA.tables;

select * from Employees

select distinct City from Employees

select * from Employees order by BirthDate

select * from Products
where ProductName like '%e%'
order by SupplierID

select SupplierID, count(ProductID) 'Count'
from Products
where UnitsInStock > 0
group by SupplierID
having count(ProductID) > 2
order by 'Count'

select Salesperson, round(avg(UnitPrice),2) Average
from Invoices
where ShipCountry = 'France' and CustomerName like '%e%'
group by Salesperson
having avg(UnitPrice) > 3
order by Salesperson

-- nested select statements
select * 
from Products
where SupplierID in ( select SupplierID
					  from Suppliers
					  where CompanyName = 'Tokyo Traders')

select * from Suppliers

select SupplierID, avg(UnitsInStock) Average
from Products
where SupplierID in ( select SupplierID
					  from Suppliers
					  where Region is not null )
group by SupplierID
having avg(UnitsInStock) > 3
order by Average

select *
from Products
where CategoryID in ( select CategoryID
					  from Categories
					  where CategoryName like '%pro%' )
and UnitsInStock > 0
order by UnitPrice

select * from Categories

-- joins
select * from [Order Details]

select ProductName, od.UnitPrice, Quantity, od.UnitPrice*Quantity 'Total'
from Products p join [Order Details] od
on p.ProductID = od.ProductID
order by ProductName

select CompanyName, ContactName, OrderDate
from Customers c join Orders o
on c.CustomerID = o.CustomerID

select CustomerID
from Customers
where CustomerID not in ( select c.CustomerID
						  from Customers c join Orders o
						  on c.CustomerID = o.CustomerID )

select CustomerID
from Customers
where CustomerID not in ( select distinct CustomerID
						  from Orders )

select ContactName, OrderDate
from Customers c join Orders o
on c.CustomerID = o.CustomerID

select concat(firstname,' ',lastname) 'Full Name', count(OrderID) 'Count'
from Employees e join Orders o
on e.EmployeeID = o.EmployeeID
group by concat(firstname,' ',lastname)

select ContactName 'Customer Name', o.OrderID, p.ProductName
from Customers c join Orders o on c.CustomerID = o.CustomerID
				 join [Order Details] od on o.OrderID = od.OrderID
				 join Products p on od.ProductID = p.ProductID

-- cross join -> unrelated tables -> for probability
select * from Region cross join Shippers

-- self join
select emp.EmployeeId 'Employee ID', 
	   emp.FirstName 'Employee Name', 
	   emp.ReportsTo 'Manager ID', 
	   mgr.FirstName 'Manager Name'
from Employees emp join Employees mgr
on emp.ReportsTo = mgr.EmployeeID