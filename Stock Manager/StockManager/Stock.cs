namespace StockManager
{
    public class Stock : IObserver
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public uint Amount { get; set; }
        private readonly StockValue _stockValue;

        public Stock(StockValue stockValue)
        {
            _stockValue = stockValue;
            
        }
        /// <summary>
        /// When ever a StockValue is updated and it notifies, this is called to pull new info
        /// </summary>
        public void Update()
        {
            throw new System.NotImplementedException();
        }
    }

    public class StockValue
    { }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager
{
    public class Stock : Subject
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

        public Stock(string name)
        {
            Name = name;
        }
    }
}
>>>>>>> 0d80e4e332fd66574c4a792eb9c2dc06bc134c8e
