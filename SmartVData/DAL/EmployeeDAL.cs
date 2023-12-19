using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SmartVision.Data;
using Microsoft.AspNetCore.Identity;
using SmartVision.Entities;
using SmartVData;

namespace SmartVision.DAL;

public class EmployeeDAL
{
    private ApplicationDbContext _dbContext;
    private readonly UserManager<ApplicationUser> _userManager;
    public EmployeeDAL(UserManager<ApplicationUser> userManager, ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _userManager = userManager;
    }
    public EmployeeDAL()
    {

    }

    public List<Employee> GetAllEmployee(string empName)
    {
        List<Employee> employeeList = new List<Employee>();

        using (var dbContext = new ApplicationDbContext())
        {
            var command = dbContext.Database.GetDbConnection().CreateCommand();
            command.CommandText = "spGetEmployees";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@EmpName", empName));

            dbContext.Database.OpenConnection();

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Employee employee = new Employee
                    {
                        EmployeeId = Convert.ToInt32(reader["EmployeeId"]),
                        Name = reader["Name"]?.ToString(),
                        Designation = reader["Designation"]?.ToString(),
                        NID = reader["NID"]?.ToString(),
                        JoiningDate = reader["JoiningDate"] != DBNull.Value ? Convert.ToDateTime(reader["JoiningDate"]) : default(DateTime),
                    };

                    employeeList.Add(employee);
                }
            }
        }

        return employeeList;
    }

    public Employee GetEmployee(int EmployeeId)
    {
        Employee emp = new Employee();
        using (var dbContext = new ApplicationDbContext())
        {
            dbContext.Database.OpenConnection();
            var empValue = dbContext.Employee.Where(x => x.EmployeeId == EmployeeId).ToList();
            emp = empValue.FirstOrDefault();
            dbContext.Database.CloseConnection();
        }

        return emp;
    }

    public async Task<int> SaveEmployee(Employee employee, int action)
    {
        int employeeId = -1;
        using (var dbContext = new ApplicationDbContext())
        {

            var command = dbContext.Database.GetDbConnection().CreateCommand();
            command.CommandText = "spSaveEmployee";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@Action", action));
            command.Parameters.Add(new SqlParameter("@EmployeeId", employee.EmployeeId));
            command.Parameters.Add(new SqlParameter("@Name", employee.Name));
            command.Parameters.Add(new SqlParameter("@Designation", employee.Designation));
            command.Parameters.Add(new SqlParameter("@NID", employee.NID));
            command.Parameters.Add(new SqlParameter("@JoiningDate", employee.JoiningDate));

            dbContext.Database.OpenConnection();

            var result = await command.ExecuteScalarAsync();


            if (result != null)
            {
                int.TryParse(result.ToString(), out employeeId);

            }
            dbContext.Database.CloseConnection();

        }
        return employeeId;
    }
    public int DeleteEmployee(int EmployeeId)
    {
        int employeeId = -1;
        using (var dbContext = new ApplicationDbContext())
        {

            try
            {


                var command = dbContext.Database.GetDbConnection().CreateCommand();
                var emp = new Employee { EmployeeId = EmployeeId };

                dbContext.Employee.Remove(emp);
                dbContext.SaveChanges();
                dbContext.Database.CloseConnection();
                return EmployeeId;
            }
            catch (Exception)
            {
                return employeeId;

            }

        }
        return employeeId;
    }
}



