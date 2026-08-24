using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class DataStruct
    {
        public uint accountNumber;
        public uint pin;
        public int balance;
        public string firstName;
        public string lastName;
        public byte[] photo; 

        public DataStruct()
        {
            accountNumber = 0;
            pin = 0;
            balance = 0;
            firstName = "";
            lastName = "";
            photo = null;   
        }
    }
}
