using System;
using System.Collections.Generic;

namespace OTNet.DatabaseModels
{
    public partial class GuildInvites
    {
        public int PlayerId { get; set; }
        public int GuildId { get; set; }

        public Guilds Guild { get; set; }
        public Players Player { get; set; }
    }
}
