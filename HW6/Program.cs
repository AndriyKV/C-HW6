using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace HW6
{
    class Program
    {
        static void Main(string[] args)
        {
            #region HW6 A)
            Dictionary<string, string> phoneBook = new Dictionary<string, string>();

            StreamReader readPhones = new StreamReader(@"C:\Users\1\source\repos\HW6\phones.txt"); //"phones.txt" it means (C:\Users\1\source\repos\HW6\HW6\bin\Debug)
            try
            {
                #region other way
                //string line;
                //while ((line = readPhones.ReadLine()) != null)
                //{
                //    string[] phonesNemes = line.Split('/');
                //    phoneBook.Add(phonesNemes[0], phonesNemes[1]);
                //}
                #endregion
                for (int i = 0; i < 9; i++)
                {
                    string line = readPhones.ReadLine();
                    string[] phonesNemes = line.Split('/');
                    phoneBook.Add(phonesNemes[1], phonesNemes[0]);
                }
            }
            catch
            {
                Console.WriteLine("Error occurred");
            }
            finally
            {
                readPhones.Close();
            }

            StreamWriter writePhones = new StreamWriter("Phones.txt");
            try
            {
                foreach (var phoneNumber in phoneBook)
                {
                    writePhones.WriteLine(phoneNumber.Value);
                }
            }
            catch
            {
                Console.WriteLine("Error occurred");
            }
            finally { writePhones.Close(); }

            Console.WriteLine("Enter the name from the phone book:");
            #region other way
            //string name = Console.ReadLine();
            //if (phoneBook.ContainsKey(name))
            //{
            //    Console.WriteLine(phoneBook[name]);
            //}
            //else
            //Console.WriteLine("Can't find this name. Please enter right ID");
            #endregion
            string name = Console.ReadLine();
            try
            {
                Console.WriteLine("Phone Number: {0}", phoneBook[name]);
            }
            catch
            {
                Console.WriteLine("Can't find name.");
            }

            #region don't work
            //foreach (var num in phoneBook)
            //{
            //    if (Convert.ToString(num.Value).StartsWith("80"))
            //    {
            //        using (var writeNewPhones = new StreamWriter("New.txt"))
            //        {
            //            foreach (var phoneNumber in phoneBook)
            //            {
            //                writeNewPhones.WriteLine("+3" + phoneNumber.Value);
            //            }
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("FFFFF");
            //    }
            //}
            #endregion

            using (var writeNewPhones = new StreamWriter("New.txt"))
            {
                foreach (var phoneNumber in phoneBook)
                {
                    writeNewPhones.WriteLine("+3" + phoneNumber.Value);
                }
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            #endregion
            #region HW6 B)

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
            #endregion
        }
    }
}
