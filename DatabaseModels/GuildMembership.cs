using System;
using System.Collections.Generic;

namespace OTNet.DatabaseModels
{
    public partial class GuildMembership
    {
        public int PlayerId { get; set; }
        public int GuildId { get; set; }
        public int RankId { get; set; }
        public string Nick { get; set; }

        public Guilds Guild { get; set; }
        public Players Player { get; set; }
        public GuildRanks Rank { get; set; }
    }
}
