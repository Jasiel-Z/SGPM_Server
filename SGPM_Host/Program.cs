using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SGPM_Host
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(SGPM_Services.ProjectsManagement.SGPMManager)))
            {
                host.Open();
                Console.WriteLine("Server is running. Press Enter to exit.");
                Console.ReadLine();
            }
        }
    }
}
