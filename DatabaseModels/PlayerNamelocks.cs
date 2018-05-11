using System;
using System.Collections.Generic;

namespace OTNet.DatabaseModels
{
    public partial class PlayerNamelocks
    {
        public int PlayerId { get; set; }
        public string Reason { get; set; }
        public long NamelockedAt { get; set; }
        public int NamelockedBy { get; set; }

        public Players NamelockedByNavigation { get; set; }
        public Players Player { get; set; }
    }
}
