namespace IggyDNSAPI.Helpers
{
    public static class Util
    {
        public static string ExtractPrimaryKey(string guid)
        {
            return guid.Split('-')[0];
        }
    }
}
