namespace StockManager
{
    public class Stock : IObserver
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public uint Amount = 0;
        private StockValue _stockValue;

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
            Amount++;
        }
    }
}
