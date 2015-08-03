namespace stocks
{
    partial class Form_addRemoveTicker
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
            this.comboBox_addTicker = new System.Windows.Forms.ComboBox();
            this.button_addTicker = new System.Windows.Forms.Button();
            this.button_Exit = new System.Windows.Forms.Button();
            this.label_addTicker = new System.Windows.Forms.Label();
            this.comboBox_removeTicker = new System.Windows.Forms.ComboBox();
            this.button_removeTicker = new System.Windows.Forms.Button();
            this.label_removeTicker = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox_addTicker
            // 
            this.comboBox_addTicker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_addTicker.FormattingEnabled = true;
            this.comboBox_addTicker.Location = new System.Drawing.Point(21, 51);
            this.comboBox_addTicker.Name = "comboBox_addTicker";
            this.comboBox_addTicker.Size = new System.Drawing.Size(293, 21);
            this.comboBox_addTicker.TabIndex = 0;
            this.comboBox_addTicker.Click += new System.EventHandler(this.comboBox_addTicker_Click);
            // 
            // button_addTicker
            // 
            this.button_addTicker.Location = new System.Drawing.Point(96, 90);
            this.button_addTicker.Name = "button_addTicker";
            this.button_addTicker.Size = new System.Drawing.Size(103, 23);
            this.button_addTicker.TabIndex = 1;
            this.button_addTicker.Text = "Add";
            this.button_addTicker.UseVisualStyleBackColor = true;
            this.button_addTicker.Click += new System.EventHandler(this.button_addTicker_Click);
            // 
            // button_Exit
            // 
            this.button_Exit.Location = new System.Drawing.Point(292, 111);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(103, 23);
            this.button_Exit.TabIndex = 2;
            this.button_Exit.Text = "Exit";
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // label_addTicker
            // 
            this.label_addTicker.AutoSize = true;
            this.label_addTicker.Location = new System.Drawing.Point(18, 25);
            this.label_addTicker.Name = "label_addTicker";
            this.label_addTicker.Size = new System.Drawing.Size(181, 13);
            this.label_addTicker.TabIndex = 3;
            this.label_addTicker.Text = "Select a new ticker to add to your list";
            // 
            // comboBox_removeTicker
            // 
            this.comboBox_removeTicker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_removeTicker.FormattingEnabled = true;
            this.comboBox_removeTicker.Location = new System.Drawing.Point(391, 51);
            this.comboBox_removeTicker.Name = "comboBox_removeTicker";
            this.comboBox_removeTicker.Size = new System.Drawing.Size(293, 21);
            this.comboBox_removeTicker.TabIndex = 0;
            this.comboBox_removeTicker.Click += new System.EventHandler(this.comboBox_removeTicker_Click);
            // 
            // button_removeTicker
            // 
            this.button_removeTicker.Location = new System.Drawing.Point(490, 90);
            this.button_removeTicker.Name = "button_removeTicker";
            this.button_removeTicker.Size = new System.Drawing.Size(103, 23);
            this.button_removeTicker.TabIndex = 1;
            this.button_removeTicker.Text = "Remove";
            this.button_removeTicker.UseVisualStyleBackColor = true;
            this.button_removeTicker.Click += new System.EventHandler(this.button_removeTicker_Click);
            // 
            // label_removeTicker
            // 
            this.label_removeTicker.AutoSize = true;
            this.label_removeTicker.Location = new System.Drawing.Point(388, 25);
            this.label_removeTicker.Name = "label_removeTicker";
            this.label_removeTicker.Size = new System.Drawing.Size(207, 13);
            this.label_removeTicker.TabIndex = 3;
            this.label_removeTicker.Text = "Select a ticker from your list to be removed";
            // 
            // Form_addRemoveTicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 146);
            this.Controls.Add(this.label_removeTicker);
            this.Controls.Add(this.label_addTicker);
            this.Controls.Add(this.button_Exit);
            this.Controls.Add(this.button_removeTicker);
            this.Controls.Add(this.button_addTicker);
            this.Controls.Add(this.comboBox_removeTicker);
            this.Controls.Add(this.comboBox_addTicker);
            this.Name = "Form_addRemoveTicker";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Add/remove a ticker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_addTicker;
        private System.Windows.Forms.Button button_addTicker;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Label label_addTicker;
        private System.Windows.Forms.ComboBox comboBox_removeTicker;
        private System.Windows.Forms.Button button_removeTicker;
        private System.Windows.Forms.Label label_removeTicker;
    }
}