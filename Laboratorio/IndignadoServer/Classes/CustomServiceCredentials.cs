using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Description;
using System.IdentityModel.Selectors;
using System.ServiceModel.Security;
using System.Diagnostics;

namespace IndignadoServer
{
    public class CustomServiceCredentials : ServiceCredentials
    {
        public CustomServiceCredentials()
        {
        }

        private CustomServiceCredentials(CustomServiceCredentials clone)
            : base(clone)
        {
        }

        protected override ServiceCredentials CloneCore()
        {
            return new CustomServiceCredentials(this);
        }

        public override SecurityTokenManager CreateSecurityTokenManager()
        {
            // Check if the current validation mode is for custom username password validation
            if (UserNameAuthentication.UserNamePasswordValidationMode == UserNamePasswordValidationMode.Custom)
            {
                return new CustomSecurityTokenManager(this);
            }

            //Trace.TraceWarning(Resources.CustomUserNamePasswordValidationNotEnabled);

            return base.CreateSecurityTokenManager();
        }
    }
}
