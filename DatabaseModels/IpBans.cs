using System;
using System.Collections.Generic;

namespace OTNet.DatabaseModels
{
    public partial class IpBans
    {
        public uint Ip { get; set; }
        public string Reason { get; set; }
        public long BannedAt { get; set; }
        public long ExpiresAt { get; set; }
        public int BannedBy { get; set; }

        public Players BannedByNavigation { get; set; }
    }
}
