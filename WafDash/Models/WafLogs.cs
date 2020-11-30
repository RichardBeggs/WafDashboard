using System;
using System.Collections.Generic;

namespace WafDash.Models
{
    public partial class WafLogs
    {
        public int Id { get; set; }
        public string TimeStamp { get; set; }
        public string Level { get; set; }
        public string VipIp { get; set; }
        public string VipPort { get; set; }
        public string ClientIp { get; set; }
        public string ClientPort { get; set; }
        public string RuleId { get; set; }
        public string RuleType { get; set; }
        public string Method { get; set; }
        public string Action { get; set; }
        public string FollowUp { get; set; }
        public string Attack { get; set; }
        public string Host { get; set; }
        public string Url { get; set; }
        public string QueryStr { get; set; }
        public string Detail { get; set; }
        public string Protocol { get; set; }
        public string SessionId { get; set; }
        public string Country { get; set; }
        public string UserAgent { get; set; }
        public string ProxyIp { get; set; }
        public string ProxyPort { get; set; }
        public string AuthenticatedUser { get; set; }
        public string Referer { get; set; }
        public string Fingerprint { get; set; }
        public string ReqRiskScore { get; set; }
        public string ClientRiskScore { get; set; }
    }
}
