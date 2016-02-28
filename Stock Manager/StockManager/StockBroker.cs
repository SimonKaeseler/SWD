using System;
using System.ComponentModel;
using System.Timers;
using System.Windows.Threading;

namespace StockManager
{
    public class StockBroker : IStockBroker
    {
        private readonly DispatcherTimer _timer;
        private readonly StockValue _stockValue;
        private readonly Random _random;

        public StockBroker(StockValue stockValue, bool autoStart = true)
        {
            _random = new Random();
            _stockValue = stockValue;
            _timer = new DispatcherTimer();
            _timer.Tick += OnTimedEvent;
            _timer.Interval = TimeSpan.FromSeconds(1);

            if (autoStart)
                _timer.Start();
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }

        private void OnTimedEvent(object sender, EventArgs e)
        {
            double percent = _random.Next(-5, 5);
            this._stockValue.Price = this._stockValue.Price +
                                          percent/100.0*this._stockValue.Price;
        }
    }
}
