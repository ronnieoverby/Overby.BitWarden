using System;

namespace BitWardenClient;

public class Item
{
    public string @object { get; set; }
    public string id { get; set; }
    public string organizationId { get; set; }
    public string folderId { get; set; }
    public ItemType type { get; set; }
    public int reprompt { get; set; }
    public string name { get; set; }
    public string notes { get; set; }
    public bool favorite { get; set; }
    public DateTime revisionDate { get; set; }
    public DateTime creationDate { get; set; }
    public DateTime? deletedDate { get; set; }

    public Attachment[] attachments { get; set; }
    public Field[] fields { get; set; }
    public Login login { get; set; }
    public string[] collectionids { get; set; }
    public Identity identity { get; set; }
    public SecureNote secureNote { get; set; }
    public Card card { get; set; }

    public class Attachment
    {
        public string id { get; set; }
        public string fileName { get; set; }
        public long size { get; set; }
        public string sizeName { get; set; }
        public string url { get; set; }
    }

    public class Login
    {
        public Uri[] uris { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string totp { get; set; }
        public DateTime? passwordRevisionDate { get; set; }

        public class Uri
        {
            public Match? match { get; set; }
            public string uri { get; set; }

            public enum Match
            {
                BaseDomain = 0,
                Host = 1,
                StartsWith = 2,
                Exact = 3,
                RegularExpression = 4,
                Never = 5
            }
        }

    }

    public class SecureNote
    {
        public int type { get; set; }
    }

    public class Card
    {
        public string cardholderName { get; set; }
        public string brand { get; set; }
        public string number { get; set; }
        public string expMonth { get; set; }
        public string expYear { get; set; }
        public string code { get; set; }
    }

    public class Identity
    {
        public string title { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string address3 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postalCode { get; set; }
        public string country { get; set; }
        public string company { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string ssn { get; set; }
        public string username { get; set; }
        public string passportNumber { get; set; }
        public string licenseNumber { get; set; }
    }

    public class Field
    {
        public string name { get; set; }
        public string value { get; set; }
        public FieldType type { get; set; }
        public int? linkedId { get; set; }

        public enum FieldType
        {
            Text = 0,
            Hidden = 1,
            Bool = 2,
            Linked = 3
        }
    }

    public enum ItemType
    {
        Login = 1,
        SecureNote = 2,
        Card = 3,
        Identity = 4
    }
}