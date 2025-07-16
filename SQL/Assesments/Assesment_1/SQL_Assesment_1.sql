create database Assesments
use Assesments

--Question-1: Create a book table with id as primary key and provide the appropriate data type to other attributes .isbn no should be unique for each book
--Write a query to fetch the details of the books written by author whose name ends with er.

create table Books (id int primary key,title varchar(50),Author varchar(30),isbn numeric unique,published_date datetime)


insert into Books values(1,'My First SQL Book','Mary Parker',981483029127,'2012-02-22 12:08:17'),
(2,'My Second SQL book','John Mayer',857300923713,'1972-07-03 09:22:45'),
(3,'My Third SQL Book','Cary Flit',523120967812,'2015-10-18 14:05:44')

select * from Books where Author like '%er'

--Question-2: Display the Title ,Author and ReviewerName for all the books from the above table

create table Books (id int primary key,title varchar(50),Author varchar(30),isbn numeric unique,published_date datetime)


insert into Books values(1,'My First SQL Book','Mary Parker',981483029127,'2012-02-22 12:08:17'),
(2,'My Second SQL book','John Mayer',857300923713,'1972-07-03 09:22:45'),
(3,'My Third SQL Book','Cary Flit',523120967812,'2015-10-18 14:05:44')

create table Reviews (Id int primary key,Book_id int,reviewer_name varchar(30),Content varchar(50),rating int,published_date datetime,foreign key (BooK_id) references Books(id))

insert into Reviews values(1,1,'John Smith','My First Review',4,'2017-12-10 05:50:11'),
(2,2,'John Smith','My Second Review',5,'2017-10-13 15:05:12'),
(3,2,'Alice Walker','Another Review',1,'2017-10-22 23:47:10')

select Title,Author,Reviewer_name from Books,Reviews where Books.id=Reviews.Book_id 


--Question-3: Display the reviewer name who reviewed more than one book.

select reviewer_name from Reviews group by reviewer_name having count(book_id)>1

--Question-4: Display the Name for the customer from above customer table who live in same address which has character o anywhere in address

create table Customer (id int primary key, Name varchar(20), Age int, Address varchar(30),Salary float)

insert into Customer values(1,'Ramesh',32,'Ahmedabad',2000.00),
(2,'Khilan',25,'Delhi',1500.00),
(3,'Kaushik',23,'Kota',2000.00),
(4,'Chatali',25,'Mumbai',6500.00),
(5,'Hardik',27,'Bhopal',8500.00),
(6,'Komal',22,'MP',4500.00),
(7,'Muffy',24,'Indore',10000.00)

select name from customer where address like '%o%'

--Question-5: Write a query to display the Date,Total no of customer placed order on same Date

create table orders (oid int primary key,Date datetime,Customer_ID int,Amount float,foreign key (customer_id) references customer(id))

insert into orders values(102,'2009-10-08 00:00:00',3,3000),
(100,'2009-10-08 00:00:00',3,1500),
(101,'2009-11-20 00:00:00',2,1560),
(103,'2008-05-20 00:00:00',4,2060)

select Date,Count((Customer_id)) as Total_no_of_Customers from orders group by Date

--Question-6: Display the Names of the Employee in lower case, whose salary is null

create table Employee ( id int primary key,name varchar(30),Age int,Address varchar(50),salary float)

insert into Employee values(1,'Ramesh',32,'Ahmedabad',2000.00),
(2,'Khilan',25,'Delhi',1500.00),
(3,'Kaushik',23,'Kota',2000.00),
(4,'Chatali',25,'Mumbai',6500.00),
(5,'Hardik',27,'Bhopal',8500.00),
(6,'Komal',22,'MP',null),
(7,'Muffy',24,'Indore',null)

select name from Employee where salary is null

--Question-7: Write a sql server query to display the Gender,Total no of male and female from the above relation

create table StudentDetails (RegisterNo int primary key,Name varchar(30),Age int,Qualification varchar(20),MobileNo numeric,Mail_id varchar(50),Location varchar(30),Gender varchar(10))

insert into StudentDetails values(2,'Sai',22, 'B.E',995283677,'Sai@gmail.com','Chennai','M'),
(3,'Kumar',20,'BSC',7890125468,'Kumar@gmail.com','Madurai','M'),
(4,'Selvi',22,'B.Tech',8904567890,'selvi@gmail.com','Selam','F'),
(5,'Nisha',25,'M.E',7834678000,'Nisha@gmail.com','Theni','F'),
(6,'SaiSaran',21,'B.A',7890345678,'saran@gamail.com','Madurai','F'),
(7,'Tom',23,'BCA',89012345678,'tom@gmail.com','Pune','M')

select Gender,count(gender) as Total_no_of_M_and_F from StudentDetails group by gender