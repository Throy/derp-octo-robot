using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IdentityModel.Policy;
using System.IdentityModel.Claims;
using System.Security.Principal;
using IndignadoServer.Controllers;

namespace IndignadoServer
{
    internal class CustomAuthorizationPolicy : IAuthorizationPolicy
    {
        public CustomAuthorizationPolicy()
        {

        }

        public CustomAuthorizationPolicy(String userName, String password) 
        { 
            const String UserNameParameterName = "userName"; 
 
            if (String.IsNullOrEmpty(userName)) 
            { 
                throw new ArgumentNullException(UserNameParameterName); 
            } 
   
            Id = Guid.NewGuid().ToString(); 
            Issuer = ClaimSet.System; 
            UserName = userName; 
            Password = password; 
        } 
   
        public bool Evaluate(EvaluationContext evaluationContext, ref object state) 
        { 
            const String IdentitiesKey = "Identities"; 

            // Check if the properties of the context has the identities list 
            if (evaluationContext.Properties.Count == 0 
                || evaluationContext.Properties.ContainsKey(IdentitiesKey) == false
                || evaluationContext.Properties[IdentitiesKey] == null) 
            { 
                return false; 
            } 
   
            // Get the identities list 
            List<IIdentity> identities = evaluationContext.Properties[IdentitiesKey] as List<IIdentity>; 
   
            // Validate that the identities list is valid 
            if (identities == null) 
            { 
                return false; 
            } 

            GenericIdentity newIdentity;
            String[] roles = new string[] { };

            // Password es el token, y UserName el idMovimiento
            if (Password != "Guest" && ControllersHub.Instance.getISessionController().ValidateToken(Convert.ToInt32(UserName), Password))
            {
                newIdentity = new GenericIdentity(Password, UserName); 
                roles = ControllersHub.Instance.getISessionController().GetUserInfo(Password).Roles;
            }
            else
            {
                newIdentity = new GenericIdentity("NoId", UserName);
            }

            const String PrimaryIdentityKey = "PrimaryIdentity"; 
   
            // Update the list and the context with the new identity 
            //identities.Remove(currentIdentity);
            identities.Add(newIdentity); 
            evaluationContext.Properties[PrimaryIdentityKey] = newIdentity; 
   
            // Create a new principal for this identity 
            GenericPrincipal newPrincipal = new GenericPrincipal(newIdentity, roles); 
            const String PrincipalKey = "Principal"; 
   
            // Store the new principal in the context 
            evaluationContext.Properties[PrincipalKey] = newPrincipal; 
   
            // This policy has successfully been evaluated and doesn't need to be called again 
            return true; 
        } 
 
        public String Id 
        {
            get;
            private set;
        } 
 
 
        public ClaimSet Issuer 
        { 
            get; 
            private set; 
        } 
   
        private String Password 
        { 
            get; 
            set; 
        } 
   
        private String UserName 
        { 
            get; 
            set; 
        } 
    }
}
