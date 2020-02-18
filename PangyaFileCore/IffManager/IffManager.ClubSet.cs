namespace PangyaFileCore.IffManager
{
    public class ClubSet : IFFFile
    {
        internal override string FileName { get { return "ClubSet.iff"; } }
        public override IFFCommon Header { get; set; } = new IFFCommon();
        public uint WoodID { get; set; }
        public uint IronID { get; set; }
        public uint WedgeID { get; set; }
        public uint PutterID { get; set; }
        public ushort Power { get; set; }
        public ushort Control { get; set; }
        public ushort Accuracy { get; set; }
        public ushort Spin { get; set; }
        public ushort Curve { get; set; }
        public ushort PowerSlot { get; set; }
        public ushort ControlSlot { get; set; }
        public ushort AccuracySlot { get; set; }
        public ushort SpinSlot { get; set; }
        public ushort CurveSlot { get; set; }
        public ClubTypeEnum ClubType { get; set; }
        public uint ClubSPoint { get; set; }
        public uint RecoveryLimit { get; set; }
        public uint RateWorkshop { get; set; }
        public uint Unknown { get; set; }
        public uint ClubTrans { get; set; }
        public ushort ClubFlag { get; set; }
        public uint Unknown2 { get; set; }
        public uint Unknown3 { get; set; }
        internal override IFFFile Get()
        {

            var item = new ClubSet();
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
            item.WoodID = Reader().ReadUInt32();
            item.IronID = Reader().ReadUInt32();
            item.WedgeID = Reader().ReadUInt32();
            item.PutterID = Reader().ReadUInt32();
            item.Power = Reader().ReadUInt16();//OK
            item.Control = Reader().ReadUInt16();//OK
            item.Accuracy = Reader().ReadUInt16();//OK
            item.Spin = Reader().ReadUInt16();//ok
            item.Curve = Reader().ReadUInt16();//ok
            item.PowerSlot = Reader().ReadUInt16();//ok
            item.ControlSlot = Reader().ReadUInt16();
            item.AccuracySlot = Reader().ReadUInt16();
            item.SpinSlot = Reader().ReadUInt16();
            item.CurveSlot = Reader().ReadUInt16();
            item.ClubType = (ClubTypeEnum)Reader().ReadUInt32();
            item.ClubSPoint = Reader().ReadUInt32();
            item.RecoveryLimit = Reader().ReadUInt32();
            item.RateWorkshop = Reader().ReadUInt32();
            item.Unknown = Reader().ReadUInt32();
            item.ClubTrans =  Reader().ReadUInt16();
            item.ClubFlag = Reader().ReadUInt16();
            item.Unknown2 = Reader().ReadUInt32();
            item.Unknown3 = Reader().ReadUInt32();
            return item;
        }
    }
}
