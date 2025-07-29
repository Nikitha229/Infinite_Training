using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Assignment_1
{

    public class Employee
    {
        public int Employeeid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string title { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public string City { get; set; }


    }

    class Program
    {
        public static void Display(List<Employee> emp)
        {
            foreach(var e in emp)
            {
                Console.WriteLine($"Employee Id: {e.Employeeid} , Employee Name:{e.FirstName + " " + e.LastName}, Title:{e.title}, DOB: {e.DOB}, DOJ:{e.DOJ}, City:{e.City} ");
            }
        }

        static void Main(string[] args)
        {
            List<Employee> Employees = new List<Employee>
            {
               new Employee{Employeeid=1001,FirstName="Malcom",LastName="Daruwalla",title="Manager",DOB=Convert.ToDateTime("16-11-1984"),DOJ=Convert.ToDateTime("08-06-2011"),City="Mumbai"},
               new Employee{Employeeid=1002,FirstName="Asdin",LastName="Dhalla",title="AsstManager",DOB=Convert.ToDateTime("20-08-1994"),DOJ=Convert.ToDateTime("07-07-2012"),City="Mumbai"},
               new Employee{Employeeid=1003,FirstName="Madhavi",LastName="Oza",title="Consultant",DOB=Convert.ToDateTime("14-11-1987"),DOJ=Convert.ToDateTime("12-04-2015"),City="Pune"},
               new Employee{Employeeid=1004,FirstName="Saba",LastName="Shaikh",title="SE",DOB=Convert.ToDateTime("03-06-1990"),DOJ=Convert.ToDateTime("02-02-2016"),City="Pune"},
               new Employee{Employeeid=1005,FirstName="Nazia",LastName="Shaikh",title="SE",DOB=Convert.ToDateTime("08-03-1991"),DOJ=Convert.ToDateTime("02-02-2016"),City="Mumbai"},
               new Employee{Employeeid=1006,FirstName="Amit",LastName="Pathak",title="Consultant",DOB=Convert.ToDateTime("07-11-1989"),DOJ=Convert.ToDateTime("08-08-2014"),City="Chennai"},
               new Employee{Employeeid=1007,FirstName="Vijay",LastName="Natrajan",title="Consultant",DOB=Convert.ToDateTime("02-12-1989"),DOJ=Convert.ToDateTime("01-06-2015"),City="Mumbai"},
               new Employee{Employeeid=1008,FirstName="Rahul",LastName="Dubey",title="Associate",DOB=Convert.ToDateTime("11-11-1993"),DOJ=Convert.ToDateTime("06-11-2014"),City="Chennai"},
               new Employee{Employeeid=1009,FirstName="Suresh",LastName="Mistry",title="Associate",DOB=Convert.ToDateTime("12-08-1992"),DOJ=Convert.ToDateTime("03-12-2014"),City="Chennai"},
               new Employee{Employeeid=1010,FirstName="Sumit",LastName="Shah",title="Manager",DOB=Convert.ToDateTime("12-04-1991"),DOJ=Convert.ToDateTime("02-01-2016"),City="Pune"},
            };

            var JoinedBefore2015 = Employees.Where(e => e.DOJ < new DateTime(2015, 1, 1)).ToList();
            Console.WriteLine("------------------------------Employees Joined Before 2015----------------------");
            Display(JoinedBefore2015);
            var DOBAfter1990 = Employees.Where(e => e.DOB > new DateTime(1990, 1, 1)).ToList();
            Console.WriteLine("--------------------Employees DOB After 1990------------------------");
            Display(DOBAfter1990);
            var ConsultantsAndAssociates = Employees.Where(e => e.title == "Consultant" || e.title == "Associate").ToList();
            Console.WriteLine("----------------Employees who are Consultants and Associates--------------------");
            Display(ConsultantsAndAssociates);
            var TotalEmployees = Employees.Count();
            Console.WriteLine("----------------Total Employees--------------------");
            Console.WriteLine("Total Count of Employees: {0}", TotalEmployees);
            var ChennaiEmployees = Employees.Count(e => e.City == "Chennai");
            Console.WriteLine("----------------Count of Employees located at Chennai--------------------");
            Console.WriteLine("Total number of Employees in Chennai location: {0} ", ChennaiEmployees);
            var HighestEmpID = Employees.Max(e => e.Employeeid);
            Console.WriteLine("----------------Highest Employee ID--------------------");
            Console.WriteLine(HighestEmpID);
            var JoinedAfter2015 = Employees.Count(e => e.DOJ > new DateTime(2015, 1, 1));
            Console.WriteLine("----------------Count of Employees joined after 2015--------------------");
            Console.WriteLine(JoinedAfter2015);
            var NotAssociates = Employees.Count(e => e.title != "Associate");
            Console.WriteLine("----------------Count of Employees who are not Associates--------------------");
            Console.WriteLine(NotAssociates);

            var employeesByCity = Employees.GroupBy(e => e.City).
                                 Select(g => new { City = g.Key, Count = g.Count() }).ToList();
            Console.WriteLine("----------------Total number of Employees by city--------------------");
            foreach(var e in employeesByCity)
            {
                Console.WriteLine($"City: {e.City}, Count:{e.Count}");
            }

            var employeesByCityAndTitle = Employees.GroupBy(e => new { e.City, e.title }).
                                          Select(g => new { City=g.Key.City, Title=g.Key.title, Count = g.Count() }).ToList();
            Console.WriteLine("----------------Total number of Employees by city and title--------------------");
            foreach(var e in employeesByCityAndTitle)
            {
                Console.WriteLine($"City:{e.City}, Title:{e.Title}, Count:{e.Count} ");
            }
            var YoungestEmployee = Employees.OrderByDescending(e => e.DOB).ToList();
            Console.WriteLine("---------------Youngest Employee--------------");
            Display(YoungestEmployee);
            Console.Read();
        }
    }
}
