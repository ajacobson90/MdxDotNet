using MdxDotNet;
using Microsoft.VisualBasic;

namespace MdxDotNetTests
{
    [TestClass]
    public class QueryTests
    {
        [TestMethod]
        public void TestQuery()
        {
            string expectedQuery = @"SELECT
NON EMPTY [Measures].[Total Sales] on 0,
[Location].[City].MEMBERS on 1
FROM [Sample Cube]
WHERE ([Date].[Year].&[2023])";

            var query = new Query("Sample Cube")
                .Axis(0, "[Measures].[Total Sales]", true)
                .Axis(1, "[Location].[City].MEMBERS")
                .Where("[Date].[Year].&[2023]")
                .ToString();
            Assert.AreEqual(expectedQuery, query);
        }

        [TestMethod]
        public void TestQuery_SetInAxis()
        {
            string expectedQuery = @"SELECT
NON EMPTY [Measures].[Total Sales] on 0,
{[Location].[City].[New York], [Location].[City].[Chicago]} on 1
FROM [Sample Cube]
WHERE ([Date].[Year].&[2023])";

            var cities = new[] { "New York", "Chicago" };
            var set = new Set();
            foreach (var city in cities) set.Add($"[Location].[City].[{city}]");

            var query = new Query("Sample Cube")
                .Axis(0, "[Measures].[Total Sales]", true)
                .Axis(1, set)
                .Where("[Date].[Year].&[2023]")
                .ToString();
            Assert.AreEqual(expectedQuery, query);
        }
    }
}