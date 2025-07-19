--Query-1:Write a T-SQL Program to find the factorial of a given number.

declare @num int=5
declare @fact int=1
declare @temp int=1
while @temp<=@num
begin 
set @fact=@fact*@temp
set @temp=@temp+1 
end 

print 'Factorial of ' + cast(@num as varchar(5))+' is '+cast(@fact as varchar(5))

--Query-2:Create a stored procedure to generate multiplication table that accepts a number and generates up to a given number. 

create or alter proc sp_multiplicationTable @num int,@limit int 
as
begin
declare @i int=1
while(@i<=@limit)
begin
print cast(@num as varchar(5)) + ' x '+cast(@i as varchar(2))+' = '+cast(@num*@i as varchar(5))
set @i = @i+1
end
end

exec sp_multiplicationTable 5,10

--Query-3:Create a function to calculate the status of the student. If student score >=50 then pass, else fail. Display the data neatly

create table student (sid int primary key,sname varchar(30))

insert into student values(1,'Jack'),
(2,'Rithvik'),(3,'Jaspreeth'),(4,'Praveen'),(5,'Bisa'),(6,'Suraj')

select * from student

create table Marks(mid int primary key,sid int references student(sid),score int)

insert into Marks values(1,1,23),
(2,6,95),(3,4,98),(4,2,17),(5,3,53),(6,5,13)

select * from Marks

create or alter function fn_CalculateStatus(@score int)
returns nvarchar(50)
as
begin
declare @status varchar(10)
if(@score>=50)
set @status='Pass'
else 
set @status='Fail'
return @status
end 

select s.sname,dbo.fn_CalculateStatus(m.score) from student s,marks m where s.sid=m.sid
