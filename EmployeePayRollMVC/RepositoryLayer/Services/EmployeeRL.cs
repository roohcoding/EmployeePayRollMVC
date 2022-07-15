using Microsoft.Extensions.Configuration;
using ModelLayer.Empoyee;
using RepositoryLayer.Interface;
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
        public void AddEmployee(EmployeeModel employeeModel)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(configuration["ConnectionStrings:EmpolyeePayroll"]))
                {
                    SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Name", employeeModel.Emp_name);
                    cmd.Parameters.AddWithValue("@profileImage", employeeModel.Profile_img);
                    cmd.Parameters.AddWithValue("@Gender", employeeModel.Gender);
                    cmd.Parameters.AddWithValue("@Department", employeeModel.Department);
                    cmd.Parameters.AddWithValue("@salary", employeeModel.Salary);
                    cmd.Parameters.AddWithValue("@startDate", employeeModel.StartDate);

                    con.Open();
                    var result = cmd.ExecuteNonQuery();
                    con.Close();
                   
                }
               
            }


            catch (Exception e)
            {
                throw e;
            }
        }

        public List<EmployeeModel> getEmployeeList()
        {
           
            try
            {
                List<EmployeeModel> employees = new List<EmployeeModel>();
                using (SqlConnection con = new SqlConnection(this.configuration.GetConnectionString("EmpolyeePayroll")))
                {
                    SqlCommand cmd = new SqlCommand("allEmployees", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    con.Open();
                    da.Fill(dt);
                    
                    //Bind EmpModel generic list using dataRow    
                    foreach (DataRow dr in dt.Rows)
                    {

                        employees.Add(
                            new EmployeeModel
                            {
                                Emp_id = Convert.ToInt32(dr["Emp_id"]),
                                Emp_name = Convert.ToString(dr["Emp_name"]),
                                Profile_img = Convert.ToString(dr["Profile_img"]),
                                Gender = Convert.ToString(dr["Gender"]),
                                Department = Convert.ToString(dr["Department"]),
                                Salary = Convert.ToInt32(dr["Salary"]),
                                StartDate = Convert.ToDateTime(dr["StartDate"]),
                                Notes = Convert.ToString(dr["Notes"])
                            }
                        );

                    }
                    con.Close();
                }
                return employees;

            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
