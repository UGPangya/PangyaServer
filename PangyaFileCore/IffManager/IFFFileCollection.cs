using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.IO.Compression;
namespace PangyaFileCore.IffManager
{
    #region Handle IFF Files
    /// <summary>
    /// Main IFF file class
    /// </summary>
    public class IFFFileCollection<T> : List<T> where T : IFFFile
    {
        private ZipArchiveEntry FileZip { get; set; }
        private bool IsZIPFile;
        private ushort BindingID { get; set; }
        private uint Version { get; set; }
        private ushort RecordCount;
        private long RecordLength;
        public IFFFileCollection(T t)
        {
            Build(t);
        }
        private void Build(T t, string Read = "data/pangya_gb.iff")
        {
            var zip = ZipFile.OpenRead(Read);//ler o arquivo de base
             FileZip = zip.Entries.FirstOrDefault(c => c.Name == t.FileName);//verifica se existe o arquivo
            if (FileZip != null)
            {
                MemoryStream memory = new MemoryStream();
                FileZip.Open().CopyTo(memory);//lê os bytes do stream atual, iniciando na posição atual, e os grava em outro stream 
                using (BinaryReader reader = new BinaryReader(memory))
                {
                    if ((IsZIPFile = (new string(reader.ReadChars(2)) == "PK")) == true)
                        return;

                    reader.BaseStream.Seek(0, SeekOrigin.Begin);

                    RecordCount = reader.ReadUInt16();
                    RecordLength = ((reader.BaseStream.Length - 8L) / (RecordCount));
                    BindingID = reader.ReadUInt16();
                    Version = reader.ReadUInt32();
                    for (int i = 0; i < RecordCount; i++)
                    {
                        reader.BaseStream.Seek(8L + (RecordLength * i), SeekOrigin.Begin);

                        byte[] recordData = reader.ReadBytes((int)RecordLength);

                        t.SetReader(new BinaryReader(new MemoryStream(recordData)));
                        //save iff 
                        var model = (T)t.Get();


                        Add(model);
                    }
                    t.CloseBinary();
                }
            }
            else
            {
                Console.WriteLine(" File No Exist: "+ Read + "/" + t.FileName);
            }
        }
        public T GetById(int id)
        {
            var Get = this.Where(c => c.Header.ID == id).FirstOrDefault();
            if (Get == null)
            {
                return null;
            }

            return Get;
        }
        public T GetItemById(int id)
        {
            var Get = this.Where(c => c.Header.ID >= id).ToList();
            if (Get == null)
            {
                return null;
            }

            return Get.FirstOrDefault();
        }
        public T Find(int id)
        {
            var Check = GetById(id);
            return Check;
        }
        public T GetByName(string name)
        {
            var Get = this.Where(c => c.Header.Name == name).ToList();
            if (Get == null)
            {
                return null;
            }

            return Get.FirstOrDefault();
        }        
        public string GetItemName(int id)
        {
            var Get = this.FirstOrDefault(c => c.Header.ID == id);
            if (Get == null)
            {
                return "Unkown Name";
            }
            return Get.Header.Name;
        }
        public bool IsBuyable(int id)
        {
            return this.Any(c => c.Header.ID == id && c.Header.Active == 1 && c.Header.MoneyFlag != MoneyFlag.Active || c.Header.MoneyFlag != MoneyFlag.Type);
        }
        public bool IsExist(int id)
        {
            return this.Any(c => c.Header.ID == id && c.Header.Active == 1);
        }
        public short GetShopPriceType(int id)
        {
            var Items = this.FirstOrDefault(c => c.Header.ID == id);

            if (Items == null)
            {
                return -1;
            }

            if (Items.Header.Active == 1)
            {
                return (short)Items.Header.ShopFlag;
            }

            return -1;
        }
        public uint GetPrice(int id)
        {
            var Items = this.FirstOrDefault(c => c.Header.ID == id);
            if (Items == null)
            {
                return 99999999;
            }
            if (Items.Header.Active == 1)
            {
                return Items.Header.Price;
            }
            return 0;
        }
        public ItemLevelEnum GetLevel(int id)
        {
            var Items = this.FirstOrDefault(c => c.Header.ID == id && c.Header.Active == 1);

            if (Items == null)
            {
                return 0;
            }

            return Items.Header.Level;
        }
    }
    #endregion
}
