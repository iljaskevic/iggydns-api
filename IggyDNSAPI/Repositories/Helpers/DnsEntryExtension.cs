using IggyDNSAPI.Models.v1;
using IggyDNSAPI.Repositories.Models;
using Newtonsoft.Json;

namespace IggyDNSAPI.Repositories.Helpers
{
    public static class DnsEntryExtension
    {
        public static DnsEntry ToDnsEntry(this DnsEntryTableEntity dnsEntryEntity)
        {
            if (dnsEntryEntity == null) return null;
            var result = new DnsEntry();
            result.ApiKey = dnsEntryEntity.RowKey;
            result.Zone = dnsEntryEntity.Zone;
            result.Subdomain = dnsEntryEntity.RecordSet;
            result.IpAddress = dnsEntryEntity.IpAddress;
            return result;
        }
    }
}
