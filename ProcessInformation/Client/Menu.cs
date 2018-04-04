using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Client
{
    class Menu
    {
        public static string ShowMenu()
        {
            string result = string.Empty;
            string param = string.Empty;
            Console.WriteLine("Menu!!!");
            Console.WriteLine(new string('-', 30));
            Console.WriteLine("1. Show all processes.");
            Console.WriteLine("2. Select process by Id.");
            Console.WriteLine("3. Start process by name.");
            Console.WriteLine("4. Kill process by name.");
            Console.WriteLine("5. Show threads in process.");
            Console.WriteLine("6. Show modules in process.");
            Console.WriteLine("0. Close solution");
            Console.WriteLine(new string('-', 30));
            Console.WriteLine();
            Console.WriteLine("Enter point menu: ");
            result = Console.ReadLine();
            Console.WriteLine();
            if (Regex.IsMatch(result, @"\d", RegexOptions.IgnoreCase))
            {
                switch (result)
                {
                    case "1":
                        {
                            return "1.data";
                        }
                    case "2":
                        {
                            Console.WriteLine("Enter Id process: ");
                            Console.WriteLine();
                            param = Console.ReadLine();
                            string local = "2." + param;
                            return local;
                        }
                    case "3":
                        {
                            Console.WriteLine("Enter Name process:");
                            Console.WriteLine();
                            param = Console.ReadLine();
                            string local = "3." + param;
                            return local;
                        }
                    case "4":
                        {
                            Console.WriteLine("Enter process name:");
                            Console.WriteLine();
                            param = Console.ReadLine();
                            string local = "4." + param;
                            return local;
                        }
                    case "5":
                        {
                            Console.WriteLine("Enter process name:");
                            Console.WriteLine();
                            param = Console.ReadLine();
                            string local = "5." + param;
                            return local;
                        }
                    case "6":
                        {
                            Console.WriteLine("Enter Name process:");
                            Console.WriteLine();
                            param = Console.ReadLine();
                            string local = "6." + param;
                            return local;
                        }
                    default:
                        return string.Format("Incorrect data entry");
                }
            }
            else
            {
                return string.Format("Incorrect data entry");
            }
        }
    }
}
