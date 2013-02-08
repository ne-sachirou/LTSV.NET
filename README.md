LTSV.NET
========
C# implementation of [LTSV (Labeled Tab-separated Values)](http://ltsv.org/).

Usage
=====
Parse LTSV.
```cs
var ltsvStr = "hunter:sAccan\tmOmonga:10\nhunter:lotus_gate\tmOmonga:1e6";
new LTSV.LTSV(ltsvStr).Records;
new LTSV.LTSV().Parse(ltsvStr).Records;
```

Parse an LTSV record.
```cs
LTSV.LTSV.ParseLine("time:28/Feb/2013:12:00:00 +0900\thost:192.168.0.1\treq:GET /list HTTP/1.1\tstatus:200\n");
// => new Dictionary<string, string>
//    {
//        { "time", "28/Feb/2013:12:00:00 +0900" },
//        { "host", "192.168.0.1" },
//        { "req", "GET /list HTTP/1.1" },
//        { "status", "200" }
//    };
```

Build LTSV.
```cs
var ltsv = new LTSV.LTSV("hunter:sAccan\tmOmonga:10\nhunter:lotus_gate\tmOmonga:1e6");
Console.WriteLine(ltsv.ToString());
```

License
=======
(Public Domain)2013 ne_Sachirou &lt;utakata.c4se@gmail.com&gt;
