using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MemberClaimsAPI.Helper;
using MemberClaimsAPI.Models;

namespace MemberClaimsAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet]
        [Route("api/{values}/GetClaim/{dateParam}")]
        public IHttpActionResult GetClaims(string dateParam)
        {
            DateTime.TryParse(dateParam, out DateTime result);
            DataHelper helper = new DataHelper();
            var claimRecords = helper.LoadData();
            var memberData = helper.LoadMemberData();
            var output = new OutputViewModel();

            foreach (var claim in claimRecords)
            {
                DateTime.TryParse(claim.ClaimDate, out DateTime retDate);
                    if (DateTime.Equals(result, retDate))
                    {
                       output = new OutputViewModel
                        {
                            MemberId = claim.MemberId,
                            FirstName = memberData.Where(p => p.MemberId == claim.MemberId).Select(a => a.FirstName).FirstOrDefault(),
                            LastName = memberData.Where(p => p.MemberId == claim.MemberId).Select(a => a.LastName).FirstOrDefault(),
                            EnrollmentDate = memberData.Where(p => p.MemberId == claim.MemberId).Select(a => a.EnrollmentDate).FirstOrDefault(),
                            ClaimAmount = claim.ClaimAmount
                        };

                    }
            }

            return Ok(output);
        }
        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
