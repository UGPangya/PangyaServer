namespace PangyaFileCore.IffManager
{
    public class CutinInformation : IFFFile
    {
        public override IFFCommon Header { get; set; } = new IFFCommon();
        public uint Num1 { get; set; }
        public uint Num2 { get; set; }

        public uint NumImg1 { get; set; }

        public string IMG1 { get; set; }

        public uint NumImg2 { get; set; }

        public string IMG2 { get; set; }
       
        public uint NumImg3 { get; set; }

        public string IMG3 { get; set; }
        public uint Num3 { get; set; }
        public uint Num4 { get; set; }


        internal override string FileName { get { return "CutinInfomation.iff"; } }


        internal override IFFFile Get()
        {
            var item = new CutinInformation();

            item.Header.Active = Reader().ReadUInt32();
            item.Header.ID = Reader().ReadUInt32();
            Skip(8);
            item.Num1 = Reader().ReadUInt32();
            item.Num2 = Reader().ReadUInt32();             
            item.NumImg1 = Reader().ReadUInt32();
            item.IMG1 = GetString(40);
            item.NumImg2 = Reader().ReadUInt32();
            item.IMG2 = GetString(40);
            item.NumImg3 = Reader().ReadUInt32();
            item.IMG3 = GetString(40);
            item.Num3 = Reader().ReadUInt32();
            Skip(44);
            item.Num4 = Reader().ReadUInt32();
            return item;
        }
    }
}
