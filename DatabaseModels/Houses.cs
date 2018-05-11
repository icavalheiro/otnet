using System;
using System.Collections.Generic;

namespace OTNet.DatabaseModels
{
    public partial class Houses
    {
        public int Id { get; set; }
        public int Owner { get; set; }
        public uint Paid { get; set; }
        public int Warnings { get; set; }
        public string Name { get; set; }
        public int Rent { get; set; }
        public int TownId { get; set; }
        public int Bid { get; set; }
        public int BidEnd { get; set; }
        public int LastBid { get; set; }
        public int HighestBidder { get; set; }
        public int Size { get; set; }
        public int Beds { get; set; }
    }
}
