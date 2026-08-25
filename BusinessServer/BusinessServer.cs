using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Library;

namespace BusinessServer
{
    internal class BusinessServer : BusinessServerInterface
    {
        

        private ChannelFactory<DataServerInterface> _factory;
        private DataServerInterface _dataServer;

        public BusinessServer()
        {
            _factory = new ChannelFactory<DataServerInterface>(
                new NetTcpBinding(),
                new EndpointAddress("net.tcp://127.0.0.1:8100/DataService")
            );

            _dataServer = _factory.CreateChannel();
            Console.Write("Initialized BusinessServer");
            Console.WriteLine("Calling DataServer...");
            Console.WriteLine("Number of entries: " + _dataServer.GetNumEntries());
        }


        public int GetNumEntries()
        {
            Console.Write("BusinessServer");
            return _dataServer.GetNumEntries();
        }

        public void GetValuesForEntry(int index, out uint accountNumber, out uint pin, out int balanace, out string firstName, out string lastName)

        {
            _dataServer.GetValuesForEntry(index, out accountNumber, out pin, out balanace, out firstName, out lastName);
        }

        public byte[] GetPhoto(int index)
        {
            return _dataServer.GetPhoto(index);
        }

        public DataStruct SearchByLastName(string lastName)
        {
            int count = _dataServer.GetNumEntries();
            for (int i = 0; i < count; i ++)
            {
                uint accountNumber;
                uint pin;
                int balance;
                string firstName;
                string foundLastname;

                _dataServer.GetValuesForEntry(i , out accountNumber, out pin, out balance, out firstName, out foundLastname);

                if (foundLastname == lastName)
                {
                    DataStruct result = new DataStruct();
                    result.accountNumber = accountNumber;
                    result.pin = pin;
                    result.balance = balance;
                    result.firstName = firstName;
                    result.lastName = foundLastname;
                    result.photo = _dataServer.GetPhoto(i);
                    return result;
                }
            }
            return null; 
        }

    }
}
