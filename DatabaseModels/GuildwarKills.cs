using System;
using System.Collections.Generic;

namespace OTNet.DatabaseModels
{
    public partial class GuildwarKills
    {
        public int Id { get; set; }
        public string Killer { get; set; }
        public string Target { get; set; }
        public int Killerguild { get; set; }
        public int Targetguild { get; set; }
        public int Warid { get; set; }
        public long Time { get; set; }

        public GuildWars War { get; set; }
    }
}
