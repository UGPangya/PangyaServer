using System.Linq;
namespace PangyaFileCore.IffManager
{
    public class CadieMagicBox : IFFFile
    {
        public uint MagicID { get; set; }

        public uint Active { get; set; }

        public uint Setor { get; set; } //Setor

        public CadieBoxEnum Character { get; set; }//#character se tiver, se não -2

        public uint Unknown { get; set; }

        public uint Quatity { get; set; }
        public uint[] TradeID { get; set; }

        public uint[] TradeQuantity { get; set; }
        public uint BoxRandomID { get; set; }

        public override IFFCommon Header { get; set; } = new IFFCommon();


        internal override string FileName { get { return "CadieMagicBox.iff"; } }


        internal override IFFFile Get()
        {
            var item = new CadieMagicBox();
            item.MagicID = Reader().ReadUInt32();
            item.Header.Active = Reader().ReadUInt32();
            item.Setor = Reader().ReadUInt32();
            item.Character = (CadieBoxEnum)Reader().ReadInt32();
            item.Header.Level = (ItemLevelEnum)Reader().ReadUInt32();
            item.Unknown = Reader().ReadUInt32();
            item.Header.ID = Reader().ReadUInt32();
            item.Quatity = Reader().ReadUInt32();
            item.TradeID = Read(4).ToArray();
            item.TradeQuantity = Read(4).ToArray();
            item.BoxRandomID = Reader().ReadUInt32();
            item.Header.Name = GetString(40);
            item.Header.StartTime.Year = Reader().ReadUInt16();
            item.Header.StartTime.Month = Reader().ReadUInt16();
            item.Header.StartTime.DayOfWeek = Reader().ReadUInt16();
            item.Header.StartTime.Day = Reader().ReadUInt16();
            item.Header.StartTime.Hour = Reader().ReadUInt16();
            item.Header.StartTime.Minute = Reader().ReadUInt16();
            item.Header.StartTime.Second = Reader().ReadUInt16();
            item.Header.StartTime.MilliSecond = Reader().ReadUInt16();
            item.Header.EndTime.Year = Reader().ReadUInt16();
            item.Header.EndTime.Month = Reader().ReadUInt16();
            item.Header.EndTime.DayOfWeek = Reader().ReadUInt16();
            item.Header.EndTime.Day = Reader().ReadUInt16();
            item.Header.EndTime.Hour = Reader().ReadUInt16();
            item.Header.EndTime.Minute = Reader().ReadUInt16();
            item.Header.EndTime.Second = Reader().ReadUInt16();
            item.Header.EndTime.MilliSecond = Reader().ReadUInt16();
            return item;
        }
    }
}
