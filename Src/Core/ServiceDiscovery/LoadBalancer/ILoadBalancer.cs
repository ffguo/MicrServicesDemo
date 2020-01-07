using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.ServiceDiscovery.LoadBalancer
{
    public interface ILoadBalancer
    {
        string Resolve(IList<string> services);
    }
}
