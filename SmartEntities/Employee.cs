using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartVision.Entities
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]

        public string? Name { get; set; }
        public string? Designation { get; set; }
        public string? NID { set; get; }
        public DateTime JoiningDate { get; set; }

        [NotMapped]
        public string? Email { get; set; }


        //public List<Attendance> Attendances { get; set; }

    }
}
