namespace PangyaFileCore.IffManager
{
    public class MemorialShopRareItem : IFFFile
    {
        public override IFFCommon Header { get; set; } = new IFFCommon();
        public uint Active { get; set; }
        public uint GachaNum { get; set; }
        public uint TotalGacha { get; set; }
        public uint TypeID { get; set; }
        public uint Prob { get; set; } //Probabilidade
        public uint TypeRare { get; set; }
        public uint TypeNormal { get; set; }
        public uint Sex { get; set; }

        public uint Amount { get; set; }

        public uint TypeID2 { get; set; }

        public uint CharacterType { get; set; }

        public string UN { get; set; }

        internal override string FileName { get { return "MemorialShopRareItem.iff"; } }


        internal override IFFFile Get()
        {
            return new MemorialShopRareItem()
            {
                Active = Reader().ReadUInt32(),
                GachaNum = Reader().ReadUInt32(),
                TotalGacha = Reader().ReadUInt32(),
                TypeID = Reader().ReadUInt32(),
                Prob = Reader().ReadUInt32(),
                TypeRare = Reader().ReadUInt32(),
                TypeNormal = Reader().ReadUInt32(),
                Sex = Reader().ReadUInt32(),
                Amount = Reader().ReadUInt32(),
                TypeID2 = Reader().ReadUInt32(),
                CharacterType = Reader().ReadUInt32(),
                UN = GetString(24)
            };
        }
    }
}
