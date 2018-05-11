namespace OTNet.Enums
{
    public enum RuleViolationType {
        REPORT_TYPE_NAME = 0,
        REPORT_TYPE_STATEMENT = 1,
        REPORT_TYPE_BOT = 2
    };

    public enum RuleViolationReasons {
        REPORT_REASON_NAMEINAPPROPRIATE = 0,
        REPORT_REASON_NAMEPOORFORMATTED = 1,
        REPORT_REASON_NAMEADVERTISING = 2,
        REPORT_REASON_NAMEUNFITTING = 3,
        REPORT_REASON_NAMERULEVIOLATION = 4,
        REPORT_REASON_INSULTINGSTATEMENT = 5,
        REPORT_REASON_SPAMMING = 6,
        REPORT_REASON_ADVERTISINGSTATEMENT = 7,
        REPORT_REASON_UNFITTINGSTATEMENT = 8,
        REPORT_REASON_LANGUAGESTATEMENT = 9,
        REPORT_REASON_DISCLOSURE = 10,
        REPORT_REASON_RULEVIOLATION = 11,
        REPORT_REASON_STATEMENT_BUGABUSE = 12,
        REPORT_REASON_UNOFFICIALSOFTWARE = 13,
        REPORT_REASON_PRETENDING = 14,
        REPORT_REASON_HARASSINGOWNERS = 15,
        REPORT_REASON_FALSEINFO = 16,
        REPORT_REASON_ACCOUNTSHARING = 17,
        REPORT_REASON_STEALINGDATA = 18,
        REPORT_REASON_SERVICEATTACKING = 19,
        REPORT_REASON_SERVICEAGREEMENT = 20
    };

    public enum BugReportType{
        BUG_CATEGORY_MAP = 0,
        BUG_CATEGORY_TYPO = 1,
        BUG_CATEGORY_TECHNICAL = 2,
        BUG_CATEGORY_OTHER = 3
    };

    public enum ThreadState {
        THREAD_STATE_RUNNING,
        THREAD_STATE_CLOSING,
        THREAD_STATE_TERMINATED,
    };

    public enum ItemAttrTypes {
        ITEM_ATTRIBUTE_NONE,

        ITEM_ATTRIBUTE_ACTIONID = 1 << 0,
        ITEM_ATTRIBUTE_UNIQUEID = 1 << 1,
        ITEM_ATTRIBUTE_DESCRIPTION = 1 << 2,
        ITEM_ATTRIBUTE_TEXT = 1 << 3,
        ITEM_ATTRIBUTE_DATE = 1 << 4,
        ITEM_ATTRIBUTE_WRITER = 1 << 5,
        ITEM_ATTRIBUTE_NAME = 1 << 6,
        ITEM_ATTRIBUTE_ARTICLE = 1 << 7,
        ITEM_ATTRIBUTE_PLURALNAME = 1 << 8,
        ITEM_ATTRIBUTE_WEIGHT = 1 << 9,
        ITEM_ATTRIBUTE_ATTACK = 1 << 10,
        ITEM_ATTRIBUTE_DEFENSE = 1 << 11,
        ITEM_ATTRIBUTE_EXTRADEFENSE = 1 << 12,
        ITEM_ATTRIBUTE_ARMOR = 1 << 13,
        ITEM_ATTRIBUTE_HITCHANCE = 1 << 14,
        ITEM_ATTRIBUTE_SHOOTRANGE = 1 << 15,
        ITEM_ATTRIBUTE_OWNER = 1 << 16,
        ITEM_ATTRIBUTE_DURATION = 1 << 17,
        ITEM_ATTRIBUTE_DECAYSTATE = 1 << 18,
        ITEM_ATTRIBUTE_CORPSEOWNER = 1 << 19,
        ITEM_ATTRIBUTE_CHARGES = 1 << 20,
        ITEM_ATTRIBUTE_FLUIDTYPE = 1 << 21,
        ITEM_ATTRIBUTE_DOORID = 1 << 22,
        ITEM_ATTRIBUTE_SPECIAL = 1 << 23,
        ITEM_ATTRIBUTE_IMBUINGSLOTS = 1 << 24,
    };

    public enum VipStatus{
        VIPSTATUS_OFFLINE = 0,
        VIPSTATUS_ONLINE = 1,
        VIPSTATUS_PENDING = 2
    };

    public enum MarketAction {
        MARKETACTION_BUY = 0,
        MARKETACTION_SELL = 1,
    };

    public enum MarketRequest {
        MARKETREQUEST_OWN_OFFERS = 0xFFFE,
        MARKETREQUEST_OWN_HISTORY = 0xFFFF,
    };

    public enum MarketOfferState {
        OFFERSTATE_ACTIVE = 0,
        OFFERSTATE_CANCELLED = 1,
        OFFERSTATE_EXPIRED = 2,
        OFFERSTATE_ACCEPTED = 3,

        OFFERSTATE_ACCEPTEDEX = 255,
    };

    public enum ChannelEvent{
        CHANNELEVENT_JOIN = 0,
        CHANNELEVENT_LEAVE = 1,
        CHANNELEVENT_INVITE = 2,
        CHANNELEVENT_EXCLUDE = 3,
    };

    public enum CreatureType{
        CREATURETYPE_PLAYER = 0,
        CREATURETYPE_MONSTER = 1,
        CREATURETYPE_NPC = 2,
        CREATURETYPE_SUMMONPLAYER = 3,
    };

    public enum OperatingSystem{
        CLIENTOS_NONE = 0,

        CLIENTOS_LINUX = 1,
        CLIENTOS_WINDOWS = 2,
        CLIENTOS_FLASH = 3,
        CLIENTOS_NEW_WINDOWS = 5,

        CLIENTOS_OTCLIENT_LINUX = 10,
        CLIENTOS_OTCLIENT_WINDOWS = 11,
        CLIENTOS_OTCLIENT_MAC = 12,
    };

    public enum SpellGroup{
        SPELLGROUP_NONE = 0,
        SPELLGROUP_ATTACK = 1,
        SPELLGROUP_HEALING = 2,
        SPELLGROUP_SUPPORT = 3,
        SPELLGROUP_SPECIAL = 4,
        SPELLGROUP_CONJURE = 5,
    };

    public enum AccountType{
        ACCOUNT_TYPE_NORMAL = 1,
        ACCOUNT_TYPE_TUTOR = 2,
        ACCOUNT_TYPE_SENIORTUTOR = 3,
        ACCOUNT_TYPE_GAMEMASTER = 4,
        ACCOUNT_TYPE_GOD = 5
    };

    public enum RaceType{
        RACE_NONE,
        RACE_VENOM,
        RACE_BLOOD,
        RACE_UNDEAD,
        RACE_FIRE,
        RACE_ENERGY,
    };

    public enum CombatType {
        COMBAT_NONE = 0,

        COMBAT_PHYSICALDAMAGE = 1 << 0,
        COMBAT_ENERGYDAMAGE = 1 << 1,
        COMBAT_EARTHDAMAGE = 1 << 2,
        COMBAT_FIREDAMAGE = 1 << 3,
        COMBAT_UNDEFINEDDAMAGE = 1 << 4,
        COMBAT_LIFEDRAIN = 1 << 5,
        COMBAT_MANADRAIN = 1 << 6,
        COMBAT_HEALING = 1 << 7,
        COMBAT_DROWNDAMAGE = 1 << 8,
        COMBAT_ICEDAMAGE = 1 << 9,
        COMBAT_HOLYDAMAGE = 1 << 10,
        COMBAT_DEATHDAMAGE = 1 << 11,

        COMBAT_COUNT = 12
    };

    public enum CombatParam {
        COMBAT_PARAM_TYPE,
        COMBAT_PARAM_EFFECT,
        COMBAT_PARAM_DISTANCEEFFECT,
        COMBAT_PARAM_BLOCKSHIELD,
        COMBAT_PARAM_BLOCKARMOR,
        COMBAT_PARAM_TARGETCASTERORTOPMOST,
        COMBAT_PARAM_CREATEITEM,
        COMBAT_PARAM_AGGRESSIVE,
        COMBAT_PARAM_DISPEL,
        COMBAT_PARAM_USECHARGES,
    };

    public enum CallBackParam {
        CALLBACK_PARAM_LEVELMAGICVALUE,
        CALLBACK_PARAM_SKILLVALUE,
        CALLBACK_PARAM_TARGETTILE,
        CALLBACK_PARAM_TARGETCREATURE,
    };

    public enum ConditionParam {
        CONDITION_PARAM_OWNER = 1,
        CONDITION_PARAM_TICKS = 2,
        //CONDITION_PARAM_OUTFIT = 3,
        CONDITION_PARAM_HEALTHGAIN = 4,
        CONDITION_PARAM_HEALTHTICKS = 5,
        CONDITION_PARAM_MANAGAIN = 6,
        CONDITION_PARAM_MANATICKS = 7,
        CONDITION_PARAM_DELAYED = 8,
        CONDITION_PARAM_SPEED = 9,
        CONDITION_PARAM_LIGHT_LEVEL = 10,
        CONDITION_PARAM_LIGHT_COLOR = 11,
        CONDITION_PARAM_SOULGAIN = 12,
        CONDITION_PARAM_SOULTICKS = 13,
        CONDITION_PARAM_MINVALUE = 14,
        CONDITION_PARAM_MAXVALUE = 15,
        CONDITION_PARAM_STARTVALUE = 16,
        CONDITION_PARAM_TICKINTERVAL = 17,
        CONDITION_PARAM_FORCEUPDATE = 18,
        CONDITION_PARAM_SKILL_MELEE = 19,
        CONDITION_PARAM_SKILL_FIST = 20,
        CONDITION_PARAM_SKILL_CLUB = 21,
        CONDITION_PARAM_SKILL_SWORD = 22,
        CONDITION_PARAM_SKILL_AXE = 23,
        CONDITION_PARAM_SKILL_DISTANCE = 24,
        CONDITION_PARAM_SKILL_SHIELD = 25,
        CONDITION_PARAM_SKILL_FISHING = 26,
        CONDITION_PARAM_STAT_MAXHITPOINTS = 27,
        CONDITION_PARAM_STAT_MAXMANAPOINTS = 28,
        // CONDITION_PARAM_STAT_SOULPOINTS = 29,
        CONDITION_PARAM_STAT_MAGICPOINTS = 30,
        CONDITION_PARAM_STAT_MAXHITPOINTSPERCENT = 31,
        CONDITION_PARAM_STAT_MAXMANAPOINTSPERCENT = 32,
        // CONDITION_PARAM_STAT_SOULPOINTSPERCENT = 33,
        CONDITION_PARAM_STAT_MAGICPOINTSPERCENT = 34,
        CONDITION_PARAM_PERIODICDAMAGE = 35,
        CONDITION_PARAM_SKILL_MELEEPERCENT = 36,
        CONDITION_PARAM_SKILL_FISTPERCENT = 37,
        CONDITION_PARAM_SKILL_CLUBPERCENT = 38,
        CONDITION_PARAM_SKILL_SWORDPERCENT = 39,
        CONDITION_PARAM_SKILL_AXEPERCENT = 40,
        CONDITION_PARAM_SKILL_DISTANCEPERCENT = 41,
        CONDITION_PARAM_SKILL_SHIELDPERCENT = 42,
        CONDITION_PARAM_SKILL_FISHINGPERCENT = 43,
        CONDITION_PARAM_BUFF_SPELL = 44,
        CONDITION_PARAM_SUBID = 45,
        CONDITION_PARAM_FIELD = 46,
        CONDITION_PARAM_SKILL_CRITICAL_HIT_CHANCE = 47,
        CONDITION_PARAM_SKILL_CRITICAL_HIT_DAMAGE = 48,
        CONDITION_PARAM_SKILL_LIFE_LEECH_CHANCE = 49,
        CONDITION_PARAM_SKILL_LIFE_LEECH_AMOUNT = 50,
        CONDITION_PARAM_SKILL_MANA_LEECH_CHANCE = 51,
        CONDITION_PARAM_SKILL_MANA_LEECH_AMOUNT = 52,
        CONDITION_PARAM_SKILL_CRITICAL_HIT_CHANCEPERCENT = 53,
        CONDITION_PARAM_SKILL_CRITICAL_HIT_DAMAGEPERCENT = 54,
        CONDITION_PARAM_SKILL_LIFE_LEECH_CHANCEPERCENT = 55,
        CONDITION_PARAM_SKILL_LIFE_LEECH_AMOUNTPERCENT = 56,
        CONDITION_PARAM_SKILL_MANA_LEECH_CHANCEPERCENT = 57,
        CONDITION_PARAM_SKILL_MANA_LEECH_AMOUNTPERCENT = 58,
    };

    public enum BlockType{
        BLOCK_NONE,
        BLOCK_DEFENSE,
        BLOCK_ARMOR,
        BLOCK_IMMUNITY
    };

    public enum Skills{
        SKILL_FIST = 0,
        SKILL_CLUB = 1,
        SKILL_SWORD = 2,
        SKILL_AXE = 3,
        SKILL_DISTANCE = 4,
        SKILL_SHIELD = 5,
        SKILL_FISHING = 6,
        SKILL_CRITICAL_HIT_CHANCE = 7,
        SKILL_CRITICAL_HIT_DAMAGE = 8,
        SKILL_LIFE_LEECH_CHANCE = 9,
        SKILL_LIFE_LEECH_AMOUNT = 10,
        SKILL_MANA_LEECH_CHANCE = 11,
        SKILL_MANA_LEECH_AMOUNT = 12,

        SKILL_MAGLEVEL = 13,
        SKILL_LEVEL = 14,

        SKILL_FIRST = SKILL_FIST,
        SKILL_LAST = SKILL_MANA_LEECH_AMOUNT
    };

    public enum Stats {
        STAT_MAXHITPOINTS,
        STAT_MAXMANAPOINTS,
        STAT_SOULPOINTS, // unused
        STAT_MAGICPOINTS,

        STAT_FIRST = STAT_MAXHITPOINTS,
        STAT_LAST = STAT_MAGICPOINTS
    };

    public enum FormulaType {
        COMBAT_FORMULA_UNDEFINED,
        COMBAT_FORMULA_LEVELMAGIC,
        COMBAT_FORMULA_SKILL,
        COMBAT_FORMULA_DAMAGE,
    };

    public enum ConditionType {
        CONDITION_NONE,

        CONDITION_POISON = 1 << 0,
        CONDITION_FIRE = 1 << 1,
        CONDITION_ENERGY = 1 << 2,
        CONDITION_BLEEDING = 1 << 3,
        CONDITION_HASTE = 1 << 4,
        CONDITION_PARALYZE = 1 << 5,
        CONDITION_OUTFIT = 1 << 6,
        CONDITION_INVISIBLE = 1 << 7,
        CONDITION_LIGHT = 1 << 8,
        CONDITION_MANASHIELD = 1 << 9,
        CONDITION_INFIGHT = 1 << 10,
        CONDITION_DRUNK = 1 << 11,
        CONDITION_EXHAUST_WEAPON = 1 << 12, // unused
        CONDITION_REGENERATION = 1 << 13,
        CONDITION_SOUL = 1 << 14,
        CONDITION_DROWN = 1 << 15,
        CONDITION_MUTED = 1 << 16,
        CONDITION_CHANNELMUTEDTICKS = 1 << 17,
        CONDITION_YELLTICKS = 1 << 18,
        CONDITION_ATTRIBUTES = 1 << 19,
        CONDITION_FREEZING = 1 << 20,
        CONDITION_DAZZLED = 1 << 21,
        CONDITION_CURSED = 1 << 22,
        CONDITION_EXHAUST_COMBAT = 1 << 23, // unused
        CONDITION_EXHAUST_HEAL = 1 << 24, // unused
        CONDITION_PACIFIED = 1 << 25,
        CONDITION_SPELLCOOLDOWN = 1 << 26,
        CONDITION_SPELLGROUPCOOLDOWN = 1 << 27,
    };

    public enum ConditionId {
        CONDITIONID_DEFAULT = -1,
        CONDITIONID_COMBAT,
        CONDITIONID_HEAD,
        CONDITIONID_NECKLACE,
        CONDITIONID_BACKPACK,
        CONDITIONID_ARMOR,
        CONDITIONID_RIGHT,
        CONDITIONID_LEFT,
        CONDITIONID_LEGS,
        CONDITIONID_FEET,
        CONDITIONID_RING,
        CONDITIONID_AMMO,
    };

    public enum PlayerSex{
        PLAYERSEX_FEMALE = 0,
        PLAYERSEX_MALE = 1,

        PLAYERSEX_LAST = PLAYERSEX_MALE
    };

    public enum Vocation {
        VOCATION_NONE = 0
    };

    public enum ReturnValue {
        RETURNVALUE_NOERROR,
        RETURNVALUE_NOTPOSSIBLE,
        RETURNVALUE_NOTENOUGHROOM,
        RETURNVALUE_PLAYERISPZLOCKED,
        RETURNVALUE_PLAYERISNOTINVITED,
        RETURNVALUE_CANNOTTHROW,
        RETURNVALUE_THEREISNOWAY,
        RETURNVALUE_DESTINATIONOUTOFREACH,
        RETURNVALUE_CREATUREBLOCK,
        RETURNVALUE_NOTMOVEABLE,
        RETURNVALUE_DROPTWOHANDEDITEM,
        RETURNVALUE_BOTHHANDSNEEDTOBEFREE,
        RETURNVALUE_CANONLYUSEONEWEAPON,
        RETURNVALUE_NEEDEXCHANGE,
        RETURNVALUE_CANNOTBEDRESSED,
        RETURNVALUE_PUTTHISOBJECTINYOURHAND,
        RETURNVALUE_PUTTHISOBJECTINBOTHHANDS,
        RETURNVALUE_TOOFARAWAY,
        RETURNVALUE_FIRSTGODOWNSTAIRS,
        RETURNVALUE_FIRSTGOUPSTAIRS,
        RETURNVALUE_CONTAINERNOTENOUGHROOM,
        RETURNVALUE_NOTENOUGHCAPACITY,
        RETURNVALUE_CANNOTPICKUP,
        RETURNVALUE_THISISIMPOSSIBLE,
        RETURNVALUE_DEPOTISFULL,
        RETURNVALUE_CREATUREDOESNOTEXIST,
        RETURNVALUE_CANNOTUSETHISOBJECT,
        RETURNVALUE_PLAYERWITHTHISNAMEISNOTONLINE,
        RETURNVALUE_NOTREQUIREDLEVELTOUSERUNE,
        RETURNVALUE_YOUAREALREADYTRADING,
        RETURNVALUE_THISPLAYERISALREADYTRADING,
        RETURNVALUE_YOUMAYNOTLOGOUTDURINGAFIGHT,
        RETURNVALUE_DIRECTPLAYERSHOOT,
        RETURNVALUE_NOTENOUGHLEVEL,
        RETURNVALUE_NOTENOUGHMAGICLEVEL,
        RETURNVALUE_NOTENOUGHMANA,
        RETURNVALUE_NOTENOUGHSOUL,
        RETURNVALUE_YOUAREEXHAUSTED,
        RETURNVALUE_PLAYERISNOTREACHABLE,
        RETURNVALUE_CANONLYUSETHISRUNEONCREATURES,
        RETURNVALUE_ACTIONNOTPERMITTEDINPROTECTIONZONE,
        RETURNVALUE_YOUMAYNOTATTACKTHISPLAYER,
        RETURNVALUE_YOUMAYNOTATTACKAPERSONINPROTECTIONZONE,
        RETURNVALUE_YOUMAYNOTATTACKAPERSONWHILEINPROTECTIONZONE,
        RETURNVALUE_YOUMAYNOTATTACKTHISCREATURE,
        RETURNVALUE_YOUCANONLYUSEITONCREATURES,
        RETURNVALUE_CREATUREISNOTREACHABLE,
        RETURNVALUE_TURNSECUREMODETOATTACKUNMARKEDPLAYERS,
        RETURNVALUE_YOUNEEDPREMIUMACCOUNT,
        RETURNVALUE_YOUNEEDTOLEARNTHISSPELL,
        RETURNVALUE_YOURVOCATIONCANNOTUSETHISSPELL,
        RETURNVALUE_YOUNEEDAWEAPONTOUSETHISSPELL,
        RETURNVALUE_PLAYERISPZLOCKEDLEAVEPVPZONE,
        RETURNVALUE_PLAYERISPZLOCKEDENTERPVPZONE,
        RETURNVALUE_ACTIONNOTPERMITTEDINANOPVPZONE,
        RETURNVALUE_YOUCANNOTLOGOUTHERE,
        RETURNVALUE_YOUNEEDAMAGICITEMTOCASTSPELL,
        RETURNVALUE_CANNOTCONJUREITEMHERE,
        RETURNVALUE_YOUNEEDTOSPLITYOURSPEARS,
        RETURNVALUE_NAMEISTOOAMBIGUOUS,
        RETURNVALUE_CANONLYUSEONESHIELD,
        RETURNVALUE_NOPARTYMEMBERSINRANGE,
        RETURNVALUE_YOUARENOTTHEOWNER,
        RETURNVALUE_NOSUCHRAIDEXISTS,
        RETURNVALUE_ANOTHERRAIDISALREADYEXECUTING,
        RETURNVALUE_TRADEPLAYERFARAWAY,
        RETURNVALUE_YOUDONTOWNTHISHOUSE,
        RETURNVALUE_TRADEPLAYERALREADYOWNSAHOUSE,
        RETURNVALUE_TRADEPLAYERHIGHESTBIDDER,
        RETURNVALUE_YOUCANNOTTRADETHISHOUSE,
        RETURNVALUE_NOTENOUGHFISTLEVEL,
        RETURNVALUE_NOTENOUGHCLUBLEVEL,
        RETURNVALUE_NOTENOUGHSWORDLEVEL,
        RETURNVALUE_NOTENOUGHAXELEVEL,
        RETURNVALUE_NOTENOUGHDISTANCELEVEL,
        RETURNVALUE_NOTENOUGHSHIELDLEVEL,
        RETURNVALUE_NOTENOUGHFISHLEVEL,
        RETURNVALUE_REWARDCHESTISEMPTY,
    };

    public enum SpeechBubble{
        SPEECHBUBBLE_NONE = 0,
        SPEECHBUBBLE_NORMAL = 1,
        SPEECHBUBBLE_TRADE = 2,
        SPEECHBUBBLE_QUEST = 3,
        SPEECHBUBBLE_QUESTTRADER = 4,
    };

    public enum MapMark{
        MAPMARK_TICK = 0,
        MAPMARK_QUESTION = 1,
        MAPMARK_EXCLAMATION = 2,
        MAPMARK_STAR = 3,
        MAPMARK_CROSS = 4,
        MAPMARK_TEMPLE = 5,
        MAPMARK_KISS = 6,
        MAPMARK_SHOVEL = 7,
        MAPMARK_SWORD = 8,
        MAPMARK_FLAG = 9,
        MAPMARK_LOCK = 10,
        MAPMARK_BAG = 11,
        MAPMARK_SKULL = 12,
        MAPMARK_DOLLAR = 13,
        MAPMARK_REDNORTH = 14,
        MAPMARK_REDSOUTH = 15,
        MAPMARK_REDEAST = 16,
        MAPMARK_REDWEST = 17,
        MAPMARK_GREENNORTH = 18,
        MAPMARK_GREENSOUTH = 19,
    };

    public enum CombatOrigin {
        ORIGIN_NONE,
        ORIGIN_CONDITION,
        ORIGIN_SPELL,
        ORIGIN_MELEE,
        ORIGIN_RANGED,
    };


    //TODO: solve this lines
    // using MarketOfferList = std::list<MarketOffer>;
    // using HistoryMarketOfferList = std::list<HistoryMarketOffer>;
    // using ShopInfoList = std::list<ShopInfo>;
}