namespace FFXIV_Trainer
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Xml;

    public class FinalFantasy
    {


        private const int PROCESS_WM_READ = 0x0010;

        private Offsets offsets;
        private KeyboardScanCodes ksc = new KeyboardScanCodes();
        private Dictionary<string, short> keybinds;
        private Dictionary<string, string[]> macros;
        private Dictionary<string, short[]> craftingSpells;
        
        private List<(string, string)> firstItemsForSale;
        private List<(string, string)> secondItemsForSale;

        private Process process;
        private IntPtr processHandle = IntPtr.Zero;
        private IntPtr baseAddress = IntPtr.Zero;
        private IntPtr readAddress = IntPtr.Zero;
        private long newAddress = 0;

        private bool online = false;

        public FinalFantasy()
        {
            this.offsets = this.LoadOffsets();

            this.process = Process.GetProcessesByName("ffxiv_dx11")[0];
            this.processHandle = OpenProcess(PROCESS_WM_READ, false, this.process.Id);
            this.baseAddress = this.process.MainModule.BaseAddress;

            this.keybinds = this.AssignKeybinds();
            this.craftingSpells = this.CreateCraftingDictionary();
            this.macros = this.CreateMacroDictionary();

            this.firstItemsForSale = new List<(string, string)>();
        }

        public List<(string, string)> GetFirstItemsForSale() => this.firstItemsForSale;

        public List<(string, string)> GetSecondItemsForSale() => this.secondItemsForSale;

        public Dictionary<string, string[]> GetMacros() => this.macros;

        public Dictionary<string, short[]> GetCraftingSpells() => this.craftingSpells;

        public byte[] GetValueFromRAM(string _offsets, int bytes) => ReadFromMemory(new List<string>(_offsets.Split(',')), bytes);
 
        public string GetTargetName() => Encoding.ASCII.GetString(this.ReadFromMemory(this.offsets.TargetName, 24));

        public int GetMaxMana() => BitConverter.ToInt32(this.ReadFromMemory(this.offsets.MaxMana, 4), 0);

        public int GetCurrentMana() => BitConverter.ToInt32(this.ReadFromMemory(this.offsets.CurrentMana, 4), 0);

        public int GetMaxHP() => BitConverter.ToInt32(this.ReadFromMemory(this.offsets.MaxHP, 4), 0);

        public int GetCurrentHP() => BitConverter.ToInt32(this.ReadFromMemory(this.offsets.CurrentHP, 4), 0);

        public int GetLowestMarketboardPrice() => BitConverter.ToInt32(this.ReadFromMemory(this.offsets.LowestMarketPrice, 4), 0);

        public int GetFirstHQPrice()
        {
            var currentPtr = new List<string>(this.offsets.LowestMarketPrice);
            var qualityOffset = new List<string>(this.offsets.LowestMarketPrice);

            qualityOffset[qualityOffset.Count - 1] = (Convert.ToInt32(currentPtr[currentPtr.Count - 1], 16) + 0x08).ToString("X").ToString();


            if (BitConverter.ToInt32(this.ReadFromMemory(qualityOffset, 4), 0) == 1)
            {
                return BitConverter.ToInt32(this.ReadFromMemory(currentPtr, 4), 0);
            }

            while (BitConverter.ToInt32(this.ReadFromMemory(qualityOffset, 4), 0) == 0)
            {
                currentPtr[currentPtr.Count - 1] = (Convert.ToInt32(currentPtr[currentPtr.Count - 1], 16) + 0x18).ToString("X").ToString();
                qualityOffset[qualityOffset.Count - 1] = (Convert.ToInt32(currentPtr[currentPtr.Count - 1], 16) + 0x08).ToString("X").ToString();
                if (BitConverter.ToInt32(this.ReadFromMemory(qualityOffset, 4), 0) == 1)
                {
                    return BitConverter.ToInt32(this.ReadFromMemory(currentPtr, 4), 0);
                }
            }

            return -1;
        }

        public (string, string) LoadFirstSellList()
        {
            //this.firstItemsForSale = new List<(string, string)>();

            var namePtr = new List<string>(this.offsets.RetainerSellList);
            namePtr[namePtr.Count - 1] = (Convert.ToInt32(namePtr[namePtr.Count - 1], 16) + 0x2A0).ToString("X").ToString();
            var pricePtr = new List<string>(namePtr);
            pricePtr[pricePtr.Count - 1] = (Convert.ToInt32(namePtr[namePtr.Count - 1], 16) + 0x5A).ToString("X").ToString();

            this.firstItemsForSale.Add(( Encoding.ASCII.GetString(this.ReadFromMemory(namePtr, 24)), Encoding.ASCII.GetString(this.ReadFromMemory(pricePtr, 9))));

            //firstItemsForSale.Add(("0", BitConverter.ToInt64(this.ReadFromMemory(this.offsets.RetainerSellList, 4), 0) ));
            //Console.WriteLine(int.Parse(Encoding.ASCII.GetString(this.ReadFromMemory(pricePtr, 9))));
            return firstItemsForSale[0];
            //return ("0", 0);
        }
              
        public void SendKeyDown(short key) => PostMessage(this.process.MainWindowHandle, 0x100, (IntPtr)key, IntPtr.Zero);

        public void SendKeyUp(short key) => PostMessage(this.process.MainWindowHandle, 0x101, (IntPtr)key, IntPtr.Zero);

        public void SendKeyDownUp(short key, int sleepTimer)
        {
            this.SendKeyDown(key);
            this.SendKeyUp(key);
            Thread.Sleep(sleepTimer);
        }

        public IEnumerable<string> PostFirstRetainer(int numberOfItems, int minimumPrice, int maximumPrice, int undercut, int resetPrice, bool? quality)
        {
            Thread.Sleep(1000);
            this.SendKeyDownUp(this.keybinds["select"], 250);
            this.SendKeyDownUp(this.keybinds["select"], 2000);
            this.SendKeyDownUp(this.keybinds["select"], 1000);

            foreach (var result in this.MarketUpdatePrices(numberOfItems, minimumPrice, maximumPrice, undercut, resetPrice, quality))
            {
                yield return result;
            }
        }

        public IEnumerable<string> PostSecondRetainer(int numberOfItems, int minimumPrice, int maximumPrice, int undercut, int resetPrice, bool? quality)
        {
            Thread.Sleep(1000);
            this.SendKeyDownUp(this.keybinds["down"], 100);
            this.SendKeyDownUp(this.keybinds["down"], 100);
            this.SendKeyDownUp(this.keybinds["select"], 3000);
            this.SendKeyDownUp(this.keybinds["select"], 1000);

            foreach (var result in this.MarketUpdatePrices(numberOfItems, minimumPrice, maximumPrice, undercut, resetPrice, quality))
            {
                yield return result;
            }
        }

        [DllImport("kernel32.dll")]
        private static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        private static extern bool ReadProcessMemory(int hProcess, long lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        [DllImport("user32.dll")]
        private static extern IntPtr PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        private IEnumerable<string> MarketUpdatePrices(int numberOfItems, int minimumPrice, int maximumPrice, int undercut, int resetPrice, bool? ignoreQuality)
        {
            int lowestPrice = 0;
            int newPrice = 0;

            Thread.Sleep(1000);
            this.SendKeyDownUp(this.keybinds["down"], 250);
            this.SendKeyDownUp(this.keybinds["down"], 250);
            this.SendKeyDownUp(this.keybinds["select"], 1000);
            Thread.Sleep(1000);
            for (int loopCounter = 0; loopCounter < numberOfItems; loopCounter++)
            {
                this.SendKeyDownUp(this.keybinds["select"], 150);
                this.SendKeyDownUp(this.keybinds["select"], 150);
                this.SendKeyDownUp(this.keybinds["up"], 150);
                this.SendKeyDownUp(this.keybinds["select"], 1500);
                
                yield return "Updating item #" + loopCounter + "\n";

                if (ignoreQuality is true)
                {
                    lowestPrice = this.GetLowestMarketboardPrice();
                    yield return ". . . ignoring quality, lowest price: " + lowestPrice;
                }
                else
                {
                    lowestPrice = this.GetFirstHQPrice();
                    yield return ". . . first HQ price: " + lowestPrice;

                }
                newPrice = lowestPrice - undercut;

                if (lowestPrice == -1)
                {
                    yield return ". . . no HQ items found, posting at reset price.";
                    newPrice = resetPrice;
                }
                else
                {
                    if (lowestPrice < minimumPrice)
                    {
                        yield return ". . . item under minimum price, posting at default";
                        newPrice = resetPrice;
                    }
                    else if (newPrice > maximumPrice)
                    {
                        yield return ". . . item over maximum price, posting at default";
                        newPrice = resetPrice;
                    }
                }

                yield return ". . . posting at: " + newPrice + "\n";

                this.SendKeyDownUp(this.keybinds["escape"], 150);
                this.SendKeyDownUp(this.keybinds["down"], 150);
                this.SendKeyDownUp(this.keybinds["select"], 150);
                this.SendKeyDownUp(this.keybinds["enter"], 150);
                this.SendKeyDownUp(this.keybinds["escape"], 150);
                
                foreach (char letter in newPrice.ToString())
                {
                    this.SendKeyDown(this.ksc.get_key_code(letter.ToString()));
                    Thread.Sleep(50);
                }

                this.SendKeyDownUp(this.keybinds["enter"], 150);
                this.SendKeyDownUp(this.keybinds["down"], 100);
                this.SendKeyDownUp(this.keybinds["down"], 100);
                this.SendKeyDownUp(this.keybinds["select"], 250);
                this.SendKeyDownUp(this.keybinds["down"], 100);
            }
            
            this.SendKeyDownUp(this.keybinds["escape"], 150);
            this.SendKeyDownUp(this.keybinds["escape"], 150);
            this.SendKeyDownUp(this.keybinds["select"], 150);
            this.SendKeyDownUp(this.keybinds["escape"], 150);
        }

        private Offsets LoadOffsets()
        {
            var offsets = new Offsets();
            XmlDocument doc = new XmlDocument();
            doc.Load("d://users//douglas klos//git//ffxiv-trainer//ffxiv_trainer//offsets.xml");

            offsets.TargetName = new List<string>(doc.SelectSingleNode("Offsets/TargetName").InnerXml.Split(','));
            offsets.CurrentHP = new List<string>(doc.SelectSingleNode("Offsets/CurrentHP").InnerXml.Split(','));
            offsets.MaxHP = new List<string>(doc.SelectSingleNode("Offsets/MaxHP").InnerXml.Split(','));
            offsets.CurrentMana = new List<string>(doc.SelectSingleNode("Offsets/CurrentMana").InnerXml.Split(','));
            offsets.MaxMana = new List<string>(doc.SelectSingleNode("Offsets/MaxMana").InnerXml.Split(','));
            offsets.LowestMarketPrice = new List<string>(doc.SelectSingleNode("Offsets/LowestMarketPrice").InnerXml.Split(','));
            offsets.RetainerSellList = new List<string>(doc.SelectSingleNode("Offsets/RetainerSellList").InnerXml.Split(','));

            return offsets;
        }

        private Dictionary<string, short[]> CreateCraftingDictionary()
        {
            // Final Fantasy XIV Crafting Spell Declarations
            // {Spell Name: {Key, Modifier, Sleep}}
            return new Dictionary<string, short[]>()
            {
                // Hotbar 1
                { "basic_synthesis", new short[] { this.ksc.get_key_code("1"), this.ksc.get_key_code("NULL"), 3000 } },
                { "careful_synthesis", new short[] { this.ksc.get_key_code("2"), this.ksc.get_key_code("NULL"), 3000 } },
                { "delicate_synthesis", new short[] { this.ksc.get_key_code("3"), this.ksc.get_key_code("NULL"), 3000 } },
                { "basic_touch", new short[] { this.ksc.get_key_code("4"), this.ksc.get_key_code("NULL"), 3000 } },
                { "standard_touch", new short[] { this.ksc.get_key_code("5"), this.ksc.get_key_code("NULL"), 3000 } },
                { "preperatory_touch", new short[] { this.ksc.get_key_code("6"), this.ksc.get_key_code("NULL"), 3000 } },
                { "byregots_blessing", new short[] { this.ksc.get_key_code("7"), this.ksc.get_key_code("NULL"), 3000 } },
                { "manipulation", new short[] { this.ksc.get_key_code("8"), this.ksc.get_key_code("NULL"), 2000 } },
                { "great_strides", new short[] { this.ksc.get_key_code("9"), this.ksc.get_key_code("NULL"), 2000 } },
                { "innovation", new short[] { this.ksc.get_key_code("0"), this.ksc.get_key_code("NULL"), 2000 } },
                { "ingenuity", new short[] { this.ksc.get_key_code("MINUS"), this.ksc.get_key_code("NULL"), 2000 } },
                { "reflect", new short[] { this.ksc.get_key_code("PLUS"), this.ksc.get_key_code("NULL"), 3000 } },

                // Horbar 2
                { "rapid_synthesis", new short[] { this.ksc.get_key_code("1"), this.ksc.get_key_code("LSHIFT"), 3000 } },
                { "intensive_synthesis", new short[] { this.ksc.get_key_code("2"), this.ksc.get_key_code("LSHIFT"), 3000 } },
                { "focused_synthesis", new short[] { this.ksc.get_key_code("3"), this.ksc.get_key_code("LSHIFT"), 3000 } },
                { "observe", new short[] { this.ksc.get_key_code("4"), this.ksc.get_key_code("LSHIFT"), 2000 } },
                { "focused_touch", new short[] { this.ksc.get_key_code("5"), this.ksc.get_key_code("LSHIFT"), 3000 } },
                { "precise_touch", new short[] { this.ksc.get_key_code("6"), this.ksc.get_key_code("LSHIFT"), 3000 } },
                { "prudent_touch", new short[] { this.ksc.get_key_code("7"), this.ksc.get_key_code("LSHIFT"), 3000 } },
                { "patient_touch", new short[] { this.ksc.get_key_code("8"), this.ksc.get_key_code("LSHIFT"), 3000 } },
                { "hasty_touch", new short[] { this.ksc.get_key_code("9"), this.ksc.get_key_code("LSHIFT"), 3000 } },
                { "trained_eye", new short[] { this.ksc.get_key_code("MINUS"), this.ksc.get_key_code("LSHIFT"), 3000 } },
                { "inner_quiet", new short[] { this.ksc.get_key_code("PLUS"), this.ksc.get_key_code("LSHIFT"), 2000 } },

                // Hotbar 3
                { "name_of_the_elements", new short[] { this.ksc.get_key_code("1"), this.ksc.get_key_code("LCONTROL"), 2000 } },
                { "brand_of_the_elements", new short[] { this.ksc.get_key_code("2"), this.ksc.get_key_code("LCONTROL"), 3000 } },
                { "waste_not", new short[] { this.ksc.get_key_code("3"), this.ksc.get_key_code("LCONTROL"), 2000 } },
                { "waste_not_2", new short[] { this.ksc.get_key_code("4"), this.ksc.get_key_code("LCONTROL"), 2000 } },
                { "muscle_memory", new short[] { this.ksc.get_key_code("5"), this.ksc.get_key_code("LCONTROL"), 3000 } },
                { "masters_mend", new short[] { this.ksc.get_key_code("6"), this.ksc.get_key_code("LCONTROL"), 2000 } },
                { "tricks_of_the_trade", new short[] { this.ksc.get_key_code("7"), this.ksc.get_key_code("LCONTROL"), 2000 } },
                { "reuse", new short[] { this.ksc.get_key_code("9"), this.ksc.get_key_code("LCONTROL"), 2000 } },
                { "careful_observation", new short[] { this.ksc.get_key_code("0"), this.ksc.get_key_code("LCONTROL"), 3000 } },
                { "final_apprasial", new short[] { this.ksc.get_key_code("MINUS"), this.ksc.get_key_code("LCONTROL"), 2000 } },
                { "collectable_synthesis", new short[] { this.ksc.get_key_code("PLUS"), this.ksc.get_key_code("LCONTROL"), 2000 } }
            };
        }

        private Dictionary<string, string[]> CreateMacroDictionary()
        {
            return new Dictionary<string, string[]>()
            {
                { "35d 538cp", new string[] { "reflect", "manipulation", "ingenuity", "innovation", "delicate_synthesis", "delicate_synthesis", "delicate_synthesis", "delicate_synthesis", "ingenuity", "innovation", "manipulation", "delicate_synthesis", "great_strides", "byregots_blessing", "careful_synthesis" } },
                { "35d 606cp", new string[] { "reflect", "manipulation", "ingenuity", "innovation", "delicate_synthesis",  "delicate_synthesis",  "delicate_synthesis",  "delicate_synthesis", "ingenuity", "innovation", "manipulation",  "delicate_synthesis", "basic_touch", "basic_touch", "ingenuity", "innovation", "basic_touch", "great_strides", "byregots_blessing", "basic_synthesis" } },
                { "70d 538cp", new string[] { "reflect", "ingenuity", "innovation", "delicate_synthesis", "delicate_synthesis", "delicate_synthesis", "delicate_synthesis", "manipulation", "ingenuity", "innovation", "delicate_synthesis", "delicate_synthesis", "great_strides", "byregots_blessing", "careful_synthesis" } },
                { "70d 620cp", new string[] { "reflect", "ingenuity", "innovation", "delicate_synthesis",  "delicate_synthesis",  "delicate_synthesis",  "delicate_synthesis", "manipulation", "ingenuity", "innovation", "delicate_synthesis", "delicate_synthesis", "delicate_synthesis", "delicate_synthesis", "prudent_touch", "great_strides", "ingenuity", "innovation", "standard_touch", "great_strides", "byregots_blessing", "careful_synthesis" } },
            };
        }

        private Dictionary<string, short> AssignKeybinds()
        {
            return new Dictionary<string, short>()
            {
                { "select", this.ksc.get_key_code("NUMPAD0") },
                { "up", this.ksc.get_key_code("NUMPAD8") },
                { "down", this.ksc.get_key_code("NUMPAD2") },
                { "escape", this.ksc.get_key_code("ESCAPE") },
                { "enter", this.ksc.get_key_code("RETURN") }
            };
        }

        private byte[] ReadFromMemory(List<string> offsets, int bytes)
        {
            int bytesRead = 0;
            byte[] buffer = new byte[8];

            this.readAddress = IntPtr.Add(this.baseAddress, Convert.ToInt32(offsets[0], 16));
            
            ReadProcessMemory((int)this.processHandle, this.readAddress.ToInt64(), buffer, buffer.Length, ref bytesRead);

            int loopCounter = 0;

            foreach (var ptr in offsets)
            {
                // Skip the first element, we already added it in above.
                if (loopCounter > 0)
                {
                    this.newAddress = BitConverter.ToInt64(buffer, 0);
                    this.newAddress += Convert.ToInt32(ptr, 16);
                    ReadProcessMemory((int)this.processHandle, this.newAddress, buffer, buffer.Length, ref bytesRead);
                }

                loopCounter++;
            }

            bytesRead = 0;
            buffer = new byte[bytes];

            ReadProcessMemory((int)this.processHandle, this.newAddress, buffer, buffer.Length, ref bytesRead);

            return buffer;
        }


        private class Offsets
        {
            public List<string> TargetName { get; set; }

            public List<string> CurrentHP { get; set; }

            public List<string> MaxHP { get; set; }

            public List<string> CurrentMana { get; set; }

            public List<string> MaxMana { get; set; }

            public List<string> LowestMarketPrice { get; set; }

            public List<string> RetainerSellList { get; set; }
        }
    }
}
