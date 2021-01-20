using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemberClaimsAPI.Models
{
    public class Claim
    {
        [Index(0)]
        public string MemberId { get; set; }

        [Index(1)]
        public string ClaimDate {get; set;}

        [Index(2)]
        public string ClaimAmount { get; set; }
    }
}