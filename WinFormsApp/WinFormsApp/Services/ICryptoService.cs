using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp.Models;

namespace WinFormsApp.Services
{
    // Interface for crypto price operations
    public interface ICryptoService
    {
        List<Coin> GetTrendingCoins();
        Coin GetCoinBySymbol(string symbol);
        void RefreshPrices();
    }
}
