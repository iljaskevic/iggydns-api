using System.Threading.Tasks;
using IggyDNSAPI.Models.v1;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web;

namespace IggyDNSAPI.Clients
{
    public interface IAzureDnsClient
    {
        Task UpdateIpAddressAsync(string ipAddress, string formData);
    }
    
    public class AzureDnsClient : IAzureDnsClient
    {
        public AzureDnsClient()
        {

        }

        public async Task UpdateIpAddressAsync(string ipAddress, string formData)
        {
            
        }
    }
}
