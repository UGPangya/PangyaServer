using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PangyaFileCore.IffManager
{
    public class QuestStuff : IFFFile
    {
        public override IFFCommon Header { get; set; } = new IFFCommon();

        internal override string FileName { get { return "QuestStuff.iff"; } }

        public byte[] UN { get; set; }
        
        public uint[] CounterItemTypeID { get; set; }
        public uint[] CounterItemQuantity { get; set; }
        public uint[] ItemRewardTypeID { get; set; }
        public uint[] ItemRewardQuantity { get; set; }
        public byte[] UN2 { get; set; }
        internal override IFFFile Get()
        {
            var item = new QuestStuff();
            item.Header.Active = Reader().ReadUInt32();
            item.Header.ID = Reader().ReadUInt32();
            item.Header.Name = GetString(80); // 40 Byte long
            item.UN = Reader().ReadBytes(80);
            item.CounterItemTypeID = Read(5).ToArray();
            item.CounterItemQuantity = Read(5).ToArray();
            item.ItemRewardTypeID = Read(3).ToArray();
            item.ItemRewardQuantity = Read(3).ToArray();
            item.UN2 = Reader().ReadBytes(12);
            if (item.Header.ID == 1816133689)
            {
            }
            return item;
        }
    }
}
