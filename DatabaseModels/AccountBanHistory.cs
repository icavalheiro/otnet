using System;
using System.Collections.Generic;

namespace OTNet.DatabaseModels
{
    public partial class AccountBanHistory
    {
        public uint Id { get; set; }
        public int AccountId { get; set; }
        public string Reason { get; set; }
        public long BannedAt { get; set; }
        public long ExpiredAt { get; set; }
        public int BannedBy { get; set; }

        public Accounts Account { get; set; }
        public Players BannedByNavigation { get; set; }
    }
}
