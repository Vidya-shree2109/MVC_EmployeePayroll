using Microsoft.Extensions.Configuration;
using ModelLayer.Model;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Services
{
    public class EmployeeRL : IEmployeeRL
    {
        private readonly IConfiguration configuration;
        public EmployeeRL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        //To add New Employee Record
        public string AddEmployee(EmployeeModel emp)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(configuration["ConnectionStrings:EmployeePayrollMVC"]))
                {
                    SqlCommand cmd = new SqlCommand("spAddEmployeeInfo", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Emp_name", emp.Emp_name);
                    cmd.Parameters.AddWithValue("@Profile_img", emp.Profile_img);
                    cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                    cmd.Parameters.AddWithValue("@Department", emp.Department);
                    cmd.Parameters.AddWithValue("@Salary", emp.Salary);
                    cmd.Parameters.AddWithValue("@StartDate", emp.StartDate);
                    cmd.Parameters.AddWithValue("@Notes", emp.Notes);
                    con.Open();
                    var result = cmd.ExecuteNonQuery();
                    con.Close();
                    if (result >= 1)
                    {
                        return "data added";
                    }
                    else
                    {
                        return "data not added";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string DeleteEmployee(int? id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(configuration["ConnectionStrings:EmployeePayrollMVC"]))
                {
                    SqlCommand cmd = new SqlCommand("spDeleteEmployeeInfo", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Emp_id", id);

                    con.Open();
                    var result = cmd.ExecuteNonQuery();
                    con.Close();
                    if (result >= 1)
                    {
                        return "data added";
                    }
                    else
                    {
                        return "data not added";
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        // To View All Employee Details
        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            try
            {
                List<EmployeeModel> listemployee = new List<EmployeeModel>();
                using (SqlConnection con = new SqlConnection(configuration["ConnectionStrings:EmployeePayrollMVC"]))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        EmployeeModel emp = new EmployeeModel();

                        emp.Emp_id = Convert.ToInt32(rdr["Emp_id"]);
                        emp.Emp_name = Convert.ToString(rdr["Emp_name"]);
                        emp.Profile_img = Convert.ToString(rdr["Profile_img"]);
                        emp.Gender = Convert.ToString(rdr["Gender"]);
                        emp.Department = Convert.ToString(rdr["Department"]);
                        emp.Salary = Convert.ToInt32(rdr["Salary"]);
                        emp.StartDate = Convert.ToDateTime(rdr["StartDate"]);
                        emp.Notes = Convert.ToString(rdr["Notes"]);

                        listemployee.Add(emp);
                    }
                    con.Close();
                }
                return listemployee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EmployeeModel GetEmployeeData(int? id)
        {
            try
            {
                EmployeeModel emp = new EmployeeModel();
                using (SqlConnection con = new SqlConnection(configuration["ConnectionStrings:EmployeePayrollMVC"]))
                {
                    string sqlQuery = "SELECT * FROM tableEmployeeInfo WHERE Emp_id= " + id;
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        emp.Emp_id = Convert.ToInt32(rdr["Emp_id"]);
                        emp.Emp_name = Convert.ToString(rdr["Emp_name"]);
                        emp.Profile_img = Convert.ToString(rdr["Profile_img"]);
                        emp.Gender = Convert.ToString(rdr["Gender"]);
                        emp.Department = Convert.ToString(rdr["Department"]);
                        emp.Salary = Convert.ToInt32(rdr["Salary"]);
                        emp.StartDate = Convert.ToDateTime(rdr["StartDate"]);
                        emp.Notes = Convert.ToString(rdr["Notes"]);
                    }
                }
                return emp;
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
                using (SqlConnection con = new SqlConnection(configuration["ConnectionStrings:EmployeePayrollMVC"]))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateEmployeeInfo", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Emp_id", emp.Emp_id);
                    cmd.Parameters.AddWithValue("@Emp_name", emp.Emp_name);
                    cmd.Parameters.AddWithValue("@Profileimage", emp.Profile_img);
                    cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                    cmd.Parameters.AddWithValue("@Department", emp.Department);
                    cmd.Parameters.AddWithValue("@Salary", emp.Salary);
                    cmd.Parameters.AddWithValue("@StartDate", emp.StartDate);
                    cmd.Parameters.AddWithValue("@Notes", emp.Notes);

                    con.Open();
                    var result = cmd.ExecuteNonQuery();
                    con.Close();
                    if (result >= 1)
                    {
                        return "data added";
                    }
                    else
                    {
                        return "data not added";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}