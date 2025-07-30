use Assesments

create table Employee_Details
( EmpId int identity primary key,
Name varchar(30),
Gender varchar(8),
Salary float,
Net_Salary float)

create or alter proc sp_InsertEmployees @name varchar(100),@gender varchar(8),@sal float,@id int output,@Netsal float output
as
begin 
 declare @netsalary float
 set @netsalary =@sal *0.9
 insert into Employee_Details values(@name,@gender,@sal,@netsalary)
 set @id=SCOPE_IDENTITY()
 set @Netsal=@netsalary
end

declare @EmpID int;
declare @Net_Salary float;

exec sp_InsertEmployees 'Nikitha','Female',30000,@EmpID output,@Net_Salary output
select * from Employee_Details


create or alter proc sp_SalaryIncrement @id int
as
begin
  update Employee_Details set Salary=Salary + 100 where EmpId=@id 
end

exec sp_SalaryIncrement 1

select EmpId,Name,Salary from Employee_Details