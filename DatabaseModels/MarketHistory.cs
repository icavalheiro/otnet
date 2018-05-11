using System;
using System.Collections.Generic;

namespace OTNet.DatabaseModels
{
    public partial class MarketHistory
    {
        public uint Id { get; set; }
        public int PlayerId { get; set; }
        public sbyte Sale { get; set; }
        public uint Itemtype { get; set; }
        public ushort Amount { get; set; }
        public uint Price { get; set; }
        public ulong ExpiresAt { get; set; }
        public ulong Inserted { get; set; }
        public byte State { get; set; }

        public Players Player { get; set; }
    }
}
