using System;
using System.Collections.Generic;

namespace OTNet.DatabaseModels
{
    public partial class AccountBans
    {
        public int AccountId { get; set; }
        public string Reason { get; set; }
        public long BannedAt { get; set; }
        public long ExpiresAt { get; set; }
        public int BannedBy { get; set; }

        public Accounts Account { get; set; }
        public Players BannedByNavigation { get; set; }
    }
}
