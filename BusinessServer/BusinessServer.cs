using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServer
{
    internal class BusinessServer : BusinessServerInterface
    {
        public BusinessServer()
        {
            _factory = new ChannelFactory<DataServerInterface>(new BasicHttpBinding(), new EndpointAddress("http://localhost:8100/DataService"));
            _dataServer = _factory.CreateChannel();
        }
        private ChannelFactory<DataServerInterface> _factory;
        private DataServerInterface _dataServer;

        public int GetNumEntries()
        {
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


    }
}
