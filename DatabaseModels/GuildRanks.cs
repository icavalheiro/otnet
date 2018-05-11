using System;
using System.Collections.Generic;

namespace OTNet.DatabaseModels
{
    public partial class GuildRanks
    {
        public GuildRanks()
        {
            GuildMembership = new HashSet<GuildMembership>();
        }

        public int Id { get; set; }
        public int GuildId { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }

        public Guilds Guild { get; set; }
        public ICollection<GuildMembership> GuildMembership { get; set; }
    }
}
