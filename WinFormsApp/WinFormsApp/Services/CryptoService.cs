using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinFormsApp.Models;

namespace WinFormsApp.Services
{
    /// <summary>
    /// Service for managing cryptocurrency data with API integration and caching
    /// Implements smart caching to minimize API calls
    /// </summary>
    public class CryptoService : ICryptoService
    {
        private List<Coin> _coins;
        private DateTime _lastRefreshTime;
        private readonly CoinGeckoApiService _apiService;
        private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(5);

        public CryptoService()
        {
            _coins = new List<Coin>();
            _lastRefreshTime = DateTime.MinValue;

            // Initialize with dummy data (fallback if API fails)
            InitializeDummyData();

            // TODO: REPLACE THIS WITH YOUR ACTUAL API KEY!
            string apiKey = "ASK NIC"; // ← PUT YOUR COINGECKO API KEY HERE

            // Try to initialize API service with your key
            try
            {
                if (!string.IsNullOrEmpty(apiKey) && apiKey != "YOUR_API_KEY_HERE")
                {
                    _apiService = new CoinGeckoApiService(apiKey);
                    System.Diagnostics.Debug.WriteLine("✅ API service initialized with key");
                }
                else
                {
                    _apiService = null;
                    System.Diagnostics.Debug.WriteLine("⚠️ No API key - using dummy data only");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ API initialization failed: {ex.Message}");
                _apiService = null;
            }
        }

        /// <summary>
        /// Checks if cached data is still valid
        /// </summary>
        private bool IsCacheValid()
        {
            return DateTime.Now - _lastRefreshTime < _cacheExpiration;
        }

        /// <summary>
        /// Refreshes data from API if cache is stale
        /// This is the smart part - only calls API when needed!
        /// </summary>
        private async Task EnsureDataFreshAsync()
        {
            if (!IsCacheValid())
            {
                await RefreshPricesAsync();
            }
        }

        /// <summary>
        /// Gets all coins, ensuring data is fresh
        /// ASYNC version - use this for new code
        /// </summary>
        public async Task<List<Coin>> GetAllCoinsAsync()
        {
            await EnsureDataFreshAsync();
            return _coins.ToList(); // Return a copy
        }

        /// <summary>
        /// Gets trending coins sorted by 24h change
        /// SYNCHRONOUS version - for backward compatibility with existing code
        /// </summary>
        public List<Coin> GetTrendingCoins()
        {
            // If cache is stale and API available, try to refresh (but don't wait)
            if (!IsCacheValid() && _apiService != null)
            {
                // Fire and forget - update in background
                Task.Run(async () => await RefreshPricesAsync());
            }

            return _coins
                .OrderByDescending(c => c.Change24h)
                .ToList();
        }

        /// <summary>
        /// Gets a specific coin by symbol
        /// </summary>
        public Coin GetCoinBySymbol(string symbol)
        {
            // Try to refresh if stale (non-blocking)
            if (!IsCacheValid() && _apiService != null)
            {
                Task.Run(async () => await RefreshPricesAsync());
            }

            return _coins.FirstOrDefault(c =>
                c.Symbol.Equals(symbol, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Refreshes prices from CoinGecko API
        /// ASYNC version - returns Task for awaiting
        /// </summary>
        public async Task RefreshPricesAsync()
        {
            // If no API service, just use dummy data
            if (_apiService == null)
            {
                System.Diagnostics.Debug.WriteLine("No API service - using dummy data");
                return;
            }

            try
            {
                System.Diagnostics.Debug.WriteLine("🔄 Calling CoinGecko API...");

                // Make ONE API call to get all coins
                var freshCoins = await _apiService.GetAllCoinsAsync();

                if (freshCoins != null && freshCoins.Count > 0)
                {
                    _coins = freshCoins;
                    _lastRefreshTime = DateTime.Now;
                    System.Diagnostics.Debug.WriteLine($"✅ API call successful! Got {freshCoins.Count} coins");
                }
            }
            catch (Exception ex)
            {
                // Log error but keep using cached/dummy data
                System.Diagnostics.Debug.WriteLine($"❌ API refresh failed: {ex.Message}");
                // Don't throw - graceful degradation to dummy data
            }
        }

        /// <summary>
        /// SYNCHRONOUS version for backward compatibility
        /// Kept for existing Dashboard code
        /// </summary>
        public void RefreshPrices()
        {
            // This simulates price changes without API call
            // Used by Dashboard's "Refresh" button for demo purposes
            var random = new Random();
            foreach (var coin in _coins)
            {
                var changePercent = (decimal)(random.NextDouble() * 10 - 5);
                coin.CurrentPrice *= (1 + changePercent / 100);
                coin.Change24h = changePercent;
            }
        }

        /// <summary>
        /// Gets price history for a specific coin
        /// NEW method for coin details screen
        /// </summary>
        public async Task<List<PriceHistory>> GetPriceHistoryAsync(string symbol)
        {
            // If no API service, return dummy data
            if (_apiService == null)
            {
                System.Diagnostics.Debug.WriteLine("No API - returning dummy price history");
                return GenerateDummyPriceHistory(symbol);
            }

            try
            {
                System.Diagnostics.Debug.WriteLine($"🔄 Fetching price history for {symbol}...");
                var history = await _apiService.GetPriceHistoryAsync(symbol);
                System.Diagnostics.Debug.WriteLine($"✅ Got {history.Count} days of price history");
                return history;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ Failed to get price history: {ex.Message}");
                // Return dummy data as fallback
                return GenerateDummyPriceHistory(symbol);
            }
        }

        /// <summary>
        /// Initializes dummy data as fallback
        /// Used if API is unavailable or during development
        /// </summary>
        private void InitializeDummyData()
        {
            _coins = new List<Coin>
            {
                new Coin("Bitcoin", "BTC", 45621m, 2.45m, 895000000000m, 28400000000m),
                new Coin("Ethereum", "ETH", 2629m, 5.82m, 316000000000m, 15200000000m),
                new Coin("Solana", "SOL", 25.23m, 8.47m, 10500000000m, 1200000000m),
                new Coin("Cardano", "ADA", 0.38m, -1.21m, 13400000000m, 450000000m),
                new Coin("Polkadot", "DOT", 5.44m, 2.15m, 7800000000m, 320000000m),
                new Coin("Chainlink", "LINK", 7.82m, 9.34m, 4300000000m, 280000000m),
                new Coin("Avalanche", "AVAX", 11.56m, 31.25m, 4500000000m, 310000000m),
                new Coin("Polygon", "MATIC", 0.56m, 14.67m, 5200000000m, 420000000m)
            };
            _lastRefreshTime = DateTime.Now;
        }

        /// <summary>
        /// Generates dummy price history as fallback
        /// </summary>
        private List<PriceHistory> GenerateDummyPriceHistory(string symbol)
        {
            var coin = GetCoinBySymbol(symbol);
            if (coin == null) return new List<PriceHistory>();

            var history = new List<PriceHistory>();
            var random = new Random();
            var basePrice = coin.CurrentPrice;

            for (int i = 6; i >= 0; i--)
            {
                var date = DateTime.Now.Date.AddDays(-i);
                var variance = (decimal)(random.NextDouble() * 0.1 - 0.05); // ±5%
                var open = basePrice * (1 + variance);
                var close = basePrice * (1 + variance * 1.2m);
                var high = Math.Max(open, close) * 1.02m;
                var low = Math.Min(open, close) * 0.98m;

                history.Add(new PriceHistory(date, open, high, low, close));
            }

            return history;
        }

        /// <summary>
        /// Gets cache status information (useful for debugging)
        /// </summary>
        public string GetCacheStatus()
        {
            if (_lastRefreshTime == DateTime.MinValue)
                return "Not loaded";

            var age = DateTime.Now - _lastRefreshTime;
            var isValid = IsCacheValid();
            var source = _apiService != null ? "API available" : "Dummy data only";

            return $"Last refresh: {age.TotalMinutes:F1} min ago ({(isValid ? "Valid" : "Stale")}) - {source}";
        }
    }
}