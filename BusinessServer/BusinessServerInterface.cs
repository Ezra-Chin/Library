 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using DataContracts;


namespace BusinessServer
{
    [ServiceContract]

    public interface BusinessServerInterface
    {
        [OperationContract]
        [FaultContract(typeof(IndexFault))]
        int GetNumEntries();

        [OperationContract]
        [FaultContract(typeof(IndexFault))]

        void GetValuesForEntry(
            int index, out uint accountNumber, out uint pin, out int balance, out string firstName, out string lastName);

        [OperationContract]
        [FaultContract(typeof(IndexFault))]
        byte[] GetPhoto(int index);

    }
}
