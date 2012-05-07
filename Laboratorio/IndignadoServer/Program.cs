using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using IndignadoServer.LinqDataContext;
using IndignadoServer.Services;

namespace IndignadoServer
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost _svcHostTest = null;
            ServiceHost _svcHostMeetings = null;
            ServiceHost _svcHostMovAdmin = null;
            ServiceHost _svcHostSysAdmin = null;
            
            try
            {
                Console.WriteLine("Starting Expense Host ...");

                // open service hosts
                _svcHostTest = LoadTestService();
                _svcHostMeetings = LoadMeetingsService();
                _svcHostMovAdmin = LoadMovAdminService();
                _svcHostSysAdmin = LoadSysAdminService();

                // work!
                
                // wait for key to exit system
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
                // close service hosts
                if (_svcHostTest != null)
                {
                    _svcHostTest.Close();
                }
                if (_svcHostMeetings != null)
                {
                    _svcHostMeetings.Close();
                }
                if (_svcHostSysAdmin != null)
                {
                    _svcHostSysAdmin.Close();
                }
            }
        }

        // load test service
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
                Console.WriteLine("\nError at loading TestService. ");
                Console.WriteLine("Exception : " + ex.Message);
                throw ex;
            }

            return svcHost;
        }

        // load meetings service
        private static ServiceHost LoadMeetingsService()
        {
            ServiceHost svcHost = null;
            try
            {
                Console.Write("Loading MeetingsService ... ");

                // Create Service Host.
                svcHost = new ServiceHost(typeof(MeetingsService));
                svcHost.Open();

                Console.WriteLine("Done!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nError at loading MeetingsService. ");
                Console.WriteLine("Exception : " + ex.Message);
                throw ex;
            }

            return svcHost;
        }


        // load movadmin service
        private static ServiceHost LoadMovAdminService()
        {
            ServiceHost svcHost = null;
            try
            {
                Console.Write("Loading MovAdminService ... ");

                // Create Service Host.
                svcHost = new ServiceHost(typeof(MovAdminService));
                svcHost.Open();

                Console.WriteLine("Done!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nError at loading MovAdminService. ");
                Console.WriteLine("Exception : " + ex.Message);
                throw ex;
            }

            return svcHost;
        }


        // load sysadmin service
        private static ServiceHost LoadSysAdminService()
        {
            ServiceHost svcHost = null;
            try
            {
                Console.Write("Loading SysAdminService ... ");

                // Create Service Host.
                svcHost = new ServiceHost(typeof(SysAdminService));
                svcHost.Open();

                Console.WriteLine("Done!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nError at loading SysAdminService. ");
                Console.WriteLine("Exception : " + ex.Message);
                throw ex;
            }

            return svcHost;
        }
    }
}
