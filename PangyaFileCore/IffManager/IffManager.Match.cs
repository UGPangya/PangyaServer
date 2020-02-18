namespace PangyaFileCore.IffManager
{
    public class Match : IFFFile
    {

        public override IFFCommon Header { get; set; } = new IFFCommon();


        internal override string FileName { get { return "Match.iff"; } }
        public string Blank { get; set; }
        public string TrophyTexture1 { get; set; }
        public string TrophyTexture2 { get; set; }
        public string TrophyTexture3 { get; set; }
        public string Blank2 { get; set; }
        internal override IFFFile Get()
        {
            var item = new Match();

            item.Header.Active = Reader().ReadUInt32();
            item.Header.ID = Reader().ReadUInt32();
            item.Header.Name = GetString(42);
            item.Blank = GetString(38);
            item.Header.Level = (ItemLevelEnum)Reader().ReadByte();
            item.TrophyTexture1 = GetString(40);
            item.TrophyTexture2 = GetString(40);
            item.TrophyTexture3 = GetString(40);
            item.Blank2 = GetString(123);
            return item;
        }
    }
}
