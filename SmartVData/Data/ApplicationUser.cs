
using Microsoft.AspNetCore.Identity;

namespace SmartVision.Data
{
    public class ApplicationUser : IdentityUser
    {
        public int EmployeeId { get; set; }
    }
}
