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
            listBox.ItemsSource = _portfolio;

            StockValue SimonsASS = new StockValue("Simon A/S");
            Stock YoStock = new Stock(SimonsASS);

            _portfolio.Add(YoStock);

            SimonsASS.Price = 50;
        }
    }
}
