using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ServiceModel;

namespace IndignadoServer
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost _svcHost = null;

            try
            {
                Console.WriteLine("Starting Expense Host ...");

                _svcHost = LoadTestService();

                Console.WriteLine("\n Indignado Server started. Press any key to exit.\n\n");
                Console.Read();
            }
            catch
            {
                Console.WriteLine("\nHost initialization has failed.");
                Console.WriteLine("Press any key to terminate.");
                Console.Read();
            }
            finally
            {
                if (_svcHost != null)
                    _svcHost.Close();
            }
        }

        private static ServiceHost LoadTestService()
        {
            ServiceHost svcHost = null;
            try
            {
                Console.Write("Loading Test Service ... ");

                // Create Service Host.
                svcHost = new ServiceHost(typeof(TestService));
                svcHost.Open();

                Console.WriteLine("Done!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nError Loading Test Service. ");
                Console.WriteLine("Exception : " + ex.Message);
                throw ex;
            }

            return svcHost;
        }

    }
}
