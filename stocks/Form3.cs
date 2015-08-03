using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stocks
{
    public partial class Form_graph : Form
    {
        public Form_graph()
        {
            InitializeComponent();
        }

        /// <summary>
        /// this method will bind a list of aCandlestick to a candlestick chart;
        /// it will also display the high/low stock value during the period
        /// </summary>
        /// <param name="candleList">a List of aCandlestick class</aCandleStick></param>
        /// <param name="stockHigh">decimal highest stock value in the period</param>
        /// <param name="stockLow">decimal lowest stock value in the period</param>
        public bool isBearishHarami(aCandlestick one, aCandlestick two)
        {
            if (one.close > one.open)
            {
                if (two.open > two.close)
                {
                    if (two.open < one.close && two.close > one.open)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool isBullishHarami(aCandlestick one, aCandlestick two)
        {
            if (one.open > one.close)
            {
                if (two.close > two.open)
                {
                    if (two.close <= one.open && two.open > one.close)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        
        public void graphIt(List<aCandlestick> candleList, decimal stockHigh, decimal stockLow, string companyName)
        {
            try
            {
                //display the value for high/low stock value
                label_stockHighValue.Text = stockHigh.ToString();
                label_stockLowValue.Text = stockLow.ToString();

                //display the company's name in the chart
                chart_candleChart.Series[0].Name = companyName;

                //getting the upper/lower bound of chart, set to 2% of max value
                double chartScale = Convert.ToDouble(stockHigh) * 0.02;

                //set chart to display +/- 2% of max value in the y axis
                chart_candleChart.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(stockHigh) + chartScale;
                chart_candleChart.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(stockLow) - chartScale;

                List<aCandlestick> special = new List<aCandlestick>();
                List<aCandlestick> special2 = new List<aCandlestick>();
                List<aCandlestick> special3 = new List<aCandlestick>();
                List<aCandlestick> special4 = new List<aCandlestick>();
                List<aCandlestick> special5 = new List<aCandlestick>();

                //bind each candlestick to the chart.
                for (int i = 0; i < candleList.Count; i++)
                {
                    chart_candleChart.Series[0].Points.AddXY(candleList[i].date, candleList[i].high);
                    chart_candleChart.Series[0].Points[i].YValues[1] = Convert.ToDouble(candleList[i].low);
                    chart_candleChart.Series[0].Points[i].YValues[2] = Convert.ToDouble(candleList[i].open);
                    chart_candleChart.Series[0].Points[i].YValues[3] = Convert.ToDouble(candleList[i].close);

                    if(candleList[i].doji == true)
                    {
                        special.Add(candleList[i]);
                    }
                    
                    if(candleList[i].dojitype == "D")
                    {
                        special2.Add(candleList[i]);
                    }

                    if(candleList[i].dojitype == "G")
                    {
                        special3.Add(candleList[i]);
                    }

                    if((i + 1) < candleList.Count)
                    {
                        if(isBearishHarami(candleList[i], candleList[i+1]))
                        {
                            if(!special4.Contains(candleList[i]))
                                special4.Add(candleList[i]);
                            if (!special4.Contains(candleList[i+1]))
                                special4.Add(candleList[i + 1]);
                        }
                        if(isBullishHarami(candleList[i], candleList[i+1]))
                        {
                            if (!special5.Contains(candleList[i]))
                                special5.Add(candleList[i]);
                            if (!special5.Contains(candleList[i + 1]))
                                special5.Add(candleList[i + 1]);
                        }
                    }

                }

               
                // setting the color and transparency for the other series
                    chart_candleChart.Series[1].BorderColor = System.Drawing.Color.Blue;
                    chart_candleChart.Series[1].Color = System.Drawing.Color.Transparent;
                    chart_candleChart.Series[2].BorderColor = System.Drawing.Color.Blue;
                    chart_candleChart.Series[2].Color = System.Drawing.Color.Transparent;
                    chart_candleChart.Series[3].BorderColor = System.Drawing.Color.Blue;
                    chart_candleChart.Series[3].Color = System.Drawing.Color.Transparent;

                    chart_candleChart.Series[4].BorderColor = System.Drawing.Color.Red;
                    chart_candleChart.Series[4].Color = System.Drawing.Color.Transparent;

                    chart_candleChart.Series[5].BorderColor = System.Drawing.Color.Green;
                    chart_candleChart.Series[5].Color = System.Drawing.Color.Transparent;
                

                // checking the candlelist for dojis and adding them to separate series which are hidden

                if (special.Count > 0)
                {
                    for (int j = 0; j < special.Count; j++)
                    {
                        chart_candleChart.Series[1].Points.AddXY(special[j].date, special[j].high);
                        chart_candleChart.Series[1].Points[j].YValues[1] = Convert.ToDouble(special[j].low);
                        chart_candleChart.Series[1].Points[j].YValues[2] = Convert.ToDouble(special[j].high);
                        chart_candleChart.Series[1].Points[j].YValues[3] = Convert.ToDouble(special[j].low);
                    }
                }

                if (special2.Count > 0)
                {
                    for (int j = 0; j < special2.Count; j++)
                    {
                        if (special2[j].doji == true)
                        {
                            chart_candleChart.Series[2].Points.AddXY(special2[j].date, special2[j].high);
                            chart_candleChart.Series[2].Points[j].YValues[1] = Convert.ToDouble(special2[j].low);
                            chart_candleChart.Series[2].Points[j].YValues[2] = Convert.ToDouble(special2[j].high);
                            chart_candleChart.Series[2].Points[j].YValues[3] = Convert.ToDouble(special2[j].low);
                        }
                    }
                }

                if (special3.Count > 0)
                {
                    for (int j = 0; j < special3.Count; j++)
                    {
                        if (special3[j].doji == true)
                        {
                            chart_candleChart.Series[3].Points.AddXY(special3[j].date, special3[j].high);
                            chart_candleChart.Series[3].Points[j].YValues[1] = Convert.ToDouble(special3[j].low);
                            chart_candleChart.Series[3].Points[j].YValues[2] = Convert.ToDouble(special3[j].high);
                            chart_candleChart.Series[3].Points[j].YValues[3] = Convert.ToDouble(special3[j].low);
                        }
                    }
                }

                if (special4.Count > 0)
                {
                    for (int j = 0; j < special4.Count; j++)
                    {
                            chart_candleChart.Series[4].Points.AddXY(special4[j].date, special4[j].high);
                            chart_candleChart.Series[4].Points[j].YValues[1] = Convert.ToDouble(special4[j].low);
                            chart_candleChart.Series[4].Points[j].YValues[2] = Convert.ToDouble(special4[j].high);
                            chart_candleChart.Series[4].Points[j].YValues[3] = Convert.ToDouble(special4[j].low);
                    }
               }
                
                if (special5.Count > 0)
                {
                    for (int j = 0; j < special5.Count; j++)
                    {
                            chart_candleChart.Series[5].Points.AddXY(special5[j].date, special5[j].high);
                            chart_candleChart.Series[5].Points[j].YValues[1] = Convert.ToDouble(special5[j].low);
                            chart_candleChart.Series[5].Points[j].YValues[2] = Convert.ToDouble(special5[j].high);
                            chart_candleChart.Series[5].Points[j].YValues[3] = Convert.ToDouble(special5[j].low);
                    }   
                }
            }
            catch
            {
            
            }    
        }

        private void comboBoxPatterns_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPatterns.Text == "None")
            {
                chart_candleChart.Series[1].Enabled = false;
                chart_candleChart.Series[2].Enabled = false;
                chart_candleChart.Series[3].Enabled = false;
                chart_candleChart.Series[4].Enabled = false;
                chart_candleChart.Series[5].Enabled = false;
            }
            
            if(comboBoxPatterns.Text == "Doji")
            {
                chart_candleChart.Series[1].Enabled = true;
                chart_candleChart.Series[2].Enabled = false;
                chart_candleChart.Series[3].Enabled = false;
                chart_candleChart.Series[4].Enabled = false;
                chart_candleChart.Series[5].Enabled = false;
            }
            
            if(comboBoxPatterns.Text == "Dragon Fly Doji")
            {
                chart_candleChart.Series[1].Enabled = false;
                chart_candleChart.Series[2].Enabled = true;
                chart_candleChart.Series[3].Enabled = false;
                chart_candleChart.Series[4].Enabled = false;
                chart_candleChart.Series[5].Enabled = false;
            }
            if(comboBoxPatterns.Text == "Gravestone Doji")
            {
                chart_candleChart.Series[1].Enabled = false;
                chart_candleChart.Series[2].Enabled = false;
                chart_candleChart.Series[3].Enabled = true;
                chart_candleChart.Series[4].Enabled = false;
                chart_candleChart.Series[5].Enabled = false;
            }
            
            if(comboBoxPatterns.Text == "Bearish Harami")
            {
                chart_candleChart.Series[1].Enabled = false;
                chart_candleChart.Series[2].Enabled = false;
                chart_candleChart.Series[3].Enabled = false;
                chart_candleChart.Series[4].Enabled = true;
                chart_candleChart.Series[5].Enabled = false;
            }
            if(comboBoxPatterns.Text == "Bullish Harami")
            {
                chart_candleChart.Series[1].Enabled = false;
                chart_candleChart.Series[2].Enabled = false;
                chart_candleChart.Series[3].Enabled = false;
                chart_candleChart.Series[4].Enabled = false;
                chart_candleChart.Series[5].Enabled = true;
            }
        }

        private void checkBear_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBear.Checked)
            {
                comboBoxPatterns.Items.Remove("Bullish Harami");
            }
            if (!checkBear.Checked)
            {
                comboBoxPatterns.Items.Add("Bullish Harami");
            }
        }

        private void checkBull_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBull.Checked)
            {
                comboBoxPatterns.Items.Remove("Bearish Harami");
            }
            if (!checkBull.Checked)
            {
                comboBoxPatterns.Items.Add("Bearish Harami");
            }
        }
    }
    
}
