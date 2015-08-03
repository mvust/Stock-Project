namespace stocks
{
    partial class Form_mainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_mainMenu));
            this.comboBox_tickerList = new System.Windows.Forms.ComboBox();
            this.button_go = new System.Windows.Forms.Button();
            this.button_populate = new System.Windows.Forms.Button();
            this.button_update = new System.Windows.Forms.Button();
            this.label_selectASticker = new System.Windows.Forms.Label();
            this.label_from = new System.Windows.Forms.Label();
            this.label_to = new System.Windows.Forms.Label();
            this.dateTimePicker_from = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_to = new System.Windows.Forms.DateTimePicker();
            this.label_dateRange = new System.Windows.Forms.Label();
            this.groupBox_dateRange = new System.Windows.Forms.GroupBox();
            this.radioButton_monthly = new System.Windows.Forms.RadioButton();
            this.radioButton_weekly = new System.Windows.Forms.RadioButton();
            this.radioButton_daily = new System.Windows.Forms.RadioButton();
            this.groupBox_dataSource = new System.Windows.Forms.GroupBox();
            this.radioButton_sourceFile = new System.Windows.Forms.RadioButton();
            this.radioButton_sourceYahoo = new System.Windows.Forms.RadioButton();
            this.button_help = new System.Windows.Forms.Button();
            this.button_exit = new System.Windows.Forms.Button();
            this.button_clearALLChart = new System.Windows.Forms.Button();
            this.pictureBox_poweredByYahoo = new System.Windows.Forms.PictureBox();
            this.label_status = new System.Windows.Forms.Label();
            this.label_programStatus = new System.Windows.Forms.Label();
            this.panel_status = new System.Windows.Forms.Panel();
            this.groupBox_dateRange.SuspendLayout();
            this.groupBox_dataSource.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_poweredByYahoo)).BeginInit();
            this.panel_status.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_tickerList
            // 
            this.comboBox_tickerList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_tickerList.FormattingEnabled = true;
            this.comboBox_tickerList.Location = new System.Drawing.Point(15, 29);
            this.comboBox_tickerList.Name = "comboBox_tickerList";
            this.comboBox_tickerList.Size = new System.Drawing.Size(261, 21);
            this.comboBox_tickerList.TabIndex = 0;
            this.comboBox_tickerList.TextChanged += new System.EventHandler(this.comboBox_tickerList_TextChanged);
            this.comboBox_tickerList.Click += new System.EventHandler(this.comboBox_tickerList_Click);
            // 
            // button_go
            // 
            this.button_go.Location = new System.Drawing.Point(327, 158);
            this.button_go.Name = "button_go";
            this.button_go.Size = new System.Drawing.Size(75, 23);
            this.button_go.TabIndex = 1;
            this.button_go.Text = "GO!";
            this.button_go.UseVisualStyleBackColor = true;
            this.button_go.Click += new System.EventHandler(this.button_go_Click);
            // 
            // button_populate
            // 
            this.button_populate.Location = new System.Drawing.Point(408, 158);
            this.button_populate.Name = "button_populate";
            this.button_populate.Size = new System.Drawing.Size(75, 23);
            this.button_populate.TabIndex = 2;
            this.button_populate.Text = "Populate";
            this.button_populate.UseVisualStyleBackColor = true;
            this.button_populate.Click += new System.EventHandler(this.button_populate_Click);
            // 
            // button_update
            // 
            this.button_update.Location = new System.Drawing.Point(489, 158);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(75, 23);
            this.button_update.TabIndex = 3;
            this.button_update.Text = "Update";
            this.button_update.UseVisualStyleBackColor = true;
            this.button_update.Click += new System.EventHandler(this.button_update_Click);
            // 
            // label_selectASticker
            // 
            this.label_selectASticker.AutoSize = true;
            this.label_selectASticker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_selectASticker.Location = new System.Drawing.Point(12, 12);
            this.label_selectASticker.Name = "label_selectASticker";
            this.label_selectASticker.Size = new System.Drawing.Size(82, 13);
            this.label_selectASticker.TabIndex = 5;
            this.label_selectASticker.Text = "Select a Ticker:";
            // 
            // label_from
            // 
            this.label_from.AutoSize = true;
            this.label_from.Location = new System.Drawing.Point(12, 119);
            this.label_from.Name = "label_from";
            this.label_from.Size = new System.Drawing.Size(36, 13);
            this.label_from.TabIndex = 6;
            this.label_from.Text = "From: ";
            // 
            // label_to
            // 
            this.label_to.AutoSize = true;
            this.label_to.Location = new System.Drawing.Point(12, 164);
            this.label_to.Name = "label_to";
            this.label_to.Size = new System.Drawing.Size(23, 13);
            this.label_to.TabIndex = 7;
            this.label_to.Text = "To:";
            // 
            // dateTimePicker_from
            // 
            this.dateTimePicker_from.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_from.Location = new System.Drawing.Point(54, 113);
            this.dateTimePicker_from.Name = "dateTimePicker_from";
            this.dateTimePicker_from.Size = new System.Drawing.Size(222, 20);
            this.dateTimePicker_from.TabIndex = 8;
            this.dateTimePicker_from.Value = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            // 
            // dateTimePicker_to
            // 
            this.dateTimePicker_to.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_to.Location = new System.Drawing.Point(54, 158);
            this.dateTimePicker_to.Name = "dateTimePicker_to";
            this.dateTimePicker_to.Size = new System.Drawing.Size(222, 20);
            this.dateTimePicker_to.TabIndex = 9;
            this.dateTimePicker_to.Value = new System.DateTime(2014, 7, 13, 22, 48, 48, 0);
            // 
            // label_dateRange
            // 
            this.label_dateRange.AutoSize = true;
            this.label_dateRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_dateRange.Location = new System.Drawing.Point(12, 81);
            this.label_dateRange.Name = "label_dateRange";
            this.label_dateRange.Size = new System.Drawing.Size(107, 13);
            this.label_dateRange.TabIndex = 6;
            this.label_dateRange.Text = "Select a Date Range";
            // 
            // groupBox_dateRange
            // 
            this.groupBox_dateRange.Controls.Add(this.radioButton_monthly);
            this.groupBox_dateRange.Controls.Add(this.radioButton_weekly);
            this.groupBox_dateRange.Controls.Add(this.radioButton_daily);
            this.groupBox_dateRange.Location = new System.Drawing.Point(327, 12);
            this.groupBox_dateRange.Name = "groupBox_dateRange";
            this.groupBox_dateRange.Size = new System.Drawing.Size(141, 121);
            this.groupBox_dateRange.TabIndex = 10;
            this.groupBox_dateRange.TabStop = false;
            this.groupBox_dateRange.Text = "Date Range";
            // 
            // radioButton_monthly
            // 
            this.radioButton_monthly.AutoSize = true;
            this.radioButton_monthly.Location = new System.Drawing.Point(31, 81);
            this.radioButton_monthly.Name = "radioButton_monthly";
            this.radioButton_monthly.Size = new System.Drawing.Size(62, 17);
            this.radioButton_monthly.TabIndex = 0;
            this.radioButton_monthly.Text = "Monthly";
            this.radioButton_monthly.UseVisualStyleBackColor = true;
            // 
            // radioButton_weekly
            // 
            this.radioButton_weekly.AutoSize = true;
            this.radioButton_weekly.Location = new System.Drawing.Point(31, 56);
            this.radioButton_weekly.Name = "radioButton_weekly";
            this.radioButton_weekly.Size = new System.Drawing.Size(61, 17);
            this.radioButton_weekly.TabIndex = 0;
            this.radioButton_weekly.Text = "Weekly";
            this.radioButton_weekly.UseVisualStyleBackColor = true;
            // 
            // radioButton_daily
            // 
            this.radioButton_daily.AutoSize = true;
            this.radioButton_daily.Checked = true;
            this.radioButton_daily.Location = new System.Drawing.Point(31, 31);
            this.radioButton_daily.Name = "radioButton_daily";
            this.radioButton_daily.Size = new System.Drawing.Size(48, 17);
            this.radioButton_daily.TabIndex = 0;
            this.radioButton_daily.TabStop = true;
            this.radioButton_daily.Text = "Daily";
            this.radioButton_daily.UseVisualStyleBackColor = true;
            // 
            // groupBox_dataSource
            // 
            this.groupBox_dataSource.Controls.Add(this.radioButton_sourceFile);
            this.groupBox_dataSource.Controls.Add(this.radioButton_sourceYahoo);
            this.groupBox_dataSource.Location = new System.Drawing.Point(527, 12);
            this.groupBox_dataSource.Name = "groupBox_dataSource";
            this.groupBox_dataSource.Size = new System.Drawing.Size(141, 120);
            this.groupBox_dataSource.TabIndex = 10;
            this.groupBox_dataSource.TabStop = false;
            this.groupBox_dataSource.Text = "Data Source";
            // 
            // radioButton_sourceFile
            // 
            this.radioButton_sourceFile.AutoSize = true;
            this.radioButton_sourceFile.Checked = true;
            this.radioButton_sourceFile.Location = new System.Drawing.Point(28, 54);
            this.radioButton_sourceFile.Name = "radioButton_sourceFile";
            this.radioButton_sourceFile.Size = new System.Drawing.Size(41, 17);
            this.radioButton_sourceFile.TabIndex = 0;
            this.radioButton_sourceFile.TabStop = true;
            this.radioButton_sourceFile.Text = "File";
            this.radioButton_sourceFile.UseVisualStyleBackColor = true;
            // 
            // radioButton_sourceYahoo
            // 
            this.radioButton_sourceYahoo.AutoSize = true;
            this.radioButton_sourceYahoo.Location = new System.Drawing.Point(28, 31);
            this.radioButton_sourceYahoo.Name = "radioButton_sourceYahoo";
            this.radioButton_sourceYahoo.Size = new System.Drawing.Size(56, 17);
            this.radioButton_sourceYahoo.TabIndex = 0;
            this.radioButton_sourceYahoo.Text = "Yahoo";
            this.radioButton_sourceYahoo.UseVisualStyleBackColor = true;
            // 
            // button_help
            // 
            this.button_help.Location = new System.Drawing.Point(570, 158);
            this.button_help.Name = "button_help";
            this.button_help.Size = new System.Drawing.Size(75, 23);
            this.button_help.TabIndex = 3;
            this.button_help.Text = "Help";
            this.button_help.UseVisualStyleBackColor = true;
            this.button_help.Click += new System.EventHandler(this.button_help_Click);
            // 
            // button_exit
            // 
            this.button_exit.Location = new System.Drawing.Point(651, 193);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(75, 23);
            this.button_exit.TabIndex = 3;
            this.button_exit.Text = "Exit";
            this.button_exit.UseVisualStyleBackColor = true;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // button_clearALLChart
            // 
            this.button_clearALLChart.Location = new System.Drawing.Point(651, 159);
            this.button_clearALLChart.Name = "button_clearALLChart";
            this.button_clearALLChart.Size = new System.Drawing.Size(75, 23);
            this.button_clearALLChart.TabIndex = 11;
            this.button_clearALLChart.Text = "Clear Charts";
            this.button_clearALLChart.UseVisualStyleBackColor = true;
            this.button_clearALLChart.Click += new System.EventHandler(this.button_clearALLChart_Click);
            // 
            // pictureBox_poweredByYahoo
            // 
            this.pictureBox_poweredByYahoo.Image = global::stocks.Properties.Resources.powered_by_yahoo_tag;
            this.pictureBox_poweredByYahoo.Location = new System.Drawing.Point(12, 193);
            this.pictureBox_poweredByYahoo.Name = "pictureBox_poweredByYahoo";
            this.pictureBox_poweredByYahoo.Size = new System.Drawing.Size(150, 23);
            this.pictureBox_poweredByYahoo.TabIndex = 12;
            this.pictureBox_poweredByYahoo.TabStop = false;
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.Location = new System.Drawing.Point(96, 0);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(0, 13);
            this.label_status.TabIndex = 13;
            // 
            // label_programStatus
            // 
            this.label_programStatus.AutoSize = true;
            this.label_programStatus.Location = new System.Drawing.Point(-2, 0);
            this.label_programStatus.Name = "label_programStatus";
            this.label_programStatus.Size = new System.Drawing.Size(82, 13);
            this.label_programStatus.TabIndex = 14;
            this.label_programStatus.Text = "Program Status:";
            // 
            // panel_status
            // 
            this.panel_status.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_status.Controls.Add(this.label_programStatus);
            this.panel_status.Controls.Add(this.label_status);
            this.panel_status.Location = new System.Drawing.Point(168, 196);
            this.panel_status.Name = "panel_status";
            this.panel_status.Size = new System.Drawing.Size(477, 43);
            this.panel_status.TabIndex = 15;
            // 
            // Form_mainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 242);
            this.Controls.Add(this.panel_status);
            this.Controls.Add(this.pictureBox_poweredByYahoo);
            this.Controls.Add(this.button_clearALLChart);
            this.Controls.Add(this.groupBox_dataSource);
            this.Controls.Add(this.groupBox_dateRange);
            this.Controls.Add(this.dateTimePicker_to);
            this.Controls.Add(this.dateTimePicker_from);
            this.Controls.Add(this.label_to);
            this.Controls.Add(this.label_dateRange);
            this.Controls.Add(this.label_from);
            this.Controls.Add(this.label_selectASticker);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.button_help);
            this.Controls.Add(this.button_update);
            this.Controls.Add(this.button_populate);
            this.Controls.Add(this.button_go);
            this.Controls.Add(this.comboBox_tickerList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_mainMenu";
            this.Text = "StockSearch Version 2.0";
            this.Load += new System.EventHandler(this.Form_mainMenu_Load);
            this.groupBox_dateRange.ResumeLayout(false);
            this.groupBox_dateRange.PerformLayout();
            this.groupBox_dataSource.ResumeLayout(false);
            this.groupBox_dataSource.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_poweredByYahoo)).EndInit();
            this.panel_status.ResumeLayout(false);
            this.panel_status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_tickerList;
        private System.Windows.Forms.Button button_go;
        private System.Windows.Forms.Button button_populate;
        private System.Windows.Forms.Button button_update;
        private System.Windows.Forms.Label label_selectASticker;
        private System.Windows.Forms.Label label_from;
        private System.Windows.Forms.Label label_to;
        private System.Windows.Forms.DateTimePicker dateTimePicker_from;
        private System.Windows.Forms.DateTimePicker dateTimePicker_to;
        private System.Windows.Forms.Label label_dateRange;
        private System.Windows.Forms.GroupBox groupBox_dateRange;
        private System.Windows.Forms.GroupBox groupBox_dataSource;
        private System.Windows.Forms.Button button_help;
        private System.Windows.Forms.RadioButton radioButton_monthly;
        private System.Windows.Forms.RadioButton radioButton_weekly;
        private System.Windows.Forms.RadioButton radioButton_daily;
        private System.Windows.Forms.RadioButton radioButton_sourceFile;
        private System.Windows.Forms.RadioButton radioButton_sourceYahoo;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.Button button_clearALLChart;
        private System.Windows.Forms.PictureBox pictureBox_poweredByYahoo;
        public System.Windows.Forms.Label label_status;
        private System.Windows.Forms.Label label_programStatus;
        private System.Windows.Forms.Panel panel_status;
    }
}

