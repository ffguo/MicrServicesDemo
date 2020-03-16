using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class ProjectConfig
    {
        public static IdentityServerConfig IdentityServer => new IdentityServerConfig();
    }

    public class IdentityServerConfig
    {
        public string Url => "http://localhost:1000";
        public string AuthenticationScheme => "Demo";
    }
}
