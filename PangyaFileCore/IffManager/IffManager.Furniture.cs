namespace PangyaFileCore.IffManager
{
    public class Furniture : IFFFile
    {
        public override IFFCommon Header { get; set; } = new IFFCommon();

        internal override string FileName { get { return "Furniture.iff"; } }

        public string Model { get; set; }
        public uint Unknown { get; set; }

        public ushort Unknown2 { get; set; }
        public ushort Unknown3 { get; set; }
        public uint Unknown4 { get; set; }

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float R { get; set; }

        public string Texture1 { get; set; }
        public string Texture2 { get; set; }
        public string Texture3 { get; set; }

        public string Texture4 { get; set; }
        public string Texture5 { get; set; }
        public string Texture6 { get; set; }

        public string Blank { get; set; }
        internal override IFFFile Get()
        {
            var item = new Furniture();
            #region Header IFF
            item.Header.Active = Reader().ReadUInt32();
            item.Header.ID = Reader().ReadUInt32();
            item.Header.Name = GetString(40); // 40 Byte long
            item.Header.Level = (ItemLevelEnum)Reader().ReadByte();
            item.Header.Icon = GetString(40);
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
            #endregion
            item.Model = GetString(40);
            item.Unknown = Reader().ReadUInt32();
            item.Unknown2 = Reader().ReadUInt16();
            item.Unknown3 = Reader().ReadUInt16();
            item.Unknown4 = Reader().ReadUInt32();
            item.X = Reader().ReadSingle();
            item.Y = Reader().ReadSingle();
            item.Z = Reader().ReadSingle();
            item.R = Reader().ReadSingle();
            item.Texture1 = GetString(40); // 40 Byte long
            item.Texture2 = GetString(40);// 40 Byte long
            item.Texture3 = GetString(40);// 40 Byte long
            item.Texture4 = GetString(40);// 40 Byte long
            item.Texture5 = GetString(40);// 40 Byte long
            item.Texture6 = GetString(40); // 40 Byte long
            item.Blank = GetString(12);
            return item;
        }
    }
}
