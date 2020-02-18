namespace PangyaFileCore.IffManager
{
    public class MemorialShopCoinItem : IFFFile
    {
        public override IFFCommon Header { get; set; } = new IFFCommon();
      
        public uint CoinType { get; set; }// tipo de moeda
        
        public uint Amount { get; set; }

        public uint Amount2 { get; set; }

        public uint GachaNum { get; set; }

        public uint Pool { get; set; }
        public uint ItemType { get; set; }

        public uint Amount3 { get; set; }
        public uint Amount4 { get; set; }
        public byte[] UN { get; set; }

        internal override string FileName { get { return "MemorialShopCoinItem.iff"; } }


        internal override IFFFile Get()
        {
            var item = new MemorialShopCoinItem();

            item.Header.Active = Reader().ReadUInt32();
            item.Header.ID = Reader().ReadUInt32();
            item.CoinType = Reader().ReadUInt32();
            item.Amount = Reader().ReadUInt32();
            item.Amount2 = Reader().ReadUInt32();
            item.GachaNum = Reader().ReadUInt32();
            item.Pool = Reader().ReadUInt32();
            item.ItemType = Reader().ReadUInt32();
            item.Amount3 = Reader().ReadUInt32();
            item.Amount4 = Reader().ReadUInt32();
            item.UN = Reader().ReadBytes(24);
            return item;
        }
    }
}
