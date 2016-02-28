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
        private  StockMarket _stockMarket;
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

                Stock newStock = new Stock(newStockValue);

                new StockBroker(newStockValue);
                _stockMarket.Add(newStock);
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
                var tempStockValue = new StockValue(StockMarketDisplay.SelectedValue.ToString());
                var tempStock = new Stock(tempStockValue);

                foreach (var stock in _portfolio)
                {
                    if (stock.Name == tempStock.Name)
                    {
                        stock.Amount = 1 + tempStock.Amount + Convert.ToUInt32(AmountInput.Text);
                        return;
                    }
                   
                }

               
                _portfolio.Add(tempStock);
            }
            else
            {
                MessageBox.Show("Please select a stock");
            }
        }

        public void InitializeContent()
        {
            _portfolio = new Portfolio();
            _stockMarket = new StockMarket();
            PortfolioDisplay.DataContext = _portfolio;
            StockMarketDisplay.DataContext = _stockMarket;
      
            StockValue GoogleStock = new StockValue("Google");
            Stock googleStock = new Stock(GoogleStock);
            sb = new StockBroker(GoogleStock);
            GoogleStock.Price = 100000;
            googleStock.Amount = 2;
            _stockMarket.Add(googleStock);

            StockValue FacebookStock = new StockValue("Facebook");
            Stock fbStock = new Stock(FacebookStock);
            sb = new StockBroker(FacebookStock);
            FacebookStock.Price = 5000;
            _stockMarket.Add(fbStock);

            StockValue VestasStock = new StockValue("Vestas");
            Stock vestasStock = new Stock(VestasStock);
            sb = new StockBroker(VestasStock);
            VestasStock.Price = 500;
            _stockMarket.Add(vestasStock);

            StockValue Microsoft = new StockValue("Microsoft");
            Stock msStock = new Stock(Microsoft);
            sb = new StockBroker(Microsoft);
            Microsoft.Price = 500;
            _stockMarket.Add(msStock);


            StockValue mcDonalds = new StockValue("MC Donalds");
            Stock mcdStock = new Stock(mcDonalds);
            sb = new StockBroker(mcDonalds);
            mcDonalds.Price = 500;
            _stockMarket.Add(mcdStock);
            
        }

        private void SellStockBtn_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
