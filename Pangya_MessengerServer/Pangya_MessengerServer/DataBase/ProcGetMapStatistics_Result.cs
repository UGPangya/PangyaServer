//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pangya_MessengerServer.DataBase
{
    using System;
    
    public partial class ProcGetMapStatistics_Result
    {
        public int ID { get; set; }
        public int UID { get; set; }
        public short Map { get; set; }
        public int Drive { get; set; }
        public int Putt { get; set; }
        public int Hole { get; set; }
        public int Fairway { get; set; }
        public int Holein { get; set; }
        public int PuttIn { get; set; }
        public int TotalScore { get; set; }
        public short BestScore { get; set; }
        public int MaxPang { get; set; }
        public int CharTypeId { get; set; }
        public byte EventScore { get; set; }
        public byte Assist { get; set; }
        public Nullable<System.DateTime> REGDATE { get; set; }
    }
}
