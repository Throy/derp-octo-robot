﻿using System;
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
            ServiceHost _svcHostSession = null;
            ServiceHost _svcHostMovAdmin = null;
            ServiceHost _svcHostSysAdmin = null;
            ServiceHost _svcHostNewsResources = null;
            ServiceHost _svcHostUsers = null;
            ServiceHost _svcHostChats = null;
            
            try
            {
                Console.WriteLine("Starting Expense Host ...");

                // open service hosts
                _svcHostSession = LoadSessionService();
                _svcHostTest = LoadTestService();
                _svcHostMeetings = LoadMeetingsService();
                _svcHostMovAdmin = LoadMovAdminService();
                _svcHostSysAdmin = LoadSysAdminService();
                _svcHostNewsResources = LoadNewsResourcesService();
                _svcHostUsers = LoadUsersService();
                _svcHostChats = LoadChatService();

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
                if (_svcHostSysAdmin != null)
                {
                    _svcHostSysAdmin.Close();
                }
                if (_svcHostChats != null)
                {
                    _svcHostChats.Close();
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


        // load sysadmin service
        private static ServiceHost LoadNewsResourcesService()
        {
            ServiceHost svcHost = null;
            try
            {
                Console.Write("Loading NewsResourcesService ... ");

                // Create Service Host.
                svcHost = new ServiceHost(typeof(NewsResourcesService));
                svcHost.Open();

                Console.WriteLine("Done!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nError at loading NewsResourcesService. ");
                Console.WriteLine("Exception : " + ex.Message);
                throw ex;
            }

            return svcHost;
        }


        // load users service
        private static ServiceHost LoadUsersService()
        {
            ServiceHost svcHost = null;
            try
            {
                Console.Write("Loading UsersService ... ");

                // Create Service Host.
                svcHost = new ServiceHost(typeof(UsersService));
                svcHost.Open();

                Console.WriteLine("Done!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nError at loading UsersService. ");
                Console.WriteLine("Exception : " + ex.Message);
                throw ex;
            }

            return svcHost;
        }

        private static ServiceHost LoadChatService()
        {
            ServiceHost svcHost = null;
            try
            {
                Console.Write("Loading ChatService ... ");

                // Create Service Host.
                svcHost = new ServiceHost(typeof(ChatsService));
                svcHost.Open();

                Console.WriteLine("Done!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nError at loading ChatsService. ");
                Console.WriteLine("Exception : " + ex.Message);
                throw ex;
            }

            return svcHost;
        }
    }
}
