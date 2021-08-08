using System;
using System.Collections.Generic;
using System.Text;

namespace Racooter.DataTransferObjects
{
    public class UserDto
    {
        public string id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public bool IsBlockFromPost { get; set; }
        public bool IsReportedForBlock { get; set; }
        public string ReportedBy { get; set; }
    }
}
