using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Question
{
    class Employee
    {
        public int Employeeid;
        public string FirstName;
        public string LastName;
        public string title;
        public DateTime DOB;
        public DateTime DOJ;
        public string City;
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> Employees = new List<Employee>
            {
               new Employee{Employeeid=1001,FirstName="Malcom",LastName="Daruwalla",title="Manager",DOB=Convert.ToDateTime("16-11-1984"),DOJ=Convert.ToDateTime("08-06-2011"),City="Mumbai"},
               new Employee{Employeeid=1002,FirstName="Asdin",LastName="Dhalla",title="AsstManager",DOB=Convert.ToDateTime("20-08-1994"),DOJ=Convert.ToDateTime("07-07-2012"),City="Mumbai"},
               new Employee{Employeeid=1003,FirstName="Madhavi",LastName="Oza",title="Consultant",DOB=Convert.ToDateTime("14-11-2001"),DOJ=Convert.ToDateTime("08-06-2013"),City="Pune"},
               new Employee{Employeeid=1004,FirstName="Saba",LastName="Shaikh",title="SE",DOB=Convert.ToDateTime("25-09-2003"),DOJ=Convert.ToDateTime("08-09-2021"),City="Pune"},
               new Employee{Employeeid=1005,FirstName="Nazia",LastName="Shaikh",title="SE",DOB=Convert.ToDateTime("29-06-2004"),DOJ=Convert.ToDateTime("08-06-2023"),City="Mumbai"},
               new Employee{Employeeid=1006,FirstName="Amit",LastName="Pathak",title="Consultant",DOB=Convert.ToDateTime("16-09-1998"),DOJ=Convert.ToDateTime("28-06-2015"),City="Chennai"},
               new Employee{Employeeid=1007,FirstName="Vijay",LastName="Natrajan",title="Consultant",DOB=Convert.ToDateTime("18-07-2002"),DOJ=Convert.ToDateTime("18-09-2021"),City="Mumbai"},
               new Employee{Employeeid=1008,FirstName="Rahul",LastName="Dubey",title="Associate",DOB=Convert.ToDateTime("16-07-2000"),DOJ=Convert.ToDateTime("09-11-2019"),City="Chennai"},
               new Employee{Employeeid=1009,FirstName="Suresh",LastName="Mistry",title="Associate",DOB=Convert.ToDateTime("18-06-1980"),DOJ=Convert.ToDateTime("20-05-2011"),City="Chennai"},
               new Employee{Employeeid=1010,FirstName="Sumit",LastName="Shah",title="Manager",DOB=Convert.ToDateTime("22-07-2000"),DOJ=Convert.ToDateTime("28-06-2020"),City="Pune"},
            };
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine("Question-a: Display detail of all the employee");
            Console.WriteLine();
            Console.WriteLine("All Employees: ");
            foreach(var employee in Employees)
            {
                Console.WriteLine($"EmpId:{employee.Employeeid},FirstName:{employee.FirstName},LastName:{employee.LastName},Title:{employee.title},DOB:{employee.DOB},DOJ:{employee.DOJ},City:{employee.City}");
            }
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine("Question-b: Display details of all the employee whose location is not Mumbai");
            Console.WriteLine();
            var LocationNotMumbai = Employees.Where(e => e.City != "Mumbai");
            foreach(var employee in LocationNotMumbai)
            {
                Console.WriteLine($"EmpId:{employee.Employeeid},FirstName:{employee.FirstName},LastName:{employee.LastName},Title:{employee.title},DOB:{employee.DOB},DOJ:{employee.DOJ},City:{employee.City}");
            }
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine("Question-c:Display details of all the employee whose title is AsstManager ");
            Console.WriteLine();
            var AsstManagers = Employees.Where(e => e.title == "AsstManager");
            foreach(var employee in AsstManagers)
            {
                Console.WriteLine($"EmpId:{employee.Employeeid},FirstName:{employee.FirstName},LastName:{employee.LastName},Title:{employee.title},DOB:{employee.DOB},DOJ:{employee.DOJ},City:{employee.City}");
            }
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine("Question-d: Display details of all the employee whose Last Name start with S");
            Console.WriteLine();
            var NameStartWithS = Employees.Where(e => e.LastName[0] == 'S');
            foreach(var employee in NameStartWithS)
            {
                Console.WriteLine($"EmpId:{employee.Employeeid},FirstName:{employee.FirstName},LastName:{employee.LastName},Title:{employee.title},DOB:{employee.DOB},DOJ:{employee.DOJ},City:{employee.City}");
            }
            Console.Read();
        }
    }
}
