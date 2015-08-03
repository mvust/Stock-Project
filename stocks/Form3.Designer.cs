namespace stocks
{
    partial class Form_graph
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series19 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series20 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series21 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series22 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series23 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series24 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart_candleChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label_stockHigh = new System.Windows.Forms.Label();
            this.label_stockHighValue = new System.Windows.Forms.Label();
            this.label_stockLow = new System.Windows.Forms.Label();
            this.label_stockLowValue = new System.Windows.Forms.Label();
            this.comboBoxPatterns = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBear = new System.Windows.Forms.CheckBox();
            this.checkBull = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart_candleChart)).BeginInit();
            this.SuspendLayout();
            // 
            // chart_candleChart
            // 
            this.chart_candleChart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            chartArea4.Name = "ChartArea1";
            this.chart_candleChart.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chart_candleChart.Legends.Add(legend4);
            this.chart_candleChart.Location = new System.Drawing.Point(0, -1);
            this.chart_candleChart.Name = "chart_candleChart";
            series19.ChartArea = "ChartArea1";
            series19.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series19.CustomProperties = "PriceDownColor=Red, PriceUpColor=Lime";
            series19.Legend = "Legend1";
            series19.Name = "Series1";
            series19.YValuesPerPoint = 4;
            series20.ChartArea = "ChartArea1";
            series20.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series20.CustomProperties = "PriceDownColor=Transparent, PriceUpColor=Transparent";
            series20.Enabled = false;
            series20.IsVisibleInLegend = false;
            series20.Legend = "Legend1";
            series20.Name = "Doji";
            series20.YValuesPerPoint = 4;
            series21.ChartArea = "ChartArea1";
            series21.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series21.CustomProperties = "PriceDownColor=Transparent, PriceUpColor=Transparent";
            series21.Enabled = false;
            series21.IsVisibleInLegend = false;
            series21.Legend = "Legend1";
            series21.Name = "Dragon Fly Doji";
            series21.YValuesPerPoint = 4;
            series22.ChartArea = "ChartArea1";
            series22.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series22.CustomProperties = "PriceDownColor=Transparent, PriceUpColor=Transparent";
            series22.Enabled = false;
            series22.IsVisibleInLegend = false;
            series22.Legend = "Legend1";
            series22.Name = "Gravestone Doji";
            series22.YValuesPerPoint = 4;
            series23.ChartArea = "ChartArea1";
            series23.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series23.CustomProperties = "PriceDownColor=Transparent, PriceUpColor=Transparent";
            series23.Enabled = false;
            series23.IsVisibleInLegend = false;
            series23.Legend = "Legend1";
            series23.Name = "Bearish Harami";
            series23.YValuesPerPoint = 4;
            series24.ChartArea = "ChartArea1";
            series24.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series24.CustomProperties = "PriceDownColor=Transparent, PriceUpColor=Transparent";
            series24.Enabled = false;
            series24.IsVisibleInLegend = false;
            series24.Legend = "Legend1";
            series24.Name = "Bullish Harami";
            series24.YValuesPerPoint = 4;
            this.chart_candleChart.Series.Add(series19);
            this.chart_candleChart.Series.Add(series20);
            this.chart_candleChart.Series.Add(series21);
            this.chart_candleChart.Series.Add(series22);
            this.chart_candleChart.Series.Add(series23);
            this.chart_candleChart.Series.Add(series24);
            this.chart_candleChart.Size = new System.Drawing.Size(770, 437);
            this.chart_candleChart.TabIndex = 0;
            this.chart_candleChart.Text = "chart1";
            // 
            // label_stockHigh
            // 
            this.label_stockHigh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_stockHigh.AutoSize = true;
            this.label_stockHigh.Location = new System.Drawing.Point(799, 48);
            this.label_stockHigh.Name = "label_stockHigh";
            this.label_stockHigh.Size = new System.Drawing.Size(60, 13);
            this.label_stockHigh.TabIndex = 1;
            this.label_stockHigh.Text = "Stock High";
            // 
            // label_stockHighValue
            // 
            this.label_stockHighValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_stockHighValue.AutoSize = true;
            this.label_stockHighValue.Location = new System.Drawing.Point(880, 48);
            this.label_stockHighValue.Name = "label_stockHighValue";
            this.label_stockHighValue.Size = new System.Drawing.Size(28, 13);
            this.label_stockHighValue.TabIndex = 1;
            this.label_stockHighValue.Text = "0.00";
            // 
            // label_stockLow
            // 
            this.label_stockLow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_stockLow.AutoSize = true;
            this.label_stockLow.Location = new System.Drawing.Point(801, 74);
            this.label_stockLow.Name = "label_stockLow";
            this.label_stockLow.Size = new System.Drawing.Size(58, 13);
            this.label_stockLow.TabIndex = 1;
            this.label_stockLow.Text = "Stock Low";
            // 
            // label_stockLowValue
            // 
            this.label_stockLowValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_stockLowValue.AutoSize = true;
            this.label_stockLowValue.Location = new System.Drawing.Point(880, 74);
            this.label_stockLowValue.Name = "label_stockLowValue";
            this.label_stockLowValue.Size = new System.Drawing.Size(28, 13);
            this.label_stockLowValue.TabIndex = 1;
            this.label_stockLowValue.Text = "0.00";
            // 
            // comboBoxPatterns
            // 
            this.comboBoxPatterns.FormattingEnabled = true;
            this.comboBoxPatterns.Items.AddRange(new object[] {
            "None",
            "Doji",
            "Dragon Fly Doji",
            "Gravestone Doji",
            "Bearish Harami",
            "Bullish Harami"});
            this.comboBoxPatterns.Location = new System.Drawing.Point(802, 158);
            this.comboBoxPatterns.Name = "comboBoxPatterns";
            this.comboBoxPatterns.Size = new System.Drawing.Size(208, 21);
            this.comboBoxPatterns.TabIndex = 2;
            this.comboBoxPatterns.Text = "None";
            this.comboBoxPatterns.SelectedIndexChanged += new System.EventHandler(this.comboBoxPatterns_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(799, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Pick which type of pattern to be highlighted:";
            // 
            // checkBear
            // 
            this.checkBear.AutoSize = true;
            this.checkBear.Location = new System.Drawing.Point(802, 202);
            this.checkBear.Name = "checkBear";
            this.checkBear.Size = new System.Drawing.Size(127, 17);
            this.checkBear.TabIndex = 4;
            this.checkBear.Text = "Only Bearish Patterns";
            this.checkBear.UseVisualStyleBackColor = true;
            this.checkBear.CheckedChanged += new System.EventHandler(this.checkBear_CheckedChanged);
            // 
            // checkBull
            // 
            this.checkBull.AutoSize = true;
            this.checkBull.Location = new System.Drawing.Point(802, 226);
            this.checkBull.Name = "checkBull";
            this.checkBull.Size = new System.Drawing.Size(122, 17);
            this.checkBull.TabIndex = 5;
            this.checkBull.Text = "Only Bullish Patterns";
            this.checkBull.UseVisualStyleBackColor = true;
            this.checkBull.CheckedChanged += new System.EventHandler(this.checkBull_CheckedChanged);
            // 
            // Form_graph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 436);
            this.Controls.Add(this.checkBull);
            this.Controls.Add(this.checkBear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxPatterns);
            this.Controls.Add(this.label_stockLowValue);
            this.Controls.Add(this.label_stockLow);
            this.Controls.Add(this.label_stockHighValue);
            this.Controls.Add(this.label_stockHigh);
            this.Controls.Add(this.chart_candleChart);
            this.Name = "Form_graph";
            this.Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)(this.chart_candleChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart_candleChart;
        private System.Windows.Forms.Label label_stockHigh;
        private System.Windows.Forms.Label label_stockHighValue;
        private System.Windows.Forms.Label label_stockLow;
        private System.Windows.Forms.Label label_stockLowValue;
        private System.Windows.Forms.ComboBox comboBoxPatterns;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBear;
        private System.Windows.Forms.CheckBox checkBull;
    }
}