namespace FFXIV_Trainer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.marketPage = new System.Windows.Forms.TabPage();
            this.marketFirstRetainerGroupBox = new System.Windows.Forms.GroupBox();
            this.marketFirstMaximumLabel = new System.Windows.Forms.Label();
            this.marketFirstMaximum = new System.Windows.Forms.TextBox();
            this.marketFirstStartPointGroupBox = new System.Windows.Forms.GroupBox();
            this.marketFirstStop = new System.Windows.Forms.Button();
            this.marketFirstPost = new System.Windows.Forms.Button();
            this.marketFirstUndercutLabel = new System.Windows.Forms.Label();
            this.marketFirstUndercut = new System.Windows.Forms.TextBox();
            this.marketFirstResetLabel = new System.Windows.Forms.Label();
            this.marketFirstReset = new System.Windows.Forms.TextBox();
            this.marketFirstMinimum = new System.Windows.Forms.TextBox();
            this.marketFirstMinimumLabel = new System.Windows.Forms.Label();
            this.marketFirstNumberOfItemsLabel = new System.Windows.Forms.Label();
            this.marketFirstNumberOfItems = new System.Windows.Forms.TextBox();
            this.marketSecondRetainerGroupBox = new System.Windows.Forms.GroupBox();
            this.marketSecondMaximumLabel = new System.Windows.Forms.Label();
            this.marketSecondMaximum = new System.Windows.Forms.TextBox();
            this.marketSecondStartPointGroupBox = new System.Windows.Forms.GroupBox();
            this.marketSecondStop = new System.Windows.Forms.Button();
            this.marketSecondPost = new System.Windows.Forms.Button();
            this.marketSecondUndercutLabel = new System.Windows.Forms.Label();
            this.marketSecondUndercut = new System.Windows.Forms.TextBox();
            this.marketSecondResetLabel = new System.Windows.Forms.Label();
            this.marketSecondMinimumLabel = new System.Windows.Forms.Label();
            this.marketSecondNumberOfItemsLabel = new System.Windows.Forms.Label();
            this.marketSecondReset = new System.Windows.Forms.TextBox();
            this.marketSecondMinimum = new System.Windows.Forms.TextBox();
            this.marketSecondNumberOfItems = new System.Windows.Forms.TextBox();
            this.craftingPage = new System.Windows.Forms.TabPage();
            this.craftingExecute = new System.Windows.Forms.Button();
            this.craftingMacrosDropdown = new System.Windows.Forms.ComboBox();
            this.craftingMacroRotation = new System.Windows.Forms.RichTextBox();
            this.characterPage = new System.Windows.Forms.TabPage();
            this.characterRefresh = new System.Windows.Forms.Button();
            this.characterInfo = new System.Windows.Forms.RichTextBox();
            this.aboutPage = new System.Windows.Forms.TabPage();
            this.generalInfoTextbox = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.marketPage.SuspendLayout();
            this.marketFirstRetainerGroupBox.SuspendLayout();
            this.marketFirstStartPointGroupBox.SuspendLayout();
            this.marketSecondRetainerGroupBox.SuspendLayout();
            this.marketSecondStartPointGroupBox.SuspendLayout();
            this.craftingPage.SuspendLayout();
            this.characterPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.marketPage);
            this.tabControl1.Controls.Add(this.craftingPage);
            this.tabControl1.Controls.Add(this.characterPage);
            this.tabControl1.Controls.Add(this.aboutPage);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(560, 389);
            this.tabControl1.TabIndex = 0;
            // 
            // marketPage
            // 
            this.marketPage.Controls.Add(this.marketFirstRetainerGroupBox);
            this.marketPage.Controls.Add(this.marketSecondRetainerGroupBox);
            this.marketPage.Location = new System.Drawing.Point(4, 22);
            this.marketPage.Name = "marketPage";
            this.marketPage.Padding = new System.Windows.Forms.Padding(3);
            this.marketPage.Size = new System.Drawing.Size(552, 363);
            this.marketPage.TabIndex = 3;
            this.marketPage.Text = "Market Sales";
            this.marketPage.UseVisualStyleBackColor = true;
            // 
            // marketFirstRetainerGroupBox
            // 
            this.marketFirstRetainerGroupBox.Controls.Add(this.marketFirstMaximumLabel);
            this.marketFirstRetainerGroupBox.Controls.Add(this.marketFirstMaximum);
            this.marketFirstRetainerGroupBox.Controls.Add(this.marketFirstStartPointGroupBox);
            this.marketFirstRetainerGroupBox.Controls.Add(this.marketFirstUndercutLabel);
            this.marketFirstRetainerGroupBox.Controls.Add(this.marketFirstUndercut);
            this.marketFirstRetainerGroupBox.Controls.Add(this.marketFirstResetLabel);
            this.marketFirstRetainerGroupBox.Controls.Add(this.marketFirstReset);
            this.marketFirstRetainerGroupBox.Controls.Add(this.marketFirstMinimum);
            this.marketFirstRetainerGroupBox.Controls.Add(this.marketFirstMinimumLabel);
            this.marketFirstRetainerGroupBox.Controls.Add(this.marketFirstNumberOfItemsLabel);
            this.marketFirstRetainerGroupBox.Controls.Add(this.marketFirstNumberOfItems);
            this.marketFirstRetainerGroupBox.Location = new System.Drawing.Point(5, 6);
            this.marketFirstRetainerGroupBox.Name = "marketFirstRetainerGroupBox";
            this.marketFirstRetainerGroupBox.Size = new System.Drawing.Size(255, 351);
            this.marketFirstRetainerGroupBox.TabIndex = 24;
            this.marketFirstRetainerGroupBox.TabStop = false;
            this.marketFirstRetainerGroupBox.Text = "First Retainer";
            // 
            // marketFirstMaximumLabel
            // 
            this.marketFirstMaximumLabel.AutoSize = true;
            this.marketFirstMaximumLabel.Location = new System.Drawing.Point(92, 87);
            this.marketFirstMaximumLabel.Name = "marketFirstMaximumLabel";
            this.marketFirstMaximumLabel.Size = new System.Drawing.Size(51, 13);
            this.marketFirstMaximumLabel.TabIndex = 25;
            this.marketFirstMaximumLabel.Text = "Maximum";
            // 
            // marketFirstMaximum
            // 
            this.marketFirstMaximum.Location = new System.Drawing.Point(149, 84);
            this.marketFirstMaximum.Name = "marketFirstMaximum";
            this.marketFirstMaximum.Size = new System.Drawing.Size(100, 20);
            this.marketFirstMaximum.TabIndex = 24;
            this.marketFirstMaximum.Text = "1000000";
            // 
            // marketFirstStartPointGroupBox
            // 
            this.marketFirstStartPointGroupBox.Controls.Add(this.marketFirstStop);
            this.marketFirstStartPointGroupBox.Controls.Add(this.marketFirstPost);
            this.marketFirstStartPointGroupBox.Location = new System.Drawing.Point(6, 214);
            this.marketFirstStartPointGroupBox.Name = "marketFirstStartPointGroupBox";
            this.marketFirstStartPointGroupBox.Size = new System.Drawing.Size(243, 129);
            this.marketFirstStartPointGroupBox.TabIndex = 23;
            this.marketFirstStartPointGroupBox.TabStop = false;
            this.marketFirstStartPointGroupBox.Text = "First Retainer Starting Point";
            // 
            // marketFirstStop
            // 
            this.marketFirstStop.Location = new System.Drawing.Point(143, 100);
            this.marketFirstStop.Name = "marketFirstStop";
            this.marketFirstStop.Size = new System.Drawing.Size(94, 23);
            this.marketFirstStop.TabIndex = 4;
            this.marketFirstStop.Text = "Stop";
            this.marketFirstStop.UseVisualStyleBackColor = true;
            this.marketFirstStop.Click += new System.EventHandler(this.MarketStopFirstRetainerClick);
            // 
            // marketFirstPost
            // 
            this.marketFirstPost.Location = new System.Drawing.Point(6, 98);
            this.marketFirstPost.Name = "marketFirstPost";
            this.marketFirstPost.Size = new System.Drawing.Size(80, 23);
            this.marketFirstPost.TabIndex = 3;
            this.marketFirstPost.Text = "Post";
            this.marketFirstPost.UseVisualStyleBackColor = true;
            this.marketFirstPost.Click += new System.EventHandler(this.MarketPostFirstRetainerClick);
            // 
            // marketFirstUndercutLabel
            // 
            this.marketFirstUndercutLabel.AutoSize = true;
            this.marketFirstUndercutLabel.Location = new System.Drawing.Point(54, 148);
            this.marketFirstUndercutLabel.Name = "marketFirstUndercutLabel";
            this.marketFirstUndercutLabel.Size = new System.Drawing.Size(89, 13);
            this.marketFirstUndercutLabel.TabIndex = 21;
            this.marketFirstUndercutLabel.Text = "Undercut amount";
            // 
            // marketFirstUndercut
            // 
            this.marketFirstUndercut.Location = new System.Drawing.Point(149, 144);
            this.marketFirstUndercut.Name = "marketFirstUndercut";
            this.marketFirstUndercut.Size = new System.Drawing.Size(100, 20);
            this.marketFirstUndercut.TabIndex = 19;
            this.marketFirstUndercut.Text = "50";
            // 
            // marketFirstResetLabel
            // 
            this.marketFirstResetLabel.AutoSize = true;
            this.marketFirstResetLabel.Location = new System.Drawing.Point(102, 116);
            this.marketFirstResetLabel.Name = "marketFirstResetLabel";
            this.marketFirstResetLabel.Size = new System.Drawing.Size(35, 13);
            this.marketFirstResetLabel.TabIndex = 12;
            this.marketFirstResetLabel.Text = "Reset";
            this.marketFirstResetLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // marketFirstReset
            // 
            this.marketFirstReset.Location = new System.Drawing.Point(149, 114);
            this.marketFirstReset.Name = "marketFirstReset";
            this.marketFirstReset.Size = new System.Drawing.Size(100, 20);
            this.marketFirstReset.TabIndex = 9;
            this.marketFirstReset.Text = "500000";
            // 
            // marketFirstMinimum
            // 
            this.marketFirstMinimum.Location = new System.Drawing.Point(149, 54);
            this.marketFirstMinimum.Name = "marketFirstMinimum";
            this.marketFirstMinimum.Size = new System.Drawing.Size(100, 20);
            this.marketFirstMinimum.TabIndex = 8;
            this.marketFirstMinimum.Text = "100000";
            // 
            // marketFirstMinimumLabel
            // 
            this.marketFirstMinimumLabel.AutoSize = true;
            this.marketFirstMinimumLabel.Location = new System.Drawing.Point(95, 52);
            this.marketFirstMinimumLabel.Name = "marketFirstMinimumLabel";
            this.marketFirstMinimumLabel.Size = new System.Drawing.Size(48, 13);
            this.marketFirstMinimumLabel.TabIndex = 7;
            this.marketFirstMinimumLabel.Text = "Minimum";
            this.marketFirstMinimumLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // marketFirstNumberOfItemsLabel
            // 
            this.marketFirstNumberOfItemsLabel.AutoSize = true;
            this.marketFirstNumberOfItemsLabel.Location = new System.Drawing.Point(59, 22);
            this.marketFirstNumberOfItemsLabel.Name = "marketFirstNumberOfItemsLabel";
            this.marketFirstNumberOfItemsLabel.Size = new System.Drawing.Size(84, 13);
            this.marketFirstNumberOfItemsLabel.TabIndex = 6;
            this.marketFirstNumberOfItemsLabel.Text = "Number of Items";
            this.marketFirstNumberOfItemsLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // marketFirstNumberOfItems
            // 
            this.marketFirstNumberOfItems.Location = new System.Drawing.Point(149, 24);
            this.marketFirstNumberOfItems.Name = "marketFirstNumberOfItems";
            this.marketFirstNumberOfItems.Size = new System.Drawing.Size(100, 20);
            this.marketFirstNumberOfItems.TabIndex = 3;
            this.marketFirstNumberOfItems.Text = "1";
            // 
            // marketSecondRetainerGroupBox
            // 
            this.marketSecondRetainerGroupBox.Controls.Add(this.marketSecondMaximumLabel);
            this.marketSecondRetainerGroupBox.Controls.Add(this.marketSecondMaximum);
            this.marketSecondRetainerGroupBox.Controls.Add(this.marketSecondStartPointGroupBox);
            this.marketSecondRetainerGroupBox.Controls.Add(this.marketSecondUndercutLabel);
            this.marketSecondRetainerGroupBox.Controls.Add(this.marketSecondUndercut);
            this.marketSecondRetainerGroupBox.Controls.Add(this.marketSecondResetLabel);
            this.marketSecondRetainerGroupBox.Controls.Add(this.marketSecondMinimumLabel);
            this.marketSecondRetainerGroupBox.Controls.Add(this.marketSecondNumberOfItemsLabel);
            this.marketSecondRetainerGroupBox.Controls.Add(this.marketSecondReset);
            this.marketSecondRetainerGroupBox.Controls.Add(this.marketSecondMinimum);
            this.marketSecondRetainerGroupBox.Controls.Add(this.marketSecondNumberOfItems);
            this.marketSecondRetainerGroupBox.Location = new System.Drawing.Point(272, 6);
            this.marketSecondRetainerGroupBox.Name = "marketSecondRetainerGroupBox";
            this.marketSecondRetainerGroupBox.Size = new System.Drawing.Size(274, 351);
            this.marketSecondRetainerGroupBox.TabIndex = 23;
            this.marketSecondRetainerGroupBox.TabStop = false;
            this.marketSecondRetainerGroupBox.Text = "Second Retainer";
            // 
            // marketSecondMaximumLabel
            // 
            this.marketSecondMaximumLabel.AutoSize = true;
            this.marketSecondMaximumLabel.Location = new System.Drawing.Point(112, 87);
            this.marketSecondMaximumLabel.Name = "marketSecondMaximumLabel";
            this.marketSecondMaximumLabel.Size = new System.Drawing.Size(51, 13);
            this.marketSecondMaximumLabel.TabIndex = 25;
            this.marketSecondMaximumLabel.Text = "Maximum";
            // 
            // marketSecondMaximum
            // 
            this.marketSecondMaximum.Location = new System.Drawing.Point(6, 84);
            this.marketSecondMaximum.Name = "marketSecondMaximum";
            this.marketSecondMaximum.Size = new System.Drawing.Size(100, 20);
            this.marketSecondMaximum.TabIndex = 24;
            this.marketSecondMaximum.Text = "1000000";
            // 
            // marketSecondStartPointGroupBox
            // 
            this.marketSecondStartPointGroupBox.Controls.Add(this.marketSecondStop);
            this.marketSecondStartPointGroupBox.Controls.Add(this.marketSecondPost);
            this.marketSecondStartPointGroupBox.Location = new System.Drawing.Point(6, 219);
            this.marketSecondStartPointGroupBox.Name = "marketSecondStartPointGroupBox";
            this.marketSecondStartPointGroupBox.Size = new System.Drawing.Size(262, 124);
            this.marketSecondStartPointGroupBox.TabIndex = 23;
            this.marketSecondStartPointGroupBox.TabStop = false;
            this.marketSecondStartPointGroupBox.Text = "Second Retainer Starting Point";
            // 
            // marketSecondStop
            // 
            this.marketSecondStop.Location = new System.Drawing.Point(162, 93);
            this.marketSecondStop.Name = "marketSecondStop";
            this.marketSecondStop.Size = new System.Drawing.Size(94, 23);
            this.marketSecondStop.TabIndex = 5;
            this.marketSecondStop.Text = "Stop";
            this.marketSecondStop.UseVisualStyleBackColor = true;
            this.marketSecondStop.Click += new System.EventHandler(this.MarketStopSecondRetainerClick);
            // 
            // marketSecondPost
            // 
            this.marketSecondPost.Location = new System.Drawing.Point(6, 93);
            this.marketSecondPost.Name = "marketSecondPost";
            this.marketSecondPost.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.marketSecondPost.Size = new System.Drawing.Size(80, 25);
            this.marketSecondPost.TabIndex = 2;
            this.marketSecondPost.Text = "Post";
            this.marketSecondPost.UseVisualStyleBackColor = true;
            this.marketSecondPost.Click += new System.EventHandler(this.MarketPostSecondRetainerClick);
            // 
            // marketSecondUndercutLabel
            // 
            this.marketSecondUndercutLabel.AutoSize = true;
            this.marketSecondUndercutLabel.Location = new System.Drawing.Point(112, 153);
            this.marketSecondUndercutLabel.Name = "marketSecondUndercutLabel";
            this.marketSecondUndercutLabel.Size = new System.Drawing.Size(89, 13);
            this.marketSecondUndercutLabel.TabIndex = 22;
            this.marketSecondUndercutLabel.Text = "Undercut amount";
            // 
            // marketSecondUndercut
            // 
            this.marketSecondUndercut.Location = new System.Drawing.Point(6, 144);
            this.marketSecondUndercut.Name = "marketSecondUndercut";
            this.marketSecondUndercut.Size = new System.Drawing.Size(100, 20);
            this.marketSecondUndercut.TabIndex = 20;
            this.marketSecondUndercut.Text = "50";
            // 
            // marketSecondResetLabel
            // 
            this.marketSecondResetLabel.AutoSize = true;
            this.marketSecondResetLabel.Location = new System.Drawing.Point(112, 121);
            this.marketSecondResetLabel.Name = "marketSecondResetLabel";
            this.marketSecondResetLabel.Size = new System.Drawing.Size(35, 13);
            this.marketSecondResetLabel.TabIndex = 18;
            this.marketSecondResetLabel.Text = "Reset";
            this.marketSecondResetLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // marketSecondMinimumLabel
            // 
            this.marketSecondMinimumLabel.AutoSize = true;
            this.marketSecondMinimumLabel.Location = new System.Drawing.Point(112, 57);
            this.marketSecondMinimumLabel.Name = "marketSecondMinimumLabel";
            this.marketSecondMinimumLabel.Size = new System.Drawing.Size(48, 13);
            this.marketSecondMinimumLabel.TabIndex = 17;
            this.marketSecondMinimumLabel.Text = "Minimum";
            this.marketSecondMinimumLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // marketSecondNumberOfItemsLabel
            // 
            this.marketSecondNumberOfItemsLabel.AutoSize = true;
            this.marketSecondNumberOfItemsLabel.Location = new System.Drawing.Point(112, 27);
            this.marketSecondNumberOfItemsLabel.Name = "marketSecondNumberOfItemsLabel";
            this.marketSecondNumberOfItemsLabel.Size = new System.Drawing.Size(84, 13);
            this.marketSecondNumberOfItemsLabel.TabIndex = 16;
            this.marketSecondNumberOfItemsLabel.Text = "Number of Items";
            this.marketSecondNumberOfItemsLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // marketSecondReset
            // 
            this.marketSecondReset.Location = new System.Drawing.Point(6, 114);
            this.marketSecondReset.Name = "marketSecondReset";
            this.marketSecondReset.Size = new System.Drawing.Size(100, 20);
            this.marketSecondReset.TabIndex = 11;
            this.marketSecondReset.Text = "500000";
            // 
            // marketSecondMinimum
            // 
            this.marketSecondMinimum.Location = new System.Drawing.Point(6, 54);
            this.marketSecondMinimum.Name = "marketSecondMinimum";
            this.marketSecondMinimum.Size = new System.Drawing.Size(100, 20);
            this.marketSecondMinimum.TabIndex = 10;
            this.marketSecondMinimum.Text = "100000";
            // 
            // marketSecondNumberOfItems
            // 
            this.marketSecondNumberOfItems.Location = new System.Drawing.Point(6, 24);
            this.marketSecondNumberOfItems.Name = "marketSecondNumberOfItems";
            this.marketSecondNumberOfItems.Size = new System.Drawing.Size(100, 20);
            this.marketSecondNumberOfItems.TabIndex = 4;
            this.marketSecondNumberOfItems.Text = "1";
            // 
            // craftingPage
            // 
            this.craftingPage.Controls.Add(this.craftingExecute);
            this.craftingPage.Controls.Add(this.craftingMacrosDropdown);
            this.craftingPage.Controls.Add(this.craftingMacroRotation);
            this.craftingPage.Location = new System.Drawing.Point(4, 22);
            this.craftingPage.Name = "craftingPage";
            this.craftingPage.Padding = new System.Windows.Forms.Padding(3);
            this.craftingPage.Size = new System.Drawing.Size(552, 363);
            this.craftingPage.TabIndex = 0;
            this.craftingPage.Text = "Crafting";
            this.craftingPage.UseVisualStyleBackColor = true;
            // 
            // craftingExecute
            // 
            this.craftingExecute.Location = new System.Drawing.Point(471, 33);
            this.craftingExecute.Name = "craftingExecute";
            this.craftingExecute.Size = new System.Drawing.Size(75, 23);
            this.craftingExecute.TabIndex = 1;
            this.craftingExecute.Text = "Execute";
            this.craftingExecute.UseVisualStyleBackColor = true;
            this.craftingExecute.Click += new System.EventHandler(this.CraftingExecuteButtonClick);
            // 
            // craftingMacrosDropdown
            // 
            this.craftingMacrosDropdown.FormattingEnabled = true;
            this.craftingMacrosDropdown.Location = new System.Drawing.Point(282, 6);
            this.craftingMacrosDropdown.Name = "craftingMacrosDropdown";
            this.craftingMacrosDropdown.Size = new System.Drawing.Size(264, 21);
            this.craftingMacrosDropdown.TabIndex = 1;
            this.craftingMacrosDropdown.SelectedIndexChanged += new System.EventHandler(this.UpdateMacroRTB);
            // 
            // craftingMacroRotation
            // 
            this.craftingMacroRotation.Location = new System.Drawing.Point(6, 6);
            this.craftingMacroRotation.Name = "craftingMacroRotation";
            this.craftingMacroRotation.Size = new System.Drawing.Size(270, 351);
            this.craftingMacroRotation.TabIndex = 0;
            this.craftingMacroRotation.Text = "";
            // 
            // characterPage
            // 
            this.characterPage.Controls.Add(this.characterRefresh);
            this.characterPage.Controls.Add(this.characterInfo);
            this.characterPage.Location = new System.Drawing.Point(4, 22);
            this.characterPage.Name = "characterPage";
            this.characterPage.Padding = new System.Windows.Forms.Padding(3);
            this.characterPage.Size = new System.Drawing.Size(552, 363);
            this.characterPage.TabIndex = 1;
            this.characterPage.Text = "Character";
            this.characterPage.UseVisualStyleBackColor = true;
            // 
            // characterRefresh
            // 
            this.characterRefresh.Location = new System.Drawing.Point(6, 6);
            this.characterRefresh.Name = "characterRefresh";
            this.characterRefresh.Size = new System.Drawing.Size(75, 23);
            this.characterRefresh.TabIndex = 1;
            this.characterRefresh.Text = "Refresh";
            this.characterRefresh.UseVisualStyleBackColor = true;
            this.characterRefresh.Click += new System.EventHandler(this.CharacterRefreshClick);
            // 
            // characterInfo
            // 
            this.characterInfo.Location = new System.Drawing.Point(6, 35);
            this.characterInfo.Name = "characterInfo";
            this.characterInfo.Size = new System.Drawing.Size(540, 322);
            this.characterInfo.TabIndex = 0;
            this.characterInfo.Text = "";
            // 
            // aboutPage
            // 
            this.aboutPage.Location = new System.Drawing.Point(4, 22);
            this.aboutPage.Name = "aboutPage";
            this.aboutPage.Padding = new System.Windows.Forms.Padding(3);
            this.aboutPage.Size = new System.Drawing.Size(552, 363);
            this.aboutPage.TabIndex = 2;
            this.aboutPage.Text = "About";
            this.aboutPage.UseVisualStyleBackColor = true;
            // 
            // generalInfoTextbox
            // 
            this.generalInfoTextbox.Location = new System.Drawing.Point(12, 403);
            this.generalInfoTextbox.Name = "generalInfoTextbox";
            this.generalInfoTextbox.Size = new System.Drawing.Size(560, 347);
            this.generalInfoTextbox.TabIndex = 1;
            this.generalInfoTextbox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 762);
            this.Controls.Add(this.generalInfoTextbox);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.marketPage.ResumeLayout(false);
            this.marketFirstRetainerGroupBox.ResumeLayout(false);
            this.marketFirstRetainerGroupBox.PerformLayout();
            this.marketFirstStartPointGroupBox.ResumeLayout(false);
            this.marketSecondRetainerGroupBox.ResumeLayout(false);
            this.marketSecondRetainerGroupBox.PerformLayout();
            this.marketSecondStartPointGroupBox.ResumeLayout(false);
            this.craftingPage.ResumeLayout(false);
            this.characterPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage marketPage;
        private System.Windows.Forms.TabPage craftingPage;
        private System.Windows.Forms.TabPage characterPage;
        private System.Windows.Forms.TabPage aboutPage;
        private System.Windows.Forms.RichTextBox craftingMacroRotation;
        private System.Windows.Forms.ComboBox craftingMacrosDropdown;
        private System.Windows.Forms.Button craftingExecute;
        private System.Windows.Forms.RichTextBox characterInfo;
        private System.Windows.Forms.Button characterRefresh;
        private System.Windows.Forms.Button marketSecondPost;
        private System.Windows.Forms.TextBox marketSecondNumberOfItems;
        private System.Windows.Forms.TextBox marketFirstNumberOfItems;
        private System.Windows.Forms.RichTextBox generalInfoTextbox;
        private System.Windows.Forms.Label marketFirstMinimumLabel;
        private System.Windows.Forms.Label marketFirstNumberOfItemsLabel;
        private System.Windows.Forms.Label marketFirstResetLabel;
        private System.Windows.Forms.TextBox marketSecondReset;
        private System.Windows.Forms.TextBox marketSecondMinimum;
        private System.Windows.Forms.TextBox marketFirstReset;
        private System.Windows.Forms.TextBox marketFirstMinimum;
        private System.Windows.Forms.Label marketSecondResetLabel;
        private System.Windows.Forms.Label marketSecondMinimumLabel;
        private System.Windows.Forms.Label marketSecondNumberOfItemsLabel;
        private System.Windows.Forms.Label marketSecondUndercutLabel;
        private System.Windows.Forms.Label marketFirstUndercutLabel;
        private System.Windows.Forms.TextBox marketSecondUndercut;
        private System.Windows.Forms.TextBox marketFirstUndercut;
        private System.Windows.Forms.GroupBox marketFirstRetainerGroupBox;
        private System.Windows.Forms.GroupBox marketSecondRetainerGroupBox;
        private System.Windows.Forms.GroupBox marketSecondStartPointGroupBox;
        private System.Windows.Forms.Label marketFirstMaximumLabel;
        private System.Windows.Forms.TextBox marketFirstMaximum;
        private System.Windows.Forms.Label marketSecondMaximumLabel;
        private System.Windows.Forms.TextBox marketSecondMaximum;
        private System.Windows.Forms.Button marketSecondStop;
        private System.Windows.Forms.GroupBox marketFirstStartPointGroupBox;
        private System.Windows.Forms.Button marketFirstStop;
        private System.Windows.Forms.Button marketFirstPost;
    }
}

