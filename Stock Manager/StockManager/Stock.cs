using System.ComponentModel;
using System.Runtime.CompilerServices;
using StockManager.Annotations;

namespace StockManager
{
    public class Stock : IObserver, INotifyPropertyChanged
    {
        public string Name { get; set; }
        public double Price { get; set; }
        
        private uint _amount;
        public uint Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                OnPropertyChanged("Amount");
            }
        }

        private readonly StockValue _stockValue;

        public Stock(StockValue stockValue)
        {
            this._stockValue = stockValue;
            this.Name = stockValue.Name;
            this.Price = stockValue.Price;
            stockValue.Attach(this);
        }

        /// <summary>
        /// When ever a StockValue is updated and it notifies, this is called to pull new info
        /// </summary>
        public void Update()
        {
            Name = _stockValue.Name;
            Price = _stockValue.Price;
            OnPropertyChanged("Price");
            OnPropertyChanged("Name");
        }

        public override string ToString()
        {
            return Amount + "x " + Name + ": " + Price;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
