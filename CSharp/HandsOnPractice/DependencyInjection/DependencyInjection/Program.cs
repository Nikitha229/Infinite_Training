using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeBAL employeeBAL = new EmployeeBAL(new EmployeeDAL());
            List<Employee> empList = employeeBAL.SelectAllEmployees();
            foreach(Employee e in empList)
            {
                Console.WriteLine($"Id: {e.Id},Name: {e.Name},Department: {e.Department}");
            }
            Console.Read();
        }
    }
}
