namespace IggyDNSAPI.Models.v1
{
    public class DnsEntry
    {
        public string ApiKey { get; set; }
        public string Zone { get; set; }
        public string Subdomain { get; set; }
        public string IpAddress { get; set; }
    }
}
