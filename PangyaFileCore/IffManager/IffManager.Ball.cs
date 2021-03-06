namespace PangyaFileCore.IffManager
{
    public class Ball : IFFFile
    {
        public override IFFCommon Header { get; set; } = new IFFCommon();
        
        public uint Unknown0{ get; set; }
        //32
        public string Model { get; set; }

        public uint Unknown2{ get; set; }
        public uint Unknown3{ get; set; }


        public string BallSequence1{ get; set; }

        public string BallSequence2{ get; set; }

        public string BallSequence3{ get; set; }

        public string BallSequence4{ get; set; }

        public string BallSequence5{ get; set; }

        public string BallSequence6{ get; set; }

        public string BallSequence7 { get; set; }



        public string BallFx1 { get; set; }

        public string BallFx2 { get; set; }

        public string BallFx3 { get; set; }

        public string BallFx4 { get; set; }

        public string BallFx5 { get; set; }

        public string BallFx6 { get; set; }

        public string BallFx7 { get; set; }
        public ushort Unknown4{ get; set; }
        public uint PangBonus{ get; set; }

        internal override string FileName { get { return "Ball.iff"; } }

        public ushort Power { get; set; }
        public ushort Control { get; set; }
        public ushort Accuracy { get; set; }
        public ushort Spin { get; set; }
        public ushort Curve { get; set; }

        internal override IFFFile Get()
        {
            var item = new Ball();

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
            item.Unknown0 = Reader().ReadUInt32();
            item.Model = GetString(40);
            item.Unknown2 = Reader().ReadUInt32();
            item.Unknown3 = Reader().ReadUInt32();
            item.BallSequence1 = GetString(40);
            item.BallSequence2 = GetString(40);
            item.BallSequence3 = GetString(40);
            item.BallSequence5 = GetString(40);
            item.BallSequence5 = GetString(40);
            item.BallSequence6 = GetString(40);
            item.BallSequence7 = GetString(40);
            item.BallFx1 = GetString(40);
            item.BallFx2 = GetString(40);
            item.BallFx3 = GetString(40);
            item.BallFx5 = GetString(40);
            item.BallFx5 = GetString(40);
            item.BallFx6 = GetString(40);
            item.BallFx7 = GetString(40);
            item.Power = Reader().ReadUInt16();
            item.Control = Reader().ReadUInt16();
            item.Accuracy = Reader().ReadUInt16();
            item.Spin = Reader().ReadUInt16();
            item.Curve = Reader().ReadUInt16();
            item.Unknown4 = Reader().ReadUInt16();
            return item;
        }


    }
}
