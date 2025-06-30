using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7_Task
{
    class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public string department { get; set; }
        public double salary { get; set; }
    }
    class Question_1
    {
        public static List<Employee> emp = new List<Employee>();

        public static void AddNewEmployee()
        {

            try
            {
                Employee employee = new Employee();
                Console.Write("Enter Employee ID: ");
                employee.id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Employee Name: ");
                employee.name = Console.ReadLine();
                Console.Write("Enter Employee Department: ");
                employee.department = Console.ReadLine();
                Console.Write("Enter Employee Salary: ");
                employee.salary = Convert.ToDouble(Console.ReadLine());
                emp.Add(employee);
                Console.WriteLine("Employee added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding employee: " + ex.Message);
            }

        }

        public static void ViewAllEmployees()
        {
            Console.WriteLine("============All Employees=========");
            foreach (var e in emp)
            {
                Console.WriteLine($"ID:{e.id} Name:{e.name} Department:{e.department} and Salary:{e.salary}");
            }
        }

        public static void SearchEmployeeById()
        {

            try
            {
                Console.Write("Enter Employee ID to search: ");
                int Id = Convert.ToInt32(Console.ReadLine());
                Employee employee = emp.Find(e => e.id == Id);

                if (employee != null)
                {
                    Console.WriteLine($"ID: {employee.id} Name: {employee.name} Department: {employee.department} and Salary: {employee.salary}");
                }

                else
                {
                    Console.WriteLine("Employee not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error searching employee: " + ex.Message);
            }

        }

        public static void UpdateEmployeeDetails()
        {

            try
            {
                Console.Write("Enter Employee ID to update: ");
                int Id = Convert.ToInt32(Console.ReadLine());
                Employee employee = emp.Find(e => e.id == Id);

                if (employee != null)
                {
                    Console.Write("Enter new Employee Name: ");
                    employee.name = Console.ReadLine();
                    Console.Write("Enter new Employee Department: ");
                    employee.department = Console.ReadLine();
                    Console.Write("Enter new Employee Salary: ");
                    employee.salary = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Employee details updated successfully.");
                }
                else
                {
                    Console.WriteLine("Employee not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating employee: " + ex.Message);
            }
        }

        public static void DeleteEmployee()
        {

            try
            {
                Console.Write("Enter Employee ID to delete: ");
                int Id = int.Parse(Console.ReadLine());
                Employee employee = emp.Find(e => e.id == Id);

                if (employee != null)
                {
                    emp.Remove(employee);
                    Console.WriteLine("Employee deleted successfully.");
                }

                else
                {
                    Console.WriteLine("Employee not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting employee: " + ex.Message);
            }

        }
        static void Main(string[] args)
        {
           
            bool exit = false;
            while (!exit)
            {

                Console.WriteLine("===== Employee Management Menu =====");
                Console.WriteLine("1. Add New Employee");
                Console.WriteLine("2. View All Employees");
                Console.WriteLine("3. Search Employee by ID");
                Console.WriteLine("4. Update Employee Details");
                Console.WriteLine("5. Delete Employee");
                Console.WriteLine("6. Exit");
                Console.WriteLine("====================================");
                Console.Write("Enter your choice: ");
                int c =Convert.ToInt32(Console.ReadLine());

                switch (c)
                {
                    case 1:
                        AddNewEmployee();
                        break;
                    case 2:
                        ViewAllEmployees();
                        break;
                    case 3:
                        SearchEmployeeById();
                        break;
                    case 4:
                        UpdateEmployeeDetails();
                        break;
                    case 5:
                        DeleteEmployee();
                        break;
                    case 6:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

       
    }
}
