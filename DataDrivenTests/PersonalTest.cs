using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using System.Globalization;

namespace DataDrivenTests
{
    public class PersonData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
    }

    [TestFixture]
    public class PersonTests
    {
        public static IEnumerable<TestCaseData> GetTestData()
        {
            using (var reader = new StreamReader("TestData.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<PersonData>();
                foreach (var record in records)
                {
                    yield return new TestCaseData(record.FirstName, record.LastName, record.FullName);
                }
            }
        }

        [Test, TestCaseSource(nameof(GetTestData))]
        public void VerifyFullName(string firstName, string lastName, string expectedFullName)
        {
            string actualFullName = $"{firstName} {lastName}";
            Assert.AreEqual(expectedFullName, actualFullName);
        }
    }
}
