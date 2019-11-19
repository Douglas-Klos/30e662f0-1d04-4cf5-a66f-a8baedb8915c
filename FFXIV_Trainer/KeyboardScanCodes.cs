namespace FFXIV_Trainer
{
    using System.Collections.Generic;

    class KeyboardScanCodes
    {
        Dictionary<string, short> DXKeyCodes;

        public KeyboardScanCodes()
        {
            DXKeyCodes = new Dictionary<string, short>
            {
                {"0", 0x30},            // 0 key
                {"1", 0x31},            // 1 key
                {"2", 0x32},            // 2 key
                {"3", 0x33},            // 3 key
                {"4", 0x34},            // 4 key
                {"5", 0x35},            // 5 key
                {"6", 0x36},            // 6 key
                {"7", 0x37},            // 7 key
                {"8", 0x38},            // 8 key
                {"9", 0x39},            // 9 key
                {"MINUS", 0xBD},        // - key
                {"PLUS", 0xBB},         // + key
                {"A", 0x41},            // A key
                {"B", 0x42},            // B key
                {"C", 0x43},            // C key
                {"D", 0x44},            // D key
                {"E", 0x45},            // E key
                {"F", 0x46},            // F key
                {"G", 0x47},            // G key
                {"H", 0x48},            // H key
                {"I", 0x49},            // I key
                {"J", 0x4A},            // J key
                {"K", 0x4B},            // K key
                {"L", 0x4C},            // L key
                {"M", 0x4D},            // M key
                {"N", 0x4E},            // N key
                {"O", 0x4F},            // O key
                {"P", 0x50},            // P key
                {"Q", 0x51},            // Q key
                {"R", 0x52},            // R key
                {"S", 0x53},            // S key
                {"T", 0x54},            // T key
                {"U", 0x55},            // U key
                {"V", 0x56},            // V key
                {"W", 0x57},            // W key
                {"X", 0x58},            // X key
                {"Y", 0x59},            // Y key
                {"Z", 0x5A},            // Z key
                {"LBUTTON", 0x01},      // Left mouse button
                {"RBUTTON", 0x02},      // Right mouse button
                {"CANCEL", 0x03},       // Control-break processing
                {"MBUTTON", 0x04},      // Middle mouse button (three-button mouse)
                {"BACK", 0x08},         // BACKSPACE key
                {"TAB", 0x09},          // TAB key
                {"CLEAR", 0x0C},        // CLEAR key
                {"RETURN", 0x0D},       // ENTER key
                {"SHIFT", 0x10},        // SHIFT key
                {"CONTROL", 0x11},      // CTRL key
                {"MENU", 0x12},         // ALT key
                {"PAUSE", 0x13},        // PAUSE key
                {"CAPITAL", 0x14},      // CAPS LOCK key
                {"ESCAPE", 0x1B},       // ESC key
                {"SPACE", 0x20},        // SPACEBAR
                {"PRIOR", 0x21},        // PAGE UP key
                {"NEXT", 0x22},         // PAGE DOWN key
                {"END", 0x23},          // END key
                {"HOME", 0x24},         // HOME key
                {"LEFT", 0x25},         // LEFT ARROW key
                {"UP", 0x26},           // UP ARROW key
                {"RIGHT", 0x27},        // RIGHT ARROW key
                {"DOWN", 0x28},         // DOWN ARROW key
                {"SELECT", 0x29},       // SELECT key
                {"PRINT", 0x2A},        // PRINT key
                {"EXECUTE", 0x2B},      // EXECUTE key
                {"SNAPSHOT", 0x2C},     // PRINT SCREEN key
                {"INSERT", 0x2D},       // INS key
                {"ELETE", 0x2E},        // DEL key
                {"HELP", 0x2F},         // HELP key
                {"[", 0x5B},            // [ key
                {"]", 0x5C},            // ] key
                {"NUMPAD0", 0x60},      // Numeric keypad 0 key
                {"NUMPAD1", 0x61},      // Numeric keypad 1 key
                {"NUMPAD2", 0x62},      // Numeric keypad 2 key
                {"NUMPAD3", 0x63},      // Numeric keypad 3 key
                {"NUMPAD4", 0x64},      // Numeric keypad 4 key
                {"NUMPAD5", 0x65},      // Numeric keypad 5 key
                {"NUMPAD6", 0x66},      // Numeric keypad 6 key
                {"NUMPAD7", 0x67},      // Numeric keypad 7 key
                {"NUMPAD8", 0x68},      // Numeric keypad 8 key
                {"NUMPAD9", 0x69},      // Numeric keypad 9 key
                {"SEPARATOR", 0x6C},    // Separator key
                {"SUBTRACT", 0x6D},     // Subtract key
                {"DECIMAL", 0x6E},      // Decimal key
                {"DIVIDE", 0x6F},       // Divide key
                {"F1", 0x70},           // F1 key
                {"F2", 0x71},           // F2 key
                {"F3", 0x72},           // F3 key
                {"F4", 0x73},           // F4 key
                {"F5", 0x74},           // F5 key
                {"F6", 0x75},           // F6 key
                {"F7", 0x76},           // F7 key
                {"F8", 0x77},           // F8 key
                {"F9", 0x78},           // F9 key
                {"F10", 0x79},          // F10 key
                {"F11", 0x7A},          // F11 key
                {"F12", 0x7B},          // F12 key
                {"SCROLL", 0x91},       // SCROLL LOCK key
                {"LSHIFT", 0xA0},       // Left SHIFT key
                {"RSHIFT", 0xA1},       // Right SHIFT key
                {"LCONTROL", 0xA2},     // Left CONTROL key
                {"RCONTROL", 0xA3},     // Right CONTROL key
                {"LMENU", 0xA4},        // Left MENU key
                {"RMENU", 0xA5},        // Right MENU key
                {"COMMA", 0xBC},        // , key
                {"PERIOD", 0xBE},       // . key
                {"PLAY", 0xFA},         // Play key
                {"ZOOM", 0xFB},         // Zoom key
                {"NULL", 0x00}          // Not A Key
            };
        }

        public short get_key_code(string key)
        {
            return DXKeyCodes[key];
        }
    }
}