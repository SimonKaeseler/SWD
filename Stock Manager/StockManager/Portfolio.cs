using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Documents;

namespace StockManager
{
    public class Portfolio : ObservableCollection<Stock>
    {
        public Portfolio()
        {
            
        }

        public void AddStock(Stock newStock, double initialPrice)
        {
            Add(new Stock(newStock.Name));
        }
    }
}