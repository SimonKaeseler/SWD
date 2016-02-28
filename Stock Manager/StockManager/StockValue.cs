using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using StockManager.Annotations;

namespace StockManager
{
    public class StockValue : Subject, INotifyPropertyChanged
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
                    OnPropertyChanged("Price");
                }
            }
        }

        public StockValue(string name)
        {
            Name = name;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}