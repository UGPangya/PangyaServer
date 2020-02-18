using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PangyaFileCore.IffManager
{
    public class Achievement : IFFFile
    {
        public override IFFCommon Header { get; set; } = new IFFCommon();
        internal override string FileName { get { return "Achievement.iff"; } }
        public uint Index { get; set; }
        public uint AchievementType { get; set; }

        public string[] Quest_Name { get; set; } = new string[10];

        public UInt16 UNK { get; set; }
        public uint[] QuestTypeID { get; set; }
       
        public uint UNK2 { get; set; }
        internal override IFFFile Get()
        {
            var item = new Achievement();
            item.Header.Active = Reader().ReadUInt32();
            item.Header.ID = Reader().ReadUInt32();
            item.Header.Name = GetString(81); // 40 Byte long
            item.Header.Flag1 = Reader().ReadByte();
            item.Header.Flag2 = Reader().ReadByte();
            item.Header.Flag3 = Reader().ReadByte();
            item.Header.Price = Reader().ReadUInt32();
            item.Header.DiscountPrice = Reader().ReadUInt32();
            item.Header.UsedPrice = Reader().ReadUInt32();
            item.Header.ShopFlag = (ShopFlag)Reader().ReadByte();
            item.Header.MoneyFlag = (MoneyFlag)Reader().ReadByte();
            item.Header.TimeFlag = Reader().ReadByte();
            item.Header.TimeByte = Reader().ReadByte();
            item.Header.TPItem = Reader().ReadUInt32();
            item.Header.TPCount = Reader().ReadUInt32();
            item.Header.Mileage = Reader().ReadUInt16();
            item.Header.BonusProb = Reader().ReadUInt16();
            item.Header.Mileage2 = Reader().ReadUInt16();
            item.Header.Mileage3 = Reader().ReadUInt16();
            item.Header.TikiPointShop = Reader().ReadUInt32();
            item.Header.TikiPang = Reader().ReadUInt32();
            item.Header.ActiveData = Reader().ReadUInt32();
            item.Header.StartTime.Year = Reader().ReadUInt16();
            item.Header.StartTime.Month = Reader().ReadUInt16();
            item.Header.StartTime.DayOfWeek = Reader().ReadUInt16();
            item.Header.StartTime.Day = Reader().ReadUInt16();
            item.Header.StartTime.Hour = Reader().ReadUInt16();
            item.Header.StartTime.Minute = Reader().ReadUInt16();
            item.Header.StartTime.Second = Reader().ReadUInt16();
            item.Header.StartTime.MilliSecond = Reader().ReadUInt16();
            item.Header.EndTime.Year = Reader().ReadUInt16();
            item.Header.EndTime.Month = Reader().ReadUInt16();
            item.Header.EndTime.DayOfWeek = Reader().ReadUInt16();
            item.Header.EndTime.Day = Reader().ReadUInt16();
            item.Header.EndTime.Hour = Reader().ReadUInt16();
            item.Header.EndTime.Minute = Reader().ReadUInt16();
            item.Header.EndTime.Second = Reader().ReadUInt16();
            item.Header.EndTime.MilliSecond = Reader().ReadUInt16();
            item.Index = Reader().ReadUInt32();
            item.AchievementType = Reader().ReadUInt32();
            item.Quest_Name[0] = GetString(129);
            item.Quest_Name[1] = GetString(129);
            item.Quest_Name[2] = GetString(129);
            item.Quest_Name[3] = GetString(129);
            item.Quest_Name[4] = GetString(129);
            item.Quest_Name[5] = GetString(129);
            item.Quest_Name[6] = GetString(129);
            item.Quest_Name[7] = GetString(129);
            item.Quest_Name[8] = GetString(129);
            item.Quest_Name[9] = GetString(129);
            item.UNK = Reader().ReadUInt16();
            item.QuestTypeID = Read(10).ToArray();
            item.UNK2 = Reader().ReadUInt32();
            if (item.Header.ID == 1816133689)
            {
            }
            return item;
        }
    }
}
