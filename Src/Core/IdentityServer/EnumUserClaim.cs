using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core
{
    public class EnumUserClaim
    {
        public const string DisplayName = "displayname";
        public const string UserId = "userid";
    }

    public static class UserIdentityExtension
    {
        /// <summary>
        /// 获得用户的Name
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static string Name(this ClaimsPrincipal @this)
        {
            return @this?.Identity?.Name;
        }

        /// <summary>
        /// 获得DisplayName
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static string DisplayName(this ClaimsPrincipal @this)
        {
            var value = @this?.Claims?.FirstOrDefault(oo => oo.Type == EnumUserClaim.DisplayName.ToString())?.Value;
            return value;
        }

        public static string UserId(this ClaimsPrincipal @this)
        {
            return @this?.Claims?.FirstOrDefault(oo => oo.Type == EnumUserClaim.UserId.ToString())?.Value;
        }
    }
}
