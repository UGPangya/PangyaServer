namespace PangyaFileCore.IffManager
{
    public class AuxPart : IFFFile
    {
        internal override string FileName { get { return "AuxPart.iff"; } }

        public override IFFCommon Header { get; set; } = new IFFCommon();
        public uint Amount{ get; set; }
        public uint Unknown1{ get; set; }
        public  ushort Unknown2{ get; set; }
        public uint Unknown3{ get; set; }

        public byte Power{ get; set; }
        public byte Control{ get; set; }
        public byte Accuracy{ get; set; }
        public byte Spin{ get; set; }
        public byte Curve{ get; set; }
        public byte PowerSlot{ get; set; }
        public byte ControlSlot{ get; set; }
        public byte AccuracySlot{ get; set; }
        public byte SpinSlot{ get; set; }
        public byte CurveSlot{ get; set; }
        public ushort ClubDistance{ get; set; }
        public ushort Luck{ get; set; }
        public ushort PowerGauge{ get; set; }
        public ushort PangBonus{ get; set; }
        public ushort ExperiencePercentage{ get; set; }
      

        internal override IFFFile Get()
        {
            var item = new AuxPart();
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
            item.Amount = Reader().ReadByte();
            item.Unknown1 = Reader().ReadUInt32();
            item.Unknown2 = Reader().ReadUInt16();            
            item.Power = Reader().ReadByte();
            item.Control = Reader().ReadByte();
            item.Accuracy = Reader().ReadByte();
            item.Spin = Reader().ReadByte();
            item.Curve = Reader().ReadByte();
            item.PowerSlot = Reader().ReadByte();
            item.ControlSlot = Reader().ReadByte();
            item.AccuracySlot = Reader().ReadByte();
            item.SpinSlot = Reader().ReadByte();
            item.CurveSlot = Reader().ReadByte();
            item.ClubDistance = Reader().ReadUInt16();
            item.Luck = Reader().ReadUInt16();
            item.PowerGauge = Reader().ReadUInt16();
            item.PangBonus = Reader().ReadUInt16();
            item.ExperiencePercentage = Reader().ReadUInt16();
            item.Unknown3 = Reader().ReadUInt32();
            
            return item;
        }
    }
}
