using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LTSV
{
    /// <summary>
    /// [LTSV (Labeled Tab-separated Values) parser and builder.
    /// </summary>
    public class LTSV
    {
        /// <summary>
        /// LTSV record parser.
        /// 
        /// ex.)
        /// new LTSV.ParseLine("time:28/Feb/2013:12:00:00 +0900\thost:192.168.0.1\treq:GET /list HTTP/1.1\tstatus:200\n");
        /// => new Dictionary&lt;string, string&gt;
        ///       {
        ///           { "time", "28/Feb/2013:12:00:00 +0900" },
        ///           { "host", "192.168.0.1" },
        ///           { "req", "GET /list HTTP/1.1" },
        ///           { "status", "200" }
        ///       };
        /// </summary>
        /// <param name="recordStr">LTSV record string</param>
        /// <returns>LTSV record</returns>
        static public Dictionary<string, string> ParseLine(string recordStr)
        {
            var fieldStrs = Regex.Split(recordStr, @"\t");
            var record = new Dictionary<string, string>();
            foreach (var fieldStr in fieldStrs)
            {
                var match = Regex.Match(fieldStr, @"^([^:]+):(.+)$");
                record[match.Groups[1].Value] = match.Groups[2].Value;
            }
            return record;
        }

        /// <summary>
        /// Hold LTSV records.
        /// </summary>
        public List<Dictionary<string, string>> Records = new List<Dictionary<string, string>>();

        /// <summary>
        /// 
        /// </summary>
        public LTSV()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ltsvStr">LTSV string</param>
        public LTSV(string ltsvStr)
        {
            Parse(ltsvStr);
        }

        /// <summary>
        /// LTSV parser.
        /// </summary>
        /// <param name="ltsvStr"></param>
        /// <returns>this</returns>
        public LTSV Parse(string ltsvStr)
        {
            var recordStrs = Regex.Split(ltsvStr.Trim(), @"\r?\n");
            foreach (var recordStr in recordStrs)
            {
                var record = ParseLine(recordStr);
                Records.Add(record);
            }
            return this;
        }

        /// <summary>
        /// Build LTSV string from <see cref="Records"/>.
        /// </summary>
        /// <returns>LTSV string</returns>
        override public string ToString()
        {
            string ltsvStr = "";
            bool isFirstRecord = true;
            foreach (var record in Records)
            {
                string recordStr = "";
                bool isFirstField = true;
                foreach (var field in record)
                {
                    if (isFirstField) isFirstField = false;
                    else recordStr += "\t";
                    recordStr += string.Format("{0}:{1}", field.Key, field.Value);
                }
                if (isFirstRecord) isFirstRecord = false;
                else ltsvStr += "\n";
                ltsvStr += recordStr;
            }
            return ltsvStr;
        }
    }
}
