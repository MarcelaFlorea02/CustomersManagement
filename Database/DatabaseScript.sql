
--create a new database 
create database CustomersDB

use CustomersDB;
GO

--create a new table: Customer 
create table Customer (
Id int identity(1,1) primary key,
FirstName varchar(50) not null, 
LastName varchar(50) not null, 
Email varchar(100) not null unique,
Phone varchar(20) null, 
CreatedAt datetime not null default getdate()
)

--insert values in Customer table 
insert into Customer (FirstName, LastName, Email) 
values ('John','Doe','john.doe@email.com'),
('Jane','Smith', 'jane.smith@email.com'),
('Alex','Popescu','alex.popoescu@email.com')

--retrive data 
select * from Customer
select * from Customer where LastName = 'Doe'
select * from Customer where FirstName like 'J%' -- firstname starts with J 

--update a customer 
update Customer 
set Phone = '99999999'
where Id = 1

-- delete a customer 
delete from Customer
where Email = 'jane.smith@email.com'

-- count the total number of records
select count(*) as TotalCount from Customer