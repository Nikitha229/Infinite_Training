select * from emp

select * from dept

--Query-1. Retrieve a list of MANAGERS. 
select empno,ename from emp where job='MANAGER'

--Query-2:Find out the names and salaries of all employees earning more than 1000 per month.

select ename,salary from emp where salary>1000

--Query-3:Display the names and salaries of all employees except JAMES.

select ename,salary from emp where ename!='JAMES'

--Query-4:Find out the details of employees whose names begin with ‘S’. 

select * from emp where ename like 'S%'

--Query-5:Find out the names of all employees that have ‘A’ anywhere in their name. 

select ename from emp where ename like '%a%'

--Query-6:Find out the names of all employees that have ‘L’ as their third character in their name.

select ename from emp where ename like '__L%'

--Query-7:Compute daily salary of JONES.

select ename,(12*salary) as yearly_Salary from emp where ename='JONES'

--Query-8:Calculate the total monthly salary of all employees. 

select sum(salary) as Total_Monthly_Salary from emp

--Query-9: Print the average annual salary . 

select avg(12*salary) as Average_Annual_Salary from emp

--Query-10:Select the name, job, salary, department number of all employees except SALESMAN from department number 30. 

select ename,job,salary,deptno from emp where  not (job='SALESMAN' and deptno=30) 

--Query-11:List unique departments of the EMP table. 

select distinct(deptno) from emp

--Query-12:List the name and salary of employees who earn more than 1500 and are in department 10 or 30. Label the columns Employee and Monthly Salary respectively.

select ename as Employee,salary as Monthly_Salary from emp where (salary>1500) and (deptno=10 or deptno=30)

--Query-13:Display the name, job, and salary of all the employees whose job is MANAGER or 
--ANALYST and their salary is not equal to 1000, 3000, or 5000. 

select ename,job,salary from emp where (job='MANAGER' or job='ANALYST') and (salary!=1000 or salary!=3000 or salary!=5000)

--Query-14: Display the name, salary and commission for all employees whose commission 
--amount is greater than their salary increased by 10%. 

select ename,salary,(salary+salary*1.1) as Commission from emp

--Query-15:Display the name of all employees who have two Ls in their name and are in 
--department 30 or their manager is 7782. 

select ename from emp where ename like '%l%l%' and (deptno=30 or mgr_id=7782)

--Query-16: Display the names of employees with experience of over 30 years and under 40 yrs.
 --Count the total number of employees. 

select ename from emp where DATEDIFF(YEAR, hire_date, GETDATE()) between 31 and 39
select count(empno) from emp where  DATEDIFF(YEAR, hire_date, GETDATE()) between 31 and 39

--Query-17:Retrieve the names of departments in ascending order and their employees in 
--descending order. 

select d.dname,e.ename from emp e join dept d on d.deptno=e.deptno order by d.dname asc,e.ename desc 

--Query-18:Find out experience of MILLER. 

select DATEDIFF(YEAR, hire_date, GETDATE()) from emp where ename='MILLER'