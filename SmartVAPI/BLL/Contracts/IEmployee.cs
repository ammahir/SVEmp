
using Microsoft.AspNetCore.Identity;
using SmartVision.Entities;
using SmartVision.Data;

namespace SmartVAPI.BLL.Contracts;
public interface IEmployee
{
    List<Employee> GetAllEmployee(string empName = "");
    Employee GetEmployee(int EmployeeId);
    Task<int> SaveEmployee(Employee employee, int Action);
    int DeleteEmployee(int EmployeeId);
}
