using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    public interface IEmployeeDAL
    {
        List<Employee> GetAllEmployees();
    }
    //DAL-Data Access Layer
    public class EmployeeDAL:IEmployeeDAL
    {
        public List<Employee> GetAllEmployees()
        {
            List<Employee> empList = new List<Employee>
            {
                new Employee(){Id=1,Name="Nikitha",Department="IT"},
                new Employee(){Id=2,Name="Subha",Department="Quality"},
                new Employee(){Id=3,Name="Mehrun",Department="Admin"},
            };
            return empList;
        }
    }
}
