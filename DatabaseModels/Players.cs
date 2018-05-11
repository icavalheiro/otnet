using System;
using System.Collections.Generic;

namespace OTNet.DatabaseModels
{
    public partial class Players
    {
        public Players()
        {
            AccountBanHistory = new HashSet<AccountBanHistory>();
            AccountBans = new HashSet<AccountBans>();
            GuildInvites = new HashSet<GuildInvites>();
            IpBans = new HashSet<IpBans>();
            MarketHistory = new HashSet<MarketHistory>();
            MarketOffers = new HashSet<MarketOffers>();
            PlayerNamelocksNamelockedByNavigation = new HashSet<PlayerNamelocks>();
            PlayerStorage = new HashSet<PlayerStorage>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int GroupId { get; set; }
        public int AccountId { get; set; }
        public int Level { get; set; }
        public int Vocation { get; set; }
        public int Health { get; set; }
        public int Healthmax { get; set; }
        public long Experience { get; set; }
        public int Lookbody { get; set; }
        public int Lookfeet { get; set; }
        public int Lookhead { get; set; }
        public int Looklegs { get; set; }
        public int Looktype { get; set; }
        public int Lookaddons { get; set; }
        public int Maglevel { get; set; }
        public int Mana { get; set; }
        public int Manamax { get; set; }
        public uint Manaspent { get; set; }
        public uint Soul { get; set; }
        public int TownId { get; set; }
        public int Posx { get; set; }
        public int Posy { get; set; }
        public int Posz { get; set; }
        public byte[] Conditions { get; set; }
        public int Cap { get; set; }
        public int Sex { get; set; }
        public ulong Lastlogin { get; set; }
        public uint Lastip { get; set; }
        public sbyte Save { get; set; }
        public sbyte Skull { get; set; }
        public int Skulltime { get; set; }
        public ulong Lastlogout { get; set; }
        public sbyte Blessings { get; set; }
        public int Onlinetime { get; set; }
        public long Deletion { get; set; }
        public ulong Balance { get; set; }
        public ushort OfflinetrainingTime { get; set; }
        public int OfflinetrainingSkill { get; set; }
        public ushort Stamina { get; set; }
        public uint SkillFist { get; set; }
        public ulong SkillFistTries { get; set; }
        public uint SkillClub { get; set; }
        public ulong SkillClubTries { get; set; }
        public uint SkillSword { get; set; }
        public ulong SkillSwordTries { get; set; }
        public uint SkillAxe { get; set; }
        public ulong SkillAxeTries { get; set; }
        public uint SkillDist { get; set; }
        public ulong SkillDistTries { get; set; }
        public uint SkillShielding { get; set; }
        public ulong SkillShieldingTries { get; set; }
        public uint SkillFishing { get; set; }
        public ulong SkillFishingTries { get; set; }

        public Accounts Account { get; set; }
        public GuildMembership GuildMembership { get; set; }
        public Guilds Guilds { get; set; }
        public PlayerNamelocks PlayerNamelocksPlayer { get; set; }
        public ICollection<AccountBanHistory> AccountBanHistory { get; set; }
        public ICollection<AccountBans> AccountBans { get; set; }
        public ICollection<GuildInvites> GuildInvites { get; set; }
        public ICollection<IpBans> IpBans { get; set; }
        public ICollection<MarketHistory> MarketHistory { get; set; }
        public ICollection<MarketOffers> MarketOffers { get; set; }
        public ICollection<PlayerNamelocks> PlayerNamelocksNamelockedByNavigation { get; set; }
        public ICollection<PlayerStorage> PlayerStorage { get; set; }
    }
}
