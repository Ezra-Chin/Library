using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Library;
using DataContracts;
using System.Runtime.Serialization;



namespace DataServer
{

    [ServiceBehavior ( ConcurrencyMode = ConcurrencyMode.Multiple , UseSynchronizationContext =false )]
    internal class DataServer: DataServerInterface
    {
        DatabaseClass db; 

        public DataServer()
        {
            db = new DatabaseClass();
        }
        public int GetNumEntries()
        {
            return db.GetNumberRecord();
        }

        public void GetValuesForEntry(
            int index, out uint accountNumber, out uint pin , out int balanace, out string firstName, out string lastName)
        {

            int count = db.GetNumberRecord();

            if (index < 0 || index >= count)
            {
                IndexFault fault = new IndexFault
                {
                    RequestedIndex = index,
                    MaxIndex = count - 1,
                    Reason = "Index must be between 0 and " + (count - 1)

                };
                throw new FaultException<IndexFault>(fault, new FaultReason(fault.Reason));
            }
            accountNumber = db.GetAccountNumberByIndex(index);
            pin = db.GetPinByIndex(index);
            balanace = db.GetBalanceByIndex(index);
            firstName = db.GetFirstNameByIndex(index);
            lastName = db.GetLastNameByIndex(index);
        }
        
        public byte[] getPhoto(int index)
        {
            int count = db.GetNumberRecord();
            if (index < 0 || index >= count)
            {
                IndexFault fault = new IndexFault
                {
                    RequestedIndex = index,
                    MaxIndex = count - 1,
                    Reason = "Index must be between 0 and " + (count - 1)
                };
                throw new FaultException<IndexFault>(fault, new FaultReason(fault.Reason));
            }
            return db.GetPhotoByIndex(index);
        }
    }

   
}
