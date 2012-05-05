using System;
using System.IdentityModel.Selectors;
using System.ServiceModel;
using IndignadoServer.Controllers;

namespace IndignadoServer
{
    class CustomUserNameValidator : UserNamePasswordValidator
    {
        // This method validates users. It allows in two users, test1 and test2 
        // with passwords 1tset and 2tset respectively.
        // This code is for illustration purposes only and 
        // must not be used in a production environment because it is not secure.    
        public override void Validate(string userName, string password)
        {
            if (null == userName || null == password)
            {
                throw new ArgumentNullException();
            }

            if (!SessionController.Instance.ValidateToken(Convert.ToInt32(userName), password))
            {
                // This throws an informative fault to the client.
                throw new FaultException("Unknown Username or Incorrect Password");
                // When you do not want to throw an infomative fault to the client,
                // throw the following exception.
                // throw new SecurityTokenException("Unknown Username or Incorrect Password");
            }
        }

    }
}
