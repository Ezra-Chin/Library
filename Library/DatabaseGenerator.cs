using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class DatabaseGenerator
    {
        Random rand = new Random();

        string[] firstNames =
        {
            "John","Mark","Alice","David","Emma"
        };
        string[] lastNames = { "Simth", "Jones", "Simpson", "Griffin", "Lee" };

        private string getFirstName()
        {

            return firstNames[rand.Next(firstNames.Length)];
        }

        private string getLastName()
        {
            return lastNames[rand.Next(lastNames.Length)];
        }

        private uint getPin()
        {
            return (uint)rand.Next(1000, 9999);
        }

        private uint getAccountNumber()
        {
            return (uint)rand.Next(100000, 999999);
        }

        private int getBalance()
        {
            return rand.Next(100, 10000);
        }

        public void GetNextAccount(
           out uint pin,
           out uint acctNo,
           out string firstName,
           out string lastName,
           out int balance)
        {
            pin = getPin();
            acctNo = getAccountNumber();
            firstName = getFirstName();
            lastName = getLastName();
            balance = getBalance();
        }
    }
}
