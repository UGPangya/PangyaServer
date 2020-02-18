using PangyaFileCore.ItemsList;
using PangyaFileCore.GameTools;
using System;
using System.Linq;
using System.Collections.Generic;
namespace PangyaFileCore.IffManager.IffList
{
    public class IFFFileManager
    {
        #region Public Fields
        public List<Card> ListCard { get; set; } = new List<Card>();
        public Dictionary<uint, Card> AllList { get; set; } = new Dictionary<uint, Card>();
        public Dictionary<uint, SetItem> ListSetItem { get; set; } = new Dictionary<uint, SetItem>();

        public List<MemorialShopRareItem> RareItem { get; set; } = new List<MemorialShopRareItem>();

        public List<MemorialSpecialItem> SPItem { get; set; } = new List<MemorialSpecialItem>();

        public Dictionary<uint, CardPack> PackData { get; set; } = new Dictionary<uint, CardPack>();
        public Dictionary<uint, MemorialShopCoinItem> CoinDB { get; set; } = new Dictionary<uint, MemorialShopCoinItem>();

        public Dictionary<uint, CadieMagicBox> MagicBox { get; set; } = new Dictionary<uint, CadieMagicBox>();
        
        //-------------------------------  IFF FILES  --------------------- \\
        public IFFFileCollection<LevelUpPrizeItem> LevelUpPrizes { get; set; }
        public IFFFileCollection<GrandPrixData> GrandPrixDatas { get; set; }
        public IFFFileCollection<ErrorCodeInfo> ErrorCodeInfos { get; set; }
        public IFFFileCollection<Character> Characters { get; set; }
        public IFFFileCollection<Part> Parts { get; set; }
        public IFFFileCollection<CaddieItem> CaddiesItem { get; set; }
        public IFFFileCollection<SetItem> SetItems { get; set; }
        public IFFFileCollection<AuxPart> AuxParts { get; set; }
        public IFFFileCollection<Mascot> Mascots { get; set; }
        public IFFFileCollection<HairStyle> HairStyles { get; set; }
        public IFFFileCollection<Desc> Descs { get; set; }
        public IFFFileCollection<Skin> Titles { get; set; }
        public IFFFileCollection<Course> Courses { get; set; }
        public IFFFileCollection<Enchant> Enchants { get; set; }
        public IFFFileCollection<Ball> Balls { get; set; }
        public IFFFileCollection<Caddie> Caddies { get; set; }
        public IFFFileCollection<Card> Cards { get; set; }
        public IFFFileCollection<Club> Clubs { get; set; }
        public IFFFileCollection<ClubSet> ClubSets { get; set; }
        public IFFFileCollection<Match> Matchs { get; set; }
        public IFFFileCollection<Item> Items { get; set; }
        public IFFFileCollection<CadieMagicBox> CaddieMagicBoxes { get; set; }
        public IFFFileCollection<CaddieMagicBoxRandom> CadieMagicBoxRandoms { get; set; }
        public IFFFileCollection<Furniture> Furnitures { get; set; }
        public IFFFileCollection<CutinInformation> CutinsInformation { get; set; }
        public IFFFileCollection<MemorialShopCoinItem> MemorialShopCoin { get; set; }
        public IFFFileCollection<MemorialShopRareItem> MemorialShopRare { get; set; }
        public IFFFileCollection<QuestItem> QuestItems { get; set; }
        public IFFFileCollection<QuestStuff> QuestStuffs { get; set; }
        public IFFFileCollection<Achievement> Achievements { get; set; }
        public IFFFileCollection<CounterItem> CounterItems { get; set; }
        //-------------------------------  IFF FILES  --------------------- \\
        #endregion

        #region Construtor
        public IFFFileManager()
        {
            QuestItems = new IFFFileCollection<QuestItem>(new QuestItem());

            QuestStuffs = new IFFFileCollection<QuestStuff>(new QuestStuff());

            Achievements = new IFFFileCollection<Achievement>(new Achievement());

            CounterItems = new IFFFileCollection<CounterItem>(new CounterItem());

            CadieMagicBoxRandoms = new IFFFileCollection<CaddieMagicBoxRandom>(new CaddieMagicBoxRandom());
            LevelUpPrizes = new IFFFileCollection<LevelUpPrizeItem>(new LevelUpPrizeItem());

            GrandPrixDatas = new IFFFileCollection<GrandPrixData>(new GrandPrixData());

            ErrorCodeInfos = new IFFFileCollection<ErrorCodeInfo>(new ErrorCodeInfo());

            Descs = new IFFFileCollection<Desc>(new Desc());

            Characters = new IFFFileCollection<Character>(new Character());

            Parts = new IFFFileCollection<Part>(new Part());

            CaddiesItem = new IFFFileCollection<CaddieItem>(new CaddieItem());

            SetItems = new IFFFileCollection<SetItem>(new SetItem());

            AuxParts = new IFFFileCollection<AuxPart>(new AuxPart());

            Mascots = new IFFFileCollection<Mascot>(new Mascot());

            Titles = new IFFFileCollection<Skin>(new Skin());

            HairStyles = new IFFFileCollection<HairStyle>(new HairStyle());

            Enchants = new IFFFileCollection<Enchant>(new Enchant());

            Courses = new IFFFileCollection<Course>(new Course());

            Balls = new IFFFileCollection<Ball>(new Ball());

            Caddies = new IFFFileCollection<Caddie>(new Caddie());

            Cards = new IFFFileCollection<Card>(new Card());

            Clubs = new IFFFileCollection<Club>(new Club());

            Matchs = new IFFFileCollection<Match>(new Match());

            ClubSets = new IFFFileCollection<ClubSet>(new ClubSet());

            Items = new IFFFileCollection<Item>(new Item());

            CaddieMagicBoxes = new IFFFileCollection<CadieMagicBox>(new CadieMagicBox());


            CutinsInformation = new IFFFileCollection<CutinInformation>(new CutinInformation());

            Furnitures = new IFFFileCollection<Furniture>(new Furniture());

            MemorialShopCoin = new IFFFileCollection<MemorialShopCoinItem>(new MemorialShopCoinItem());

            MemorialShopRare = new IFFFileCollection<MemorialShopRareItem>(new MemorialShopRareItem());
            foreach (var Item in MemorialShopRare)
            {
                RareItem.Add(Item);
            }

            foreach (var listset in SetItems)
            {
                ListSetItem.Add(listset.Header.ID, listset);
            }
            this.AddMagicBox();
            this.AddPackCard();


            AddSPList();
            AddCoinDB();

            foreach (var cards in Cards)
            {
                AllList.Add(cards.Header.ID, cards);
            }
        }

        #endregion

        #region Public Methods
        public List<MemorialSpecialItem> GetNormalItem(uint TypeID)
        {
            byte PairNum;
            var result = new List<MemorialSpecialItem>();
            switch (TypeID)
            {
                case 436208242:
                    {
                        PairNum = (byte)new Random().Next(8, 18);
                    }
                    break;
                default:
                    {
                        PairNum = (byte)new Random().Next(1, 7);
                    }
                    break;
            }
            foreach (var SpecialItem in SPItem)
            {
                if (SpecialItem.Number == PairNum)
                {
                    result.Add(SpecialItem);
                }
            }
            return result;
        }
        public ItemRandomClass GetRareItem(uint CoinTypeID)
        {
            int number = 1;
            ushort prob = 0;
            var result = new ItemRandomClass();

            switch (CoinTypeID)
            {
                case 436208242:
                    {

                        foreach (var item in RareItem)
                        {
                            prob = (ushort)number;
                            number += 1;
                            result.AddItems(item.TypeID, 1, item.TypeRare, prob);
                        }
                    }
                    break;
                default:
                    {
                        foreach (var item in RareItem)
                        {
                            if (item.CharacterType == GetPool(CoinTypeID))
                            {
                                prob = (ushort)number;
                                number += 1;
                                result.AddItems(item.TypeID, 1, item.TypeRare, prob);
                            }
                        }
                    }
                    break;
            }
            result.SetCanDup(false);
            result.Arrange();
            return result;
        }

        private void AddSPList()
        {

            MemorialSpecialItem SPT;
            // 1. ## Strength Boost x5
            SPT = new MemorialSpecialItem
            {
                Number = 1,
                TypeID = 402653188,
                Quantity = 5
            };
            SPItem.Add(SPT);
            // 2. ## Miracle Sign x5
            SPT = new MemorialSpecialItem
            {
                Number = 2,
                TypeID = 402653189,
                Quantity = 5
            };
            SPItem.Add(SPT);
            // 3. ## Spin Mastery x5
            SPT = new MemorialSpecialItem
            {
                Number = 3,
                TypeID = 402653184,
                Quantity = 5
            };
            SPItem.Add(SPT);
            // 4. ## Curve Mastery x5
            SPT = new MemorialSpecialItem
            {
                Number = 4,
                TypeID = 402653185,
                Quantity = 5
            };
            SPItem.Add(SPT);
            // 5. ## Generic Lucky Pangya x5
            SPT = new MemorialSpecialItem
            {
                Number = 5,
                TypeID = 402653191,
                Quantity = 5
            };
            SPItem.Add(SPT);
            // 6. ## Generic Nerve Stabilizer x5
            SPT = new MemorialSpecialItem
            {
                Number = 6,
                TypeID = 402653192,
                Quantity = 5
            };
            SPItem.Add(SPT);
            // 7. ## Club Modification Kit x1
            SPT = new MemorialSpecialItem
            {
                Number = 7,
                TypeID = 436208143,
                Quantity = 1
            };
            SPItem.Add(SPT);
            // Premium Coin Set No.1
            SPT = new MemorialSpecialItem
            {
                Number = 8,
                TypeID = 402653190,
                // ## Silent Wind
                Quantity = 3
            };
            SPItem.Add(SPT);
            SPT = new MemorialSpecialItem
            {
                Number = 8,
                TypeID = 436208015,
                // ## Bongdari Clip
                Quantity = 1
            };
            SPItem.Add(SPT);
            SPT = new MemorialSpecialItem
            {
                Number = 8,
                TypeID = 335544321,
                // ## Bomber Aztec
                Quantity = 30
            };
            SPItem.Add(SPT);
            SPT = new MemorialSpecialItem
            {
                Number = 8,
                TypeID = 436207633,
                // ## Timer Boost
                Quantity = 30
            };
            SPItem.Add(SPT);
            SPT = new MemorialSpecialItem
            {
                Number = 8,
                TypeID = 436207680,
                // ## Auto Clipper
                Quantity = 30
            };
            SPItem.Add(SPT);
            // End Premium Coin
            // Premium Coin Set No.2
            SPT = new MemorialSpecialItem
            {
                Number = 9,
                TypeID = 436208145,
                // ## UCIM CHIP
                Quantity = 2
            };
            SPItem.Add(SPT);
            SPT = new MemorialSpecialItem
            {
                Number = 9,
                TypeID = 335544342,
                // ## Watermelon Aztec
                Quantity = 40
            };
            SPItem.Add(SPT);
            SPT = new MemorialSpecialItem
            {
                Number = 9,
                TypeID = 402653224,
                // ## Safe Tee
                Quantity = 5
            };
            SPItem.Add(SPT);
            SPT = new MemorialSpecialItem
            {
                Number = 9,
                TypeID = 436207633,
                // ## Timer Boost
                Quantity = 100
            };
            SPItem.Add(SPT);
            SPT = new MemorialSpecialItem
            {
                Number = 9,
                TypeID = 436207680,
                // ## Auto Clipper
                Quantity = 100
            };
            SPItem.Add(SPT);
            // End Premium Coin
            // Premium Coin Set No.3
            SPT = new MemorialSpecialItem
            {
                Number = 10,
                TypeID = 436208144,
                // ## Abbot Coating
                Quantity = 3
            };
            SPItem.Add(SPT);
            SPT = new MemorialSpecialItem
            {
                Number = 10,
                TypeID = 335544332,
                // ## Clover Aztec
                Quantity = 50
            };
            SPItem.Add(SPT);
            SPT = new MemorialSpecialItem
            {
                Number = 10,
                TypeID = 402653223,
                // ## Double Strength Boost
                Quantity = 10
            };
            SPItem.Add(SPT);
            SPT = new MemorialSpecialItem
            {
                Number = 10,
                TypeID = 436207815,
                // ## Air Note
                Quantity = 60
            };
            SPItem.Add(SPT);
            SPT = new MemorialSpecialItem
            {
                Number = 10,
                TypeID = 436207633,
                // ## Timer Boost
                Quantity = 60
            };
            SPItem.Add(SPT);
            // End Premium Coin
            // Premium Coin Set No.4
            SPT = new MemorialSpecialItem
            {
                Number = 11,
                TypeID = 2092957696,
                // ## Card Pack No. 1
                Quantity = 1
            };
            SPItem.Add(SPT);
            SPT = new MemorialSpecialItem
            {
                Number = 11,
                TypeID = 335544350,
                // ## Sakura Aztec
                Quantity = 50
            };
            SPItem.Add(SPT);
            SPT = new MemorialSpecialItem
            {
                Number = 11,
                TypeID = 402653230,
                // ## Double P.Strength Boost
                Quantity = 3
            };
            SPItem.Add(SPT);
            SPT = new MemorialSpecialItem
            {
                Number = 11,
                TypeID = 436207618,
                // ## Pang Mastery
                Quantity = 20
            };
            SPItem.Add(SPT);
            SPT = new MemorialSpecialItem
            {
                Number = 11,
                TypeID = 436207633,
                // ## Timer Boost
                Quantity = 50
            };
            SPItem.Add(SPT);
            // End Premium Coin
            // Premium Coin Set No.5
            SPT = new MemorialSpecialItem
            {
                Number = 12,
                TypeID = 2092957700,
                // ## Card Pack No.2
                Quantity = 1
            };
            SPItem.Add(SPT);
            SPT = new MemorialSpecialItem
            {
                Number = 12,
                TypeID = 335544369,
                // ## Halloween Skull Aztec
                Quantity = 30
            };
            SPItem.Add(SPT);
            SPT = new MemorialSpecialItem
            {
                Number = 12,
                TypeID = 402653194,
                // ## Dual Lucky Pangya
                Quantity = 5
            };
            SPItem.Add(SPT);
            SPT = new MemorialSpecialItem
            {
                Number = 12,
                TypeID = 436207618,
                // ## Pang Mastery
                Quantity = 30
            };
            SPItem.Add(SPT);
            SPT = new MemorialSpecialItem
            {
                Number = 12,
                TypeID = 436207633,
                // ## Timer Boost
                Quantity = 50
            };
            SPItem.Add(SPT);
            // End Premium Coin
            // Premium Coin Set No.6
            SPT = new MemorialSpecialItem
            {
                Number = 13,
                TypeID = 2092957701,
                // ## Card Pack No.3
                Quantity = 1
            };
            SPItem.Add(SPT);
            SPT = new MemorialSpecialItem
            {
                Number = 13,
                TypeID = 335544352,
                // ## Rainbow Aztec
                Quantity = 30
            };
            SPItem.Add(SPT);
            SPT = new MemorialSpecialItem
            {
                Number = 13,
                TypeID = 402653195,
                // ## Dual Tran
                Quantity = 5
            };
            SPItem.Add(SPT);
            SPT = new MemorialSpecialItem
            {
                Number = 13,
                TypeID = 436207618,
                // ## Pang Mastery
                Quantity = 30
            };
            SPItem.Add(SPT);
            SPT = new MemorialSpecialItem
            {
                Number = 13,
                TypeID = 436207680,
                // ## Auto Clipper
                Quantity = 40
            };
            SPItem.Add(SPT);
            // End Premium Coin
            // Premium Coin Set No.7
            SPT = new MemorialSpecialItem
            {
                Number = 14,
                TypeID = 2092957703,
                // ## Card Pack No.4
                Quantity = 1
            };
            SPItem.Add(SPT);
            SPT = new MemorialSpecialItem
            {
                Number = 14,
                TypeID = 335544465,
                // ## Smiling Goblin Aztec
                Quantity = 50
            };
            SPItem.Add(SPT);
            SPT = new MemorialSpecialItem
            {
                Number = 14,
                TypeID = 402653223,
                // ## Double Strength Boost
                Quantity = 5
            };
            SPItem.Add(SPT);
            SPT = new MemorialSpecialItem
            {
                Number = 14,
                TypeID = 436207633,
                // ## Timer Boost
                Quantity = 50
            };
            SPItem.Add(SPT);
            SPT = new MemorialSpecialItem
            {
                Number = 14,
                TypeID = 436207680,
                // ## Auto Clipper
                Quantity = 50
            };
            SPItem.Add(SPT);

            SPT = new MemorialSpecialItem
            {
                Number = 15,
                TypeID = 436207709,
                // ##Fragment of time (Fall)
                Quantity = 1
            };
            SPItem.Add(SPT);

            SPT = new MemorialSpecialItem
            {
                Number = 16,
                TypeID = 436207707,
                // ##Fragment of time (Spring)
                Quantity = 1
            };
            SPItem.Add(SPT);

            SPT = new MemorialSpecialItem
            {
                Number = 17,
                TypeID = 436207708,
                // ##Fragment of time (Summer)
                Quantity = 1
            };
            SPItem.Add(SPT);

            SPT = new MemorialSpecialItem
            {
                Number = 18,
                TypeID = 436207710,
                // ##Fragment of time (Winter)
                Quantity = 1
            };
            SPItem.Add(SPT);

            // NOVOS ITENS!
            SPT = new MemorialSpecialItem
            {
                Number = 19,
                TypeID = 436208242, // Moeda do Memorial Premium
                Quantity = 5
            };
            SPItem.Add(SPT);

            SPT = new MemorialSpecialItem
            {
                Number = 20,
                TypeID = 608256015, // Patinhas Spika
                Quantity = 1
            };
            SPItem.Add(SPT);

            SPT = new MemorialSpecialItem
            {
                Number = 21,
                TypeID = 608174132, // Patinhas Nuri
                Quantity = 1
            };
            SPItem.Add(SPT);

            SPT = new MemorialSpecialItem
            {
                Number = 22,
                TypeID = 608182322, // Patinhas Hana
                Quantity = 1
            };
            SPItem.Add(SPT);

            SPT = new MemorialSpecialItem
            {
                Number = 23,
                TypeID = 608190501, // Patinhas Azer
                Quantity = 1
            };
            SPItem.Add(SPT);

            SPT = new MemorialSpecialItem
            {
                Number = 24,
                TypeID = 608198722, // Patinhas Cecilia
                Quantity = 1
            };
            SPItem.Add(SPT);

            SPT = new MemorialSpecialItem
            {
                Number = 25,
                TypeID = 608206889, // Patinhas Max
                Quantity = 1
            };
            SPItem.Add(SPT);

            SPT = new MemorialSpecialItem
            {
                Number = 26,
                TypeID = 608215139, // Patinhas Kooh
                Quantity = 1
            };
            SPItem.Add(SPT);

            SPT = new MemorialSpecialItem
            {
                Number = 27,
                TypeID = 608223292, // Patinhas Arin
                Quantity = 1
            };
            SPItem.Add(SPT);

            SPT = new MemorialSpecialItem
            {
                Number = 28,
                TypeID = 608231468, // Patinhas Kaz
                Quantity = 1
            };
            SPItem.Add(SPT);

            SPT = new MemorialSpecialItem
            {
                Number = 29,
                TypeID = 608239698, // Patinhas Lucia
                Quantity = 1
            };
            SPItem.Add(SPT);

            SPT = new MemorialSpecialItem
            {
                Number = 30,
                TypeID = 608247843, // Patinhas Nell
                Quantity = 1
            };
            SPItem.Add(SPT);
        }

        public SortedDictionary<uint, uint> GetSPCL(uint TypeID)
        {
            AllList.TryGetValue(TypeID, out Card datacard);
            var result = new SortedDictionary<uint, uint>();

            if (null == datacard)
            {
                result.Add(0, 0);
                return result;
            }
            result.Add((uint)datacard.Effect, (uint)datacard.EffectValue);
            return result;
        }

        public Dictionary<bool, Card> GetCardSPCL(uint TypeID)
        {
            AllList.TryGetValue(TypeID, out Card datacard);
            var result = new Dictionary<bool, Card>();

            if (null == datacard)
            {
                result.Add(false, null);
                return result;
            }
            result.Add(true, datacard);
            return result;
        }

        public List<SortedDictionary<uint, byte>> GetCard(uint TypeID)
        {
            var result = new List<SortedDictionary<uint, byte>>();
            byte CQty;
            ItemRandomClass CRandom;
            ItemRandom CItem;
            CRandom = new ItemRandomClass();

            PackData.TryGetValue(TypeID, out CardPack CPack);

            if (CPack == null)
            {
                return result;
            }

            switch (CPack.CardTypePack)
            {
                case PackCard.Pack1:
                    {
                        foreach (var PZCard in ListCard)
                        {
                            if (PZCard.Volume == 1)
                            {
                                CRandom.AddItems(PZCard.Header.ID, 1, PZCard.CardType, (ushort)GetCardProb((byte)PZCard.CardType));
                            }
                        }
                    }
                    break;
                case PackCard.Pack2:
                    foreach (var PZCard in ListCard)
                    {
                        if (PZCard.Volume == 2)
                        {
                            CRandom.AddItems(PZCard.Header.ID, 1, PZCard.CardType, (ushort)GetCardProb((byte)PZCard.CardType));
                        }
                    }
                    break;
                case PackCard.Pack3:
                    foreach (var PZCard in ListCard)
                    {
                        if (PZCard.Volume == 3)
                        {
                            CRandom.AddItems(PZCard.Header.ID, 1, PZCard.CardType, (ushort)GetCardProb((byte)PZCard.CardType));
                        }
                    }
                    break;
                case PackCard.Pack4:
                    foreach (var PZCard in ListCard)
                    {
                        if (PZCard.Volume == 4)
                        {
                            CRandom.AddItems(PZCard.Header.ID, 1, PZCard.CardType, (ushort)GetCardProb((byte)PZCard.CardType));
                        }
                    }
                    break;
                case PackCard.Rare:
                    foreach (var PZCard in ListCard)
                    {
                        if ((int)PZCard.CardType >= 1)
                        {
                            CRandom.AddItems(PZCard.Header.ID, 1, PZCard.CardType, (ushort)GetCardFreshUPProb((byte)PZCard.CardType));
                        }
                    }
                    break;
                case PackCard.All:
                    foreach (var PZCard in ListCard)
                    {

                        CRandom.AddItems(PZCard.Header.ID, 1, PZCard.CardType, (ushort)GetCardProb((byte)PZCard.CardType));
                    }
                    break;
            }
            // ## set random class
            CRandom.SetCanDup(false);
            CRandom.Arrange();
            for (CQty = 1; CQty <= CPack.Quantity; CQty++)
            {
                CItem = CRandom.GetItems();
                result.Add(new SortedDictionary<uint, byte>
                {
                    { CItem.TypeId, (byte)CItem.RareType }
                });
            }
            return result;
        }

        public uint GetCardProb(byte RareType)
        {
            uint Prob = 2;
            switch (RareType)
            {
                case 0:
                    {
                        Prob = 100;
                    }
                    break;
                case 1:
                    {
                        Prob = 6;
                    }
                    break;
                case 2:
                    {
                        Prob = 5;
                    }
                    break;
                case 3:
                    {
                        Prob = 1;
                    }
                    break;
            }
            return Prob;
        }

        public uint GetCardFreshUPProb(byte RareType)
        {
            uint Prob = 2;
            switch (RareType)
            {
                case 1:
                    {
                        Prob = 100;
                    }
                    break;
                case 2:
                    {
                        Prob = 10;
                    }
                    break;
                case 3:
                    {
                        Prob = 4;
                    }
                    break;
            }
            return Prob;
        }

        private void AddMagicBox()
        {
            foreach (var basemagic in CaddieMagicBoxes)
            {
                MagicBox.Add(basemagic.MagicID, basemagic);
            }
        }

        private void AddPackCard()
        {
            var CardPacks = new CardPack();
            foreach (var basecard in Cards)
            {
                switch (basecard.Header.ID)
                {
                    case 2092957696: //{ Pangya Card Pack No.1 }
                    case 2092957697: //{ Golden Card Ticket }
                    case 2092957698: //{ Silver Card Ticket }
                    case 2092957699: //{ Bronze card ticket }
                    case 2092957700: //{ Pangya Card Pack No.2 }
                    case 2092957701:// { Card Pack No.3 }
                    case 2092957702: //{ Platinum Ticket }
                    case 2092957703: //{ Card Pack No.4 }
                    case 2092957704: //{ Grand Prix Card Pack }
                    case 2092957706: //{ Fresh Up! Card Pack }
                    case 2097152001: //{ Pangya Card Box No.2 }
                    case 2097152002: //{ Card Box No.3 }
                    case 2097152003: //{ Pangya Card Box #4 }
                    case 2084569125: //{ Unknown Name }
                    case 2084569128: //{ Unknown Name }
                        continue;
                }
                ListCard.Add(basecard);
            }
            // ## pack 1
            CardPacks.CardTypePack = PackCard.Pack1;
            CardPacks.Quantity = 3;
            PackData.Add(2092957696, CardPacks);
            // ## pack 2
            CardPacks = new CardPack
            {
                CardTypePack = PackCard.Pack2,
                Quantity = 3
            };
            PackData.Add(2092957700, CardPacks);
            // ## pack 3
            CardPacks = new CardPack
            {
                CardTypePack = PackCard.Pack3,
                Quantity = 3
            };
            PackData.Add(2092957701, CardPacks);
            // ## pack 4
            CardPacks = new CardPack
            {
                CardTypePack = PackCard.Pack4,
                Quantity = 3
            };
            PackData.Add(2092957703, CardPacks);
            // ## FRESH UP!
            CardPacks = new CardPack
            {
                CardTypePack = PackCard.Rare,
                Quantity = 3
            };
            PackData.Add(0x7CC0000A, CardPacks);
            //{ Golden Card Ticket }
            CardPacks = new CardPack()
            {
                CardTypePack = PackCard.All,
                Quantity = 3
            };
            PackData.Add(2092957697, CardPacks);
            //{ Silver Card Ticket }
            PackData.Add(2092957698, CardPacks);
            //{ Bronze card ticket }
            PackData.Add(2092957699, CardPacks);
        }

        public bool IsGPExist(uint TypeID)
        {
            if (GrandPrixDatas.GetById((int)TypeID) == null)
            {
                return false;
            }
            return true;
        }

        public bool IsNovice(uint TypeID)
        {
            var Get = GrandPrixDatas.FirstOrDefault(c => c.Header.ID == TypeID);
            if (Get != null && Get.DateOpenHour == 0 || Get.DateOpenMin == 0 && Get.DatetimeEndHour == 0 || Get.DatetimeEndMin == 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Procura em todos os arq carregados e retorna se caso encontrar referente ao ID
        /// </summary>
        /// <param name="id">TypeID Item</param>
        /// <returns></returns>
        public IFFFile FindAllFiles(int id)
        {
            switch ((TITEMGROUP)Tools.GetItemGroup((uint)id))
            {
                case TITEMGROUP.ITEM_TYPE_CHARACTER:
                    {
                        return Characters.GetById(id);
                    }
                case TITEMGROUP.ITEM_TYPE_HAIR_STYLE:
                    {
                        return HairStyles.GetById(id);
                    }
                case TITEMGROUP.ITEM_TYPE_PART:
                    {
                        return Parts.GetById(id);
                    }
                case TITEMGROUP.ITEM_TYPE_CLUB:
                    {
                        return ClubSets.GetById(id);
                    }
                case TITEMGROUP.ITEM_TYPE_BALL:
                    {
                        return Balls.GetById(id);
                    }
                case TITEMGROUP.ITEM_TYPE_USE:
                    {
                        return Items.GetById(id);
                    }
                case TITEMGROUP.ITEM_TYPE_CADDIE:
                    {
                        return Caddies.GetById(id);
                    }
                case TITEMGROUP.ITEM_TYPE_CADDIE_ITEM:
                    {
                        return CaddiesItem.GetById(id);
                    }
                case TITEMGROUP.ITEM_TYPE_SETITEM:
                    {
                        return SetItems.GetById(id);
                    }
                case TITEMGROUP.ITEM_TYPE_MATCH:
                    {
                        return Matchs.GetById(id);
                    }
                case TITEMGROUP.ITEM_TYPE_SKIN:
                    {
                        return Titles.GetById(id);
                    }
                case TITEMGROUP.ITEM_TYPE_MASCOT:
                    {
                        return Mascots.GetById(id);
                    }
                case TITEMGROUP.ITEM_TYPE_FURNITURE:
                    {
                        return Furnitures.GetById(id);
                    }
                case TITEMGROUP.ITEM_TYPE_CARD:
                    {
                        return Cards.GetById(id);
                    }
                case TITEMGROUP.ITEM_TYPE_AUX:
                    {
                        return AuxParts.GetById(id);
                    }
                case TITEMGROUP.ITEM_TYPE_ACHIEVEMENT_COUNTER_ITEM:
                    {
                        return CounterItems.GetById(id);
                    }
                case TITEMGROUP.ITEM_TYPE_ACHIEVEMENT:
                    {
                        return Achievements.GetById(id);
                    }
                case TITEMGROUP.ITEM_TYPE_ACHIEVEMENT_QUEST_ITEM:
                    {
                        return QuestItems.GetById(id);
                    }
                case TITEMGROUP.ITEM_TYPE_ACHIEVEMENT_QUEST_STUFFS:
                    {
                        return QuestStuffs.GetById(id);
                    }
                default:
                    {
                        Console.WriteLine($"ItemGroup_Un -> {Tools.GetItemGroup((uint)id)}");
                    }
                    break;

            }
            return null;
        }

        public string GetItemName(int id)
        {
            switch ((TITEMGROUP)Tools.GetItemGroup((uint)id))
            {
                case TITEMGROUP.ITEM_TYPE_CHARACTER:
                    {
                        return Characters.GetItemName(id);
                    }
                case TITEMGROUP.ITEM_TYPE_HAIR_STYLE:
                    {
                        return HairStyles.GetItemName(id);
                    }
                case TITEMGROUP.ITEM_TYPE_PART:
                    {
                        return Parts.GetItemName(id);
                    }
                case TITEMGROUP.ITEM_TYPE_CLUB:
                    {
                        return ClubSets.GetItemName(id);
                    }
                case TITEMGROUP.ITEM_TYPE_BALL:
                    {
                        return Balls.GetItemName(id);
                    }
                case TITEMGROUP.ITEM_TYPE_USE:
                    {
                        return Items.GetItemName(id);
                    }
                case TITEMGROUP.ITEM_TYPE_CADDIE:
                    {
                        return Caddies.GetItemName(id);
                    }
                case TITEMGROUP.ITEM_TYPE_CADDIE_ITEM:
                    {
                        return CaddiesItem.GetItemName(id);
                    }
                case TITEMGROUP.ITEM_TYPE_SETITEM:
                    {
                        return SetItems.GetItemName(id);
                    }
                case TITEMGROUP.ITEM_TYPE_MATCH:
                    {
                        return Matchs.GetItemName(id);
                    }
                case TITEMGROUP.ITEM_TYPE_SKIN:
                    {
                        return Titles.GetItemName(id);
                    }
                case TITEMGROUP.ITEM_TYPE_MASCOT:
                    {
                        return Mascots.GetItemName(id);
                    }
                case TITEMGROUP.ITEM_TYPE_FURNITURE:
                    {
                        return Furnitures.GetItemName(id);
                    }
                case TITEMGROUP.ITEM_TYPE_CARD:
                    {
                        return Cards.GetItemName(id);
                    }
                case TITEMGROUP.ITEM_TYPE_AUX:
                    {
                        return AuxParts.GetItemName(id);
                    }
                default:
                    {
                        Console.WriteLine($"ItemGroup_Un -> {Tools.GetItemGroup((uint)id)}");
                    }
                    break;

            }

            return "Unknown Item Name";
        }


        public bool IsBuyable(int id)
        {
            switch ((TITEMGROUP)Tools.GetItemGroup((uint)id))
            {
                case TITEMGROUP.ITEM_TYPE_CHARACTER:
                    {
                        return Characters.IsBuyable(id);
                    }
                case TITEMGROUP.ITEM_TYPE_HAIR_STYLE:
                    {
                        return HairStyles.IsBuyable(id);
                    }

                case TITEMGROUP.ITEM_TYPE_PART:
                    {
                        return Parts.IsBuyable(id);
                    }
                case TITEMGROUP.ITEM_TYPE_CLUB:
                    {
                        return ClubSets.IsBuyable(id);
                    }
                case TITEMGROUP.ITEM_TYPE_BALL:
                    {
                        return Balls.IsBuyable(id);
                    }

                case TITEMGROUP.ITEM_TYPE_USE:
                    {
                        return Items.IsBuyable(id);
                    }

                case TITEMGROUP.ITEM_TYPE_CADDIE:
                    {
                        return Caddies.IsBuyable(id);
                    }
                case TITEMGROUP.ITEM_TYPE_CADDIE_ITEM:
                    {
                        return CaddiesItem.IsBuyable(id);
                    }
                case TITEMGROUP.ITEM_TYPE_SETITEM:
                    {
                        return SetItems.IsBuyable(id);
                    }
                case TITEMGROUP.ITEM_TYPE_SKIN:
                    {
                        return Titles.IsBuyable(id);
                    }
                case TITEMGROUP.ITEM_TYPE_MASCOT:
                    {
                        return Mascots.IsBuyable(id);
                    }
                case TITEMGROUP.ITEM_TYPE_CARD:
                    {
                        return Cards.IsBuyable(id);
                    }
                case TITEMGROUP.ITEM_TYPE_AUX:
                    {
                        return AuxParts.IsBuyable(id);
                    }
            }
            return false;
        }

        public uint GetRentalPrice(uint typeID)
        {
            if (!(Tools.GetItemGroup(typeID) == 2))
            {
                return 0;
            }
            return PartsGetRentalPrice(typeID);
        }

        public uint PartsGetRentalPrice(uint typeID)
        {
            var items = Parts.FirstOrDefault(c => c.Header.ID == typeID && c.Header.Active == 1);

            if (items == null)
            {
                return 0;
            }

            if (items != null)
            {
                return items.RentPang;
            }

            return 0;
        }

        public bool IsExist(int id)
        {
            switch ((TITEMGROUP)Tools.GetItemGroup((uint)id))
            {
                case TITEMGROUP.ITEM_TYPE_CHARACTER:
                    {
                        return Characters.IsExist(id);
                    }

                case TITEMGROUP.ITEM_TYPE_HAIR_STYLE:
                    {
                        return HairStyles.IsExist(id);
                    }

                case TITEMGROUP.ITEM_TYPE_PART:
                    {
                        return Parts.IsExist(id);
                    }

                case TITEMGROUP.ITEM_TYPE_CLUB:
                    {
                        return ClubSets.IsExist(id);
                    }

                case TITEMGROUP.ITEM_TYPE_BALL:
                    {
                        return Balls.IsExist(id);
                    }

                case TITEMGROUP.ITEM_TYPE_USE:
                    {
                        return Items.IsExist(id);
                    }

                case TITEMGROUP.ITEM_TYPE_CADDIE:
                    {
                        return Caddies.IsExist(id);
                    }

                case TITEMGROUP.ITEM_TYPE_CADDIE_ITEM:
                    {
                        return CaddiesItem.IsExist(id);
                    }

                case TITEMGROUP.ITEM_TYPE_SETITEM:
                    {
                        return SetItems.IsExist(id);
                    }

                case TITEMGROUP.ITEM_TYPE_SKIN:
                    {
                        return Titles.IsExist(id);
                    }

                case TITEMGROUP.ITEM_TYPE_MASCOT:
                    {
                        return Mascots.IsExist(id);
                    }

                case TITEMGROUP.ITEM_TYPE_CARD:
                    {
                        return Cards.IsExist(id);
                    }

                case TITEMGROUP.ITEM_TYPE_AUX:
                    {
                        return AuxParts.IsExist(id);
                    }


            }
            return false;
        }

        public byte GetPool(uint TypeID)
        {
            return !MemorialLoadCoin(TypeID, out MemorialShopCoinItem Coin) ? (byte)0 : (byte)Coin.Pool;
        }

        private void AddCoinDB()
        {
            foreach (var Item in MemorialShopCoin)
            {
                CoinDB.Add(Item.Header.ID, Item);
            }

        }
        public bool MemorialCoinIsExist(uint TypeID)
        {
            return !MemorialLoadCoin(TypeID, out MemorialShopCoinItem Coin) ? false : true;
        }

        public bool MemorialLoadCoin(uint TypeID, out MemorialShopCoinItem PCoin)
        {
            return !CoinDB.TryGetValue(TypeID, out PCoin) ? false : true;
        }


        public short GetShopPriceType(int id)
        {
            switch ((TITEMGROUP)Tools.GetItemGroup((uint)id))
            {
                case TITEMGROUP.ITEM_TYPE_CHARACTER:
                    {
                        return Characters.GetShopPriceType(id);
                    }

                case TITEMGROUP.ITEM_TYPE_HAIR_STYLE:
                    {
                        return HairStyles.GetShopPriceType(id);
                    }

                case TITEMGROUP.ITEM_TYPE_PART:
                    {
                        return Parts.GetShopPriceType(id);
                    }

                case TITEMGROUP.ITEM_TYPE_CLUB:
                    {
                        return ClubSets.GetShopPriceType(id);
                    }

                case TITEMGROUP.ITEM_TYPE_BALL:
                    {
                        return Balls.GetShopPriceType(id);
                    }

                case TITEMGROUP.ITEM_TYPE_USE:
                    {
                        return Items.GetShopPriceType(id);
                    }

                case TITEMGROUP.ITEM_TYPE_CADDIE:
                    {
                        return Caddies.GetShopPriceType(id);
                    }

                case TITEMGROUP.ITEM_TYPE_CADDIE_ITEM:
                    {
                        return CaddiesItem.GetShopPriceType(id);
                    }

                case TITEMGROUP.ITEM_TYPE_SETITEM:
                    {
                        return SetItems.GetShopPriceType(id);
                    }

                case TITEMGROUP.ITEM_TYPE_SKIN:
                    {
                        return Titles.GetShopPriceType(id);
                    }

                case TITEMGROUP.ITEM_TYPE_MASCOT:
                    {
                        return Mascots.GetShopPriceType(id);
                    }

                case TITEMGROUP.ITEM_TYPE_CARD:
                    {
                        return Cards.GetShopPriceType(id);
                    }

                case TITEMGROUP.ITEM_TYPE_AUX:
                    {
                        return AuxParts.GetShopPriceType(id);
                    }

            }

            return -1;
        }


        public uint GetPrice(int id, uint Day = 1)
        {
            switch ((TITEMGROUP)Tools.GetItemGroup((uint)id))
            {
                case TITEMGROUP.ITEM_TYPE_CHARACTER:
                    {
                        return Characters.GetPrice(id);
                    }

                case TITEMGROUP.ITEM_TYPE_HAIR_STYLE:
                    {
                        return HairStyles.GetPrice(id);
                    }

                case TITEMGROUP.ITEM_TYPE_PART:
                    {
                        return Parts.GetPrice(id);
                    }

                case TITEMGROUP.ITEM_TYPE_CLUB:
                    {
                        return ClubSets.GetPrice(id);
                    }

                case TITEMGROUP.ITEM_TYPE_BALL:
                    {
                        return Balls.GetPrice(id);
                    }

                case TITEMGROUP.ITEM_TYPE_USE:
                    {
                        return Items.GetPrice(id);
                    }

                case TITEMGROUP.ITEM_TYPE_CADDIE:
                    {
                        return Caddies.GetPrice(id);
                    }

                case TITEMGROUP.ITEM_TYPE_CADDIE_ITEM:
                    {
                        return CaddieGetPrice((uint)id, Day);
                    }

                case TITEMGROUP.ITEM_TYPE_SETITEM:
                    {
                        return SetItems.GetPrice(id);
                    }

                case TITEMGROUP.ITEM_TYPE_SKIN:
                    {
                        return SkinGetPrice((uint)id, Day);
                    }

                case TITEMGROUP.ITEM_TYPE_MASCOT:
                    {
                        return MascotGetPrice((uint)id, Day);
                    }

                case TITEMGROUP.ITEM_TYPE_CARD:
                    {
                        return Cards.GetPrice(id);
                    }

                case TITEMGROUP.ITEM_TYPE_AUX:
                    {
                        return AuxParts.GetPrice(id);
                    }

            }

            return 0;
        }



        public ItemLevelEnum GetLevel(int id, int Day)
        {
            var Level = ItemLevelEnum.ROOKIE_F;
            switch ((TITEMGROUP)Tools.GetItemGroup((uint)id))
            {
                case TITEMGROUP.ITEM_TYPE_CHARACTER:
                    {
                        Level = Characters.GetLevel(id);
                    }
                    break;
                case TITEMGROUP.ITEM_TYPE_HAIR_STYLE:
                    {
                        Level = HairStyles.GetLevel(id);
                    }
                    break;
                case TITEMGROUP.ITEM_TYPE_PART:
                    {
                        Level = Parts.GetLevel(id);
                    }
                    break;
                case TITEMGROUP.ITEM_TYPE_CLUB:
                    {
                        Level = ClubSets.GetLevel(id);
                    }
                    break;
                case TITEMGROUP.ITEM_TYPE_BALL:
                    {
                        Level = Balls.GetLevel(id);
                    }
                    break;
                case TITEMGROUP.ITEM_TYPE_USE:
                    {
                        Level = Items.GetLevel(id);
                    }
                    break;
                case TITEMGROUP.ITEM_TYPE_CADDIE:
                    {
                        Level = Caddies.GetLevel(id);
                    }
                    break;
                case TITEMGROUP.ITEM_TYPE_CADDIE_ITEM:
                    {
                        Level = CaddiesItem.GetLevel(id);
                    }
                    break;
                case TITEMGROUP.ITEM_TYPE_SETITEM:
                    {
                        Level = SetItems.GetLevel(id);
                    }
                    break;


            }

            return (ItemLevelEnum)Level;
        }

        public uint GetRealQuantity(int id, uint quantity)
        {
            switch ((TITEMGROUP)Tools.GetItemGroup((uint)id))
            {

                case TITEMGROUP.ITEM_TYPE_BALL:
                    {
                        return BallGetRealQuantity(id, quantity);
                    }
                case TITEMGROUP.ITEM_TYPE_USE:
                    {
                        return ItemsGetRealQuantity(id, quantity);
                    }

            }
            return quantity;
        }

        public uint BallGetRealQuantity(int id, uint quantity)
        {
            var Items = Balls.FirstOrDefault(c => c.Header.ID == id && c.Header.Active == 1);

            if (Items == null)
            {
                return 0;
            }

            if (Items.Power > 0)
            {
                return quantity;
            }

            return quantity;
        }

        public uint ItemsGetRealQuantity(int id, uint quantity)
        {
            var items = Items.FirstOrDefault(c => c.Header.ID == id && c.Header.Active == 1);

            if (items == null)
            {
                return 0;
            }

            if (items.Power > 0)
            {
                return quantity;
            }

            return quantity;
        }


        public string GetSetItemStr(uint TypeId)
        {
            string result = "";
            UInt32 Count;
            if (!ListSetItem.TryGetValue(TypeId, out SetItem itemSet))
            {
                return "";
            }
            if (itemSet.Header.Active == 1)
            {
                for (Count = 0; Count <= 9; Count++)
                {
                    if (!(itemSet.TypeID[Count] > 0))
                    {
                        break;
                    }
                    result = result + $"{itemSet.TypeID[Count]}, {Tools.IfCompare<uint>(itemSet.QNT[Count] > 0, itemSet.QNT[Count], 1)}";
                }
                return result;
            }
            return "";
        }


        /// <summary>
        /// Key = TypeID, value = quantity
        /// </summary>
        /// <param name="TypeID"></param>
        /// <returns></returns>
        public List<Dictionary<uint, uint>> SetList(uint TypeID)
        {
            var result = new List<Dictionary<uint, uint>>();

            byte Count;
            if (!ListSetItem.TryGetValue(TypeID, out SetItem itemSet))
            {
                result.Add(new Dictionary<uint, uint> { { 0, 0 } });
                return result;
            }
            for (Count = 0; Count <= itemSet.TypeID.Length - 1; Count++)
            {
                if (itemSet.TypeID[Count] > 0)
                {
                    result.Add(new Dictionary<uint, uint> { { itemSet.TypeID[Count], Tools.IfCompare<uint>(itemSet.QNT[Count] == 0, 1, itemSet.QNT[Count]) } });
                }
            }
            return result;
        }
        public SortedList<uint, uint> GetItemMagic(uint MagicID)
        {
            var result = new SortedList<uint, uint>();

            if (!MagicBox.TryGetValue(MagicID, out CadieMagicBox MGBox))
            {
                result.Add(0, 0);
                return result;
            }
            result.Add(MGBox.Header.ID, MGBox.Quatity);
            return result;
        }

        public List<SortedList<uint, uint>> GetMagicTrade(uint MagicID)
        {
            var result = new List<SortedList<uint, uint>>();
            byte Count;
            if (!MagicBox.TryGetValue(MagicID, out CadieMagicBox MGBox))
            {
                result.Add(new SortedList<uint, uint> { { 0, 0 } });
                return result;
            }

            for (Count = 0; Count <= MGBox.TradeID.Length - 1; Count++)
            {
                if (MGBox.TradeID[Count] > 0)
                {
                    result.Add(new SortedList<uint, uint> { { MGBox.TradeID[Count], MGBox.TradeQuantity[Count] } });
                }
            }
            return result;
        }

        public uint CaddieGetPrice(uint typeID, uint ADay)
        {
            var Day = new uint();
            var caddie = CaddiesItem.FirstOrDefault(c => c.Header.ID == typeID && c.Header.Active == 1);
            if (caddie != null)
            {
                switch (ADay)
                {

                    case 1:
                        {
                            Day = caddie.Price1Day;
                        }
                        break;
                    case 15:
                        {
                            Day = caddie.Price15Day;
                        }
                        break;
                    case 30:
                        {
                            Day = caddie.Price30Day;
                        }
                        break;
                }
                if (caddie.Price1Day == 0 && caddie.Price15Day == 0 && caddie.Price30Day == 0)
                {
                    Day = caddie.Header.Price;
                }
            }
            return Day;
        }

        public uint SkinGetPrice(uint typeID, uint ADay)
        {
            var Day = new uint();
            var skin = Titles.Where(c => c.Header.ID == typeID && c.Header.Active == 1).FirstOrDefault();
            if (skin != null)
            {
                switch (ADay)
                {
                    case 15:
                        {
                            Day = skin.Price15Day;
                        }
                        break;
                    case 30:
                        {
                            Day = skin.Price30Day;
                        }
                        break;
                    case 365:
                        {
                            Day = skin.Price365Day;
                        }
                        break;
                }
                if (skin.Price15Day == 0 && skin.Price30Day == 0 && skin.Price365Day == 0)
                {
                    Day = skin.Header.Price;
                }

            }
            return Day;
        }


        public bool IsSelfDesign(uint TypeId)
        {
            switch (TypeId)
            {
                case 134258720:
                case 134242351:
                case 134258721:
                case 134242355:
                case 134496433:
                case 134496434:
                case 134512665:
                case 134496344:
                case 134512666:
                case 134496345:
                case 134783001:
                case 134758439:
                case 134783002:
                case 134758443:
                case 135020720:
                case 135020721:
                case 135045144:
                case 135020604:
                case 135045145:
                case 135020607:
                case 135299109:
                case 135282744:
                case 135299110:
                case 135282745:
                case 135545021:
                case 135545022:
                case 135569438:
                case 135544912:
                case 135569439:
                case 135544915:
                case 135807173:
                case 135807174:
                case 135823379:
                case 135807066:
                case 135823380:
                case 135807067:
                case 136093719:
                case 136069163:
                case 136093720:
                case 136069166:
                case 136331407:
                case 136331408:
                case 136355843:
                case 136331271:
                case 136355844:
                case 136331272:
                case 136593549:
                case 136593550:
                case 136617986:
                case 136593410:
                case 136617987:
                case 136593411:
                case 136880144:
                case 136855586:
                case 136880145:
                case 136855587:
                case 136855588:
                case 136855589:
                case 137379868:
                case 137379869:
                case 137404426:
                case 137379865:
                case 137404427:
                case 137379866:
                case 137904143:
                case 137904144:
                case 137928708:
                case 137904140:
                case 137928709:
                case 137904141:
                    {
                        return true;
                    }

            }
            return false;
        }

        public byte GetItemTimeFlag(uint typeID)
        {
            switch ((TITEMGROUP)Tools.GetItemGroup(typeID))
            {
                case TITEMGROUP.ITEM_TYPE_CADDIE:
                    {
                        if (CaddieGetSalary(typeID) > 0)
                        {
                            return 2;
                        }
                        return 0;
                    }
                case TITEMGROUP.ITEM_TYPE_SKIN:
                    {
                        return SkinGetFlag(typeID);
                    }
                case TITEMGROUP.ITEM_TYPE_MASCOT:
                    {
                        return 4;
                    }

            }
            return 0;
        }
        public uint MascotGetPrice(uint typeID, uint ADay)
        {
            var get = new uint();
            var items = Mascots.FirstOrDefault(c => c.Header.ID == typeID && c.Header.Active == 1);
            if (items != null)
            {
                switch (ADay)
                {

                    case 1:
                        {
                            get = items.Price1Day;
                        }
                        break;
                    case 7:
                        {
                            get = items.Price7Day;
                        }
                        break;
                    case 30:
                        {
                            get = items.Price30Day;
                        }
                        break;
                }
                if (items.Price1Day == 0 && items.Price7Day == 0 && items.Price30Day == 0)
                {
                    get = items.Header.Price;
                }

            }
            return get;
        }



        public uint CaddieGetSalary(uint typeID)
        {
            var items = Caddies.FirstOrDefault(c => c.Header.ID == typeID && c.Header.Active == 1);
            if (items != null)
            {
                return items.Salary;
            }
            return 0;
        }

        public byte SkinGetFlag(uint typeID)
        {
            var get = 0;
            var skin = Titles.FirstOrDefault(c => c.Header.ID == typeID && c.Header.Active == 1);


            if (skin != null)
            {
                if (skin.Price15Day == 0 && skin.Price30Day == 0 && skin.Price365Day == 0)
                {

                }
                else
                {
                    get = 0x20;
                }
            }

            return (byte)get;
        }
        public TClubStatus ClubData(uint TypeID)
        {
            var ClubInfo = new TClubStatus();
            var result = ClubSets.GetById((int)TypeID);

            if (result == null)
            {
                return null;
            }
            ClubInfo.Power = result.PowerSlot;
            ClubInfo.Control = result.ControlSlot;
            ClubInfo.Impact = result.AccuracySlot;
            ClubInfo.Spin = result.SpinSlot;
            ClubInfo.Curve = result.CurveSlot;
            ClubInfo.ClubType = result.ClubType;
            ClubInfo.ClubSPoint = (byte)result.ClubSPoint;
            return ClubInfo;
        }
        #endregion
    }
}
