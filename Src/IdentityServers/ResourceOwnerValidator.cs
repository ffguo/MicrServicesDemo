using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServers
{
    public class ResourceOwnerValidator : IResourceOwnerPasswordValidator
    {
        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            if (context.UserName == "Leon" && context.Password == "123")
            {
                context.Result = new GrantValidationResult(
                    subject: context.UserName,
                    authenticationMethod: OidcConstants.AuthenticationMethods.Password);
            }
            else
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "无效的秘钥");
            }
            return Task.FromResult("");
        }
    }
}
