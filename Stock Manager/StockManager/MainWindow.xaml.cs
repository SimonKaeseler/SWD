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
        private  Portfolio _portfolio;
        private  List<StockValue> _stockMarket;
        private IStockBroker sb;

        public MainWindow()
        {
            InitializeComponent();
            InitializeContent();
            
        }

        private void NewMarketStockBtn_Click(object sender, RoutedEventArgs e)
        {
            AddNewStockToMarketBox.Visibility = System.Windows.Visibility.Visible;
        }

        private void PopUpAddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (StockNameBox.Text != "")
            {
                StockValue newStockValue = new StockValue(StockNameBox.Text);
                if (StockPriceBox.Text != "")
                {
                    newStockValue.Price = Convert.ToDouble(StockPriceBox.Text);

                }
                else
                {
                    newStockValue.Price = 0;
                }

                new StockBroker(newStockValue);
                _stockMarket.Add(newStockValue);
                AddNewStockToMarketBox.Visibility = System.Windows.Visibility.Hidden;
            }
            else
            {
                MessageBox.Show("Please enter a name");
            }
            
        }

        private void PopUpCancelBtn_Click(object sender, RoutedEventArgs e)
        {
            AddNewStockToMarketBox.Visibility = System.Windows.Visibility.Hidden;
        }

        private void BuyStockBtn_Click(object sender, RoutedEventArgs e)
        {
            if (StockMarketDisplay.SelectedValue != null)
            {
                var tempStockValue = _stockMarket[StockMarketDisplay.SelectedIndex];

                for (int i = 0; i < _portfolio.Count; i++)
                {
                    if (_portfolio[i].Name == tempStockValue.Name)
                    {
                        _portfolio[i].Amount += uint.Parse(AmountInput.Text);
                        return;
                    }
                }

                var newStock = new Stock(tempStockValue);
                newStock.Amount = uint.Parse(AmountInput.Text);

                _portfolio.Add(newStock);
            }
            else
            {
                MessageBox.Show("Please select a stock");
            }
        }

        public void InitializeContent()
        {
            _portfolio = new Portfolio();
            _stockMarket = new List<StockValue>();
            PortfolioDisplay.DataContext = _portfolio;
            StockMarketDisplay.DataContext = _stockMarket;
      
            StockValue GoogleStock = new StockValue("Google");
            sb = new StockBroker(GoogleStock);
            GoogleStock.Price = 100000;
            _stockMarket.Add(GoogleStock);

            StockValue FacebookStock = new StockValue("Facebook");
            sb = new StockBroker(FacebookStock);
            FacebookStock.Price = 5000;
            _stockMarket.Add(FacebookStock);

            StockValue VestasStock = new StockValue("Vestas");
            sb = new StockBroker(VestasStock);
            VestasStock.Price = 500;
            _stockMarket.Add(VestasStock);

            StockValue Microsoft = new StockValue("Microsoft");
            sb = new StockBroker(Microsoft);
            Microsoft.Price = 500;
            _stockMarket.Add(Microsoft);

            StockValue mcDonalds = new StockValue("MC Donalds");
            sb = new StockBroker(mcDonalds);
            mcDonalds.Price = 500;
            _stockMarket.Add(mcDonalds);
            
        }

        private void SellStockBtn_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
