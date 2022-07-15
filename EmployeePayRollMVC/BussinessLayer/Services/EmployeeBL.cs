using BussinessLayer.Interface;
using ModelLayer.Empoyee;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Services
{
    public class EmployeeBL : IEmployeeBL
    {
        IEmployeeRL EmployeeRL;

        public EmployeeBL(IEmployeeRL employeeRL)
        {
            this.EmployeeRL = employeeRL;
        }
        public void AddEmployee(EmployeeModel employeeModel)
        {
            try
            {
                this.EmployeeRL.AddEmployee(employeeModel);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<EmployeeModel> getEmployeeList()
        {
            try
            {
                return this.EmployeeRL.getEmployeeList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

       
    }
}
