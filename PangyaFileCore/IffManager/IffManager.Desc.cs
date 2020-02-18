namespace PangyaFileCore.IffManager
{
    public class Desc : IFFFile
    {
        public override IFFCommon Header { get; set; } = new IFFCommon();

        public string TextDescription { get; set; }
        internal override string FileName { get { return "Desc.iff"; } }
        internal override IFFFile Get()
        {
            var item = new Desc();

            item.Header.ID = Reader().ReadUInt32();
            item.TextDescription = GetString(512);
            return item;
        }
    }
}
