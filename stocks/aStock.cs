using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace stocks
{
    public class aStock
    {
        private string _ticker;
        private string _period;
        private string _companyName;
        private List<aCandlestick> candleList;
        
        /// <summary>
        /// default constructor, empty;
        /// </summary>
        public aStock()
        {

        }

        /// <summary>
        /// aStock constructor takes 3 arguments: 
        /// </summary>
        /// <param name="ticker">ticker name: example "MSFT"</param>
        /// <param name="period">stock period: example "WEEKLY"</param>
        /// <param name="companyName">name of company: exampe "Microsoft Inc."</param>
        public aStock(string ticker, string period, string companyName)
        {
            candleList = new List<aCandlestick>();
            _ticker = ticker;
            _period = period;
            _companyName = companyName;
        }
        
        /// <summary>
        /// this method will save the List<aCandleStick> within this object into a file specified
        /// by the ticker name and the stock period
        /// </summary>
        public void save()
        {
            //create a string which contains the path name for the file that we need to create
            string filePath = Environment.CurrentDirectory + @"\TICKERS\" + _period + @"\" + _ticker + ".csv";

            //create a giant string with the first line containing the header information
            string myFile = "Date,Open,High,Low,Close,Volume,Adj Close\n";

            //add in all the candlestick information converted to string
            for (int i = 0; i < candleList.Count; i++)
            {
                myFile += candleList[i].date.ToString() + ",";
                myFile += candleList[i].open.ToString() + ",";
                myFile += candleList[i].high.ToString() + ",";
                myFile += candleList[i].low.ToString() + ",";
                myFile += candleList[i].close.ToString() + ",";
                myFile += candleList[i].volume.ToString() + ",";
                myFile += candleList[i].adjClose.ToString() + "\n";

            }
            
            //write that big string into the text file, with the path we created in the beginning of this method
            File.WriteAllText(filePath, myFile);
        }

        /// <summary>
        /// this method will take in a big string (downloaded from the net maybe),
        /// parse it, create a list of candlestick object, 
        /// the aStock object must be created using the aStock(string ticker, string period, string companyName) constructor
        /// before you can use this method.
        /// </summary>
        /// <param name="myBigString">string downloaded from the internet, or read from file</param>
        public void loadFromString(string myBigString)
        {
            //split the big string into rows
            string[] rows = myBigString.Split('\n');

            //further split those rows into columns and then set each of the candlestick's properties

            for (int i = 1; i < rows.Length - 1; i++)
            {
                //split it into columns
                string[] columns = rows[i].Split(',');

                //make a new candlestick
                aCandlestick candlestick = new aCandlestick();

                //load that candlestick with information from parsing 
                candlestick.date = Convert.ToDateTime(columns[0]);
                candlestick.open = Convert.ToDecimal(columns[1]);
                candlestick.high = Convert.ToDecimal(columns[2]);
                candlestick.low = Convert.ToDecimal(columns[3]);
                candlestick.close = Convert.ToDecimal(columns[4]);
                candlestick.volume = Convert.ToDecimal(columns[5]);
                candlestick.adjClose = Convert.ToDecimal(columns[6]);

                if (candlestick.isDoji())
                {
                    candlestick.doji = true;
                }
                    
                if (candlestick.isDragonFlyDoji() && candlestick.doji == true)
                {
                    candlestick.dojitype = "D";
                }
                
                if (candlestick.isGravestoneDoji() && candlestick.doji == true)
                {
                    candlestick.dojitype = "G";
                }
                                
                //insert the new stick into the list
                candleList.Insert(i - 1, candlestick);
            }
        }

        /// <summary>
        /// this method will load the List of candlestick into aStock object via loadFromString(string) method
        /// </summary>
        public void load()
        {
            //build file path
            string filePath = Environment.CurrentDirectory + @"\TICKERS\" + _period + @"\" + _ticker + ".csv";

            //read the file into a big string
            string myBigString = File.ReadAllText(filePath);

            //call on loadFromString method to parse/create candlesticks
            loadFromString(myBigString);   
        }

        /// <summary>
        /// this method will download stock information from yahoo with the daterange from the last candlestick
        /// in your file, to the most current date
        /// </summary>
        /// <param name="ticker">ticker symbol</param>
        /// <param name="companyname">name of company</param>
        /// <param name="from">datetime range start update at (end of available date in file)</param>
        /// <param name="to">datetime range end (current date) </param>
        /// <param name="period">stock period: WEEKLY, MONTHLY, or DAILY</param>
        public void append(string ticker, string companyname, DateTime from, DateTime to, string period)
        {
            //set up URL path to download update data
            string urlPath = "http://ichart.finance.yahoo.com/table.csv?s=" +
                                    ticker + "&a=" +
                                    (from.Month - 1) + "&b=" +
                                    from.Day + "&c=" +
                                    from.Year + "&d=" +
                                    (to.Month - 1) + "&e=" +
                                    to.Day + "&f=" +
                                    to.Year + "&g=" +
                                    period + "&ignore=.csv";

            string myBigString = "";
            try
            {
                //download the data into a big string
                WebClient myWebClient = new WebClient();
                myBigString = myWebClient.DownloadString(urlPath).Replace("\r", "");
            }
                
            catch
            {
                MessageBox.Show("An error has occurred while attempting to download update file");
            }
            
            if (myBigString != "")
            {
                //remove the first candlestick in the list
                candleList.Remove(candleList[0]);

                //load the new candlestick into the list
                loadFromString(myBigString);

                //save to file, it will now have the new list appended at top of old list
                save();
            }
        }
        
        public bool isBearishHarami(aCandlestick one, aCandlestick two)
        {
            // maybe check if candlesticks are doji
            
            if(one.close > one.open)
            {
                if(two.open > two.close)
                {
                    if(two.open < one.close && two.close > one.open)
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
        
        /// <summary>
        /// return the starting date of the oldest candlestick in the list
        /// </summary>
        /// <returns></returns>
        
        public DateTime getStartDate()
        {
            return candleList[candleList.Count - 1].date;
        }


        /// <summary>
        /// returns the date of the most current candlestick in the list
        /// </summary>
        /// <returns></returns>
        public DateTime getEndDate() 
        {
            return candleList[0].date;
        }
        
        //returns the list of candle stick of the aStock object
        public List<aCandlestick> getList()
        {
            return candleList;
        }
        
        //set and get the list of candlestick in aStock
        public List<aCandlestick> CandleList
        {
            set { candleList = value; }
            get { return candleList; }
        }

        //set and get the company name in aStock
        public string CompanyName
        {
            set { _companyName = value; }
            get { return _companyName; }
        }

    }
    
}
