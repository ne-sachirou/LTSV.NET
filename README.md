LTSV.NET
========
Just simple C# (.NET) implementation for [LTSV (Labeled Tab-separated Values)](http://ltsv.org/).

Install
-------
Install from NuGet ([NuGet Gallery | LTSV.NET](https://nuget.org/packages/LTSV/)).
```ps1
PM> Install-Package LTSV
```

Usage
-----
Using namespace.
```cs
using LTSV;
```

Parse an LTSV record.
```cs
Ltsv.ParseLine("time:28/Feb/2013:12:00:00 +0900\thost:192.168.0.1\treq:GET /list HTTP/1.1\tstatus:200\n");
// => new Dictionary<string, string>
//    {
//        { "time", "28/Feb/2013:12:00:00 +0900" },
//        { "host", "192.168.0.1" },
//        { "req", "GET /list HTTP/1.1" },
//        { "status", "200" }
//    };
```

Build an LTSV record.
```cs
Ltsv.BuildLine(new Dictionary<string, string>
    {
        { "time", "28/Feb/2013:12:00:00 +0900" },
        { "host", "192.168.0.1" },
        { "req", "GET /list HTTP/1.1" },
        { "status", "200" }
    });
// => "time:28/Feb/2013:12:00:00 +0900\thost:192.168.0.1\treq:GET /list HTTP/1.1\tstatus:200"
```

Parse LTSV.
```cs
var ltsvStr = "hunter:sAccan\tmOmonga:10\nhunter:lotus_gate\tmOmonga:1e6";
new Ltsv(ltsvStr).Records;
new Ltsv().Parse(ltsvStr).Records;
```

Build LTSV.
```cs
var ltsv = new Ltsv("hunter:sAccan\tmOmonga:10\nhunter:lotus_gate\tmOmonga:1e6");
Console.WriteLine(ltsv.ToString());
```

License
-------
(Public Domain)2013 ne_Sachirou &lt;utakata.c4se@gmail.com&gt;
