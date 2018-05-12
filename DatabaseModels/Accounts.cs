using System;
using System.Collections.Generic;

namespace OTNet.DatabaseModels
{
    public partial class Accounts
    {
        public Accounts()
        {
            AccountBanHistory = new HashSet<AccountBanHistory>();
            Players = new HashSet<Players>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Secret { get; set; }
        public int Type { get; set; }
        public int Premdays { get; set; }
        public uint Lastday { get; set; }
        public string Email { get; set; }
        public int Creation { get; set; }
        public UInt32 Coins { get; set; }

        public AccountBans AccountBans { get; set; }
        public ICollection<AccountBanHistory> AccountBanHistory { get; set; }
        public ICollection<Players> Players { get; set; }
    }
}
