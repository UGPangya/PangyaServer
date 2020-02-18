namespace PangyaFileCore.IffManager
{
    public class Character : IFFFile
    {

        internal override string FileName { get { return "Character.iff"; } }

        
        public override IFFCommon Header { get; set; } = new IFFCommon();

        public string Model{ get; set; }
        public string Texture1{ get; set; }
        public string Texture2{ get; set; }
        public string Texture3{ get; set; }
        public ushort Power{ get; set; }
        public ushort Control{ get; set; }
        public ushort Accuracy{ get; set; }
        public ushort Spin{ get; set; }
        public ushort Curve{ get; set; }
        public byte PowerSlot{ get; set; }
        public byte ControlSlot{ get; set; }
        public byte AccuracySlot{ get; set; }
        public byte SpinSlot{ get; set; }
        public byte CurveSlot{ get; set; }
        public byte Unknown1{ get; set; }
        public float RankS{ get; set; }
        public byte RankSPowerSlot{ get; set; }
        public byte RankSControlSlot{ get; set; }
        public byte RankSAccuracySlot{ get; set; }
        public byte RankSSpinSlot{ get; set; }
        public byte RankSCurveSlot{ get; set; }
        public string AdditionalTexture{ get; set; }
      
        internal override IFFFile Get()
        {
            var item = new Character();
            
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
            item.Model = GetString(40);
            item.Texture1 = GetString(40);
            item.Texture2 = GetString(40);
            item.Texture3 = GetString(40); // 40 Byte long
            item.Power = Reader().ReadUInt16();
            item.Control = Reader().ReadUInt16();
            item.Accuracy = Reader().ReadUInt16();
            item.Spin = Reader().ReadUInt16();
            item.Curve = Reader().ReadUInt16();
            item.PowerSlot = Reader().ReadByte();
            item.ControlSlot = Reader().ReadByte();
            item.AccuracySlot = Reader().ReadByte();
            item.SpinSlot = Reader().ReadByte();
            item.CurveSlot = Reader().ReadByte();
            item.Unknown1 = Reader().ReadByte();
            item.RankS = Reader().ReadSingle();
            item.RankSPowerSlot = Reader().ReadByte();
            item.RankSControlSlot = Reader().ReadByte();
            item.RankSAccuracySlot = Reader().ReadByte();
            item.RankSSpinSlot = Reader().ReadByte();
            item.RankSCurveSlot = Reader().ReadByte();
            item.AdditionalTexture = GetString(43); // 40 Byte long
            return item;
        }
    }
}
