using System.Collections.Generic;
using System.Windows.Documents;

namespace StockManager
{
    public class Portfolio
    {
        private List<Stock> _myStockList;

        public Portfolio()
        {
            _myStockList = new List<Stock>();
        }
    }
}