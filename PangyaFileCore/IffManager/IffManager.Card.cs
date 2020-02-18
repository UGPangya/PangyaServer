namespace PangyaFileCore.IffManager
{
    public class Card : IFFFile
    {
        internal override string FileName { get { return "Card.iff"; } }
        public override IFFCommon Header { get; set; } = new IFFCommon();
        public string Texture { get; set; }
        public byte Unknown { get; private set; }
        public byte Rarity{ get; set; }
        public ushort PowerSlot{ get; set; }
        public ushort ControlSlot{ get; set; }
        public ushort AccuracySlot{ get; set; }
        public ushort SpinSlot{ get; set; }
        public ushort CurveSlot{ get; set; }
        public CardEffectFlag Effect { get; set; }
        public ushort EffectValue{ get; set; }

        public string AdditionalTexture1{ get; set; }

        public string AdditionalTexture2{ get; set; }

        public string AdditionalTexture3{ get; set; }
        public ushort EffectTime{ get; set; }
        public ushort Volume{ get; set; }
        public uint CardID{ get; set; }
        public uint CardType { get; set; }
        public uint Unknown2 { get; set; }
      
        internal override IFFFile Get()
        {

            var item = new Card();

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
            item.Rarity = Reader().ReadByte();
            item.Texture = GetString(40);
            item.Unknown = Reader().ReadByte();
            item.PowerSlot = Reader().ReadUInt16();
            item.ControlSlot = Reader().ReadUInt16();
            item.AccuracySlot = Reader().ReadUInt16();
            item.SpinSlot = Reader().ReadUInt16();
            item.CurveSlot = Reader().ReadUInt16();
            item.Effect = (CardEffectFlag)Reader().ReadUInt16();
            item.EffectValue = Reader().ReadUInt16();
            item.AdditionalTexture1 = GetString(40);
            item.AdditionalTexture2 = GetString(40);
            item.AdditionalTexture3 = GetString(40);
            item.EffectTime = Reader().ReadUInt16();
            item.Volume = Reader().ReadUInt16();
            item.CardID = Reader().ReadUInt32();
            item.CardType = Reader().ReadUInt32();
            item.Unknown2 = Reader().ReadUInt32();
           
            return item;
        }
    }
}
