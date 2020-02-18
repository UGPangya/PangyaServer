using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PangyaFileCore.ItemsList
{
    public class ItemRandomClass : List<ItemRandom>
    {
        public List<Supplies> FSupplies { get; set; }
        public List<ItemRandom> FTItem { get; set; }
        public bool FDuplicated = false;
        public ItemRandom PItemRadom;

        public ItemRandomClass()
        {
            FSupplies = new List<Supplies>();
            FTItem = new List<ItemRandom>();
            FDuplicated = true;
        }



        public void AddItems(uint TypeID, uint MaxQuan, uint RareType, ushort Probabilities, bool ItemActive = true)
        {

            ItemRandom Items;
            Items = new ItemRandom
            {
                Index = (uint)new Random().Next(),  
                Number = -1,
                Active = ItemActive,
                TypeId = TypeID,
                MaxQuantity = MaxQuan,
                Probs = Probabilities,
                RareType = RareType,
            };
            this.Add(Items);
        }

        public void AddItems(string ItemName,uint TypeID, uint MaxQuan, uint RareType, ushort Probabilities)
        {

            ItemRandom Items;
            Items = new ItemRandom
            {
                Index = (uint)new Random().Next(),
                NameItem = ItemName,
                Active= true,
                TypeId = TypeID,
                MaxQuantity = MaxQuan,
                Probs = Probabilities,
                RareType = RareType,
            };
            this.Add(Items);
        }

        public void AddSupply(uint TypeID, uint Quantity = 1)
        {
            Supplies FSupply;
            FSupply = new Supplies
            {
                TypeId = TypeID,
                DelQuantity = (ushort)Quantity
            };
            FSupplies.Add(FSupply);
        }

        public void Arrange()
        {
            uint negative = 0;
            var Item1 = FTItem.FirstOrDefault();
            var Item2 = this.FirstOrDefault();
            if (Item1.RareType > Item2.RareType)
            {

                negative -= 1;

            }
            else if (Item1.RareType < Item2.RareType)
            {
                negative = 1;
            }
            else
            {
                negative = 0;
            }

        }
        public void SetCanDup(bool Val)
        {
            FDuplicated = Val;
            Restore();
        }

        public void Restore()
        {
            FTItem.Clear();
            foreach (var Items in this)
            {
                FTItem.Add(Items);
            }
        }


        public ItemRandom GetItems(int count)
        {
            int RInt = new Random().Next(1, count);
            if (!FDuplicated)
            {
                foreach (var Items in FTItem)
                {
                    RInt -= Items.Probs;
                    if (RInt <= 0)
                    {
                        FTItem.Remove(Items);
                        return Items;
                    }
                }
            }
            else if (FDuplicated)
            {
                foreach (var Items in this)
                {
                    RInt -= Items.Probs;
                    if (RInt <= 0)
                    {
                        return Items;
                    }
                }
            }
            return null;
        }

        public ItemRandom GetItems()
        {
            int RInt = new Random().Next(1, 150);
            if (!FDuplicated)
            {
                foreach (var Items in FTItem)
                {
                    RInt -= Items.Probs;
                    if (RInt <= 0)
                    {
                        FTItem.Remove(Items);
                        return Items;
                    }
                }
            }
            else if (FDuplicated)
            {
                foreach (var Items in this)
                {
                    RInt -= Items.Probs;
                    if (RInt <= 0)
                    {
                        return Items;
                    }
                }
            }
            return null;
        }
        public uint GetLeft()
        {
            if (FDuplicated)
            {
                return (uint)Count;
            }
            else
            {
                return (uint)FTItem.Count;
            }
        }

    }
    public class ItemRandom
    {
        public uint Index { get; set; }
        public string NameItem { get; set; }
        public uint TypeId { get; set; }
        public int Number { get; set; } = -1;
        public uint MaxQuantity { get; set; }
        public ushort Probs { get; set; }
        public uint RareType { get; set; }
        public bool Active { get; set; }
    }
    public class Supplies
    {
        public uint TypeId { get; set; }
        public ushort DelQuantity { get; set; }
    }
}
