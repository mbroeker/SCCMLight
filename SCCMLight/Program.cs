/**
 * Get a List of installed Software
 * 
 * @copyright       Just use it License
 * @author          Markus Bröker
 */
using System;
using System.IO;
using System.Management;

namespace SCCMLight
{
    class Program
    {
        /// <summary>
        /// Common Tasks in Companies - Get a list of installed software on each computer and catalogize it in an external software...
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {                
                StreamWriter writer = new StreamWriter(@"installed_software.csv");

                ManagementObjectCollection managementObjectCollection;
                ManagementObjectSearcher moSearch;

                moSearch = new ManagementObjectSearcher("Select * from Win32_Product");

                managementObjectCollection = moSearch.Get();
                writer.WriteLine("NAME;VERSION");
                foreach (ManagementObject mo in managementObjectCollection)
                {
                    String name = mo["Name"].ToString();
                    String version = mo["Version"].ToString();

                    // Show console output
                    Console.WriteLine("{0};{1}", name, version);

                    // write it to csv
                    writer.WriteLine("{0};{1}", name, version);
                }

                writer.Flush();
                writer.Close();

            } catch (IOException ioe)
            {
                Console.WriteLine("Generation of CSV-File failed: " + ioe.Message);
            }

            Environment.Exit(0);
        }
    }
}
