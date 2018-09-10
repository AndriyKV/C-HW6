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


            for (int i = 0; i < phoneBook.Count; i++)
            {
                if (phoneBook.Values.ElementAt(i).StartsWith("80"))
                {
                    phoneBook[phoneBook.Keys.ElementAt(i)] = "+3" + phoneBook.Values.ElementAt(i);
                }
            }
            //foreach (var num in phoneBook)
            //{
            //    if (num.Value.StartsWith("80"))
            //    {
            //        phoneBook[num.Key]  = "+3" + num.Value;
            //    }
            //    else
            //    {
            //        Console.WriteLine("FFFFF");
            //    }
            //}


            using (var writeNewPhones = new StreamWriter("New.txt"))
            {
                foreach (var phoneNumber in phoneBook)
                {
                    writeNewPhones.WriteLine(phoneNumber.Value);
                }
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
            #endregion
            #region HW6 B)
            Console.WriteLine("Input numbers from... console / file");
            string readFrom = Console.ReadLine();

            switch (readFrom)
            {
                case "console":
                case "Console":
                case "c":
                    int numb = 1;
                    int c = 0;
                    while (c < 10 && numb < 99)
                    {
                        try
                        {
                            numb = ReadConsoleNumber(numb, 100);
                            c++;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    break;
                case "file":
                case "File":
                case "f":

                    Console.WriteLine(ReadFileNumber(1, 100));

                    break;
                default:
                    Console.WriteLine("You did not select: console or file");
                    break;
                    //goto case "console";
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static int ReadFileNumber(int startF, int endF)
        {

        }
        static int ReadConsoleNumber(int start, int end)
        {
            //Console.WriteLine("\nPlease enter 10 integer number:");
            //try
            //{
            int number = Convert.ToInt32(Console.ReadLine());
            if (number > start && number < end)
            {
                return number;
            }
            else
            {
                throw new OverflowException("Number not in the range");
            }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Error occurred: {ex.Message}");
            //}
            //return 0;            
            #endregion
        }
    }
}
