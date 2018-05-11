using System;
using System.Collections.Generic;
using OTNet.Enums;

namespace OTNet.DataTypes
{
    struct Outfit {
        public UInt16 LookType;
        public UInt16 LookTypeEx;
        public UInt16 LookMount;
        public byte LookHead;
        public byte LookBody;
        public byte LookLegs;
        public byte LookFeet;
        public byte LookAddons;
    };

    struct LightInfo {
        public byte Level;
        public byte Color;
    };

    //TODO: try to convert this into a struct later on
    class ShopInfo {
        public UInt16 ItemId;
        public Int32 SubType;
        public UInt32 BuyPrice;
        public UInt32 SellPrice;
        public string RealName;

        public ShopInfo() {
            SubType = 1;
        }
    };

    struct MarketOffer {
        public UInt32 Price;
        public UInt32 Timestamp;
        public UInt16 Amount;
        public UInt16 Counter;
        public UInt16 ItemId;
        string PlayerName;
    };
    
    struct MarketOfferEx {
        public UInt32 Id;
        public UInt32 PlayerId;
        public UInt32 Timestamp;
        public UInt32 Price;
        public UInt16 Amount;
        public UInt16 Counter;
        public UInt16 ItemId;
        public MarketAction Type;
        string PlayerName;
    };

    struct HistoryMarketOffer {
        public UInt32 Timestamp;
        public UInt32 Price;
        public UInt16 ItemId;
        public UInt16 Amount;
        public MarketOfferState State;
    };

    struct MarketStatistics {
        public UInt32 NumTransactions;
        public UInt32 HighestPrice;
        public UInt64 TotalPrice;
        public UInt32 LowestPrice;
    };

    //TODO: try to convert Buttons and Choices into dictionaries
    struct ModalWindow {
        public List<(string, byte)> Buttons;
        public List<(string, byte)> Choices;
        string Title;
        string Message;
        public UInt32 Id;
        public byte DefaultEnterButton;
        public byte DefaultEscapeButton;
        bool Priority;
    };

    struct CombatDamageType {
        public CombatType Type;
        public Int32 Value;
    }

    struct CombatDamage {
        public CombatDamageType Primary;
        public CombatDamageType Secondary;

        public CombatOrigin Origin;
        public bool Critical;
    };
}