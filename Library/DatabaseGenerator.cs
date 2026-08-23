using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Drawing.Imaging;

namespace Library
{
    internal class DatabaseGenerator
    {
        Random rand = new Random();

        string[] photofiles = Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"..","..", "Images"), "*.jpg");
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

        private byte[] getPhoto()
        {
            string file = photofiles[rand.Next(photofiles.Length)];


            using (Bitmap original = new Bitmap(file)) 
            using (Bitmap resized = new Bitmap(original, new Size(120,150)))
            using (MemoryStream ms = new MemoryStream())
            {
                resized.Save(ms, ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        public void GetNextAccount(
           out uint pin,
           out uint acctNo,
           out string firstName,
           out string lastName,
           out int balance,
           out byte[] photo)
        {
            pin = getPin();
            acctNo = getAccountNumber();
            firstName = getFirstName();
            lastName = getLastName();
            balance = getBalance();
            photo = getPhoto();
        }
    }
}
