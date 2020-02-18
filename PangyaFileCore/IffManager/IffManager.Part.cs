using PangyaFileCore.GameTools;

namespace PangyaFileCore.IffManager
{
    public class Part : IFFFile
    {
        public override IFFCommon Header { get; set; } = new IFFCommon();

        internal override string FileName { get { return "Part.iff"; } }

        public PartTypeEnum ItemGroup { get; set; }

        public CharacterTypeEnum CharID { get; set; }

        public string Model { get; set; }
        public uint UCCType { get; set; }

        public uint SlotCount { get; set; }
        public uint Unknown { get; set; }
        public string Texture1 { get; set; }
        public string Texture2 { get; set; }
        public string Texture3 { get; set; }

        public string Texture4 { get; set; }
        public string Texture5 { get; set; }
        public string Texture6 { get; set; }


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

        public string Blank { get; set; }

        public uint Unknown2 { get; set; }
        public uint Unknown3 { get; set; }
        public uint RentPang { get; set; }
        public uint Unknown4 { get; set; }
        internal override IFFFile Get()
        {
            var item = new Part();

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
            item.Header.TPItem = Reader().ReadUInt32();//ok
            item.Header.TPCount = Reader().ReadUInt32();//ok
            item.Header.Mileage = Reader().ReadUInt16(); //ok
            item.Header.BonusProb = Reader().ReadUInt16();//ok
            item.Header.Mileage2 = Reader().ReadUInt16();//0ok
            item.Header.Mileage3 = Reader().ReadUInt16();//0ok
            item.Header.TikiPointShop = Reader().ReadUInt32();//ok
            item.Header.TikiPang = Reader().ReadUInt32();//ok

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
            item.ItemGroup = (PartTypeEnum)Tools.GetItemGroup(item.Header.ID);
            item.CharID = (CharacterTypeEnum)(item.Header.ID & 0xff);
            item.Model = GetString(40); // 40 Byte long
            item.UCCType = Reader().ReadUInt32();
            item.SlotCount = Reader().ReadUInt32();
            item.Unknown = Reader().ReadUInt32();
            item.Texture1 = GetString(40); // 40 Byte long
            item.Texture2 = GetString(40);// 40 Byte long
            item.Texture3 = GetString(40);// 40 Byte long
            item.Texture4 = GetString(40);// 40 Byte long
            item.Texture5 = GetString(40);// 40 Byte long
            item.Texture6 = GetString(40);// 40 Byte long
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
            item.Blank = GetString(48);
            item.Unknown2 = Reader().ReadUInt32();
            item.Unknown3 = Reader().ReadUInt32();
            item.RentPang = Reader().ReadUInt32();
            item.Unknown4 = Reader().ReadUInt32();
            return item;
        }
    }
}
