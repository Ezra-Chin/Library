using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using DataContracts;

namespace DataServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bank Server Startig...");

            ServiceHost host;
            NetTcpBinding tcp = new NetTcpBinding();
            tcp.MaxReceivedMessageSize = 10 * 1024 * 1024; 
            tcp.MaxBufferSize = 10 * 1024 * 1024;

            host = new ServiceHost(typeof(DataServer));

            host.AddServiceEndpoint(
                typeof(DataServerInterface), tcp, "net.tcp://0.0.0.0:8100/DataService");


            host.Open();
            Console.WriteLine("Service Online");

            Console.ReadLine();

            host.Close();
        }
    }
}
