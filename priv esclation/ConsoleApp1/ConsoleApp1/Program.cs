using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;
using Microsoft.Win32;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //HKLM\SYSTEM\CurrentControlSet\Services  

            //Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services");
            ServiceController[] scs = ServiceController.GetServices();

            foreach (ServiceController controller in scs)
            {
                RegistryKey rkey =  Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services"  +controller.ServiceName);
                
                
                string Paht = rkey.GetValue("ImagePath").ToString();

                if (Paht[0] != '"' && !Paht.Contains("system32") && !Paht.Contains("System32"))
                {
                    Console.WriteLine(controller.ServiceName);
                    Console.WriteLine(Paht);
                }
            }
           
            Console.ReadKey();

        }
    }
}
