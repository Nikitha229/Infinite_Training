--1. Write a T-Sql based procedure to generate complete payslip of a given employee with respect to the following condition

--   a) HRA as 10% of Salary
--   b) DA as 20% of Salary
--   c) PF as 8% of Salary
--   d) IT as 5% of Salary
--   e) Deductions as sum of PF and IT
--   f) Gross Salary as sum of Salary, HRA, DA
--   g) Net Salary as Gross Salary - Deductions

--Print the payslip neatly with all details

select * from Employees
create or alter proc SP_Payslip @EmpID int
as 
begin
  declare @empname varchar(30),@salary float,@HRA float,@DA float
  declare @PF float,@IT float,@Deductions float,@GrossSalary float,@NetSalary float

  select @empname=ename,@salary=salary from Employees where @EmpID=Empno
  set @HRA=@salary*0.1
  set @DA=@salary*0.2
  set @PF=@salary*0.08 
  set @IT=@salary*0.05 
  set @Deductions=@PF+@IT
  set @GrossSalary=@salary+@HRA+@DA
  set @NetSalary=@GrossSalary-@Deductions

  print '================================'
  print '          PAYSLIP               '  
  print '================================'
  print 'Employee_Id: '+cast(@EmpId as varchar(10))
  print 'Employee_Name: '+@empname 
  print 'Salary: '+cast(@salary as varchar(10))
  print 'HRA(10%): '+cast(@HRA as varchar(10))
  print 'DA(20%): '+cast(@DA as varchar(10))
  print 'PF(8%): '+cast(@PF as varchar(10))
  print 'IT(5%): '+cast(@IT as varchar(10))
  print 'Gross_Salary: '+cast(@GrossSalary as varchar(10))
  print 'Net_Salary: '+cast(@NetSalary as varchar(10))
end

exec SP_Payslip 7003

--2.  Create a trigger to restrict data manipulation on EMP table during General holidays. Display the error message 
--like “Due to Independence day you cannot manipulate data” or "Due To Diwali", you cannot manipulate" etc
--Note: Create holiday table with (holiday_date,Holiday_name). Store at least 4 holiday details. try to match and stop manipulation 