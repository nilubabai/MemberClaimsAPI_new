using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CsvHelper.Configuration.Attributes;

namespace MemberClaimsAPI.Models
{
    public class Member
    {
        [Index(0)]
        public string MemberId { get; set; }

        [Index(1)]
        public string EnrollmentDate { get; set; }

        [Index(2)]
        public string FirstName { get; set; }

        [Index(3)]
        public string LastName { get; set; }

    }
}