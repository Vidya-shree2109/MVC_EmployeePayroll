using ModelLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IEmployeeBL
    {
        public string AddEmployee(EmployeeModel emp);
        public string UpdateEmployee(EmployeeModel emp);
        public string DeleteEmployee(int? id);
        public IEnumerable<EmployeeModel> GetAllEmployees();
        public EmployeeModel GetEmployeeData(int? id);
    }
}
