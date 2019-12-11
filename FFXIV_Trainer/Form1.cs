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
            if (this.thr != null)
                this.thr.Abort();

            this.thr = new Thread(new ThreadStart(this.MarketPostFirstThread));
            this.thr.Start();

        }
        private void MarketPostSecondRetainerClick(object sender, EventArgs e)
        {
            if (this.thr != null)
                this.thr.Abort();

            this.thr = new Thread(new ThreadStart(this.MarketPostSecondThread));
            this.thr.Start();

        }

        private void MarketPostFirstThread()
        {
            foreach (var result in this.ffxiv.PostFirstRetainer(Convert.ToInt32(this.marketFirstNumberOfItems.Text), Convert.ToInt32(this.marketFirstMinimum.Text), Convert.ToInt32(this.marketFirstMaximum.Text), Convert.ToInt32(this.marketFirstUndercut.Text), Convert.ToInt32(this.marketFirstReset.Text), this.marketFirstIgnoreQuality.Checked))
            {
                this.AppendTextBox(result);
            }
        }

        private void MarketPostSecondThread()
        {
            foreach (var result in this.ffxiv.PostSecondRetainer(Convert.ToInt32(this.marketSecondNumberOfItems.Text), Convert.ToInt32(this.marketSecondMinimum.Text), Convert.ToInt32(this.marketSecondMaximum.Text), Convert.ToInt32(this.marketSecondUndercut.Text), Convert.ToInt32(this.marketSecondReset.Text), this.marketSecondIgnoreQuality.Checked))
            {
                this.AppendTextBox(result);
            }
        }

        private void MarketStopFirstRetainerClick(object sender, EventArgs e)
        {
            if (this.thr != null)
                this.thr.Abort();
            
        }

        private void MarketStopSecondRetainerClick(object sender, EventArgs e)
        {
            if (this.thr != null)
                this.thr.Abort();
        }

        // Development
        private void DevGetRAMValueIntButton_Click(object sender, EventArgs e)
        {
            this.generalInfoTextbox.Text += "---DEV--- Int: " + BitConverter.ToInt32(this.ffxiv.GetValueFromRAM(this.devGetRAMValueInputTB.Text, 4), 0).ToString() + "\n";
        }

        private void devGetRAMStringValueButton_Click(object sender, EventArgs e)
        {
            this.generalInfoTextbox.Text += "---DEV--- String: " + Encoding.ASCII.GetString(this.ffxiv.GetValueFromRAM(this.devGetRAMValueInputTB.Text, 24));
            this.generalInfoTextbox.Text += "\n";
        }

        private void DevLowestMBPriceButton_Click(object sender, EventArgs e)
        {
            this.generalInfoTextbox.Text += "---DEV--- Lowest MB Price: " + this.ffxiv.GetLowestMarketboardPrice().ToString() + "\n";
        }

        private void devGetFirstHQPriceButton_Click(object sender, EventArgs e)
        {
            this.generalInfoTextbox.Text += "---DEV--- First HQ Price: " + this.ffxiv.GetFirstHQPrice().ToString() + "\n";
        }

        private void marketFirstLoadSellList_Click(object sender, EventArgs e)
        {
            this.generalInfoTextbox.Text += this.ffxiv.LoadFirstSellList();
            this.generalInfoTextbox.Text += "\n";

        }
    }
}

