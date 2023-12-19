using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SmartVData;
using SmartVision.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartVision.DAL
{
    public class TimesheetDAL
    {

        public enum TimeoffReasons
        {
            IN = 1,
            LunchOut = 2,
            Out = 3,
            SickOut = 4,
            OfficialOut = 5,
            BreakOut = 6
        }
       
        public TimesheetDAL()
        {

        }
        public List<Timesheet> GetTimesheet(int? EmployeeId)
        {
            List<Timesheet> employeeAttendanceList = new List<Timesheet>();

            using (var dbContext = new ApplicationDbContext())
            {
                var command = dbContext.Database.GetDbConnection().CreateCommand();
                command.CommandText = "spGetTimesheetByEmpId";
                command.Parameters.Add(new SqlParameter("@EmployeeId", EmployeeId));
                command.CommandType = CommandType.StoredProcedure;

                dbContext.Database.OpenConnection();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Timesheet Att = new Timesheet
                        {
                            EmployeeId = Convert.ToInt32(reader["EmployeeId"]),
                            DateTime =  reader["DateTime"] != DBNull.Value ? Convert.ToDateTime(reader["DateTime"]) : default(DateTime),
                            //TimeoffReason = (Timesheet.TimeoffReasons)Convert.ToInt32(reader["TimeoffReason"])
                            TimeoffReason = Convert.ToInt32(reader["TimeoffReason"]).ToString()
                        };

                        employeeAttendanceList.Add(Att);
                    }
                }
                dbContext.Database.CloseConnection();
            }

            return employeeAttendanceList;
        }
        public async Task<int> SaveTimesheet(Timesheet timesheet)
        {
            int isSuccess = -1;
            using (var dbContext = new ApplicationDbContext())
            {
                var command = dbContext.Database.GetDbConnection().CreateCommand();

                command.CommandText = "spSaveTimesheet";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Id", timesheet.Id));
                command.Parameters.Add(new SqlParameter("@EmployeeId", timesheet.EmployeeId));
                command.Parameters.Add(new SqlParameter("@TimeoffReason",timesheet.TimeoffReason));
                command.Parameters.Add(new SqlParameter("@DateTime", timesheet.DateTime));
                dbContext.Database.OpenConnection();

                
                var result = await command.ExecuteScalarAsync();


                if (result != null)
                {
                    isSuccess = 1;

                }

                dbContext.Database.CloseConnection();
            }
            return isSuccess;
        }

    }
}
