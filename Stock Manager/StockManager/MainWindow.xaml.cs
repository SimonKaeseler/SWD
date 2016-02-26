using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StockManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Portfolio _portfolio;

        public MainWindow()
        {
            InitializeComponent();
            _portfolio = new Portfolio();
            StockDisplay.ItemsSource = _portfolio;

            StockValue SimonsASS = new StockValue("Simon A/S");
            Stock simonStock = new Stock(SimonsASS);

            _portfolio.Add(simonStock);

            SimonsASS.Price = 50;
        }

        private void AddNewStock_Click(object sender, RoutedEventArgs e)
        {
            StockValue newStockValue = new StockValue(StockNameBox.Text);
            newStockValue.Price = Convert.ToDouble(StockPriceBox.Text);
            Stock newStock = new Stock(newStockValue);
            
            newStockValue.Notify();

            foreach (var stock in _portfolio)
            {
                if (StockNameBox.Text == stock.Name)
                {
                    stock.Amount++;
                    newStockValue.Notify();
                    return;
                }
                    
            }
            _portfolio.Add(newStock);
        }
    }
}
