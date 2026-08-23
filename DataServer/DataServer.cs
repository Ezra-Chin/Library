using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Library;

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
            accountNumber = db.GetAccountNumberByIndex(index);
            pin = db.GetPinByIndex(index);
            balanace = db.GetBalanceByIndex(index);
            firstName = db.GetFirstNameByIndex(index);
            lastName = db.GetLastNameByIndex(index);
        }
    
    }

   
}
