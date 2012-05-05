using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IdentityModel.Selectors;
using System.Collections.ObjectModel;
using System.IdentityModel.Policy;

namespace IndignadoServer
{
    internal class CustomSecurityTokenAuthenticator : CustomUserNameSecurityTokenAuthenticator
    {
        public CustomSecurityTokenAuthenticator(UserNamePasswordValidator validator)
            : base(validator)
        {
        }

        protected override ReadOnlyCollection<IAuthorizationPolicy> ValidateUserNamePasswordCore(String userName, String password)
        {
            ReadOnlyCollection<IAuthorizationPolicy> currentPolicies = base.ValidateUserNamePasswordCore(
                userName, password);
            List<IAuthorizationPolicy> newPolicies = new List<IAuthorizationPolicy>(currentPolicies);

            newPolicies.Add(new CustomAuthorizationPolicy(userName, password));

            return newPolicies.AsReadOnly();
        }
    }
}
