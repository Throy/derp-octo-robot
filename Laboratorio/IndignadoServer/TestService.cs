using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace IndignadoServer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class TestService : ITestService
    {
        public string Ping(string name)
        {
            Console.WriteLine("SERVER - Processing Ping('{0}')", name);

            return "Hello, " + name;
        }
    }
}
