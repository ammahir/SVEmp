using Microsoft.AspNetCore.Mvc;
using SmartVision.Entities;
using SmartVision.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SmartVAPI.BLL.Contracts;


namespace SmartVAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimesheetController : ControllerBase
    {
        private readonly ITimesheet _iTimesheet;

        public TimesheetController(ITimesheet iTimesheet)
        {
            _iTimesheet = iTimesheet;
        }

        [HttpGet]
        public IEnumerable<Timesheet> Get(int EmployeeId)
        {
            List<Timesheet> timesheets = _iTimesheet.GetAllTimesheet(EmployeeId);

            return timesheets;
        }


        [HttpPost]
        public async Task<int> Save([FromBody] Timesheet timesheet)
        {
            int a = await _iTimesheet.Save(timesheet);
            return a;

        }
    }
}
