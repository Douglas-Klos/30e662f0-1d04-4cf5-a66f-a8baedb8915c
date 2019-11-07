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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.execute_crafting_macro_button = new System.Windows.Forms.Button();
            this.macros_dropdown = new System.Windows.Forms.ComboBox();
            this.macro_rotation_rtb = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.refresh_character_sheet = new System.Windows.Forms.Button();
            this.character_rtb = new System.Windows.Forms.RichTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.about_rtb = new System.Windows.Forms.RichTextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.second_retainer_default_label = new System.Windows.Forms.Label();
            this.second_retainer_minimum_label = new System.Windows.Forms.Label();
            this.second_retainer_number_of_items_label = new System.Windows.Forms.Label();
            this.first_retainer_default_label = new System.Windows.Forms.Label();
            this.second_retainer_default_tb = new System.Windows.Forms.TextBox();
            this.second_retainer_minimum_tb = new System.Windows.Forms.TextBox();
            this.first_retainer_default_tb = new System.Windows.Forms.TextBox();
            this.first_retainer_minimum_tb = new System.Windows.Forms.TextBox();
            this.first_retainer_minimum_label = new System.Windows.Forms.Label();
            this.first_retainer_number_of_items_label = new System.Windows.Forms.Label();
            this.retainers_rtb = new System.Windows.Forms.RichTextBox();
            this.second_retainer_number_of_items_tb = new System.Windows.Forms.TextBox();
            this.first_retainer_number_of_items_tb = new System.Windows.Forms.TextBox();
            this.post_retainer_2 = new System.Windows.Forms.Button();
            this.post_retainer_1 = new System.Windows.Forms.Button();
            this.general_info_textbox = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(560, 509);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.execute_crafting_macro_button);
            this.tabPage1.Controls.Add(this.macros_dropdown);
            this.tabPage1.Controls.Add(this.macro_rotation_rtb);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(552, 483);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Home";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // execute_crafting_macro_button
            // 
            this.execute_crafting_macro_button.Location = new System.Drawing.Point(7, 454);
            this.execute_crafting_macro_button.Name = "execute_crafting_macro_button";
            this.execute_crafting_macro_button.Size = new System.Drawing.Size(75, 23);
            this.execute_crafting_macro_button.TabIndex = 1;
            this.execute_crafting_macro_button.Text = "Execute";
            this.execute_crafting_macro_button.UseVisualStyleBackColor = true;
            this.execute_crafting_macro_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // macros_dropdown
            // 
            this.macros_dropdown.FormattingEnabled = true;
            this.macros_dropdown.Location = new System.Drawing.Point(7, 7);
            this.macros_dropdown.Name = "macros_dropdown";
            this.macros_dropdown.Size = new System.Drawing.Size(539, 21);
            this.macros_dropdown.TabIndex = 1;
            this.macros_dropdown.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // macro_rotation_rtb
            // 
            this.macro_rotation_rtb.Location = new System.Drawing.Point(6, 34);
            this.macro_rotation_rtb.Name = "macro_rotation_rtb";
            this.macro_rotation_rtb.Size = new System.Drawing.Size(540, 414);
            this.macro_rotation_rtb.TabIndex = 0;
            this.macro_rotation_rtb.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.refresh_character_sheet);
            this.tabPage2.Controls.Add(this.character_rtb);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(552, 483);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Character";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // refresh_character_sheet
            // 
            this.refresh_character_sheet.Location = new System.Drawing.Point(6, 454);
            this.refresh_character_sheet.Name = "refresh_character_sheet";
            this.refresh_character_sheet.Size = new System.Drawing.Size(75, 23);
            this.refresh_character_sheet.TabIndex = 1;
            this.refresh_character_sheet.Text = "Refresh";
            this.refresh_character_sheet.UseVisualStyleBackColor = true;
            this.refresh_character_sheet.Click += new System.EventHandler(this.button2_Click);
            // 
            // character_rtb
            // 
            this.character_rtb.Location = new System.Drawing.Point(6, 6);
            this.character_rtb.Name = "character_rtb";
            this.character_rtb.Size = new System.Drawing.Size(540, 442);
            this.character_rtb.TabIndex = 0;
            this.character_rtb.Text = "";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.about_rtb);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(552, 483);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "About";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // about_rtb
            // 
            this.about_rtb.Location = new System.Drawing.Point(6, 6);
            this.about_rtb.Name = "about_rtb";
            this.about_rtb.Size = new System.Drawing.Size(540, 471);
            this.about_rtb.TabIndex = 0;
            this.about_rtb.Text = "";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.second_retainer_default_label);
            this.tabPage4.Controls.Add(this.second_retainer_minimum_label);
            this.tabPage4.Controls.Add(this.second_retainer_number_of_items_label);
            this.tabPage4.Controls.Add(this.first_retainer_default_label);
            this.tabPage4.Controls.Add(this.second_retainer_default_tb);
            this.tabPage4.Controls.Add(this.second_retainer_minimum_tb);
            this.tabPage4.Controls.Add(this.first_retainer_default_tb);
            this.tabPage4.Controls.Add(this.first_retainer_minimum_tb);
            this.tabPage4.Controls.Add(this.first_retainer_minimum_label);
            this.tabPage4.Controls.Add(this.first_retainer_number_of_items_label);
            this.tabPage4.Controls.Add(this.retainers_rtb);
            this.tabPage4.Controls.Add(this.second_retainer_number_of_items_tb);
            this.tabPage4.Controls.Add(this.first_retainer_number_of_items_tb);
            this.tabPage4.Controls.Add(this.post_retainer_2);
            this.tabPage4.Controls.Add(this.post_retainer_1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(552, 483);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Retainers";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // second_retainer_default_label
            // 
            this.second_retainer_default_label.AutoSize = true;
            this.second_retainer_default_label.Location = new System.Drawing.Point(406, 83);
            this.second_retainer_default_label.Name = "second_retainer_default_label";
            this.second_retainer_default_label.Size = new System.Drawing.Size(41, 13);
            this.second_retainer_default_label.TabIndex = 18;
            this.second_retainer_default_label.Text = "Default";
            this.second_retainer_default_label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // second_retainer_minimum_label
            // 
            this.second_retainer_minimum_label.AutoSize = true;
            this.second_retainer_minimum_label.Location = new System.Drawing.Point(406, 48);
            this.second_retainer_minimum_label.Name = "second_retainer_minimum_label";
            this.second_retainer_minimum_label.Size = new System.Drawing.Size(48, 13);
            this.second_retainer_minimum_label.TabIndex = 17;
            this.second_retainer_minimum_label.Text = "Minimum";
            this.second_retainer_minimum_label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // second_retainer_number_of_items_label
            // 
            this.second_retainer_number_of_items_label.AutoSize = true;
            this.second_retainer_number_of_items_label.Location = new System.Drawing.Point(406, 13);
            this.second_retainer_number_of_items_label.Name = "second_retainer_number_of_items_label";
            this.second_retainer_number_of_items_label.Size = new System.Drawing.Size(84, 13);
            this.second_retainer_number_of_items_label.TabIndex = 16;
            this.second_retainer_number_of_items_label.Text = "Number of Items";
            this.second_retainer_number_of_items_label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // first_retainer_default_label
            // 
            this.first_retainer_default_label.AutoSize = true;
            this.first_retainer_default_label.Location = new System.Drawing.Point(103, 83);
            this.first_retainer_default_label.Name = "first_retainer_default_label";
            this.first_retainer_default_label.Size = new System.Drawing.Size(41, 13);
            this.first_retainer_default_label.TabIndex = 12;
            this.first_retainer_default_label.Text = "Default";
            this.first_retainer_default_label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // second_retainer_default_tb
            // 
            this.second_retainer_default_tb.Location = new System.Drawing.Point(300, 80);
            this.second_retainer_default_tb.Name = "second_retainer_default_tb";
            this.second_retainer_default_tb.Size = new System.Drawing.Size(100, 20);
            this.second_retainer_default_tb.TabIndex = 11;
            this.second_retainer_default_tb.Text = "500000";
            // 
            // second_retainer_minimum_tb
            // 
            this.second_retainer_minimum_tb.Location = new System.Drawing.Point(300, 45);
            this.second_retainer_minimum_tb.Name = "second_retainer_minimum_tb";
            this.second_retainer_minimum_tb.Size = new System.Drawing.Size(100, 20);
            this.second_retainer_minimum_tb.TabIndex = 10;
            this.second_retainer_minimum_tb.Text = "100000";
            // 
            // first_retainer_default_tb
            // 
            this.first_retainer_default_tb.Location = new System.Drawing.Point(150, 80);
            this.first_retainer_default_tb.Name = "first_retainer_default_tb";
            this.first_retainer_default_tb.Size = new System.Drawing.Size(100, 20);
            this.first_retainer_default_tb.TabIndex = 9;
            this.first_retainer_default_tb.Text = "500000";
            // 
            // first_retainer_minimum_tb
            // 
            this.first_retainer_minimum_tb.Location = new System.Drawing.Point(150, 45);
            this.first_retainer_minimum_tb.Name = "first_retainer_minimum_tb";
            this.first_retainer_minimum_tb.Size = new System.Drawing.Size(100, 20);
            this.first_retainer_minimum_tb.TabIndex = 8;
            this.first_retainer_minimum_tb.Text = "100000";
            // 
            // first_retainer_minimum_label
            // 
            this.first_retainer_minimum_label.AutoSize = true;
            this.first_retainer_minimum_label.Location = new System.Drawing.Point(96, 48);
            this.first_retainer_minimum_label.Name = "first_retainer_minimum_label";
            this.first_retainer_minimum_label.Size = new System.Drawing.Size(48, 13);
            this.first_retainer_minimum_label.TabIndex = 7;
            this.first_retainer_minimum_label.Text = "Minimum";
            this.first_retainer_minimum_label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // first_retainer_number_of_items_label
            // 
            this.first_retainer_number_of_items_label.AutoSize = true;
            this.first_retainer_number_of_items_label.Location = new System.Drawing.Point(60, 13);
            this.first_retainer_number_of_items_label.Name = "first_retainer_number_of_items_label";
            this.first_retainer_number_of_items_label.Size = new System.Drawing.Size(84, 13);
            this.first_retainer_number_of_items_label.TabIndex = 6;
            this.first_retainer_number_of_items_label.Text = "Number of Items";
            this.first_retainer_number_of_items_label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // retainers_rtb
            // 
            this.retainers_rtb.Location = new System.Drawing.Point(6, 243);
            this.retainers_rtb.Name = "retainers_rtb";
            this.retainers_rtb.Size = new System.Drawing.Size(540, 205);
            this.retainers_rtb.TabIndex = 5;
            this.retainers_rtb.Text = "";
            // 
            // second_retainer_number_of_items_tb
            // 
            this.second_retainer_number_of_items_tb.Location = new System.Drawing.Point(300, 10);
            this.second_retainer_number_of_items_tb.Name = "second_retainer_number_of_items_tb";
            this.second_retainer_number_of_items_tb.Size = new System.Drawing.Size(100, 20);
            this.second_retainer_number_of_items_tb.TabIndex = 4;
            this.second_retainer_number_of_items_tb.Text = "1";
            // 
            // first_retainer_number_of_items_tb
            // 
            this.first_retainer_number_of_items_tb.Location = new System.Drawing.Point(150, 10);
            this.first_retainer_number_of_items_tb.Name = "first_retainer_number_of_items_tb";
            this.first_retainer_number_of_items_tb.Size = new System.Drawing.Size(100, 20);
            this.first_retainer_number_of_items_tb.TabIndex = 3;
            this.first_retainer_number_of_items_tb.Text = "1";
            // 
            // post_retainer_2
            // 
            this.post_retainer_2.Location = new System.Drawing.Point(446, 214);
            this.post_retainer_2.Name = "post_retainer_2";
            this.post_retainer_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.post_retainer_2.Size = new System.Drawing.Size(100, 23);
            this.post_retainer_2.TabIndex = 2;
            this.post_retainer_2.Text = "2nd Retainer";
            this.post_retainer_2.UseVisualStyleBackColor = true;
            this.post_retainer_2.Click += new System.EventHandler(this.button4_Click);
            // 
            // post_retainer_1
            // 
            this.post_retainer_1.Location = new System.Drawing.Point(6, 214);
            this.post_retainer_1.Name = "post_retainer_1";
            this.post_retainer_1.Size = new System.Drawing.Size(100, 23);
            this.post_retainer_1.TabIndex = 1;
            this.post_retainer_1.Text = "1st Retainer";
            this.post_retainer_1.UseVisualStyleBackColor = true;
            this.post_retainer_1.Click += new System.EventHandler(this.button3_Click);
            // 
            // general_info_textbox
            // 
            this.general_info_textbox.Location = new System.Drawing.Point(12, 527);
            this.general_info_textbox.Name = "general_info_textbox";
            this.general_info_textbox.Size = new System.Drawing.Size(560, 223);
            this.general_info_textbox.TabIndex = 1;
            this.general_info_textbox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 762);
            this.Controls.Add(this.general_info_textbox);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RichTextBox macro_rotation_rtb;
        private System.Windows.Forms.ComboBox macros_dropdown;
        private System.Windows.Forms.Button execute_crafting_macro_button;
        private System.Windows.Forms.RichTextBox character_rtb;
        private System.Windows.Forms.RichTextBox about_rtb;
        private System.Windows.Forms.Button refresh_character_sheet;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button post_retainer_1;
        private System.Windows.Forms.Button post_retainer_2;
        private System.Windows.Forms.TextBox second_retainer_number_of_items_tb;
        private System.Windows.Forms.TextBox first_retainer_number_of_items_tb;
        private System.Windows.Forms.RichTextBox general_info_textbox;
        private System.Windows.Forms.RichTextBox retainers_rtb;
        private System.Windows.Forms.Label first_retainer_minimum_label;
        private System.Windows.Forms.Label first_retainer_number_of_items_label;
        private System.Windows.Forms.Label first_retainer_default_label;
        private System.Windows.Forms.TextBox second_retainer_default_tb;
        private System.Windows.Forms.TextBox second_retainer_minimum_tb;
        private System.Windows.Forms.TextBox first_retainer_default_tb;
        private System.Windows.Forms.TextBox first_retainer_minimum_tb;
        private System.Windows.Forms.Label second_retainer_default_label;
        private System.Windows.Forms.Label second_retainer_minimum_label;
        private System.Windows.Forms.Label second_retainer_number_of_items_label;
    }
}

