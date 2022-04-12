using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SystemUsage
{
    public class Ip
    {
        public int Index { get; set; }
        public string ConnectedIp { get; set; }
        public string IpLoginTime { get; set; }
    }
    class IpConnection
    {
        public List<Ip> GetIp()
        {
            List<Ip> metrics = new List<Ip>();

            var output = "";
            var ipInfo = new ProcessStartInfo("w");
            ipInfo.FileName = "/bin/bash";
            ipInfo.Arguments = "-c \"w\"";
            ipInfo.RedirectStandardOutput = true;

            using (var process = Process.Start(ipInfo))
            {
                output = process.StandardOutput.ReadToEnd();
                Console.WriteLine(output);
            }

            var ipLines = output.Split("\n").ToList();
            int i = 0;
            ipLines.RemoveRange(0, 2);
            ipLines.RemoveAt(ipLines.Count - 1);

            foreach (var item in ipLines)
            {
                metrics.Add(new Ip()
                {
                    Index = i,
                    ConnectedIp = item.Split(" ", StringSplitOptions.RemoveEmptyEntries)[2],
                    IpLoginTime = item.Split(" ", StringSplitOptions.RemoveEmptyEntries)[3]
                });
                i++;
            }

            return metrics;
        }
    }
}