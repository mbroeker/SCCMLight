/**
* Get a List of installed Software
* 
* @copyright       Just use it License
* @author          Markus Bröker
*/

using Microsoft.Win32;
using SCCMLight.Model;
using System;
using System.Collections;
using System.IO;

namespace SCCMLight
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ArrayList GetInstalledAppsWithVersion()
        {
            ArrayList list = new ArrayList();

            string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (Microsoft.Win32.RegistryKey key = Registry.LocalMachine.OpenSubKey(registry_key))
            {
                foreach (string subkeyName in key.GetSubKeyNames())
                {
                    using (RegistryKey subkey = key.OpenSubKey(subkeyName))
                    {
                        object oName = subkey.GetValue("DisplayName");
                        object oVersion = subkey.GetValue("DisplayVersion");

                        string name = "";
                        string version = "";

                        if (oName is string)
                        {
                            name = oName.ToString();

                            if (name != "")
                            {
                                if (oVersion is string) version = oVersion.ToString();

                                Entry entry = new Entry(name, version);
                                list.Add(entry);
                            }
                        }
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// Common Tasks in Companies - Get a list of installed software on each computer and catalogize it in an external software...
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                StreamWriter writer = new StreamWriter(@"installed_software.csv");

                writer.WriteLine("NAME;VERSION");

                ArrayList installedApps = GetInstalledAppsWithVersion();
                installedApps.Sort(new Comparators.SortByNameComparer());

                foreach (Entry entry in installedApps)
                {
                    // Show console output
                    Console.WriteLine("{0};{1}", entry.name, entry.version);

                    // write it to csv
                    writer.WriteLine("{0};{1}", entry.name, entry.version);
                }

                writer.Flush();
                writer.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Generation of CSV-File failed: " + e.Message);
            }

            // Wait for Keypress
            Console.ReadLine();

            // Exit Cleanly
            Environment.Exit(0);
        }
    }
}
