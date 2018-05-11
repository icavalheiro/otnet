using System;
using System.Collections.Generic;

namespace OTNet.DatabaseModels
{
    public partial class GuildWars
    {
        public GuildWars()
        {
            GuildwarKills = new HashSet<GuildwarKills>();
        }

        public int Id { get; set; }
        public int Guild1 { get; set; }
        public int Guild2 { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public sbyte Status { get; set; }
        public long Started { get; set; }
        public long Ended { get; set; }

        public ICollection<GuildwarKills> GuildwarKills { get; set; }
    }
}
