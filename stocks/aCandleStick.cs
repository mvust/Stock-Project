using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stocks
{
    /// <summary>
    /// class aCandlestick.
    /// </summary>
    public class aCandlestick
    {
        //class has the following private members
        private DateTime _date;
        private decimal _high;
        private decimal _low;
        private decimal _open;
        private decimal _close;
        private decimal _volume;
        private decimal _adjClose;
        private bool _doji;
        private string _dojitype;

        /// <summary>
        /// Default constructor, initialize all values to empty or zero
        /// </summary>
        public aCandlestick()
        {
            _doji = false;
        }

        public bool isDoji()
        {
            decimal percentage = Math.Abs(_open - _close) / ((_open + _close) / 2);
            if (percentage <= 0.002m)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isDragonFlyDoji()
        {
            if (_close >= _open)
            {
                decimal percentage2 = Math.Abs(_high - _close) / ((high + _close) / 2);
                if (percentage2 <= 0.002m)
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
                decimal percentage4 = Math.Abs(_high - _open) / ((_high + _open) / 2);
                if (percentage4 <= 0.002m)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool isGravestoneDoji()
        {
            if (_close >= _open)
            {
                decimal percentage6 = Math.Abs(_open - _low) / ((_open + _low) / 2);
                if (percentage6 <= 0.002m)
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
                decimal percentage8 = Math.Abs(_low - _close) / ((_low + _close) / 2);
                if (percentage8 <= 0.002m)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        //public asscessors, simply set (assign) or get (return) the private class variables;

        /// <summary>
        /// set and get the DateTime value of the aCandleStick.date
        /// </summary>
        public DateTime date
        {
            set { _date = value; }
            get { return _date; }
        }

        /// <summary>
        /// set and get the decimal value of aCandleStick.high
        /// </summary>
        public decimal high
        {
            set { _high = value; }
            get { return _high; }
        }

        /// <summary>
        /// set and get the decimal value of the aCandleStick.low
        /// </summary>
        public decimal low
        {
            set { _low = value; }
            get { return _low; }
        }

        /// <summary>
        /// set and get the decimal value of the aCandleStick.open
        /// </summary>
        public decimal open
        {
            set { _open = value; }
            get { return _open; }
        }

        /// <summary>
        /// set and get the decimal value of the aCandleStick.close
        /// </summary>
        public decimal close
        {
            set { _close = value; }
            get { return _close; }
        }

        /// <summary>
        /// set and get the decimal value of the aCandleStick.volume
        /// </summary>
        public decimal volume
        {
            set { _volume = value; }
            get { return _volume; }
        }

        /// <summary>
        /// set and get the decimal value of the aCandleStick.adjClose
        /// </summary>
        public decimal adjClose
        {
            set { _adjClose = value; }
            get { return _adjClose; }
        }

        public bool doji
        {
            set { _doji = value; }
            get { return _doji; }
        }

        public String dojitype
        {
            set { _dojitype = value; }
            get { return _dojitype; }
        }
    }
}
