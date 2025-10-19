using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp.Models;
using PriceHistory = WinFormsApp.Models.CoinGeckoMarketData.PriceHistory;

namespace WinFormsApp.Services
{
    /// <summary>
    /// Interface for crypto price operations
    /// Updated to support async operations for API calls
    /// </summary>
    public interface ICryptoService
    {
        // Existing synchronous methods (keep for backward compatibility)
        List<Coin> GetTrendingCoins();
        Coin GetCoinBySymbol(string symbol);
        void RefreshPrices();

        // New async methods for API integration
        Task<List<Coin>> GetAllCoinsAsync();
        Task RefreshPricesAsync();
        Task<List<PriceHistory>> GetPriceHistoryAsync(string symbol);
        string GetCacheStatus();
    }
}
