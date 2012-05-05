using System;
using System.IdentityModel.Selectors;
using System.ServiceModel;
using IndignadoServer.Controllers;

namespace IndignadoServer
{
    class CustomUserNameValidator : UserNamePasswordValidator
    {
        // This method validates users.  
        public override void Validate(string userName, string password)
        {
            if (null == userName || null == password)
            {
                throw new ArgumentNullException();
            }

        }

    }
}
