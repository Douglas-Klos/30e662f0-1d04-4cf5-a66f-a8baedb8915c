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
        Thread thr;
        public Form1()
        {
            ffxiv = new FinalFantasy();
            ksc = new KeyboardScanCodes();
            InitializeComponent();

            this.character_rtb.Text = "";
            //this.character_rtb.Text += "Mana: " + ffxiv.get_current_mana() + " / " + ffxiv.get_max_mana() + "\n";
            //this.character_rtb.Text += "HP: " + ffxiv.get_current_hp() + " / " + ffxiv.get_max_hp() + "\n";
            this.character_rtb.Refresh();

            foreach (string macro in ffxiv.Macros.Keys)
            {
                this.macros_dropdown.Items.Add(macro);
            }
            this.macros_dropdown.SelectedItem = "35d 538cp";

        }

        public void AppendTextBox(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendTextBox), new object[] { value });
                return;
            }
            this.general_info_textbox.AppendText(value);
            this.general_info_textbox.SelectionStart = this.general_info_textbox.Text.Length;
            this.general_info_textbox.ScrollToCaret();
        }

        // Crafting
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.macro_rotation_rtb.Text = "";

            foreach (string spell in ffxiv.Macros[this.macros_dropdown.SelectedItem.ToString()])
            {
                this.macro_rotation_rtb.Text += spell;
                this.macro_rotation_rtb.Text += "\n";
            }

        }

        private void execute_crafting_Click(object sender, EventArgs e)
        {
            this.general_info_textbox.Text = "Crafting . . .\n";

            foreach (string spell in ffxiv.Macros[this.macros_dropdown.SelectedItem.ToString()])
            {
                this.general_info_textbox.Text += ". . ." + spell + "\n";
                this.general_info_textbox.Refresh();
                //ffxiv.send_key_down_up(ffxiv.CraftingSpells[spell]);
                Thread.Sleep(ffxiv.CraftingSpells[spell][2]);
            }
        }

        // Character Sheet
        private void refresh_character_Click(object sender, EventArgs e)
        {
            this.character_rtb.Text = "";
            this.character_rtb.Text += "Mana: " + ffxiv.get_current_mana() + " / " + ffxiv.get_max_mana() + "\n";
            this.character_rtb.Text += "HP: " + ffxiv.get_current_hp() + " / " + ffxiv.get_max_hp() + "\n";
            this.character_rtb.Text += "Lowest Marketboard Price :" + ffxiv.get_lowest_marketboard_price() + "\n";
        }

        // Market

        private void update_prices(int number_of_items, int minimum, int maximum, int undercut, int reset)
        {
            int lowest_price = 0;
            int new_price = 0;

            short select = ksc.get_key_code("NUMPAD0");
            short up = ksc.get_key_code("NUMPAD8");
            short down = ksc.get_key_code("NUMPAD2");
            short escape = ksc.get_key_code("ESCAPE");
            short enter = ksc.get_key_code("RETURN");

            Thread.Sleep(1000);
            ffxiv.send_key_down_up(down);
            Thread.Sleep(250);
            ffxiv.send_key_down_up(down);
            Thread.Sleep(250);
            ffxiv.send_key_down_up(select);
            Thread.Sleep(1000);


            for (int loop_counter = 0; loop_counter < number_of_items; loop_counter++)
            {
                ffxiv.send_key_down_up(select);
                Thread.Sleep(150);
                ffxiv.send_key_down_up(select);
                Thread.Sleep(150);
                ffxiv.send_key_down_up(up);
                Thread.Sleep(150);
                ffxiv.send_key_down_up(select);
                Thread.Sleep(1500);


                AppendTextBox("Updating item #" + loop_counter + "\n");
                if (ffxiv.get_quality() == 0)
                {
                    AppendTextBox(". . . First listed item is low quality\n");
                    AppendTextBox(". . . Price of second item :" + ffxiv.get_next_price() + "\n");
                    lowest_price = ffxiv.get_next_price();
                }
                else
                {
                    lowest_price = ffxiv.get_lowest_marketboard_price();
                }

                
                
                new_price = lowest_price - undercut;

                
                AppendTextBox(". . . lowest price: " + lowest_price + "\n");

                if (new_price < minimum)
                {

                    AppendTextBox(". . . item under minimum price, posting at default");
                    new_price = reset;
                }
                if (new_price > maximum)
                {
                    AppendTextBox(". . . item under minimum price, posting at default");
                    new_price = reset;
                }


                AppendTextBox(". . . posted price: " + new_price + "\n");

                ffxiv.send_key_down_up(escape);
                Thread.Sleep(150);
                ffxiv.send_key_down_up(down);
                Thread.Sleep(150);
                ffxiv.send_key_down_up(select);
                Thread.Sleep(150);
                ffxiv.send_key_down_up(enter);
                Thread.Sleep(150);
                ffxiv.send_key_down_up(escape);
                Thread.Sleep(150);

                foreach (char letter in new_price.ToString())
                {
                    ffxiv.send_key_down(ksc.get_key_code(letter.ToString()));
                    Thread.Sleep(50);
                }
                ffxiv.send_key_down_up(enter);
                Thread.Sleep(150);
                ffxiv.send_key_down_up(down);
                Thread.Sleep(100);
                ffxiv.send_key_down_up(down);
                Thread.Sleep(100);
                ffxiv.send_key_down_up(select);
                Thread.Sleep(250);
                ffxiv.send_key_down_up(down);
                Thread.Sleep(100);

            }
            ffxiv.send_key_down_up(escape);
            Thread.Sleep(150);
            ffxiv.send_key_down_up(escape);
            Thread.Sleep(150);
            ffxiv.send_key_down_up(select);
            Thread.Sleep(150);
            ffxiv.send_key_down_up(escape);
            Thread.Sleep(150);

        }

        private void start_thread_1()
        {
            short select = ksc.get_key_code("NUMPAD0");

            Thread.Sleep(1000);
            ffxiv.send_key_down_up(select);
            Thread.Sleep(250);
            ffxiv.send_key_down_up(select);
            Thread.Sleep(2000);
            ffxiv.send_key_down_up(select);
            Thread.Sleep(1000);
            update_prices(Convert.ToInt32(this.first_retainer_number_of_items_tb.Text), Convert.ToInt32(this.first_retainer_minimum_tb.Text), Convert.ToInt32(this.first_retainer_maximum_tb.Text), Convert.ToInt32(this.first_retainer_undercut.Text), Convert.ToInt32(this.first_retainer_default_tb.Text));
        }
        private void start_thread_2()
        {
            short select = ksc.get_key_code("NUMPAD0");
            short down = ksc.get_key_code("NUMPAD2");

            Thread.Sleep(1000);
            ffxiv.send_key_down_up(down);
            Thread.Sleep(100);
            ffxiv.send_key_down_up(down);
            Thread.Sleep(100);
            ffxiv.send_key_down_up(select);
            Thread.Sleep(3000);
            ffxiv.send_key_down_up(select);
            Thread.Sleep(1000);

            update_prices(Convert.ToInt32(this.second_retainer_number_of_items_tb.Text), Convert.ToInt32(this.second_retainer_minimum_tb.Text), Convert.ToInt32(this.second_retainer_maximum_tb.Text), Convert.ToInt32(this.second_retainer_undercut.Text), Convert.ToInt32(this.second_retainer_default_tb.Text));
        }


        private void first_retainer_thread_1_Click(object sender, EventArgs e)
        {
            thr.Abort();
            thr = new Thread(new ThreadStart(this.start_thread_1));
            thr.Start();
        }

        private void second_retainer_thread_1_Click(object sender, EventArgs e)
        {
            thr.Abort();
            thr = new Thread(new ThreadStart(this.start_thread_2));
            thr.Start();
        }

        private void kill_thread_1_Click(object sender, EventArgs e)
        {
            thr.Abort();
        }

        private void kill_thread_2_Click(object sender, EventArgs e)
        {
            thr.Abort();
        }

        private void test_button_Click(object sender, EventArgs e)
        {
            AppendTextBox(ffxiv.get_lowest_marketboard_price().ToString());
        }
    }
}
