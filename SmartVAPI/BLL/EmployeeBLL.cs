using Microsoft.AspNetCore.Identity;
using SmartVision.Data;
using SmartVision.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartVision.DAL;
using SmartVAPI.BLL.Contracts;

namespace SmartVision.BLL
{
    public class EmployeeBLL:IEmployee
    {

       
        public Task<int> SaveEmployee(Employee employee, int action)
        {
            EmployeeDAL dal = new EmployeeDAL();
            return  dal.SaveEmployee(employee,action);
        }

       public List<Employee> GetAllEmployee(string empName)
        {
            EmployeeDAL dal = new EmployeeDAL();
            return dal.GetAllEmployee(empName);
        }
        public Employee GetEmployee(int EmployeeId)
        {
            EmployeeDAL dal = new EmployeeDAL();
            return dal.GetEmployee(EmployeeId);
        }

        public int DeleteEmployee(int EmployeeId)
        {
            EmployeeDAL dal = new EmployeeDAL();
            return dal.DeleteEmployee(EmployeeId);
        }
    }
}