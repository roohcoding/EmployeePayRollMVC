using ModelLayer.Empoyee;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Interface
{
    public interface IEmployeeBL
    {
        public void AddEmployee(EmployeeModel employeeModel);
       public List<EmployeeModel> getEmployeeList();
        //EmployeeModel getEmployee(int? id);
        //void deleteEmployee(EmployeeModel employeeModel);
        //void editEmployee(EmployeeModel employeeModel);
    }
}
