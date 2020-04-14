using Core;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using IdentityServers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServers
{
    public static class TestConfig
    {
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = ProjectConfig.ServicesAApi.ClientId,
                    AllowedGrantTypes = new List<string>
                    {
                        GrantTypes.ResourceOwnerPassword.FirstOrDefault(),
                        GrantTypeConstants.ResourceWeixinOpen
                    },
                    ClientSecrets =
                    {
                        new Secret(ProjectConfig.ServicesAApi.Secret.Sha256())
                    },
                    AllowOfflineAccess = true,
                    AllowedScopes = 
                    { 
                        ProjectConfig.ServicesAApi.ApiName,
                        IdentityServerConstants.StandardScopes.OfflineAccess
                    }
                }
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource(ProjectConfig.ServicesAApi.ApiName, ProjectConfig.ServicesAApi.ApiName, new List<string>(){ JwtClaimTypes.Role })
            };
        }

        public static List<TestUser> GetTestUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "ffg",
                    Password = "123"
                }
            };
        }

        public static List<WeChatOpenIdModel> GetWeiXinOpenIdTestUsers()
        {
            return new List<WeChatOpenIdModel>
            {
                new WeChatOpenIdModel
                {
                    OpenId = "openid",
                    UnionId = "unionid",
                    UserName = "ffg"
                }
            };
        }
    }
}
