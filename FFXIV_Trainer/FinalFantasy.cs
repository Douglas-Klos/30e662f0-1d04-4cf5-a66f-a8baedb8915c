using System;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace FFXIV_Trainer
{
    class FinalFantasy
    {

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);
        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess, Int64 lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);
        [DllImport("user32.dll")]
        public static extern IntPtr PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        const int PROCESS_WM_READ = 0x0010;
        IntPtr processHandle = IntPtr.Zero;
        IntPtr BaseAddress = IntPtr.Zero;
        IntPtr ReadAddress = IntPtr.Zero;
        Int64 new_addr = 0;
        Process process;
        public Dictionary<string, short[]> CraftingSpells;
        public Dictionary<string, string[]> Macros;

        public FinalFantasy()
        {
            KeyboardScanCodes ksc = new KeyboardScanCodes();
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

        public string get_target_name()
        {
            int offset = 0x01C04D60;
            int[] ptrs = { 0x38, 0x80, 0x180, 0x18, 0x40, 0x230, 0xDA };
            byte[] buffer = new byte[24];
            buffer = read_memory(offset, ptrs, 24);
            return Encoding.ASCII.GetString(buffer);
        }

        public int get_current_mana()
        {
            int offset = 0x01C04D60;
            int[] ptrs = { 0x38, 0x18, 0x20, 0x20, 0x3C };
            byte[] buffer = new byte[4];
            buffer = read_memory(offset, ptrs, 4);
            return BitConverter.ToInt32(buffer, 0);
        }

        public int get_max_mana()
        {
            int offset = 0x01C04D60;
            int[] ptrs = { 0x108, 0x180, 0x38, 0x18, 0x20, 0x20, 0x40 };
            byte[] buffer = new byte[4];
            buffer = read_memory(offset, ptrs, 4);
            return BitConverter.ToInt32(buffer, 0);
        }

        public int get_max_hp()
        {
            int offset = 0x01C047A0;
            int[] ptrs = { 0x260, 0x2D8, 0x378, 0xDEC };
            byte[] buffer = new byte[4];
            buffer = read_memory(offset, ptrs, 4);
            return BitConverter.ToInt32(buffer, 0);
        }

        public int get_current_hp()
        {
            int offset = 0x01C047A0;
            int[] ptrs = { 0x140, 0x378, 0xB0, 0x10, 0xD40 };
            byte[] buffer = new byte[4];
            buffer = read_memory(offset, ptrs, 4);
            return BitConverter.ToInt32(buffer, 0);
        }
        
        public int get_lowest_marketboard_price()
        {
            int offset = 0x01C04D60;
            int[] ptrs = { 0x108, 0x180, 0x38, 0x10, 0x110, 0x20, 0x7D8 };
            byte[] buffer = new byte[4];
            buffer = read_memory(offset, ptrs, 4);
            return BitConverter.ToInt32(buffer, 0);
        }

        public void send_keys(short[] keys)
        {
            const uint WM_KEYDOWN = 0x100;
            const uint WM_KEYUP = 0x0101;

            IntPtr edit = process.MainWindowHandle;

            PostMessage(edit, WM_KEYDOWN, (IntPtr)(keys[1]), IntPtr.Zero);
            PostMessage(edit, WM_KEYDOWN, (IntPtr)(keys[0]), IntPtr.Zero);
            PostMessage(edit, WM_KEYUP, (IntPtr)(keys[0]), IntPtr.Zero);
            PostMessage(edit, WM_KEYUP, (IntPtr)(keys[1]), IntPtr.Zero);
        }

        public void send_key(short key)
        {
            const uint WM_KEYDOWN = 0x100;
            const uint WM_KEYUP = 0x0101;

            IntPtr edit = process.MainWindowHandle;

            PostMessage(edit, WM_KEYDOWN, (IntPtr)(key), IntPtr.Zero);
        }

        public byte[] read_memory(int offset, int[] ptrs, int bytes)
        {
            int bytesRead = 0;
            byte[] buffer = new byte[8];

            ReadAddress = IntPtr.Add(BaseAddress, offset);
            ReadProcessMemory((int)processHandle, ReadAddress.ToInt64(), buffer, buffer.Length, ref bytesRead);

            foreach (var ptr in ptrs)
            {
                new_addr = BitConverter.ToInt64(buffer, 0);
                new_addr += ptr;
                ReadProcessMemory((int)processHandle, new_addr, buffer, buffer.Length, ref bytesRead);
            }

            bytesRead = 0;
            buffer = new byte[bytes];

            ReadProcessMemory((int)processHandle, new_addr, buffer, buffer.Length, ref bytesRead);

            return buffer;
        }
    }
}
