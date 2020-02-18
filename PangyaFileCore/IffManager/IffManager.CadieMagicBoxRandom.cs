namespace PangyaFileCore.IffManager
{
    public class CaddieMagicBoxRandom : IFFFile
    {
        public uint Amount { get; set; }

        public uint Rate { get; set; }
        public override IFFCommon Header { get; set; } = new IFFCommon();

        internal override string FileName { get { return "CadieMagicBoxRandom.iff"; } }


        internal override IFFFile Get()
        {
            var item = new CaddieMagicBoxRandom();
            item.Header.Active = Reader().ReadUInt32();
            item.Header.ID = Reader().ReadUInt32();
            item.Amount = Reader().ReadUInt32();
            item.Rate = Reader().ReadUInt32();
            return item;
        }
    }
}
