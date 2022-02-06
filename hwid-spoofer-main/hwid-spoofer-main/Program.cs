using Microsoft.Win32;
using System;
using System.Linq;

namespace Unix_Spoofer
{
    class Program
    {
        static void Main()
        {
            Console.Title = "Unix Coding | Free HWID Spoofer | Discord: https://discord.gg/tEVQA8zHNZ";

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.Clear();

            Console.WriteLine("\n\n                ██╗░░░██╗███╗░░██╗██╗██╗░░██╗  ░██████╗██████╗░░█████╗░░█████╗░███████╗███████╗██████╗░");
            Console.WriteLine("                ██║░░░██║████╗░██║██║╚██╗██╔╝  ██╔════╝██╔══██╗██╔══██╗██╔══██╗██╔════╝██╔════╝██╔══██╗");
            Console.WriteLine("                ██║░░░██║██╔██╗██║██║░╚███╔╝░  ╚█████╗░██████╔╝██║░░██║██║░░██║█████╗░░█████╗░░██████╔╝");
            Console.WriteLine("                ██║░░░██║██║╚████║██║░██╔██╗░  ░╚═══██╗██╔═══╝░██║░░██║██║░░██║██╔══╝░░██╔══╝░░██╔══██╗");
            Console.WriteLine("                ╚██████╔╝██║░╚███║██║██╔╝╚██╗  ██████╔╝██║░░░░░╚█████╔╝╚█████╔╝██║░░░░░███████╗██║░░██║");
            Console.WriteLine("                ░╚═════╝░╚═╝░░╚══╝╚═╝╚═╝░░╚═╝  ╚═════╝░╚═╝░░░░░░╚════╝░░╚════╝░╚═╝░░░░░╚══════╝╚═╝░░╚═╝");
            Console.WriteLine("\n                                         ====================================");
            Console.WriteLine("                                         [1] Check HWID        [2] Spoof HWID");
            Console.WriteLine("                                         ====================================");
            Console.Write("\n>");

            var option = Console.ReadLine();

            switch(option)
            {
                case "1":
                    CheckHWID();
                    break;

                case "2":
                    SpoofHWID();
                    break;
            }
            Console.ReadKey();
        }

        public static void CheckHWID()
        {
            try
            {
                Console.Clear();

                string key = "HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\IDConfigDB\\Hardware Profiles\\0001";

                string guid = (string)Registry.GetValue(key, "GUID", (object)"default");

                Console.WriteLine("[Unix] Current HWID: " + guid);

                Console.ReadKey();

                Main();
            }
            catch(Exception)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("[Unix] There was an error while getting your HWID");

                Console.ReadKey();

                Main();
            }
        }

        public static void SpoofHWID()
        {
            try
            {
                Console.Clear();

                string key = "HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\IDConfigDB\\Hardware Profiles\\0001";

                string oldHwid = (string)Registry.GetValue(key, "HwProfileGuid", (object)"default");

                string newHwid = "{Unix-" + GenID(5) + "-" + GenID(5) + "-" + GenID(4) + "-" + GenID(9) + "}";

                Registry.SetValue(key, "GUID", (object)newHwid);

                Registry.SetValue(key, "HwProfileGuid", (object)newHwid);

                Console.WriteLine("[Unix] Successfully Changed Your HWID!");

                Console.WriteLine("\n[Unix] Old HWID: " + oldHwid);

                Console.WriteLine("\n[Unix] New HWID: " + newHwid);

                Console.ReadKey();

                Main();
            }
            catch(Exception)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("[Unix] There was an error while changing your HWID, Try running this tool as an administrator.");

                Console.ReadKey();

                Main();
            }
        }

        private static Random random = new Random();

        public static string GenID(int length)
        {
            string chars = "123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}