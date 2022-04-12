using System;
using System.Diagnostics;
using System.Threading;

namespace SystemUsage
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new IpConnection();
            while (true)
            {
                var metrics = client.GetIp();

                foreach (var item in metrics)
                {
                    Console.WriteLine("IP: " + item.ConnectedIp);
                    Console.WriteLine("Login Time: " + item.IpLoginTime);
                }
                Thread.Sleep(1000);
            }
        }
    }
}