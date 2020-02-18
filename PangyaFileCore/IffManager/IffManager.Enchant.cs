namespace PangyaFileCore.IffManager
{
    public class Enchant : IFFFile
    {

        public override IFFCommon Header { get; set; } = new IFFCommon();

        internal override string FileName { get { return "Enchant.iff"; } }

        public long Value { get; set; }
        internal override IFFFile Get()
        {
            var item = new Enchant();

            item.Header.Active = Reader().ReadUInt32();
            item.Header.ID = Reader().ReadUInt32();
            Value = Reader().ReadInt64();
            return item; 
        }
    }
}
