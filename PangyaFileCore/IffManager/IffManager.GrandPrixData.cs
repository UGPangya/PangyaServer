namespace PangyaFileCore.IffManager
{
    public class GrandPrixData : IFFFile
    {
        public override IFFCommon Header { get; set; } = new IFFCommon();

        internal override string FileName { get { return "GrandPrixData.iff"; } }
        public uint TypeID { get; set; } //referencia de outro IFF do GP: RankReward e conditionEquip
        public uint TypeGP { get; set; }
        public ushort TimeHole { get; set; }
        public uint TicketTypeID { get; set; }
        public uint AmountTicket { get; set; }
        public string RoomTexture { get; set; }
        public byte Un { get; set; }
        public byte Natural { get; set; }
        public byte ShortGame { get; set; }
        public byte HoleX2 { get; set; }
        public uint RuleTypeID { get; set; }
        public uint Course { get; set; }
        public uint Mode { get; set; }
        public byte AmountHole { get; set; }
        public byte LevelMin { get; set; }
        public byte LevelMax { get; set; }
        public byte Un2 { get; set; }
        public uint Condition1 { get; set; }
        public uint Condition2 { get; set; }
        public uint ScoreBotMax { get; set; }
        public uint ScoreBotMed { get; set; }
        public uint ScoreBotMin { get; set; }
        public uint Difficulty { get; set; }
        public uint Pangs { get; set; }
        public uint RewardTypeID { get; set; }
        public uint RewardTypeID2 { get; set; }
        public uint RewardTypeID3 { get; set; }
        public uint RewardTypeID4 { get; set; }
        public uint RewardTypeID5 { get; set; }

        public uint RewardAmount { get; set; }
        public uint RewardAmount2 { get; set; }
        public uint RewardAmount3 { get; set; }
        public uint RewardAmount4 { get; set; }
        public uint RewardAmount5 { get; set; }

        public byte[] Un3 { get; set; }//12
        public byte[] DateActive { get; set; }
        public ushort DateOpenHour { get; set; }
        public ushort DateOpenMin { get; set; }
        public byte[] DateClose { get; set; }
        public ushort DateStartHour { get; set; }
        public ushort DateStartMin { get; set; }
        public byte[] DateStartRest{ get; set; }
        public ushort DatetimeEndHour { get; set; }
        public ushort DatetimeEndMin { get; set; }
        public byte[] DatetimeEndClose { get; set; }
        public uint GPTypeIDLocker { get; set; }
        public uint GPLocker { get; set; }
        public string TextDescription { get; set; }
        internal override IFFFile Get()
        {
            var item = new GrandPrixData();

            item.Header.Active = Reader().ReadUInt32();
            item.Header.ID = Reader().ReadUInt32();
            item.TypeID = Reader().ReadUInt32();
            item.TypeGP = Reader().ReadUInt32();
            item.TimeHole = Reader().ReadUInt16();
            item.Header.Name = GetString(66);
            item.TicketTypeID = Reader().ReadUInt32();
            item.AmountTicket = Reader().ReadUInt32();
            item.RoomTexture = GetString(40);
            item.Un = Reader().ReadByte();
            item.Natural = Reader().ReadByte();
            item.ShortGame = Reader().ReadByte();
            item.HoleX2 = Reader().ReadByte();
            item.RuleTypeID = Reader().ReadUInt32();
            item.Course = Reader().ReadUInt32();
            item.Mode = Reader().ReadUInt32();
            item.AmountHole = Reader().ReadByte();
            item.LevelMin = Reader().ReadByte();
            item.LevelMax = Reader().ReadByte();
            item.Un2 = Reader().ReadByte();
            item.Condition1 = Reader().ReadUInt32();
            item.Condition2 = Reader().ReadUInt32();
            item.ScoreBotMax = Reader().ReadUInt32();
            item.ScoreBotMed = Reader().ReadUInt32();
            item.ScoreBotMin = Reader().ReadUInt32();
            item.Difficulty = Reader().ReadUInt32();
            item.Pangs = Reader().ReadUInt32();
            item.RewardTypeID = Reader().ReadUInt32();
            item.RewardTypeID2 = Reader().ReadUInt32();
            item.RewardTypeID3 = Reader().ReadUInt32();
            item.RewardTypeID4 = Reader().ReadUInt32();
            item.RewardTypeID5 = Reader().ReadUInt32();
            item.RewardAmount = Reader().ReadUInt32();
            item.RewardAmount2 = Reader().ReadUInt32();
            item.RewardAmount3 = Reader().ReadUInt32();
            item.RewardAmount4 = Reader().ReadUInt32();
            item.RewardAmount5 = Reader().ReadUInt32();
            item.Un3 = Reader().ReadBytes(12);
            item.DateActive = Reader().ReadBytes(16);
            item.DateOpenHour = Reader().ReadUInt16();
            item.DateOpenMin = Reader().ReadUInt16();
            item.DateClose = Reader().ReadBytes(12);
            item.DateStartHour = Reader().ReadUInt16();
            item.DateStartMin = Reader().ReadUInt16();
            item.DateStartRest = Reader().ReadBytes(12);
            item.DatetimeEndHour = Reader().ReadUInt16();
            item.DatetimeEndMin = Reader().ReadUInt16();
            item.DatetimeEndClose = Reader().ReadBytes(8);
            item.GPTypeIDLocker = Reader().ReadUInt32();
            item.GPLocker = Reader().ReadUInt32();
            item.TextDescription = GetString(516);
            return item;
        }
    }
}
