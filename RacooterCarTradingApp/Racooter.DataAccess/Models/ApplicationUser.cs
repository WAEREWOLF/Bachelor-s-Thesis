using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Racooter.DataAccess.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public bool? IsBlockFromPost { get; set; }
        public bool? IsReportedForBlock { get; set; }
        public string ReportedBy { get; set; }
    }
}
