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
}
