using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PangyaFileCore.IffManager
{
    public abstract class IFFFile
    {
        

        private readonly Encoding encoding = Encoding.UTF8;
        #region Internal Abstract Fields
        internal abstract string FileName { get; }
        #endregion

        #region Public Fields
        private BinaryReader Binaryreader { get; set; }
        #endregion

        #region Public Abstract Fields

        public abstract IFFCommon Header { get; set; }

        #endregion

        #region Internal Abstract Methods
        internal abstract IFFFile Get();
        #endregion

        public BinaryReader SetReader(BinaryReader reader)
        {
            this.Binaryreader = reader;
            return this.Binaryreader;
        }

        public void CloseBinary()
        {
            this.Binaryreader.Close();
        }
        public BinaryReader Reader()
        {
            
            return this.Binaryreader;
        }

        /// <summary>
        /// Pula bytes a partir da posição no fluxo atual
        /// </summary>
        /// <param name="jump"></param>
        public void Skip(int jump)
        {
            Reader().BaseStream.Seek(jump, SeekOrigin.Current);
        }

        public IEnumerable<ushort> ReadUInt16(uint count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return Reader().ReadUInt16();
            }
        }

        public IEnumerable<uint> ReadUInt32(uint count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return Reader().ReadUInt16();
            }
        }

        public IEnumerable<uint> Read(uint count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return Reader().ReadUInt32();
            }
        }

        #region Public Metods
        
        public string GetString(int count)
        {
            return encoding.GetString(Reader().ReadBytes(count)).Replace("\0", "");
        }

        #endregion
    }
}
