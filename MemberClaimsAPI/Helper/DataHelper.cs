using MemberClaimsAPI.Models;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using CsvHelper.Configuration;
using System.Linq;

namespace MemberClaimsAPI.Helper
{
    public class DataHelper
    {
        string path = @"C:\Users\yesit\Downloads\WebAPI-SampleProject\Claim.csv";
        string path2 = @"C:\Users\yesit\Downloads\WebAPI-SampleProject\Member.csv";

        public IEnumerable<Claim> LoadData()
        {
            IEnumerable<Claim> records = null;
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };
            using (var reader = new StreamReader(path))
            {
                using (var csv = new CsvReader(reader, config))
                {
                    records = csv.GetRecords<Claim>().ToList();
                }
            }

            return records;
        }

        public IEnumerable<Member> LoadMemberData()
        {
            IEnumerable<Member> records = null;
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };
            using (var reader = new StreamReader(path2))
            {
                using (var csv = new CsvReader(reader, config))
                {
                    records = csv.GetRecords<Member>().ToList();
                }
            }
            return records;
        }

        //unused
        public static List<string> ReadInCSV(string absolutePath)
        {
            List<string> result = new List<string>();
            string value;
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };
            using (TextReader fileReader = File.OpenText(absolutePath))
            {
                var csv = new CsvReader(fileReader, config);
                //csv.Configuration.HasHeaderRecord = false;
                while (csv.Read())
                {
                    for (int i = 0; csv.TryGetField<string>(i, out value); i++)
                    {
                        result.Add(value);
                    }
                }
            }
            return result;
        }
    }
}