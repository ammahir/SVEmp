using SmartVision.Entities;

namespace SmartVAPI.BLL.Contracts
{
    public interface ITimesheet
    {
        List<Timesheet> GetAllTimesheet(int? EmployeeId);
        Task<int> Save(Timesheet timesheet);
    }
}
