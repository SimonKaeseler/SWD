using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager
{
    public interface IStockBroker
    {
        void Start();
        void Stop();
    }
}
