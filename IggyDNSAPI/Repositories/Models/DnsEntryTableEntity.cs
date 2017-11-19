using Microsoft.WindowsAzure.Storage.Table;
using IggyDNSAPI.Helpers;

namespace IggyDNSAPI.Repositories.Models
{
    public class DnsEntryTableEntity : TableEntity
    {
        public DnsEntryTableEntity() { }
        public DnsEntryTableEntity(string apiKey)
        {
            this.PartitionKey = Util.ExtractPrimaryKey(apiKey);
            this.RowKey = apiKey;
        }
        public string Zone { get; set; }
        public string RecordSet { get; set; }
        public string IpAddress { get; set; }
    }
}
