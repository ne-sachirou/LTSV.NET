using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using LTSV;

namespace UnitTestLTSV
{
    [TestClass]
    public class UnitTestLTSV
    {
        [TestMethod]
        public void ParseLineTest()
        {
            string ltsvStr = "time:28/Feb/2013:12:00:00 +0900\thost:192.168.0.1\treq:GET /list HTTP/1.1\tstatus:200\n";
            var ltsvLine = Ltsv.ParseLine(ltsvStr);
            Assert.AreEqual<string>("28/Feb/2013:12:00:00 +0900", ltsvLine["time"]);
            Assert.AreEqual<string>("192.168.0.1", ltsvLine["host"]);
            Assert.AreEqual<string>("GET /list HTTP/1.1", ltsvLine["req"]);
            Assert.AreEqual<string>("200", ltsvLine["status"]);
        }

        [TestMethod]
        public void BuildLineTest()
        {
            var record = new Dictionary<string, string>
            {
                { "time", "28/Feb/2013:12:00:00 +0900" },
                { "host", "192.168.0.1" },
                { "req", "GET /list HTTP/1.1" },
                { "status", "200" }
            };
            var ltsvStr = Ltsv.BuildLine(record);
            Assert.AreEqual<string>("time:28/Feb/2013:12:00:00 +0900\thost:192.168.0.1\treq:GET /list HTTP/1.1\tstatus:200", ltsvStr);
        }

        [TestMethod]
        public void ParseToStringTest()
        {
            string ltsvStr = "time:28/Feb/2013:12:00:00 +0900\thost:192.168.0.1\treq:GET /list HTTP/1.1\tstatus:200\n";
            ltsvStr += ltsvStr;
            var ltsv = new Ltsv(ltsvStr);
            Assert.AreEqual<string>(ltsvStr.Trim(), ltsv.ToString());
        }
    }
}
