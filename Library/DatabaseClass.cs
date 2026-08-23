using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Library
{

    public class DatabaseClass
    {
        List<DataStruct> dataStruct;

        public DatabaseClass()
        {

            dataStruct = new List<DataStruct>();

            DatabaseGenerator gen = new DatabaseGenerator();

            for (int i = 0; i < 100; i ++)
            {
                DataStruct temp = new DataStruct();

                gen.GetNextAccount(
                    out temp.pin, out temp.accountNumber, out temp.firstName, out temp.lastName, out temp.balance);

                dataStruct.Add(temp);
            }
        }


        public uint GetAccountNumberByIndex(int index)
        {
            return dataStruct[index].accountNumber;
        }

        public uint GetPinByIndex(int index)
        {
            return dataStruct[index].pin;
        }

        public string GetFirstNameByIndex(int index)
        {
            return dataStruct[index].firstName;
        }

        public string GetLastNameByIndex(int index)
        {
            return dataStruct[index].lastName;
        }
        public int GetBalanceByIndex(int index)
        {
            return dataStruct[index].balance;
        }

        public int GetNumberRecord()
        {
            return dataStruct.Count;
        }


    }
}
