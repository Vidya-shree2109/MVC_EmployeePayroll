using ModelLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IEmployeeRL
    {
        EmployeeModel GetEmployeeData(int? id);
        string AddEmployee(EmployeeModel emp);
        string UpdateEmployee(EmployeeModel emp);
        string DeleteEmployee(int? id);
        IEnumerable<EmployeeModel> GetAllEmployees();
    }
}
