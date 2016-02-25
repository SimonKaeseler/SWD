using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager
{
    public class StockValue : Subject
    {
        public string Name { get; private set; }

        private double _price;
        public double Price
        {
            get { return _price; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Cannot have a negative stock price");

                if (_price != value)
                {
                    _price = value;
                    Notify();
                }
            }
        }

        public StockValue(string name)
        {
            Name = name;
        }
    }
}