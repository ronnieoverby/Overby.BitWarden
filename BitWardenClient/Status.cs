using System;

namespace BitWardenClient;

public class Status
{
    public string @object { get; set; }
    public Template template { get; set; }

    public class Template
    {
        public string serverUrl { get; set; }
        public DateTime lastSync { get; set; }
        public string userEmail { get; set; }
        public string userID { get; set; }
        public Status status { get; set; }


        public enum Status
        {
            Locked,
            Unlocked,
            Unauthenticated
        }
    }
}