namespace BitWardenClient;

public class Collection
{
    public string @object { get; set; }
    public string id { get; set; }
    public string name { get; set; }
    public string organizationId { get; set; }
    public string externalId { get; set; }
    public Group[] groups { get; set; }

    public class Group
    {
        public string id { get; set; }
        public bool readOnly { get; set; }
        public bool hidePasswords { get; set; }
    }
}