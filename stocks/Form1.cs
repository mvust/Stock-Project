using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Windows.Forms.DataVisualization.Charting;

namespace stocks
{
    public partial class Form_mainMenu : Form
    {
        public Form_mainMenu()
        {
            InitializeComponent();
        }
        public List<aCandlestick> myCandleList = new List<aCandlestick>();

        /// <summary>
        /// Form load event, when user first runs program;
        /// this will create the folder and subfolders needed to store stock information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_mainMenu_Load(object sender, EventArgs e)
        {
            try
            {
                //create a string containing the path of the TICKER folder
                string pathString = System.IO.Path.Combine(Environment.CurrentDirectory, "TICKERS");
                
                //create that folder using the path name
                System.IO.Directory.CreateDirectory(pathString);

                //in TICKER folder, create 3 sub-folders MONTHLY WEEKLY and DAILY
                System.IO.Directory.CreateDirectory(pathString + @"\MONTHLY");
                System.IO.Directory.CreateDirectory(pathString + @"\WEEKLY");
                System.IO.Directory.CreateDirectory(pathString + @"\DAILY");
                label_status.Text = "Folder and sub-folders created - Program is ready to go";
            }
            catch
            {
                label_status.Text ="Error while attempting to create TICKERS folders and sub-folders";
            }
        }

        /// <summary>
        /// for when the user clicks on the combo box to select a ticker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_tickerList_Click(object sender, EventArgs e)
        {
            //clear the old list, we want the most up to date, since the user has the ability to add/remove tickers
            comboBox_tickerList.Items.Clear();

            //read in the most up to date tickers
            string filePath = Environment.CurrentDirectory;
            filePath += @"\tickers_working.txt";

            try
            {
                //populate the list with all the tickers that we are working with
                string[] ticker_line = File.ReadAllLines(filePath);

                foreach (var line in ticker_line)
                    comboBox_tickerList.Items.Add(line);
            }

            catch
            {
               label_status.Text = filePath + "\n was not found.";
            }
        }

        //whenever we select something different, we want to check if they are selecting
        //<add/remove a ticker> option;
        private void comboBox_tickerList_TextChanged(object sender, EventArgs e)
        {
            //so if they did select that option
            if (comboBox_tickerList.Text == "<add/remove a ticker>")
            {
                //clear the list, since we are going to change it, this will force the combobox to refresh later
                //when we select it again, and not add more on top of what's there
                comboBox_tickerList.Items.Clear();

                //instantiate an addRemoveForm
                Form_addRemoveTicker addRemoveForm = new Form_addRemoveTicker();

                //show that form in dialog mode, so user MUST use that form and not the main one;
                //user can always click exit in addRemoveForm to cancel it
                addRemoveForm.ShowDialog();
            }
        }

        //when user clicks go, must check all the input in the form
        private void button_go_Click(object sender, EventArgs e)
        {
            //create some variable that we are going to use
            string tickerName = string.Empty;
            string companyName = string.Empty;
            decimal stockHigh = 0m;
            decimal stockLow = 1000000m;
            
            //obtain the input from user, radio button in stockperiod box
            string chartRange = "d";
                if (radioButton_weekly.Checked)
                    chartRange = "w";
                else if (radioButton_monthly.Checked)
                    chartRange = "m";

            //make sure user selected a ticker
            if (comboBox_tickerList.Text == "")
            {
                label_status.Text = "Please select a ticker from the list thank you";
            }
            else
            { 
                //split whatever they selected into two chunks
                string[] tickerText = comboBox_tickerList.Text.Split(new char[] { ',' }, 2);
                
                //first chunk contains the symbol
                tickerName = tickerText[0];

                //second chunk contains the company's name
                companyName = tickerText[1].Replace("\"", "");
            
                //fork out from here, either from file or from yahoo;

                //if from yahoo
                if (radioButton_sourceYahoo.Checked)
                {
                    //make a url path with the user-specified information 
                    string urlPath = "http://ichart.finance.yahoo.com/table.csv?s=" +
                                    tickerName + "&a=" +
                                    (dateTimePicker_from.Value.Month - 1) + "&b=" +
                                    dateTimePicker_from.Value.Day + "&c=" +
                                    dateTimePicker_from.Value.Year + "&d=" +
                                    (dateTimePicker_to.Value.Month - 1) + "&e=" +
                                    dateTimePicker_to.Value.Day + "&f=" +
                                    dateTimePicker_to.Value.Year + "&g=" +
                                    chartRange + "&ignore=.csv";

                    //set bigstring to "" so that we can validate it later
                    String myBigstring ="";

                    try
                    {
                        //download and store data in a big string
                        WebClient myWebClient = new WebClient();
                        myBigstring = myWebClient.DownloadString(urlPath).Replace("\r", "");
                    }
                    catch
                    {
                        label_status.Text = "Stock data not available for given inputs, try again";
                    }

                    //make sure we managed to download something, instead of empty.
                    if(myBigstring != "")
                    {
                        //create a new myStock object, empty list so far
                        aStock myStock = new aStock(tickerName, chartRange, companyName);

                        //load the list in myStock object from the strings that we obtained
                        myStock.loadFromString(myBigstring);

                        //get the list of candlesticks that we made
                        List<aCandlestick> candlelist = myStock.getList();

                        //calculate high and low
                        foreach (aCandlestick candle in candlelist)
                        {
                            if (candle.high > stockHigh)
                                stockHigh = candle.high;
                            if (candle.low < stockLow)
                                stockLow = candle.low;
                        }

                        //show graph with all the candlesticks, high/low prices and company name
                        Form_graph myCandleChart = new Form_graph();
                       
                        myCandleChart.graphIt(candlelist, stockHigh, stockLow, companyName);
                        myCandleChart.Show();
                        label_status.Text = "Chart form has been generated - please check to confirm";
                    }

                }
                
                //else if the user had selected from file
                else if (radioButton_sourceFile.Checked)
                {
                    try
                    {
                        //set the period to match the FOLDER's name
                        string period = "DAILY";
                        if (chartRange == "m")
                            period = "MONTHLY";
                        if (chartRange == "w")
                            period = "WEEKLY";

                        //this is going to be used for an attempt to fix a bug in the program
                        //where if you select a range that is shorter than your stock period, stock is not displayed properly
                        int numberOfDay = ((dateTimePicker_to.Value.Year - dateTimePicker_from.Value.Year) * 365) +
                                   ((dateTimePicker_to.Value.Month - dateTimePicker_from.Value.Month) * 30) +
                                   ((dateTimePicker_to.Value.Day - dateTimePicker_from.Value.Day) + 1);

                        //if user selected weekly but only selected a range of 3 days, for example,
                        //or if the user selected monthly but only selected a range of 14 days, for example,
                        //we check what they selected, and how many days are in that range
                        if (((numberOfDay < 30) && period == "MONTHLY") ||
                            ((numberOfDay < 7) && period == "WEEKLY"))
                        {
                            decimal stockHi = 0m;
                            decimal stockLo = 1000000m;

                            //obtain ALL the daily candlesticks from the daily folder
                            aStock myStock = new aStock(tickerName, "DAILY", companyName);
                            
                            //load the candle list from file
                            myStock.load();

                            //store that list in a temporary list
                            List<aCandlestick> tempCandleList = myStock.getList();

                            //create a new list that we are going to actually use
                            List<aCandlestick> newCandleList = new List<aCandlestick>();
                           

                            foreach (var candle in tempCandleList)
                            {
                                //get the appropriate candlestick form temp list that is within range
                                if (candle.date >= dateTimePicker_from.Value && candle.date <= dateTimePicker_to.Value)
                                {
                                    //calculate high and low while we are at it
                                    if (candle.high > stockHi)
                                        stockHi = candle.high;
                                    if (candle.low < stockLo)
                                        stockLo = candle.low;

                                    //add that particular in-range candlestick to our actual list we are using
                                    newCandleList.Add(candle);
                                }
                            }

                            //create a new SINGLE candlestick;
                            //basically combine ALL of the daily candlesticks in the range into one SINGLE one
                            aCandlestick myNewCandle = new aCandlestick();

                            //set the open high low close volume adjClose of the candlestick
                            myNewCandle.open = newCandleList[newCandleList.Count - 1].open;
                            myNewCandle.close = newCandleList[0].close;

                            myNewCandle.low = stockLo;
                            myNewCandle.high = stockHi;
                            myNewCandle.date = newCandleList[newCandleList.Count-1].date;
                            myNewCandle.volume = newCandleList[0].volume;
                            myNewCandle.adjClose = newCandleList[0].adjClose;

                            //clear the list, make it empty
                            newCandleList.Clear();

                            //add the single candlestick we just created to the list
                            newCandleList.Add(myNewCandle);
                           
                            //graph that single stick
                            Form_graph myCandleChart = new Form_graph();
                            myCandleChart.graphIt(newCandleList, stockHi, stockLo, companyName);
                            myCandleChart.Show();
                            label_status.Text = "Chart form has been generated - please check to confirm";
                        }

                        //else the user had selected a proper range
                        else
                        {
                            //create a myStock object
                            aStock myStock = new aStock(tickerName, period, companyName);

                            //load up the list with ALL the candlesticks
                            myStock.load();

                            //if our file is old, update it by appending new information
                            if (myStock.getEndDate() < DateTime.Today)
                            {
                                myStock.append(tickerName, companyName, myStock.getEndDate(), dateTimePicker_to.Value, chartRange);
                            }
                            
                            //create a list that we are going to graph
                            List<aCandlestick> graphList = new List<aCandlestick>();

                            //select all the candlesticks in the valid range and add it to our graph list
                            foreach (aCandlestick candle in myStock.getList())
                            {
                                if (candle.date >= dateTimePicker_from.Value && candle.date <= dateTimePicker_to.Value)
                                {
                                    graphList.Add(candle);
                                    //calculate the high and low while we're at it
                                    if (candle.high > stockHigh)
                                        stockHigh = candle.high;
                                    if (candle.low < stockLow)
                                        stockLow = candle.low;
                                }

                            }

                            //pass information into a new graph form
                            Form_graph myCandleChart = new Form_graph();
                            myCandleChart.graphIt(graphList, stockHigh, stockLow, companyName);
                            myCandleChart.Show();
                            label_status.Text = "Chart form has been generated - please check to confirm";
                        }
                    }
                    catch
                    {
                        label_status.Text ="Stock data not available for given inputs, try again";
                    }
                }
            }
        }
        
        //when user clicks the populate button
        public void button_populate_Click(object sender, EventArgs e)
        {
            //get today's date and time
            DateTime todayDate = System.DateTime.Today;
            
            //read in all the ticker symbols that we are going to populate
            string[] tickerName = File.ReadAllLines(Environment.CurrentDirectory + @"\tickers_working.txt");
            try
            {
                //check to see if the TICKER folder is there... it kept getting deleted while testing and got annoying
                string directoryPath = Environment.CurrentDirectory + @"\TICKERS";
                if (System.IO.Directory.GetDirectories(directoryPath).Length == 0)
                {
                    //do nothing, won't get in here because empty directory will throw exception.
                    //the catch will attempt to reestablish the folder, and re-populate.
                }
            }
            catch
            {
                //programmatically invoke events that create the folders, which is our form load event
                Form_mainMenu_Load(null, null);

                //run populate again basically
                button_populate_Click(null, null);
            }
            
            //for every ticker symbol that we have
            for(int i = 1; i < tickerName.Length; i++)
            {
                //we are going to get the ticker symbol and store it in an array
                string[] columns = tickerName[i].Split(',');
                tickerName[i] = columns[0]; //save those tickers to an array of strings.

                WebClient myWebClient = new WebClient();
                string myBigString = string.Empty;
                string urlPath = string.Empty;
                
                //set all the path to populate data: example ...\TICKERS\MONTHLY\MSFT.csv
                string filePath_monthly = Environment.CurrentDirectory + @"\TICKERS\MONTHLY\" + tickerName[i] + ".csv";
                string filePath_weekly = Environment.CurrentDirectory + @"\TICKERS\WEEKLY\" + tickerName[i] + ".csv";
                string filePath_daily = Environment.CurrentDirectory + @"\TICKERS\DAILY\" + tickerName[i] + ".csv";

                //this happens for every ticker

                //=================================MONTHLY DATA===============================================
                //check to see if it already exists, so we don't have to do extra work
                if (!File.Exists(filePath_monthly))
                {
                    //download and save monthly data to file
                    urlPath = "http://ichart.finance.yahoo.com/table.csv?s=" + tickerName[i] + "&a=" +
                                        0 + "&b=" + 1 + "&c=" + 2010 + "&d=" + (todayDate.Month - 1) + "&e=" +
                                        todayDate.Day + "&f=" + todayDate.Year + "&g=" + "m" + "&ignore=.csv";
                    
                    //download and store to file
                    myBigString = myWebClient.DownloadString(urlPath);
                    File.WriteAllText(filePath_monthly, myBigString);
                }


                //===============================WEEKLY DATA==================================================
                //check to see if it already exists, so we don't have to do extra work
                if (!File.Exists(filePath_weekly))
                {
                    //download and save weekly data to file
                    urlPath = "http://ichart.finance.yahoo.com/table.csv?s=" + tickerName[i] + "&a=" +
                                        0 + "&b=" + 1 + "&c=" + 2010 + "&d=" + (todayDate.Month - 1) + "&e=" +
                                        todayDate.Day + "&f=" + todayDate.Year + "&g=" + "w" + "&ignore=.csv";

                    //download and store to file
                    myBigString = myWebClient.DownloadString(urlPath);
                    File.WriteAllText(filePath_weekly, myBigString);
                }


                //=========================================DAILY DATA===========================================
                //check to see if it already exists, so we don't have to do extra work
                if (!File.Exists(filePath_daily))
                {
                    //download and save daily data to file
                    urlPath = "http://ichart.finance.yahoo.com/table.csv?s=" + tickerName[i] + "&a=" +
                                        0 + "&b=" + 1 + "&c=" + 2010 + "&d=" + (todayDate.Month - 1) + "&e=" +
                                        todayDate.Day + "&f=" + todayDate.Year + "&g=" + "d" + "&ignore=.csv";
                    
                    //download and store to file
                    myBigString = myWebClient.DownloadString(urlPath);
                    File.WriteAllText(filePath_daily, myBigString);
                }
            }
            
           label_status.Text ="Stock Data Have Been Successfully Populated!";
        }

        //when user clicks update, append the old files with new information, do not redownload whole thing
        private void button_update_Click(object sender, EventArgs e)
        {
            //get the ticker symbols that we are updating
            string[] tickerLine = File.ReadAllLines(Environment.CurrentDirectory + @"\tickers_working.txt");
            try
            {
                string directoryPath = Environment.CurrentDirectory + @"\TICKERS";
                if (System.IO.Directory.GetDirectories(directoryPath).Length == 0)
                {
                    //do nothing, won't get in here because empty directory will throw exception.
                    //the catch will attempt to reestablish the folder, and re-populate.
                }
            }
            catch
            {
                //once again, check if the folder actually exists
                //programmatically invoke events that create and populate the folders and files.
                Form_mainMenu_Load(null, null);     //create folders
                button_populate_Click(null, null);  //populate files
            }
            //trying out a new thing called LINQ, see if we have ALL of the .csv file before trying to update
            var fileCount = (from file in Directory.EnumerateFiles(Environment.CurrentDirectory + @"\TICKERS", "*.csv", SearchOption.AllDirectories)
                             select file).Count();

            //if we had 5 tickers, we should have 5 * 3 = 15 files in TICKERS folder
            if (fileCount < (tickerLine.Length - 1) * 3)
            {
                //if any of those files is missing, we are going to repopulate that file before updating
                button_populate_Click(null, null);
            }

            //today's date, so we can get the most current information
            DateTime todayDate = System.DateTime.Today;

            for (int i = 1; i < tickerLine.Length; i++)
            {
                string[] columns = tickerLine[i].Split(',');
                //columns[0] = symbol, columns[1] = company's Name

                //update the ticker.csv file in the DAILY folder
                if(File.Exists(Environment.CurrentDirectory + @"\TICKERS\" + "DAILY" + @"\" + columns[0] + ".csv"))
                {
                    aStock stockdaily = new aStock(columns[0], "DAILY", columns[1]);
                    stockdaily.load();
                    stockdaily.append(columns[0], columns[1], stockdaily.getEndDate(), todayDate, "d");
                }

                //update the ticker.csv file in the WEEKLY folder
                if (File.Exists(Environment.CurrentDirectory + @"\TICKERS\" + "WEEKLY" + @"\" + columns[0] + ".csv"))
                {
                    aStock stockweekly = new aStock(columns[0], "WEEKLY", columns[1]);
                    stockweekly.load();
                    stockweekly.append(columns[0], columns[1], stockweekly.getEndDate(),todayDate, "w");
                }

                //update the ticker.csv file in the MONTHLY folder
                if (File.Exists(Environment.CurrentDirectory + @"\TICKERS\" + "MONTHLY" + @"\" + columns[0] + ".csv"))
                {
                    aStock stockmonthly = new aStock(columns[0], "MONTHLY", columns[1]);
                    stockmonthly.load();
                    stockmonthly.append(columns[0], columns[1], stockmonthly.getEndDate(), todayDate, "m");
                }
            }
            label_status.Text ="Stock data have been updated!";   
        }

        private void button_help_Click(object sender, EventArgs e)
        {
            label_status.Text = "Help form has been generated, please consult for more details\n" +
                                "on how to use the program, thank you";
            Form_help helpForm = new Form_help();
            helpForm.Show();
        }

        private void button_clearALLChart_Click(object sender, EventArgs e)
        {
            //using LINQ cast extension method
            Form[] formsCollection = Application.OpenForms.Cast<Form>().ToArray();
            foreach(Form form in formsCollection)
            {
                //close every opened form except the main one.
                if (form.Name != "Form_mainMenu" && form.Name != "Form_help")
                    form.Close();
            }
            label_status.Text = "ALL chart forms have been cleared...\n" +
                                "Enjoy the clear view :)";
        }  
        
        private void button_exit_Click(object sender, EventArgs e)
        {
            //exit everything!!!
            this.Close();
        }
    }
}
