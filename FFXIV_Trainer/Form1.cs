namespace FFXIV_Trainer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;
    
    public partial class Form1 : Form
    {
        private FinalFantasy ffxiv;
        private Thread thr;

        public Form1()
        {
            this.ffxiv = new FinalFantasy();
            this.InitializeComponent();
            
            foreach (string macro in this.ffxiv.GetMacros().Keys)
            {
                this.craftingMacrosDropdown.Items.Add(macro);
            }

            this.craftingMacrosDropdown.SelectedItem = "35d 538cp";
        }

        public void AppendTextBox(string value)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(this.AppendTextBox), new object[] { value });
                return;
            }

            this.generalInfoTextbox.AppendText(value);
            this.generalInfoTextbox.SelectionStart = this.generalInfoTextbox.Text.Length;
            this.generalInfoTextbox.ScrollToCaret();
        }

        // Crafting
        private void UpdateMacroRTB(object sender, EventArgs e)
        {
            this.craftingMacroRotation.Text = string.Empty;

            foreach (string spell in this.ffxiv.GetMacros()[this.craftingMacrosDropdown.SelectedItem.ToString()])
            {
                this.craftingMacroRotation.Text += spell;
                this.craftingMacroRotation.Text += "\n";
            }
        }

        private void CraftingExecuteButtonClick(object sender, EventArgs e)
        {
            this.generalInfoTextbox.Text = "Crafting . . .\n";

            foreach (string spell in this.ffxiv.GetMacros()[this.craftingMacrosDropdown.SelectedItem.ToString()])
            {
                this.generalInfoTextbox.Text += ". . ." + spell + "\n";
                this.generalInfoTextbox.Refresh();
                ////this.ffxiv.SendKeyDownUp(this.ffxiv.CraftingSpells[spell]);
                Thread.Sleep(this.ffxiv.GetCraftingSpells()[spell][2]);
            }
        }

        // Character Sheet
        private void CharacterRefreshClick(object sender, EventArgs e)
        {
            this.characterInfo.Text = string.Empty;
            this.characterInfo.Text += "Mana: " + this.ffxiv.GetCurrentMana() + " / " + this.ffxiv.GetMaxMana() + "\n";
            this.characterInfo.Text += "HP: " + this.ffxiv.GetCurrentHP() + " / " + this.ffxiv.GetMaxHP() + "\n";
            this.characterInfo.Text += "Lowest Marketboard Price :" + this.ffxiv.GetLowestMarketboardPrice() + "\n";
        }

        // Market
        private void MarketPostFirstRetainerClick(object sender, EventArgs e)
        {
            this.thr = new Thread(new ThreadStart(() => this.ffxiv.PostFirstRetainer(Convert.ToInt32(this.marketFirstNumberOfItems.Text), Convert.ToInt32(this.marketFirstMinimum.Text), Convert.ToInt32(this.marketFirstMaximum.Text), Convert.ToInt32(this.marketFirstUndercut.Text), Convert.ToInt32(this.marketFirstReset.Text))));
            this.thr.Start();
        }

        private void MarketPostSecondRetainerClick(object sender, EventArgs e)
        {
            this.thr = new Thread(new ThreadStart(() => this.ffxiv.PostSecondRetainer(Convert.ToInt32(this.marketSecondNumberOfItems.Text), Convert.ToInt32(this.marketSecondMinimum.Text), Convert.ToInt32(this.marketSecondMaximum.Text), Convert.ToInt32(this.marketSecondUndercut.Text), Convert.ToInt32(this.marketSecondReset.Text))));
            this.thr.Start();
        }

        private void MarketStopFirstRetainerClick(object sender, EventArgs e)
        {
            this.thr.Abort();
        }

        private void MarketStopSecondRetainerClick(object sender, EventArgs e)
        {
            this.thr.Abort();
        }
    }
}
