using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemberClaimsAPI.Models
{
    public class OutputViewModel
    {
        public string MemberId { get; set; }
        public string EnrollmentDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ClaimAmount { get; set; }
    }
}