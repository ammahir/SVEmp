using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SmartVision.Entities
{

    public class Timesheet
    {
        [Key]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime DateTime { get; set; }
      
        public enum TimeoffReasons
        {
            IN = 1,
            LunchOut = 2,
            Out = 3,
            SickOut = 4,
            OfficialOut = 5,
            BreakOut = 6
        }
        public string? TimeoffReason { get; set; }

        public Timesheet()
        {
        }
        public Timesheet(Timesheet timesheet)
        {
            Id = timesheet.Id;
            EmployeeId = timesheet.EmployeeId;
            DateTime = timesheet.DateTime;
            TimeoffReason = timesheet.TimeoffReason;
        }
    }
}