using ModelLayer.Empoyee;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IEmployeeRL
    {
        public void AddEmployee(EmployeeModel employeeModel);
        public List<EmployeeModel> getEmployeeList();
        //EmployeeModel getEmployee(int? id);
        //void deleteEmployee(EmployeeModel employeeModel);
        //void editEmployee(EmployeeModel employeeModel);
    }
}
