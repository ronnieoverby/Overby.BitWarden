namespace BitWardenClient;

public class OrgMember
{
    public string @object { get; set; }
    public string id { get; set; }
    public string name { get; set; }
    public string email { get; set; }
    public Status status { get; set; }
    public Type type { get; set; }
    public bool twoFactorEnabled { get; set; }


    public enum Type
    {
        Owner = 0,
        Admin = 1,
        User = 2,
        Manager = 3,
    }

    public enum Status
    {
        Revoked = -1,
        Invited = 0,
        Accepted = 1,
        Confirmed = 2,
    }
}