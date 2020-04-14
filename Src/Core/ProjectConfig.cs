using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class ProjectConfig
    {
        /// <summary>
        /// 过期秒数
        /// </summary>
        public const int ExpireIn = 36000;

        /// <summary>
        /// IdentityServer相关
        /// </summary>
        public static class IdentityServer
        {
            public static string Url = "http://localhost:1000";

            public static string AuthenticationScheme = "Demo";
        }

        /// <summary>
        /// 用户Api相关
        /// </summary>
        public static class UserApi
        {
            public static string ApiName = "user_api";

            public static string ClientId = "user_clientid";

            public static string Secret = "user_secret";
        }

        /// <summary>
        /// ServicesA Api相关
        /// </summary>
        public static class ServicesAApi
        {
            public static string ApiName = "services_a_api";

            public static string ClientId = "services_a_clientid";

            public static string Secret = "services_a_secret";
        }
    }
}
