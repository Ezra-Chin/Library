using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("BusinessServer Startig...");

            ServiceHost host;
            NetTcpBinding tcp = new NetTcpBinding();
            tcp.MaxReceivedMessageSize = 10 * 1024 * 1024;
            tcp.MaxBufferSize = 10 * 1024 * 1024;

            host = new ServiceHost(typeof(BusinessServer));

            host.AddServiceEndpoint(
                typeof(BusinessServerInterface), tcp, "net.tcp://0.0.0.0:8200/BusinessServer");


            host.Open();
            Console.WriteLine("Service Online");

            Console.ReadLine();

            host.Close();
        }
    }
}
