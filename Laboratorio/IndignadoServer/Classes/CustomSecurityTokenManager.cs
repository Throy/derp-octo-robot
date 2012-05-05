using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Security;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;

namespace IndignadoServer
{
    internal class CustomSecurityTokenManager : ServiceCredentialsSecurityTokenManager
    {
        public CustomSecurityTokenManager(CustomServiceCredentials credentials)
            : base(credentials)
        {
        }

        public override SecurityTokenAuthenticator CreateSecurityTokenAuthenticator(SecurityTokenRequirement tokenRequirement, out SecurityTokenResolver outOfBandTokenResolver)
        {
            if (tokenRequirement.TokenType == SecurityTokenTypes.UserName)
            {
                outOfBandTokenResolver = null;

                // Get the current validator
                UserNamePasswordValidator validator =
                    ServiceCredentials.UserNameAuthentication.CustomUserNamePasswordValidator;

                return new CustomSecurityTokenAuthenticator(validator);
            }

            return base.CreateSecurityTokenAuthenticator(tokenRequirement, out outOfBandTokenResolver);
        }
    }
}
