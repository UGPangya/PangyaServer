namespace PangyaFileCore.IffManager
{
    public class CounterItem : IFFFile
    {
        public override IFFCommon Header { get; set; } = new IFFCommon();
        internal override string FileName { get { return "CounterItem.iff"; } }
        internal override IFFFile Get()
        {
            var item = new CounterItem();
            item.Header.Active = Reader().ReadUInt32();
            item.Header.ID = Reader().ReadUInt32();
            item.Header.Name = GetString(240);
            if (item.Header.ID == 1816133689)
            {
            }
            return item;
        }
    }
}
