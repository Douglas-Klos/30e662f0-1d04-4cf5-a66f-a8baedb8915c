using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace FFXIV_Trainer
{
    public partial class Form1 : Form
    {
        FinalFantasy ffxiv;
        KeyboardScanCodes ksc;
        public Form1()
        {
            ffxiv = new FinalFantasy();
            ksc = new KeyboardScanCodes();
            InitializeComponent();

            this.character_rtb.Text = "";
            this.character_rtb.Text += "Mana: " + ffxiv.get_current_mana() + " / " + ffxiv.get_max_mana() + "\n";
            this.character_rtb.Text += "HP: " + ffxiv.get_current_hp() + " / " + ffxiv.get_max_hp() + "\n";

            foreach (string macro in ffxiv.Macros.Keys)
            {
                this.macros_dropdown.Items.Add(macro);
            }
            this.macros_dropdown.SelectedItem = "35d 538cp";

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.macro_rotation_rtb.Text = "";

            foreach (string spell in ffxiv.Macros[this.macros_dropdown.SelectedItem.ToString()])
            {
                this.macro_rotation_rtb.Text += spell;
                this.macro_rotation_rtb.Text += "\n";
            }
             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.general_info_textbox.Text = "Crafting . . .\n";

            foreach (string spell in ffxiv.Macros[this.macros_dropdown.SelectedItem.ToString()])
            {
                this.general_info_textbox.Text += ". . ." + spell + "\n";
                this.general_info_textbox.Refresh();
                //ffxiv.send_keys(ffxiv.CraftingSpells[spell]);
                //Thread.Sleep(50);
                Thread.Sleep(ffxiv.CraftingSpells[spell][2]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.character_rtb.Text = "";
            this.character_rtb.Text += "Mana: " + ffxiv.get_current_mana() + " / " + ffxiv.get_max_mana() + "\n";
            this.character_rtb.Text += "HP: " + ffxiv.get_current_hp() + " / " + ffxiv.get_max_hp() + "\n";
            this.character_rtb.Text += "Lowest Marketboard Price :" + ffxiv.get_lowest_marketboard_price() + "\n";
        }

        private void button3_Click(object sender, EventArgs e)
        {

            short[] select = { ksc.get_key_code("NUMPAD0"), ksc.get_key_code("NULL") };
            short[] up = { ksc.get_key_code("NUMPAD8"), ksc.get_key_code("NULL") };
            short[] down = { ksc.get_key_code("NUMPAD2"), ksc.get_key_code("NULL") };
            short[] escape = { ksc.get_key_code("ESCAPE"), ksc.get_key_code("NULL") };
            short[] enter = { ksc.get_key_code("RETURN"), ksc.get_key_code("NULL") };

            //ffxiv.send_keys(select);
            //Thread.Sleep(1000);
            ffxiv.send_keys(select);
            Thread.Sleep(1000);
            ffxiv.send_keys(select);
            Thread.Sleep(1000);
            ffxiv.send_keys(select);
            Thread.Sleep(2000);

            update_prices(Convert.ToInt32(this.first_retainer_number_of_items_tb.Text), Convert.ToInt32(this.first_retainer_minimum_tb.Text), Convert.ToInt32(this.first_retainer_default_tb.Text));
        }


        private void button4_Click(object sender, EventArgs e)
        {

            short[] select = { ksc.get_key_code("NUMPAD0"), ksc.get_key_code("NULL") };
            short[] up = { ksc.get_key_code("NUMPAD8"), ksc.get_key_code("NULL") };
            short[] down = { ksc.get_key_code("NUMPAD2"), ksc.get_key_code("NULL") };
            short[] escape = { ksc.get_key_code("ESCAPE"), ksc.get_key_code("NULL") };
            short[] enter = { ksc.get_key_code("RETURN"), ksc.get_key_code("NULL") };


            //ffxiv.send_keys(select);
            //Thread.Sleep(1000); ;
            ffxiv.send_keys(down);
            Thread.Sleep(1000);
            ffxiv.send_keys(down);
            Thread.Sleep(1000);
            ffxiv.send_keys(select);
            Thread.Sleep(1000);
            ffxiv.send_keys(select);
            Thread.Sleep(2000);
            
            update_prices(Convert.ToInt32(this.second_retainer_number_of_items_tb.Text), Convert.ToInt32(this.second_retainer_minimum_tb.Text), Convert.ToInt32(this.second_retainer_default_tb.Text));
        }


    
        private void update_prices(int number_of_items, int minimum, int reset)
        {
            int lowest_price = 0;
            int new_price = 0;

            short[] select = { ksc.get_key_code("NUMPAD0"), ksc.get_key_code("NULL") };
            short[] up = { ksc.get_key_code("NUMPAD8"), ksc.get_key_code("NULL") };
            short[] down = { ksc.get_key_code("NUMPAD2"), ksc.get_key_code("NULL") };
            short[] escape = { ksc.get_key_code("ESCAPE"), ksc.get_key_code("NULL") };
            short[] enter = { ksc.get_key_code("RETURN"), ksc.get_key_code("NULL") };

            ffxiv.send_keys(down);
            Thread.Sleep(500);
            ffxiv.send_keys(down);
            Thread.Sleep(500);
            ffxiv.send_keys(select);
            Thread.Sleep(500);


            for (int loop_counter = 0; loop_counter < number_of_items; loop_counter++)
            {
                ffxiv.send_keys(select);
                Thread.Sleep(500);
                ffxiv.send_keys(select);
                Thread.Sleep(500);
                ffxiv.send_keys(up);
                Thread.Sleep(500);
                ffxiv.send_keys(select);
                Thread.Sleep(1500);
                lowest_price = ffxiv.get_lowest_marketboard_price();
                new_price = lowest_price - 1;

                this.general_info_textbox.Text += "Updating item #" + loop_counter + "\n";
                this.general_info_textbox.Refresh();
                this.general_info_textbox.Text += ". . . lowest price: " + lowest_price + "\n";
                this.general_info_textbox.Refresh();

                if (new_price < minimum)
                {
                    this.general_info_textbox.Text += ". . . item under minimum price, posting at default";
                    new_price = reset;
                }


                this.general_info_textbox.Text += ". . . posted price: " + new_price + "\n";
                this.general_info_textbox.Refresh();

                ffxiv.send_keys(escape);
                Thread.Sleep(500);
                ffxiv.send_keys(down);
                Thread.Sleep(500);
                ffxiv.send_keys(select);
                Thread.Sleep(500);
                ffxiv.send_keys(enter);
                Thread.Sleep(100);
                ffxiv.send_keys(escape);
                Thread.Sleep(500);

                foreach (char letter in new_price.ToString())
                {
                    ffxiv.send_key(ksc.get_key_code(letter.ToString()));
                    Thread.Sleep(50);
                }
                ffxiv.send_keys(enter);
                Thread.Sleep(500);
                ffxiv.send_keys(down);
                Thread.Sleep(100);
                ffxiv.send_keys(down);
                Thread.Sleep(100);
                ffxiv.send_keys(select);
                Thread.Sleep(500);
                ffxiv.send_keys(down);
                Thread.Sleep(100);

            }
            ffxiv.send_keys(escape);
            Thread.Sleep(250);
            ffxiv.send_keys(escape);
            Thread.Sleep(250);
            ffxiv.send_keys(select);
            Thread.Sleep(250);
            ffxiv.send_keys(escape);
            Thread.Sleep(250);

        }
    }
}
