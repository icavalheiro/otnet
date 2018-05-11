using System;
using System.Collections.Generic;

namespace OTNet.DatabaseModels
{
    public partial class Guilds
    {
        public Guilds()
        {
            GuildInvites = new HashSet<GuildInvites>();
            GuildMembership = new HashSet<GuildMembership>();
            GuildRanks = new HashSet<GuildRanks>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Ownerid { get; set; }
        public int Creationdata { get; set; }
        public string Motd { get; set; }

        public Players Owner { get; set; }
        public ICollection<GuildInvites> GuildInvites { get; set; }
        public ICollection<GuildMembership> GuildMembership { get; set; }
        public ICollection<GuildRanks> GuildRanks { get; set; }
    }
}
