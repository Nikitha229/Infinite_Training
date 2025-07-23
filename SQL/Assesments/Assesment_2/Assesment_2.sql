--Query-1: Write a query to display your birthday( day of week)

select '2004-06-29' as Birthday_date,DATENAME(DW,'2004-06-29') as Birthday_Day_of_week


--Query-2:Write a query to display your age in days

select '2004-06-29' as Birthday,DATEDIFF(day,'2004-06-29',getdate()) as Age_in_Days


--Department Table
create table dept(deptno int primary key,dname varchar(30),loc varchar(30))
insert into dept values(10,'ACCOUNTING','NEW YORK'),
(20,'RESEARCH','DALLAS'),
(30,'SALES','CHICAGO' ),
(40,'OPERATIONS','BOSTON')

--Query-3:Write a query to display all employees information those who joined before 5 years in the current month
--Employee Table
create table emp(empno int primary key,ename varchar(30) not null,job varchar(30) not null,mgr_id int,hire_date date,salary int,comm int,deptno int references dept(deptno))
insert into emp values (7369, 'SMITH', 'CLERK', 7902, '1980-12-17', 800, NULL, 20),
(7499, 'ALLEN', 'SALESMAN', 7698, '1981-02-20', 1600, 300, 30),
(7521, 'WARD', 'SALESMAN', 7698, '1981-02-22', 1250, 500, 30),
(7566, 'JONES', 'MANAGER', 7839, '1981-04-18', 2975, NULL, 20),
(7654, 'MARTIN', 'SALESMAN', 7698, '2023-03-01', 1250, 1400, 30),
(7698, 'BLAKE', 'MANAGER', 7839, '2022-06-15', 2850, NULL, 30),
(7782, 'CLARK', 'MANAGER', 7839, '1999-03-19', 2450, NULL, 10),
(7788, 'SCOTT', 'ANALYST', 7566, '1998-01-14', 3000, NULL, 20),
(7839, 'KING', 'PRESIDENT', NULL, '1980-06-26', 5000, NULL, 10),
(7844, 'TURNER', 'SALESMAN', 7698, '2021-11-17', 1500, 0, 30),
(7876, 'ADAMS', 'CLERK', 7788, '1987-05-23', 1100, NULL, 20),
(7900, 'JAMES', 'CLERK', 7698, '2020-07-22', 950, NULL, 30)

update emp set hire_date='2020-05-30' where empno=7654

select * from emp where year(hire_date)=year(getdate())-5


--Query-4:Create table Employee with empno, ename, sal, doj columns or use your emp table and perform the following operations in a single transaction
--	a. First insert 3 rows 
--	b. Update the second row sal with 15% increment  
--  c. Delete first row.
--After completing above all actions, recall the deleted row without losing increment of second row.

create table Employees(empid int primary key,empname varchar(30),salary float,DOJ date)
insert into Employees values(1,'Nikitha',30000,'2025-06-05'),
(2,'Tejaswini',40000,'2023-11-15'),
(3,'Aparna',45000,'2020-12-07')
update Employees set salary=salary*1.15 where empid=2

begin transaction 
declare @deletedrow table(empid int,empname varchar(30),salary float,doj date)
insert into @deletedrow select * from employees where empid=1
delete from employees where empid=1
--deleted row
select * from @deletedrow
select * from employees
rollback
select * from employees

--Query-5:Create a user defined function calculate Bonus for all employees of a  given dept using 	following conditions
--	a.     For Deptno 10 employees 15% of sal as bonus.
--	b.     For Deptno 20 employees  20% of sal as bonus
--	c      For Others employees 5%of sal as bonus
select * from Emp
create or alter function fn_Calculate_Bonus(@deptno int,@sal float)
returns float
as
begin
  if(@deptno=10)
  begin
   return @sal*0.15
  end
  else if(@deptno=20)
  begin
   return @sal*0.20
  end
  return @sal*0.05 
end

select empno,ename,salary,dbo.fn_Calculate_Bonus(deptno,salary) as Bonus,salary+dbo.fn_Calculate_Bonus(deptno,salary) as Salary_After_getting_Bonus from emp


--Query-6:Create a procedure to update the salary of employee by 500 whose dept name is Sales and current salary is below 1500 (use emp table)
select * from emp
select * from dept
--Before Update 
select * from emp join dept on emp.deptno=dept.deptno and dept.dname='SALES'
create or alter proc sp_Update_Sales_Employee 
as
begin
  update emp set salary=salary+500 where salary<1500 and deptno=(select deptno from dept where dname='SALES')
end

--After Update 
select * from emp join dept on emp.deptno=dept.deptno and dept.dname='SALES'

