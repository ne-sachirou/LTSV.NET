using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestLTSV
{
    [TestClass]
    public class UnitTestLTSV
    {
        [TestMethod]
        public void ParseLineTest()
        {
            string ltsvStr = "time:28/Feb/2013:12:00:00 +0900\thost:192.168.0.1\treq:GET /list HTTP/1.1\tstatus:200\n";
            var ltsvLine = LTSV.LTSV.ParseLine(ltsvStr);
            Assert.AreEqual<string>(ltsvLine["time"], "28/Feb/2013:12:00:00 +0900");
            Assert.AreEqual<string>(ltsvLine["host"], "192.168.0.1");
            Assert.AreEqual<string>(ltsvLine["req"], "GET /list HTTP/1.1");
            Assert.AreEqual<string>(ltsvLine["status"], "200");
        }

        [TestMethod]
        public void ParseToStringTest()
        {
            string ltsvStr = "time:28/Feb/2013:12:00:00 +0900\thost:192.168.0.1\treq:GET /list HTTP/1.1\tstatus:200\n";
            ltsvStr += ltsvStr;
            var ltsv = new LTSV.LTSV(ltsvStr);
            Assert.AreEqual<string>(ltsv.ToString(), ltsvStr.Trim());
        }
    }
}
