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
    public class TimesheetBLL:ITimesheet
    {
        public Task<int> Save(Timesheet timesheet)
        {
            TimesheetDAL dal = new TimesheetDAL();
            return dal.SaveTimesheet(timesheet);
        }

        public List<Timesheet> GetAllTimesheet(int? EmployeeId)
        {
            TimesheetDAL dal = new TimesheetDAL();
            return dal.GetTimesheet(EmployeeId);
        }
    }
}
