using System;
using System.Collections.Generic;

namespace OTNet.DatabaseModels
{
    public partial class MarketOffers
    {
        public uint Id { get; set; }
        public int PlayerId { get; set; }
        public sbyte Sale { get; set; }
        public uint Itemtype { get; set; }
        public ushort Amount { get; set; }
        public ulong Created { get; set; }
        public sbyte Anonymous { get; set; }
        public uint Price { get; set; }

        public Players Player { get; set; }
    }
}
