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
        private Dictionary<string, string[]> macros;
        private Dictionary<string, short[]> craftingSpells;

        private Process process;
        private IntPtr processHandle = IntPtr.Zero;
        private IntPtr baseAddress = IntPtr.Zero;
        private IntPtr readAddress = IntPtr.Zero;
        private long newAddress = 0;

        private bool online = false;

        public FinalFantasy()
        {
            this.offsets = this.LoadOffsets();
            ////process = Process.GetProcessesByName("ffxiv_dx11")[0];
            ////processHandle = OpenProcess(PROCESS_WM_READ, false, process.Id);
            ////baseAddress = process.MainModule.BaseAddress;
            this.craftingSpells = this.CreateCraftingDictionary();
            this.macros = this.CreateMacroDictionary();
        }

        public Dictionary<string, string[]> GetMacros() => this.macros;

        public Dictionary<string, short[]> GetCraftingSpells() => this.craftingSpells;

        public string GetTargetName() => Encoding.ASCII.GetString(this.ReadFromMemory(this.offsets.TargetName, 24));

        public int GetMaxMana() => BitConverter.ToInt32(this.ReadFromMemory(this.offsets.MaxMana, 4), 0);

        public int GetCurrentMana() => BitConverter.ToInt32(this.ReadFromMemory(this.offsets.CurrentMana, 4), 0);

        public int GetMaxHP() => BitConverter.ToInt32(this.ReadFromMemory(this.offsets.MaxHP, 4), 0);

        public int GetCurrentHP() => BitConverter.ToInt32(this.ReadFromMemory(this.offsets.CurrentHP, 4), 0);

        public int GetLowestMarketboardPrice() => BitConverter.ToInt32(this.ReadFromMemory(this.offsets.LowestMarketPrice, 4), 0);

        public int GetLowestMarketboardPriceQuality(List<string> quality_offsets) => BitConverter.ToInt32(this.ReadFromMemory(quality_offsets, 4), 0);

        public int GetNextPrice()
        {
            var next_price = new List<string>(this.offsets.LowestMarketPrice);
            next_price[next_price.Count - 1] = (Convert.ToInt32(this.offsets.LowestMarketPrice[this.offsets.LowestMarketPrice.Count - 1], 16) + 0x18).ToString("X").ToString();
            Console.WriteLine(this.offsets.LowestMarketPrice[this.offsets.LowestMarketPrice.Count - 1].ToString());
            Console.WriteLine(next_price[next_price.Count - 1].ToString());
            return BitConverter.ToInt32(this.ReadFromMemory(next_price, 4), 0);
        }

        public int GetQuality()
        {
            var quality_offsets = new List<string>(this.offsets.LowestMarketPrice);
            quality_offsets[quality_offsets.Count - 1] = (Convert.ToInt32(this.offsets.LowestMarketPrice[this.offsets.LowestMarketPrice.Count - 1], 16) + 0x08).ToString("X").ToString();

            return this.GetLowestMarketboardPriceQuality(quality_offsets);
        }

        public void SendKeyDown(short key) => PostMessage(this.process.MainWindowHandle, 0x100, (IntPtr)key, IntPtr.Zero);

        public void SendKeyUp(short key) => PostMessage(this.process.MainWindowHandle, 0x101, (IntPtr)key, IntPtr.Zero);

        public void SendKeyDownUp(short key)
        {
            this.SendKeyDown(key);
            this.SendKeyUp(key);
        }

        public void PostFirstRetainer(int numberOfItems, int minimumPrice, int maximumPrice, int undercut, int resetPrice)
        {
            short select = this.ksc.get_key_code("NUMPAD0");

            Thread.Sleep(1000);
            this.SendKeyDownUp(select);
            Thread.Sleep(250);
            this.SendKeyDownUp(select);
            Thread.Sleep(2000);
            this.SendKeyDownUp(select);
            Thread.Sleep(1000);

            this.MarketUpdatePrices(numberOfItems, minimumPrice, maximumPrice, undercut, resetPrice);
        }

        public void PostSecondRetainer(int numberOfItems, int minimumPrice, int maximumPrice, int undercut, int resetPrice)
        {
            short select = this.ksc.get_key_code("NUMPAD0");
            short down = this.ksc.get_key_code("NUMPAD2");

            Thread.Sleep(1000);
            this.SendKeyDownUp(down);
            Thread.Sleep(100);
            this.SendKeyDownUp(down);
            Thread.Sleep(100);
            this.SendKeyDownUp(select);
            Thread.Sleep(3000);
            this.SendKeyDownUp(select);
            Thread.Sleep(1000);

            this.MarketUpdatePrices(numberOfItems, minimumPrice, maximumPrice, undercut, resetPrice);
        }

        public void MarketUpdatePrices(int numberOfItems, int minimumPrice, int maximumPrice, int undercut, int resetPrice)
        {
            int lowest_price = 0;
            int new_price = 0;

            short select = this.ksc.get_key_code("NUMPAD0");
            short up = this.ksc.get_key_code("NUMPAD8");
            short down = this.ksc.get_key_code("NUMPAD2");
            short escape = this.ksc.get_key_code("ESCAPE");
            short enter = this.ksc.get_key_code("RETURN");

            Thread.Sleep(1000);
            this.SendKeyDownUp(down);
            Thread.Sleep(250);
            this.SendKeyDownUp(down);
            Thread.Sleep(250);
            this.SendKeyDownUp(select);
            Thread.Sleep(1000);

            for (int loop_counter = 0; loop_counter < numberOfItems; loop_counter++)
            {
                this.SendKeyDownUp(select);
                Thread.Sleep(150);
                this.SendKeyDownUp(select);
                Thread.Sleep(150);
                this.SendKeyDownUp(up);
                Thread.Sleep(150);
                this.SendKeyDownUp(select);
                Thread.Sleep(1500);

                // this.AppendTextBox("Updating item #" + loop_counter + "\n");
                if (this.GetQuality() == 0)
                {
                    // this.AppendTextBox(". . . First listed item is low quality\n");
                    // this.AppendTextBox(". . . Price of second item :" + this.ffxiv.GetNextPrice() + "\n");
                    lowest_price = this.GetNextPrice();
                }
                else
                {
                    lowest_price = this.GetLowestMarketboardPrice();
                }

                new_price = lowest_price - undercut;

                // this.AppendTextBox(". . . lowest price: " + lowest_price + "\n");
                if (new_price < minimumPrice)
                {
                    // this.AppendTextBox(". . . item under minimum price, posting at default");
                    new_price = resetPrice;
                }

                if (new_price > maximumPrice)
                {
                    // this.AppendTextBox(". . . item over maximum price, posting at default");
                    new_price = resetPrice;
                }

                // this.AppendTextBox(". . . posted price: " + new_price + "\n");
                this.SendKeyDownUp(escape);
                Thread.Sleep(150);
                this.SendKeyDownUp(down);
                Thread.Sleep(150);
                this.SendKeyDownUp(select);
                Thread.Sleep(150);
                this.SendKeyDownUp(enter);
                Thread.Sleep(150);
                this.SendKeyDownUp(escape);
                Thread.Sleep(150);

                foreach (char letter in new_price.ToString())
                {
                    this.SendKeyDown(this.ksc.get_key_code(letter.ToString()));
                    Thread.Sleep(50);
                }

                this.SendKeyDownUp(enter);
                Thread.Sleep(150);
                this.SendKeyDownUp(down);
                Thread.Sleep(100);
                this.SendKeyDownUp(down);
                Thread.Sleep(100);
                this.SendKeyDownUp(select);
                Thread.Sleep(250);
                this.SendKeyDownUp(down);
                Thread.Sleep(100);
            }

            this.SendKeyDownUp(escape);
            Thread.Sleep(150);
            this.SendKeyDownUp(escape);
            Thread.Sleep(150);
            this.SendKeyDownUp(select);
            Thread.Sleep(150);
            this.SendKeyDownUp(escape);
            Thread.Sleep(150);
        }

        [DllImport("kernel32.dll")]
        private static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        private static extern bool ReadProcessMemory(int hProcess, long lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        [DllImport("user32.dll")]
        private static extern IntPtr PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

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

        private byte[] ReadFromMemory(List<string> offsets, int bytes)
        {
            int bytesRead = 0;
            byte[] buffer = new byte[8];

            this.readAddress = IntPtr.Add(this.baseAddress, Convert.ToInt32(offsets[0], 16));
            
            ReadProcessMemory((int)this.processHandle, this.readAddress.ToInt64(), buffer, buffer.Length, ref bytesRead);

            int loop_counter = 0;

            foreach (var ptr in offsets)
            {
                // Skip the first element, we already added it in above.
                if (loop_counter > 0)
                {
                    this.newAddress = BitConverter.ToInt64(buffer, 0);
                    this.newAddress += Convert.ToInt32(ptr, 16);
                    ReadProcessMemory((int)this.processHandle, this.newAddress, buffer, buffer.Length, ref bytesRead);
                }

                loop_counter++;
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
        }
    }
}
