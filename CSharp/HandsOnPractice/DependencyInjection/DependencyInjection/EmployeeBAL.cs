using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    class EmployeeBAL
    {
        public IEmployeeDAL employeeDAL;

        public EmployeeBAL(IEmployeeDAL _edal)
        {
            employeeDAL = _edal;
        }
        public List<Employee>SelectAllEmployees()
        {
            //employeeDAL = new EmployeeDAL(); //tight coupling
            return employeeDAL.GetAllEmployees();
        }
    }
}
