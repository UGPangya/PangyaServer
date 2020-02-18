namespace PangyaFileCore.IffManager
{
    public class ErrorCodeInfo : IFFFile
    {
        public override IFFCommon Header { get; set; } = new IFFCommon();
        public uint Un1 { get; set; }
        public string ErrorTextDescription { get; set; }
        internal override string FileName { get { return "ErrorCodeInfo.iff"; } }
        internal override IFFFile Get()
        {
            var item = new ErrorCodeInfo();
            item.Header.Active = Reader().ReadUInt32();
            item.Header.ID = Reader().ReadUInt32();
            item.Un1 = Reader().ReadUInt32();
            item.ErrorTextDescription = GetString(260);
            return item;
        }
    }
}
