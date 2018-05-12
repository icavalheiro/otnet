using System;
using System.Collections.Generic;

namespace OTNet.DatabaseModels
{
    public partial class StoreHistory
    {
        public uint Id { get; set; }
        public int CoinAmount { get; set; }
        public uint AccountId { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }
    }
}