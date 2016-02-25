namespace StockManager
{
    public class Stock : IObserver
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public uint Amount { get; set; }
        private  StockValue _stockValue;

        public Stock()
        {
            _stockValue = new StockValue();
           

        }
        /// <summary>
        /// When ever a StockValue is updated and it notifies, this is called to pull new info
        /// </summary>
        public void Update()
        {
            Name = _stockValue.name;
            Price = _stockValue.price;
            Amount = _stockValue.amount;
        }
    }
}
