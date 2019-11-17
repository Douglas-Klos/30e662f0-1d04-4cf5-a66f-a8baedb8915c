using System;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace FFXIV_Trainer
{


    class FinalFantasy
    {
        public Offsets offsets;
        public Dictionary<string, short[]> CraftingSpells;
        public Dictionary<string, string[]> Macros;

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess, Int64 lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);
        
        [DllImport("user32.dll")]
        public static extern IntPtr PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        
        private const int PROCESS_WM_READ = 0x0010;
        private Process process;
        
        private IntPtr processHandle = IntPtr.Zero;
        private IntPtr BaseAddress = IntPtr.Zero;
        private IntPtr ReadAddress = IntPtr.Zero;
        private long new_addr = 0;
        
        public FinalFantasy()
        {
            KeyboardScanCodes ksc = new KeyboardScanCodes();
            
       
            offsets = load_offsets(); 
            process = Process.GetProcessesByName("ffxiv_dx11")[0];
            processHandle = OpenProcess(PROCESS_WM_READ, false, process.Id);
            BaseAddress = process.MainModule.BaseAddress;

            // Final Fantasy XIV Crafting Spell Declarations
            // {Spell Name: {Key, Modifier, Sleep}}
            CraftingSpells = new Dictionary<string, short[]>()
            {
                // Hotbar 1
                {"basic_synthesis", new short[] {ksc.get_key_code("1"), ksc.get_key_code("NULL"), 3000}},
                {"careful_synthesis", new short[] {ksc.get_key_code("2"), ksc.get_key_code("NULL"), 3000}},
                {"delicate_synthesis", new short[]  {ksc.get_key_code("3"), ksc.get_key_code("NULL"), 3000}},
                {"basic_touch", new short[]  {ksc.get_key_code("4"), ksc.get_key_code("NULL"), 3000}},
                {"standard_touch", new short[]  {ksc.get_key_code("5"), ksc.get_key_code("NULL"), 3000}},
                {"preperatory_touch", new short[]  {ksc.get_key_code("6"), ksc.get_key_code("NULL"), 3000}},
                {"byregots_blessing", new short[]  {ksc.get_key_code("7"), ksc.get_key_code("NULL"), 3000}},
                {"manipulation", new short[]  {ksc.get_key_code("8"), ksc.get_key_code("NULL"), 2000}},
                {"great_strides", new short[]  {ksc.get_key_code("9"), ksc.get_key_code("NULL"), 2000}},
                {"innovation", new short[]  {ksc.get_key_code("0"), ksc.get_key_code("NULL"), 2000}},
                {"ingenuity", new short[]  {ksc.get_key_code("MINUS"), ksc.get_key_code("NULL"), 2000}},
                {"reflect", new short[]  {ksc.get_key_code("PLUS"), ksc.get_key_code("NULL"), 3000}},

                // Horbar 2
                {"rapid_synthesis", new short[] {ksc.get_key_code("1"), ksc.get_key_code("LSHIFT"), 3000}},
                {"intensive_synthesis", new short[] {ksc.get_key_code("2"), ksc.get_key_code("LSHIFT"), 3000}},
                {"focused_synthesis", new short[]  {ksc.get_key_code("3"), ksc.get_key_code("LSHIFT"), 3000}},
                {"observe", new short[]  {ksc.get_key_code("4"), ksc.get_key_code("LSHIFT"), 2000}},
                {"focused_touch", new short[]  {ksc.get_key_code("5"), ksc.get_key_code("LSHIFT"), 3000}},
                {"precise_touch", new short[]  {ksc.get_key_code("6"), ksc.get_key_code("LSHIFT"), 3000}},
                {"prudent_touch", new short[]  {ksc.get_key_code("7"), ksc.get_key_code("LSHIFT"), 3000}},
                {"patient_touch", new short[]  {ksc.get_key_code("8"), ksc.get_key_code("LSHIFT"), 3000}},
                {"hasty_touch", new short[]  {ksc.get_key_code("9"), ksc.get_key_code("LSHIFT"), 3000}},
                {"trained_eye", new short[]  {ksc.get_key_code("MINUS"), ksc.get_key_code("LSHIFT"), 3000}},
                {"inner_quiet", new short[]  {ksc.get_key_code("PLUS"), ksc.get_key_code("LSHIFT"), 2000}},

                // Hotbar 3
                {"name_of_the_elements", new short[] {ksc.get_key_code("1"), ksc.get_key_code("LCONTROL"), 2000}},
                {"brand_of_the_elements", new short[] {ksc.get_key_code("2"), ksc.get_key_code("LCONTROL"), 3000}},
                {"waste_not", new short[]  {ksc.get_key_code("3"), ksc.get_key_code("LCONTROL"), 2000}},
                {"waste_not_2", new short[]  {ksc.get_key_code("4"), ksc.get_key_code("LCONTROL"), 2000}},
                {"muscle_memory", new short[]  {ksc.get_key_code("5"), ksc.get_key_code("LCONTROL"), 3000}},
                {"masters_mend", new short[]  {ksc.get_key_code("6"), ksc.get_key_code("LCONTROL"), 2000}},
                {"tricks_of_the_trade", new short[]  {ksc.get_key_code("7"), ksc.get_key_code("LCONTROL"), 2000}},
                {"reuse", new short[]  {ksc.get_key_code("9"), ksc.get_key_code("LCONTROL"), 2000}},
                {"careful_observation", new short[]  {ksc.get_key_code("0"), ksc.get_key_code("LCONTROL"), 3000}},
                {"final_apprasial", new short[]  {ksc.get_key_code("MINUS"), ksc.get_key_code("LCONTROL"), 2000}},
                {"collectable_synthesis", new short[]  {ksc.get_key_code("PLUS"), ksc.get_key_code("LCONTROL"), 2000}}
            };

            Macros = new Dictionary<string, string[]>()
            {
                {"35d 538cp", new string[] {"reflect", "manipulation", "ingenuity", "innovation", "delicate_synthesis", "delicate_synthesis", "delicate_synthesis", "delicate_synthesis", "ingenuity", "innovation", "manipulation", "delicate_synthesis", "great_strides", "byregots_blessing", "careful_synthesis"}},
                {"35d 606cp", new string[] {"reflect", "manipulation", "ingenuity", "innovation", "delicate_synthesis",  "delicate_synthesis",  "delicate_synthesis",  "delicate_synthesis", "ingenuity", "innovation", "manipulation",  "delicate_synthesis", "basic_touch", "basic_touch", "ingenuity", "innovation", "basic_touch", "great_strides", "byregots_blessing", "basic_synthesis"}},
                {"70d 538cp", new string[] {"reflect", "ingenuity", "innovation", "delicate_synthesis", "delicate_synthesis", "delicate_synthesis", "delicate_synthesis", "manipulation", "ingenuity", "innovation", "delicate_synthesis", "delicate_synthesis", "great_strides", "byregots_blessing", "careful_synthesis"}},
                {"70d 620cp", new string[] {"reflect", "ingenuity", "innovation", "delicate_synthesis",  "delicate_synthesis",  "delicate_synthesis",  "delicate_synthesis", "manipulation", "ingenuity", "innovation", "delicate_synthesis", "delicate_synthesis", "delicate_synthesis", "delicate_synthesis", "prudent_touch", "great_strides", "ingenuity", "innovation", "standard_touch", "great_strides", "byregots_blessing", "careful_synthesis"}},
            };
        }

        public Offsets load_offsets()
        {
            var offsets = new Offsets();

            XmlDocument doc = new XmlDocument();
            doc.Load("d://users//douglas klos//git//ffxiv-trainer//ffxiv_trainer//offsets.xml");

            offsets.target_name = new List<string>(doc.SelectSingleNode("Offsets/target_name").InnerXml.Split(','));
            offsets.current_hp = new List<string>(doc.SelectSingleNode("Offsets/current_hp").InnerXml.Split(','));
            offsets.max_hp = new List<string>(doc.SelectSingleNode("Offsets/max_hp").InnerXml.Split(','));
            offsets.current_mana = new List<string> (doc.SelectSingleNode("Offsets/current_mana").InnerXml.Split(','));
            offsets.max_mana = new List<string> (doc.SelectSingleNode("Offsets/max_mana").InnerXml.Split(','));
            offsets.lowest_marketboard_price = new List<string>(doc.SelectSingleNode("Offsets/lowest_marketboard_price").InnerXml.Split(','));
            offsets.lowest_marketboard_price_quality = new List<string>(doc.SelectSingleNode("Offsets/lowest_marketboard_price_quality").InnerXml.Split(','));

            return offsets;

        }

        public string get_target_name() => Encoding.ASCII.GetString(read_memory(this.offsets.target_name, 24));
        public int get_max_mana() => BitConverter.ToInt32(read_memory(this.offsets.max_mana, 4), 0);
        public int get_current_mana() => BitConverter.ToInt32(read_memory(this.offsets.current_mana, 4), 0);
        public int get_max_hp() => BitConverter.ToInt32(read_memory(this.offsets.max_hp, 4), 0);
        public int get_current_hp() => BitConverter.ToInt32(read_memory(this.offsets.current_hp, 4), 0);
        public int get_lowest_marketboard_price() => BitConverter.ToInt32(read_memory(this.offsets.lowest_marketboard_price, 4), 0);
        public int get_lowest_marketboard_price_quality(List<string> quality_offsets) => BitConverter.ToInt32(read_memory(quality_offsets, 4), 0);
        public void send_key_down(short key) => PostMessage(process.MainWindowHandle, 0x100, (IntPtr)key, IntPtr.Zero);
        public void send_key_up(short key) => PostMessage(process.MainWindowHandle, 0x101, (IntPtr)key, IntPtr.Zero);
        public int get_next_price()
        {
            var next_price = new List<String>(this.offsets.lowest_marketboard_price);
            //List<string> next_price = this.offsets.lowest_marketboard_price;
            //Console.WriteLine(this.offsets.lowest_marketboard_price[this.offsets.lowest_marketboard_price.Count -+1].ToString());
            next_price[next_price.Count - 1] = ((Convert.ToInt32(this.offsets.lowest_marketboard_price[this.offsets.lowest_marketboard_price.Count - 1], 16) + 0x18)).ToString("X").ToString();
            //Console.WriteLine(this.offsets.lowest_marketboard_price[this.offsets.lowest_marketboard_price.Count - 1].ToString());
            //Console.WriteLine((Convert.ToInt32(this.offsets.lowest_marketboard_price[this.offsets.lowest_marketboard_price.Count - 1], 16) + 0x18).ToString("X"));
            Console.WriteLine(this.offsets.lowest_marketboard_price[this.offsets.lowest_marketboard_price.Count - 1].ToString());
            Console.WriteLine(next_price[next_price.Count - 1].ToString());
            return BitConverter.ToInt32(read_memory(next_price, 4), 0);
            //return get_lowest_marketboard_price();
        }
        public int get_quality()
        {
            var quality_offsets = new List<String>(this.offsets.lowest_marketboard_price);
            quality_offsets[quality_offsets.Count - 1] = ((Convert.ToInt32(this.offsets.lowest_marketboard_price[this.offsets.lowest_marketboard_price.Count - 1], 16) + 0x08)).ToString("X").ToString();

            return get_lowest_marketboard_price_quality(quality_offsets);
        }
        public void send_key_down_up(short key)
        {
            send_key_down(key);
            send_key_up(key);
        }

        public byte[] read_memory(List<string> offsets, int bytes)
        {
            int bytesRead = 0;
            byte[] buffer = new byte[8];

            ReadAddress = IntPtr.Add(BaseAddress, Convert.ToInt32(offsets[0], 16));
            
            ReadProcessMemory((int)processHandle, ReadAddress.ToInt64(), buffer, buffer.Length, ref bytesRead);

            int loop_counter = 0;

            foreach (var ptr in offsets)
            {
                if (loop_counter > 0) // Skip the first element, we already added it in above.
                {
                    new_addr = BitConverter.ToInt64(buffer, 0);
                    new_addr += Convert.ToInt32(ptr, 16);
                    ReadProcessMemory((int)processHandle, new_addr, buffer, buffer.Length, ref bytesRead);
                }
                loop_counter++;
            }

            bytesRead = 0;
            buffer = new byte[bytes];

            ReadProcessMemory((int)processHandle, new_addr, buffer, buffer.Length, ref bytesRead);

            return buffer;
        }

        public class Offsets
        {
            public List<string> target_name { get; set; }
            public List<string> current_hp { get; set; }
            public List<string> max_hp { get; set; }
            public List<string> current_mana { get; set; }
            public List<string> max_mana { get; set; }
            public List<string> lowest_marketboard_price { get; set; }
            public List<string> lowest_marketboard_price_quality { get; set; }

        }
    }
}
