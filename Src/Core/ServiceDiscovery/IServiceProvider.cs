﻿using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.ServiceDiscovery.LoadBalancer;

namespace Core.ServiceDiscovery
{
    public interface IServiceProvider
    {
        Task<IList<string>> GetServicesAsync(string serviceName);
    }
}
