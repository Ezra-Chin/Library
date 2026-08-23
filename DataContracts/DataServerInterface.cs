using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace DataContracts
{
    [ServiceContract]
    public interface DataServerInterface
    {
        [OperationContract]
        int GetNumEntries();

        [OperationContract]
        void GetValuesForEntry(
            int index, out uint accountNumber, out uint pin, out int balance, out string firstName, out string lastName);

        [OperationContract]
        [FaultContract(typeof(IndexFault))]
        byte[] GetPhoto(int index);


    }
}
