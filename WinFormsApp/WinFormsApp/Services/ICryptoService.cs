using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp.Models;
using PriceHistory = WinFormsApp.Models.CoinGeckoMarketData.PriceHistory;

namespace WinFormsApp.Services
{

    /// Interface for crypto price operations
    /// Updated to support async operations for API calls
    public interface ICryptoService
    {

        List<Coin> GetTrendingCoins();
        Coin GetCoinBySymbol(string symbol);
        void RefreshPrices();

        Task<List<Coin>> GetAllCoinsAsync();
        Task RefreshPricesAsync();
        Task<List<PriceHistory>> GetPriceHistoryAsync(string symbol);
        string GetCacheStatus();
    }
}
