using Core;
using Core.IdentityServer;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using IdentityServers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServers
{
    public class ResourceOwnerValidator : IResourceOwnerPasswordValidator
    {
        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            if (Validate(context.UserName, context.Password, out List<Claim> claims))
            {
                context.Result = new GrantValidationResult(
                    subject: context.UserName,
                    authenticationMethod: OidcConstants.AuthenticationMethods.Password,
                    claims: claims);
            }
            else
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "无效的秘钥");
            }
            return Task.FromResult("");
        }

        private bool Validate(string loginName, string password, out List<Claim> claims)
        {
            claims = null;

            var user = GetUserByUserName(loginName);
            if (user == null)
                return false;

            if (user.Password != password)
                return false;

            claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, loginName),
                new Claim(EnumUserClaim.DisplayName, loginName),
                new Claim(EnumUserClaim.UserId, user.SubjectId),
                new Claim(JwtClaimTypes.Role, user.Role.ToString())
            };

            return true;
        }

        private UserModel GetUserByUserName(string userName)
        {
            var normalUser = new UserModel()
            {
                DisplayName = "张三",
                Password = "123456",
                Role = EnumUserRole.Normal,
                SubjectId = "1",
                UserId = 20001,
                UserName = "testNormal"
            };
            var manageUser = new UserModel()
            {
                DisplayName = "李四",
                Password = "123456",
                Role = EnumUserRole.Manage,
                SubjectId = "1",
                UserId = 20001,
                UserName = "testManage"
            };
            var supperManageUser = new UserModel()
            {
                DisplayName = "dotNET博士",
                Password = "123456",
                Role = EnumUserRole.SupperManage,
                SubjectId = "1",
                UserId = 20001,
                UserName = "testSupperManage"
            };

            var list = new List<UserModel>() {
                 normalUser,
                 manageUser,
                 supperManageUser
             };
            return list?.Where(item => item.UserName.Equals(userName))?.FirstOrDefault();
        }
    }
}
