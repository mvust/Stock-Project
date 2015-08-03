using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

namespace stocks
{
    public partial class Form_addRemoveTicker : Form
    {
        public Form_addRemoveTicker()
        {
            InitializeComponent();
        }

        //path of the file that contains the list of ticker we are working with (default is 5 tickers);
        public string filePath_myTickers = Environment.CurrentDirectory + @"\tickers_working.txt";

        //path of the file that contains all the tickers there are...almost all
        public string filePath_allTickers = Environment.CurrentDirectory + @"\tickers_all.txt";

        //will hold the list of tickers we are working with, so we can manipulate easier, like inserting, sorting...
        public List<string> list_myTickers = new List<string>();


        //when the user clicks the remove ticker combobox
        private void comboBox_removeTicker_Click(object sender, EventArgs e)
        {
            //clear it first, in case we had old list in there, we want the most up to date list.
            comboBox_removeTicker.Items.Clear();

            try
            {
                //read in the tickers from our file
                string[] tickerLine = File.ReadAllLines(filePath_myTickers);
                foreach (var line in tickerLine)
                {
                    //skip this "<add/remove a ticker>" line, do not show it in the list
                    if (line != "<add/remove a ticker>")
                    {
                        //add the valid ticker line into our combobox, loop back, until there is no more
                        comboBox_removeTicker.Items.Add(line);
                    }
                }
            }
            catch
            {
                //if we can't find the file for some reason, handle that exception with an error
                MessageBox.Show(filePath_myTickers + " was not found.");
            }
        }


        //when the user clicks the remove button
        private void button_removeTicker_Click(object sender, EventArgs e)
        {
            if (comboBox_removeTicker.Text == "")
            {
                //make sure something from the list has already been selected and not blank
                MessageBox.Show("please select a ticker to be removed or click Exit.");
            }
            else
            {
                try
                {
                    //obtain the ticker symbol from combobox.text
                    string[] tickerName = comboBox_removeTicker.Text.Split(',');

                    //find that file in the monthly folder: SYMBOL.csv
                    string filePath = Environment.CurrentDirectory + @"\TICKERS\MONTHLY\" + tickerName[0] + ".csv";

                    //delete it in the monthly folder
                    File.Delete(filePath);

                    //find and delete TICKER.csv in the weekly folder
                    filePath = Environment.CurrentDirectory + @"\TICKERS\WEEKLY\" + tickerName[0] + ".csv";
                    File.Delete(filePath);

                    //find and delete TICKER.csv in the daily
                    filePath = Environment.CurrentDirectory + @"\TICKERS\DAILY\" + tickerName[0] + ".csv";
                    File.Delete(filePath);

                    //rewrite the working_tickers.txt file, because it has our list of tickers we are working with
                    //set up a temporary file
                    string tempFile = Path.GetTempFileName();
                    using (var sReader = new StreamReader("tickers_working.txt"))

                    //stream the content of the old file into tempfile, EXCEPT the line that we want to delete
                    using (var sWriter = new StreamWriter(tempFile))
                    {
                        string line;
                        while ((line = sReader.ReadLine()) != null)
                        {
                            //the line that we want to delete is the same as the remove selection from combobox.text
                            if (line != comboBox_removeTicker.Text)
                            {
                                //so if it's not the same, then stream to tempfile
                                sWriter.WriteLine(line);
                            }
                        }
                    }

                    //delete the old file
                    File.Delete("tickers_working.txt");

                    //replace with the tempfile
                    File.Move(tempFile, "tickers_working.txt");

                    //clear the combo list, so that it must repopulate again when user clicks
                    //so it will so the updated list.
                    comboBox_removeTicker.Items.Clear();
                }
                catch
                {
                    MessageBox.Show("something went wrong here!");
                }
            }
        }

        //when the user clicks the combobox to add a ticker
        private void comboBox_addTicker_Click(object sender, EventArgs e)
        {
            //check to see if the list has already been populated
            if (comboBox_addTicker.Items.Count <= 0)
            {
                try
                {
                    //obtain the information from the file that has ALL the ticker
                    string[] tickerLine = File.ReadAllLines(filePath_allTickers);
                    foreach (var line in tickerLine)
                    {
                        //populate the dropdown list
                        comboBox_addTicker.Items.Add(line);
                    }
                }
                catch
                {
                    MessageBox.Show(filePath_allTickers + " was not found.");
                }
            }
        }

        //when the user actually clicks the ADD TO LIST button
        private void button_addTicker_Click(object sender, EventArgs e)
        {
            //make sure something was selected   
            if (comboBox_addTicker.Text == "")
            {
                MessageBox.Show("Please select a ticker to be added or click Exit.");
            }

            else
            {
                //clear our old list
                list_myTickers.Clear();
                try
                {
                    bool matched = false;
                    foreach (string line in File.ReadAllLines("tickers_working.txt"))
                    {
                        //find the ticker line that is the same as what we selected to be added
                        if (comboBox_addTicker.Text == line)
                        {
                            //set the flag matched to true
                            matched = true;
                        }
                        //add the line to a list of ticker, that way we can insert or sort if needed.
                        list_myTickers.Add(line);

                    }

                    //if the matched flag was not raised
                    if (!matched)
                    {
                        //then we insert that ticker into our list of ticker
                        list_myTickers.Insert((list_myTickers.Count - 1), comboBox_addTicker.Text);

                        //sort it, so it will be alphabetically displayed
                        list_myTickers.Sort();

                        //create a tempfile and stream the content of our list into that file
                        string tempFile = Path.GetTempFileName();
                        using (var sWriter = new StreamWriter(tempFile))
                        {
                            foreach (var line in list_myTickers)
                                sWriter.WriteLine(line);
                        }

                        //delete the old file
                        File.Delete("tickers_working.txt");
                        //replace it with new tempfile
                        File.Move(tempFile, "tickers_working.txt");

                        //create an instance of mainform in memory
                        Form_mainMenu newForm = new Form_mainMenu();

                        //programmatically invoke the populate button event
                        //this will check the folders and see that the new ticker files do not exist and populate it from the internet
                        newForm.button_populate_Click(null, null);
                    }
                    else
                        MessageBox.Show("You already have that ticker in your list");
                }
                catch
                {
                    MessageBox.Show(filePath_allTickers + " was not found.");
                }
            }
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
