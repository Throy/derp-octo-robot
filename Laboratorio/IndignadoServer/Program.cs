using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignadoServer.LinqDataContext;
using System.ServiceModel;

namespace IndignadoServer
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost _svcHostTest = null;
            ServiceHost _svcHostMeetings = null;
            ServiceHost _svcHostSession = null;
            
            try
            {
                Console.WriteLine("Starting Expense Host ...");

                // load service hosts
                _svcHostSession = LoadSessionService();
                _svcHostTest = LoadTestService();
                _svcHostMeetings = LoadMeetingsService();

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
                if (_svcHostSession != null)
                {
                    _svcHostSession.Close();
                }
                if (_svcHostTest != null)
                {
                    _svcHostTest.Close();
                }
                if (_svcHostMeetings != null)
                {
                    _svcHostMeetings.Close();
                }
            }
        }

        private static ServiceHost LoadSessionService()
        {
            ServiceHost svcHost = null;
            try
            {
                Console.Write("Loading Session Service ... ");

                // Create Service Host.
                svcHost = new ServiceHost(typeof(SessionService));
                svcHost.Open();

                Console.WriteLine("Done!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nError at loading SessionService. ");
                Console.WriteLine("Exception : " + ex.Message);
                throw ex;
            }

            return svcHost;
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
                Console.Write("Loading Meetings Service ... ");

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

    }
}
