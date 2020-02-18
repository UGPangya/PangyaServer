using System;

namespace PangyaFileCore
{
    public class IFFCommon
    {
        public uint Active { get; set; }
        public uint ID { get; set; }
        public string Name { get; set; }
        public ItemLevelEnum Level { get; set; }
        public string Icon { get; set; }
        public byte Flag1 { get; set; }
        public byte Flag2 { get; set; }
        public byte Flag3 { get; set; }
        public uint Price { get; set; }
        public uint DiscountPrice { get; set; }
        public uint UsedPrice { get; set; }
        public ShopFlag ShopFlag { get; set; }
        public MoneyFlag MoneyFlag { get; set; }
        public byte TimeFlag { get; set; }
        public byte TimeByte { get; set; }
        public uint TPItem { get; set; }
        public uint TPCount { get; set; }
        public ushort Mileage { get; set; }
        public ushort BonusProb { get; set; }
        public ushort Mileage2 { get; set; }
        public ushort Mileage3 { get; set; }
        public uint TikiPointShop { get; set; }
        public uint TikiPang { get; set; }
        public uint ActiveData { get; set; }
        public SystemTime StartTime { get; set; } = new SystemTime();
        public SystemTime EndTime { get; set; } = new SystemTime();
    }
    public class SystemTime
    {
        public ushort Year { get; set; }
        public ushort Month { get; set; }
        public ushort DayOfWeek { get; set; }
        public ushort Day { get; set; }
        public ushort Hour { get; set; }
        public ushort Minute { get; set; }
        public ushort Second { get; set; }
        public ushort MilliSecond { get; set; }
    }
    public class MemorialSpecialItem
    {
        public byte Number { get; set; }
        public uint TypeID { get; set; }
        public uint Quantity { get; set; }
    }
    public class CardPack
    {
        public PackCard CardTypePack { get; set; }
        public byte Quantity { get; set; }
    }   
    
    public class TClubStatus
    {
        public ushort Power { get; set; }

        public ushort Control { get; set; }

        public ushort Impact { get; set; }

        public ushort Spin { get; set; }

        public ushort Curve { get; set; }

        public ClubTypeEnum ClubType { get; set; }
        public byte ClubSPoint { get; set; }

        public byte GetClubArray(int ID)
        {
            byte[] result = new byte[5];
            result[0] = (byte)Power;
            result[1] = (byte)Control;
            result[2] = (byte)Impact;
            result[3] = (byte)Spin;
            result[4] = (byte)Curve;
            return result[ID];
        }
        public TClubStatus GetClubPlayer(TClubStatus ClubPlayerData)
        {
            TClubStatus result;
            Power += ClubPlayerData.Power;
            Control += ClubPlayerData.Control;
            Impact += ClubPlayerData.Impact;
            Spin += ClubPlayerData.Spin;
            Curve += ClubPlayerData.Curve;
            result = this;
            return result;
        }
        public static TClubStatus operator -(TClubStatus X, TClubStatus Y)
        {
            TClubStatus result = new TClubStatus
            {
                Power = X.Power -= Y.Power,
                Control = X.Control -= Y.Control,
                Impact = X.Impact -= Y.Impact,
                Spin = X.Spin -= Y.Spin,
                Curve = X.Curve -= Y.Curve
            };
            if (
                result.Power == 65519
                && result.Control == 65518
                && result.Impact == 65518
                && result.Spin == 65529
                && result.Curve == 65530
                )
            {
                result.Power = 0;
                result.Control = 0;
                result.Impact = 0;
                result.Spin = 0;
                result.Curve = 0;
            }
            return result;
        }


        public static TClubStatus operator +(TClubStatus X, TClubStatus Y)
        {
            TClubStatus result = new TClubStatus
            {
                Power = X.Power += Y.Power,
                Control = X.Control += Y.Control,
                Impact = X.Impact += Y.Impact,
                Spin = X.Spin += Y.Spin,
                Curve = X.Curve += Y.Curve
            };
            return result;
        }
        public int GetClubTotal(TClubStatus ClubPlayerData, bool IsRankUp)
        {
            int result =
                (
                Power +
                Control +
                Impact +
                Spin +
                Curve +
                ClubPlayerData.Power +
                ClubPlayerData.Control +
                ClubPlayerData.Impact +
                ClubPlayerData.Spin +
                ClubPlayerData.Curve
                );
            if (IsRankUp)
            {
                result = result += 1;
            }
            else
            {
                result = result -= 7;
            }

            return result;
        }
        /// <summary>
        /// retorna novo status do club
        /// </summary>
        /// <param name="power"></param>
        /// <param name="control"></param>
        /// <param name="impact"></param>
        /// <param name="spin"></param>
        /// <param name="curve"></param>
        /// <returns></returns>
        public TClubStatus GetNewClubStatus(int power, int control, int impact, int spin, int curve)
        {
            int OldPower = Power;
            int OldControl = Control;
            int OldImpact = Impact;
            int OldSpin = Spin;
            int OldCurve = Curve;
            Power = Convert.ToUInt16(OldPower + power);
            Control = Convert.ToUInt16(OldControl + control);
            Impact = Convert.ToUInt16(OldImpact + impact);
            Spin = Convert.ToUInt16(OldSpin + spin);
            Curve = Convert.ToUInt16(OldCurve + curve);
            return this;
        }
    }
  

    #region FlagsIFFEnum
    public enum IFF_REGION : short
    {
        Default = -1,
        Usa = 0,
        Japan = 1,
        Korea = 2,
        Thaiwan = 3
    }

    public enum PackCard
    {
        Pack1,
        Pack2,
        Pack3,
        Pack4,
        Rare,
        All
    }

    public enum CardTypeEnum : uint
    {
        Normal = 0,
        Caddie = 0x40,
        NCP = 0x41,
        Special = 0x80,
        SpecialRare = 0x0C
    }

    public enum ItemTypeEnum : uint
    {
        Active = 0,
        All = 1,
        Passive = 4,
    }


    public enum CaddieTypeItem
    {
        Quma = 16,

    }

    public enum PartTypeEnum
    {
        Bottom = 2,
        Top = 3,
        GlovesOrAcessory = 4,
        SelfDesign = 5,
        Shoes = 7,
        HatOrHair = 16,

    }

    public enum ShopFlag : byte
    {
        Unknown1 = 128,
        Unknown2 = 64,
        Pangs = 32,
        Points = 33,
        Unknown3 = 34,
        Unknown4 = 16,
        Unknown5 = 8,
        Unknown7 = 96,
        Unknown6 = 97,
        Coupon = 4,
        NonGiftable = 2,
        Cookies = 3,
        Giftable = 1,
        None = 0
    }
    public enum MoneyFlag : byte
    {
        Unknown1 = 128,
        BannerSpecial = 64,
        BannerHot = 32,
        BannerNew = 16,
        Unknown2 = 8,
        DisplayOnly = 4,
        Type = 2,
        Active = 1,
        None = 0
    }

    public enum HairColorEnum : ushort
    {
        None = 0,
        Black = 1,
        Blue = 2,
        Yellow = 3,
        Red = 4,
        Green = 5,
    }
    public enum CardEffectFlag : ushort
    {
        None = 0,
        Experience = 1,
        PercentPang = 2,
        PercentExperience = 3,
        Pang = 4,
        Power = 5,
        Control = 6,
        Accuracy = 7,
        Spin = 8,
        Curve = 9,
        StartingGauge = 10,
        Inventory = 11
    }
    /// <summary>
    /// PART CHARACTER TYPE 
    /// </summary>
    public enum CharacterTypeEnum : int
    {
        UNK = -2,
        NURI = 0,
        HANA = 1,
        AZER = 2,
        CESILLIA = 3,
        MAX = 4,
        KOOH = 5,
        ARIN = 6,
        KAZ = 7,
        LUCIA = 8,
        NELL = 9,
        SPIKA = 10,
        NURI_R = 11,
        HANA_R = 12,
        UNKNOWN = 13,
        CESILLIA_R = 14
    }

    public enum CadieBoxEnum : int
    {
        MascotType = -1,
        PartOrSomethingElse = -2,
        NURI = 0,
        HANA = 1,
        AZER = 2,
        CESILLIA = 3,
        MAX = 4,
        KOOH = 5,
        ARIN = 6,
        KAZ = 7,
        LUCIA = 8,
        NELL = 9,
        SPIKA = 10,
        NURI_R = 11,
        HANA_R = 12,
        UNKNOWN = 13,
        CESILLIA_R = 14
    }
    public enum CharacterTypeIdEnum
    {
        NURI = 67108864,
        HANA = 67108865,
        AZER = 67108866,
        CESILLIA = 67108867,
        MAX = 67108868,
        KOOH = 67108869,
        ARIN = 67108870,
        KAZ = 67108871,
        LUCIA = 67108872,
        NELL = 67108873,
        SPIKA = 67108874,
        NURI_R = 67108875,
        HANA_R = 67108876,
        CESILLIA_R = 67108878
    }

    public enum ItemLevelEnum : byte
    {
        ROOKIE_F = 0x00,
        ROOKIE_E = 0x01,
        ROOKIE_D = 0x02,
        ROOKIE_C = 0x03,
        ROOKIE_B = 0x04,
        ROOKIE_A = 0x05,
        BEGINNER_E = 0x06,
        BEGINNER_D = 0x07,
        BEGINNER_C = 0x08,
        BEGINNER_B = 0x09,
        BEGINNER_A = 0x0A,
        JUNIOR_E = 0x0B,
        JUNIOR_D = 0x0C,
        JUNIOR_C = 0x0D,
        JUNIOR_B = 0x0E,
        JUNIOR_A = 0x0F,
        SENIOR_E = 0x10,
        SENIOR_D = 0x11,
        SENIOR_C = 0x12,
        SENIOR_B = 0x13,
        SENIOR_A = 0x14,
        AMATEUR_E = 0x15,
        AMATEUR_D = 0x16,
        AMATEUR_C = 0x17,
        AMATEUR_B = 0x18,
        AMATEUR_A = 0x19,
        SEMI_PRO_E = 0x1A,
        SEMI_PRO_D = 0x1B,
        SEMI_PRO_C = 0x1C,
        SEMI_PRO_B = 0x1D,
        SEMI_PRO_A = 0x1E,
        PRO_E = 0x1F,
        PRO_D = 0x20,
        PRO_C = 0x21,
        PRO_B = 0x22,
        PRO_A = 0x23,
        NATIONAL_PRO_E = 0x24,
        NATIONAL_PRO_D = 0x25,
        NATIONAL_PRO_C = 0x26,
        NATIONAL_PRO_B = 0x27,
        NATIONAL_PRO_A = 0x28,
        WORLD_PRO_E = 0x29,
        WORLD_PRO_D = 0x2A,
        WORLD_PRO_C = 0x2B,
        WORLD_PRO_B = 0x2C,
        WORLD_PRO_A = 0x2D,
        MASTER_E = 0x2E,
        MASTER_D = 0x2F,
        MASTER_C = 0x30,
        MASTER_B = 0x31,
        MASTER_A = 0x32,
        TOP_MASTER_E = 0x33,
        TOP_MASTER_D = 0x34,
        TOP_MASTER_C = 0x35,
        TOP_MASTER_B = 0x36,
        TOP_MASTER_A = 0x37,
        WORLD_MASTER_E = 0x38,
        WORLD_MASTER_D = 0x39,
        WORLD_MASTER_C = 0x3A,
        WORLD_MASTER_B = 0x3B,
        WORLD_MASTER_A = 0x3C,
        LEGEND_E = 0x3D,
        LEGEND_D = 0x3E,
        LEGEND_C = 0x3F,
        LEGEND_B = 0x40,
        LEGEND_A = 0x41,
        INFINITY_LEGEND_E = 0x42,
        INFINITY_LEGEND_D = 0x43,
        INFINITY_LEGEND_C = 0x44,
        INFINITY_LEGEND_B = 0x45,
        INFINITY_LEGEND_A = 0x46
    }
    #endregion

    #region Outros Enums   
   
    public enum TITEMGROUP
    {
        ITEM_TYPE_CHARACTER = 01,
        ITEM_TYPE_PART = 0x2,
        ITEM_TYPE_CLUB = 0x4,
        ITEM_TYPE_BALL = 0x5,
        ITEM_TYPE_USE = 0x6,
        ITEM_TYPE_CADDIE = 0x7,
        ITEM_TYPE_CADDIE_ITEM = 0x8,
        ITEM_TYPE_SETITEM = 9,
        ITEM_TYPE_MATCH = 11,
        ITEM_TYPE_SKIN = 14,
        ITEM_TYPE_HAIR_STYLE = 15,
        ITEM_TYPE_MASCOT = 16,
        ITEM_TYPE_FURNITURE = 18,
        ITEM_TYPE_ACHIEVEMENT = 19,
        ITEM_TYPE_ACHIEVEMENT_COUNTER_ITEM = 27,
        ITEM_TYPE_AUX = 28,
        ITEM_TYPE_ACHIEVEMENT_QUEST_STUFFS = 29,
        ITEM_TYPE_ACHIEVEMENT_QUEST_ITEM = 30,
        ITEM_TYPE_CARD = 31,        
    }
   
    
    public enum ClubTypeEnum : uint
    {
        TYPE_BALANCE = 0,
        TYPE_POWER = 1,
        TYPE_CONTROL = 2,
        TYPE_SPIN = 3,
        TYPE_SPECIAL = 4
    }
    
    #endregion

  
}
