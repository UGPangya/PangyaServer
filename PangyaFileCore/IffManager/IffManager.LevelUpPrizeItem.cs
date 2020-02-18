using System.Linq;

namespace PangyaFileCore.IffManager
{
    public class LevelUpPrizeItem : IFFFile
    {
        internal override string FileName { get { return "LevelUpPrizeItem.iff"; } }

        public override IFFCommon Header { get; set; } = new IFFCommon();
      
        public uint[] TypeID { get; set; }
        public uint[] Quantity { get; set; }
        internal override IFFFile Get()
        {
            var item = new LevelUpPrizeItem();
            Skip(34);
            item.Header.Level = (ItemLevelEnum)Reader().ReadUInt16();
            item.TypeID = Read(2).ToArray();
            item.Quantity = Read(2).ToArray();
            Skip(2);
            item.Header.Name = GetString(132);
            return item;
        }
    }
}