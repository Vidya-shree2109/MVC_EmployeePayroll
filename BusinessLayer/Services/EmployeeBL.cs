using BusinessLayer.Interfaces;
using ModelLayer.Model;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class EmployeeBL : IEmployeeBL
    {
        private readonly IEmployeeRL employeeRL;
        public EmployeeBL(IEmployeeRL employeeRL)
        {
            this.employeeRL = employeeRL;
        }
        public string AddEmployee(EmployeeModel emp)
        {
            try
            {
                return this.employeeRL.AddEmployee(emp);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public string UpdateEmployee(EmployeeModel emp)
        {
            try
            {
                return this.employeeRL.UpdateEmployee(emp);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public string DeleteEmployee(int? id)
        {
            try
            {
                return this.employeeRL.DeleteEmployee(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            try
            {
                return this.employeeRL.GetAllEmployees();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public EmployeeModel GetEmployeeData(int? id)
        {
            try
            {
                return this.employeeRL.GetEmployeeData(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
