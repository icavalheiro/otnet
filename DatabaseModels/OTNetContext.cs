using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OTNet.DatabaseModels
{
    public partial class OTNetContext : DbContext
    {
        public virtual DbSet<AccountBanHistory> AccountBanHistory { get; set; }
        public virtual DbSet<AccountBans> AccountBans { get; set; }
        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<GuildInvites> GuildInvites { get; set; }
        public virtual DbSet<GuildMembership> GuildMembership { get; set; }
        public virtual DbSet<GuildRanks> GuildRanks { get; set; }
        public virtual DbSet<Guilds> Guilds { get; set; }
        public virtual DbSet<GuildwarKills> GuildwarKills { get; set; }
        public virtual DbSet<GuildWars> GuildWars { get; set; }
        public virtual DbSet<Houses> Houses { get; set; }
        public virtual DbSet<IpBans> IpBans { get; set; }
        public virtual DbSet<MarketHistory> MarketHistory { get; set; }
        public virtual DbSet<MarketOffers> MarketOffers { get; set; }
        public virtual DbSet<PlayerNamelocks> PlayerNamelocks { get; set; }
        public virtual DbSet<Players> Players { get; set; }
        public virtual DbSet<PlayersOnline> PlayersOnline { get; set; }
        public virtual DbSet<PlayerStorage> PlayerStorage { get; set; }
        public virtual DbSet<ServerConfig> ServerConfig { get; set; }

        // Unable to generate entity type for table 'account_viplist'. Please see the warning messages.
        // Unable to generate entity type for table 'house_lists'. Please see the warning messages.
        // Unable to generate entity type for table 'player_deaths'. Please see the warning messages.
        // Unable to generate entity type for table 'player_depotitems'. Please see the warning messages.
        // Unable to generate entity type for table 'player_inboxitems'. Please see the warning messages.
        // Unable to generate entity type for table 'player_items'. Please see the warning messages.
        // Unable to generate entity type for table 'player_spells'. Please see the warning messages.
        // Unable to generate entity type for table 'tile_store'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Host=localhost;Port=3306;Database=OTNet;Username=root;Password=password");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountBanHistory>(entity =>
            {
                entity.ToTable("account_ban_history");

                entity.HasIndex(e => e.AccountId)
                    .HasName("account_id");

                entity.HasIndex(e => e.BannedBy)
                    .HasName("banned_by");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccountId)
                    .HasColumnName("account_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BannedAt)
                    .HasColumnName("banned_at")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.BannedBy)
                    .HasColumnName("banned_by")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ExpiredAt)
                    .HasColumnName("expired_at")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Reason)
                    .IsRequired()
                    .HasColumnName("reason")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.AccountBanHistory)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("account_ban_history_ibfk_1");

                entity.HasOne(d => d.BannedByNavigation)
                    .WithMany(p => p.AccountBanHistory)
                    .HasForeignKey(d => d.BannedBy)
                    .HasConstraintName("account_ban_history_ibfk_2");
            });

            modelBuilder.Entity<AccountBans>(entity =>
            {
                entity.HasKey(e => e.AccountId);

                entity.ToTable("account_bans");

                entity.HasIndex(e => e.BannedBy)
                    .HasName("banned_by");

                entity.Property(e => e.AccountId)
                    .HasColumnName("account_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BannedAt)
                    .HasColumnName("banned_at")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.BannedBy)
                    .HasColumnName("banned_by")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ExpiresAt)
                    .HasColumnName("expires_at")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Reason)
                    .IsRequired()
                    .HasColumnName("reason")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Account)
                    .WithOne(p => p.AccountBans)
                    .HasForeignKey<AccountBans>(d => d.AccountId)
                    .HasConstraintName("account_bans_ibfk_1");

                entity.HasOne(d => d.BannedByNavigation)
                    .WithMany(p => p.AccountBans)
                    .HasForeignKey(d => d.BannedBy)
                    .HasConstraintName("account_bans_ibfk_2");
            });

            modelBuilder.Entity<Accounts>(entity =>
            {
                entity.ToTable("accounts");

                entity.HasIndex(e => e.Name)
                    .HasName("name")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Creation)
                    .HasColumnName("creation")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Lastday)
                    .HasColumnName("lastday")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(32);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasColumnType("char(40)");

                entity.Property(e => e.Premdays)
                    .HasColumnName("premdays")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Secret)
                    .HasColumnName("secret")
                    .HasColumnType("char(16)");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<GuildInvites>(entity =>
            {
                entity.HasKey(e => new { e.PlayerId, e.GuildId });

                entity.ToTable("guild_invites");

                entity.HasIndex(e => e.GuildId)
                    .HasName("guild_id");

                entity.Property(e => e.PlayerId)
                    .HasColumnName("player_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.GuildId)
                    .HasColumnName("guild_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.HasOne(d => d.Guild)
                    .WithMany(p => p.GuildInvites)
                    .HasForeignKey(d => d.GuildId)
                    .HasConstraintName("guild_invites_ibfk_2");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.GuildInvites)
                    .HasForeignKey(d => d.PlayerId)
                    .HasConstraintName("guild_invites_ibfk_1");
            });

            modelBuilder.Entity<GuildMembership>(entity =>
            {
                entity.HasKey(e => e.PlayerId);

                entity.ToTable("guild_membership");

                entity.HasIndex(e => e.GuildId)
                    .HasName("guild_id");

                entity.HasIndex(e => e.RankId)
                    .HasName("rank_id");

                entity.Property(e => e.PlayerId)
                    .HasColumnName("player_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GuildId)
                    .HasColumnName("guild_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nick)
                    .IsRequired()
                    .HasColumnName("nick")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.RankId)
                    .HasColumnName("rank_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Guild)
                    .WithMany(p => p.GuildMembership)
                    .HasForeignKey(d => d.GuildId)
                    .HasConstraintName("guild_membership_ibfk_2");

                entity.HasOne(d => d.Player)
                    .WithOne(p => p.GuildMembership)
                    .HasForeignKey<GuildMembership>(d => d.PlayerId)
                    .HasConstraintName("guild_membership_ibfk_1");

                entity.HasOne(d => d.Rank)
                    .WithMany(p => p.GuildMembership)
                    .HasForeignKey(d => d.RankId)
                    .HasConstraintName("guild_membership_ibfk_3");
            });

            modelBuilder.Entity<GuildRanks>(entity =>
            {
                entity.ToTable("guild_ranks");

                entity.HasIndex(e => e.GuildId)
                    .HasName("guild_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GuildId)
                    .HasColumnName("guild_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Level)
                    .HasColumnName("level")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Guild)
                    .WithMany(p => p.GuildRanks)
                    .HasForeignKey(d => d.GuildId)
                    .HasConstraintName("guild_ranks_ibfk_1");
            });

            modelBuilder.Entity<Guilds>(entity =>
            {
                entity.ToTable("guilds");

                entity.HasIndex(e => e.Name)
                    .HasName("name")
                    .IsUnique();

                entity.HasIndex(e => e.Ownerid)
                    .HasName("ownerid")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Creationdata)
                    .HasColumnName("creationdata")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Motd)
                    .IsRequired()
                    .HasColumnName("motd")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Ownerid)
                    .HasColumnName("ownerid")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Owner)
                    .WithOne(p => p.Guilds)
                    .HasForeignKey<Guilds>(d => d.Ownerid)
                    .HasConstraintName("guilds_ibfk_1");
            });

            modelBuilder.Entity<GuildwarKills>(entity =>
            {
                entity.ToTable("guildwar_kills");

                entity.HasIndex(e => e.Warid)
                    .HasName("warid");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Killer)
                    .IsRequired()
                    .HasColumnName("killer")
                    .HasMaxLength(50);

                entity.Property(e => e.Killerguild)
                    .HasColumnName("killerguild")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Target)
                    .IsRequired()
                    .HasColumnName("target")
                    .HasMaxLength(50);

                entity.Property(e => e.Targetguild)
                    .HasColumnName("targetguild")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasColumnType("bigint(15)");

                entity.Property(e => e.Warid)
                    .HasColumnName("warid")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.HasOne(d => d.War)
                    .WithMany(p => p.GuildwarKills)
                    .HasForeignKey(d => d.Warid)
                    .HasConstraintName("guildwar_kills_ibfk_1");
            });

            modelBuilder.Entity<GuildWars>(entity =>
            {
                entity.ToTable("guild_wars");

                entity.HasIndex(e => e.Guild1)
                    .HasName("guild1");

                entity.HasIndex(e => e.Guild2)
                    .HasName("guild2");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Ended)
                    .HasColumnName("ended")
                    .HasColumnType("bigint(15)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Guild1)
                    .HasColumnName("guild1")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Guild2)
                    .HasColumnName("guild2")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Name1)
                    .IsRequired()
                    .HasColumnName("name1")
                    .HasMaxLength(255);

                entity.Property(e => e.Name2)
                    .IsRequired()
                    .HasColumnName("name2")
                    .HasMaxLength(255);

                entity.Property(e => e.Started)
                    .HasColumnName("started")
                    .HasColumnType("bigint(15)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("tinyint(2)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Houses>(entity =>
            {
                entity.ToTable("houses");

                entity.HasIndex(e => e.Owner)
                    .HasName("owner");

                entity.HasIndex(e => e.TownId)
                    .HasName("town_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Beds)
                    .HasColumnName("beds")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Bid)
                    .HasColumnName("bid")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.BidEnd)
                    .HasColumnName("bid_end")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.HighestBidder)
                    .HasColumnName("highest_bidder")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.LastBid)
                    .HasColumnName("last_bid")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Owner)
                    .HasColumnName("owner")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Paid)
                    .HasColumnName("paid")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Rent)
                    .HasColumnName("rent")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Size)
                    .HasColumnName("size")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.TownId)
                    .HasColumnName("town_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Warnings)
                    .HasColumnName("warnings")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<IpBans>(entity =>
            {
                entity.HasKey(e => e.Ip);

                entity.ToTable("ip_bans");

                entity.HasIndex(e => e.BannedBy)
                    .HasName("banned_by");

                entity.Property(e => e.Ip).HasColumnName("ip");

                entity.Property(e => e.BannedAt)
                    .HasColumnName("banned_at")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.BannedBy)
                    .HasColumnName("banned_by")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ExpiresAt)
                    .HasColumnName("expires_at")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Reason)
                    .IsRequired()
                    .HasColumnName("reason")
                    .HasMaxLength(255);

                entity.HasOne(d => d.BannedByNavigation)
                    .WithMany(p => p.IpBans)
                    .HasForeignKey(d => d.BannedBy)
                    .HasConstraintName("ip_bans_ibfk_1");
            });

            modelBuilder.Entity<MarketHistory>(entity =>
            {
                entity.ToTable("market_history");

                entity.HasIndex(e => new { e.PlayerId, e.Sale })
                    .HasName("player_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.ExpiresAt).HasColumnName("expires_at");

                entity.Property(e => e.Inserted).HasColumnName("inserted");

                entity.Property(e => e.Itemtype).HasColumnName("itemtype");

                entity.Property(e => e.PlayerId)
                    .HasColumnName("player_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Sale)
                    .HasColumnName("sale")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.State).HasColumnName("state");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.MarketHistory)
                    .HasForeignKey(d => d.PlayerId)
                    .HasConstraintName("market_history_ibfk_1");
            });

            modelBuilder.Entity<MarketOffers>(entity =>
            {
                entity.ToTable("market_offers");

                entity.HasIndex(e => e.Created)
                    .HasName("created");

                entity.HasIndex(e => e.PlayerId)
                    .HasName("player_id");

                entity.HasIndex(e => new { e.Sale, e.Itemtype })
                    .HasName("sale");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Anonymous)
                    .HasColumnName("anonymous")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Created).HasColumnName("created");

                entity.Property(e => e.Itemtype).HasColumnName("itemtype");

                entity.Property(e => e.PlayerId)
                    .HasColumnName("player_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Sale)
                    .HasColumnName("sale")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.MarketOffers)
                    .HasForeignKey(d => d.PlayerId)
                    .HasConstraintName("market_offers_ibfk_1");
            });

            modelBuilder.Entity<PlayerNamelocks>(entity =>
            {
                entity.HasKey(e => e.PlayerId);

                entity.ToTable("player_namelocks");

                entity.HasIndex(e => e.NamelockedBy)
                    .HasName("namelocked_by");

                entity.Property(e => e.PlayerId)
                    .HasColumnName("player_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NamelockedAt)
                    .HasColumnName("namelocked_at")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.NamelockedBy)
                    .HasColumnName("namelocked_by")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Reason)
                    .IsRequired()
                    .HasColumnName("reason")
                    .HasMaxLength(255);

                entity.HasOne(d => d.NamelockedByNavigation)
                    .WithMany(p => p.PlayerNamelocksNamelockedByNavigation)
                    .HasForeignKey(d => d.NamelockedBy)
                    .HasConstraintName("player_namelocks_ibfk_2");

                entity.HasOne(d => d.Player)
                    .WithOne(p => p.PlayerNamelocksPlayer)
                    .HasForeignKey<PlayerNamelocks>(d => d.PlayerId)
                    .HasConstraintName("player_namelocks_ibfk_1");
            });

            modelBuilder.Entity<Players>(entity =>
            {
                entity.ToTable("players");

                entity.HasIndex(e => e.AccountId)
                    .HasName("account_id");

                entity.HasIndex(e => e.Name)
                    .HasName("name")
                    .IsUnique();

                entity.HasIndex(e => e.Vocation)
                    .HasName("vocation");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AccountId)
                    .HasColumnName("account_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Balance)
                    .HasColumnName("balance")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Blessings)
                    .HasColumnName("blessings")
                    .HasColumnType("tinyint(2)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Cap)
                    .HasColumnName("cap")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Conditions)
                    .IsRequired()
                    .HasColumnName("conditions")
                    .HasColumnType("blob");

                entity.Property(e => e.Deletion)
                    .HasColumnName("deletion")
                    .HasColumnType("bigint(15)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Experience)
                    .HasColumnName("experience")
                    .HasColumnType("bigint(20)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.GroupId)
                    .HasColumnName("group_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Health)
                    .HasColumnName("health")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'150'");

                entity.Property(e => e.Healthmax)
                    .HasColumnName("healthmax")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'150'");

                entity.Property(e => e.Lastip)
                    .HasColumnName("lastip")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Lastlogin)
                    .HasColumnName("lastlogin")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Lastlogout)
                    .HasColumnName("lastlogout")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Level)
                    .HasColumnName("level")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Lookaddons)
                    .HasColumnName("lookaddons")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Lookbody)
                    .HasColumnName("lookbody")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Lookfeet)
                    .HasColumnName("lookfeet")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Lookhead)
                    .HasColumnName("lookhead")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Looklegs)
                    .HasColumnName("looklegs")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Looktype)
                    .HasColumnName("looktype")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'136'");

                entity.Property(e => e.Maglevel)
                    .HasColumnName("maglevel")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Mana)
                    .HasColumnName("mana")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Manamax)
                    .HasColumnName("manamax")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Manaspent)
                    .HasColumnName("manaspent")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.OfflinetrainingSkill)
                    .HasColumnName("offlinetraining_skill")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'-1'");

                entity.Property(e => e.OfflinetrainingTime)
                    .HasColumnName("offlinetraining_time")
                    .HasDefaultValueSql("'43200'");

                entity.Property(e => e.Onlinetime)
                    .HasColumnName("onlinetime")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Posx)
                    .HasColumnName("posx")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Posy)
                    .HasColumnName("posy")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Posz)
                    .HasColumnName("posz")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Save)
                    .HasColumnName("save")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Sex)
                    .HasColumnName("sex")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.SkillAxe)
                    .HasColumnName("skill_axe")
                    .HasDefaultValueSql("'10'");

                entity.Property(e => e.SkillAxeTries)
                    .HasColumnName("skill_axe_tries")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.SkillClub)
                    .HasColumnName("skill_club")
                    .HasDefaultValueSql("'10'");

                entity.Property(e => e.SkillClubTries)
                    .HasColumnName("skill_club_tries")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.SkillDist)
                    .HasColumnName("skill_dist")
                    .HasDefaultValueSql("'10'");

                entity.Property(e => e.SkillDistTries)
                    .HasColumnName("skill_dist_tries")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.SkillFishing)
                    .HasColumnName("skill_fishing")
                    .HasDefaultValueSql("'10'");

                entity.Property(e => e.SkillFishingTries)
                    .HasColumnName("skill_fishing_tries")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.SkillFist)
                    .HasColumnName("skill_fist")
                    .HasDefaultValueSql("'10'");

                entity.Property(e => e.SkillFistTries)
                    .HasColumnName("skill_fist_tries")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.SkillShielding)
                    .HasColumnName("skill_shielding")
                    .HasDefaultValueSql("'10'");

                entity.Property(e => e.SkillShieldingTries)
                    .HasColumnName("skill_shielding_tries")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.SkillSword)
                    .HasColumnName("skill_sword")
                    .HasDefaultValueSql("'10'");

                entity.Property(e => e.SkillSwordTries)
                    .HasColumnName("skill_sword_tries")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Skull)
                    .HasColumnName("skull")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Skulltime)
                    .HasColumnName("skulltime")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Soul)
                    .HasColumnName("soul")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Stamina)
                    .HasColumnName("stamina")
                    .HasDefaultValueSql("'2520'");

                entity.Property(e => e.TownId)
                    .HasColumnName("town_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Vocation)
                    .HasColumnName("vocation")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("players_ibfk_1");
            });

            modelBuilder.Entity<PlayersOnline>(entity =>
            {
                entity.HasKey(e => e.PlayerId);

                entity.ToTable("players_online");

                entity.Property(e => e.PlayerId)
                    .HasColumnName("player_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<PlayerStorage>(entity =>
            {
                entity.HasKey(e => new { e.PlayerId, e.Key });

                entity.ToTable("player_storage");

                entity.Property(e => e.PlayerId)
                    .HasColumnName("player_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Key)
                    .HasColumnName("key")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.PlayerStorage)
                    .HasForeignKey(d => d.PlayerId)
                    .HasConstraintName("player_storage_ibfk_1");
            });

            modelBuilder.Entity<ServerConfig>(entity =>
            {
                entity.HasKey(e => e.Config);

                entity.ToTable("server_config");

                entity.Property(e => e.Config)
                    .HasColumnName("config")
                    .HasMaxLength(50);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value")
                    .HasMaxLength(256)
                    .HasDefaultValueSql("''");
            });
        }
    }
}
