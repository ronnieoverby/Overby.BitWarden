namespace BitWardenClient;

public class Organization
{
    public string @object { get; set; }
    public string id { get; set; }
    public string name { get; set; }
    public int? status { get; set; }
    public int? type { get; set; }
    public bool? enabled { get; set; }
}