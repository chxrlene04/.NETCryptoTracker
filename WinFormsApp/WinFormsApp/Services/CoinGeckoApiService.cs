using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using WinFormsApp.Models;

namespace WinFormsApp.Services
{
    /// <summary>
    /// Service for interacting with CoinGecko API
    /// Handles all HTTP requests, authentication, and rate limiting
    /// </summary>
    public class CoinGeckoApiService
    {
        private readonly HttpClient _httpClient;
        private const string BASE_URL = "https://api.coingecko.com/api/v3";
        private readonly string _apiKey;

        // Coin IDs used by CoinGecko (different from symbols!)
        private readonly Dictionary<string, string> _coinIds = new Dictionary<string, string>
        {
            { "BTC", "bitcoin" },
            { "ETH", "ethereum" },
            { "SOL", "solana" },
            { "ADA", "cardano" },
            { "DOT", "polkadot" },
            { "LINK", "chainlink" },
            { "AVAX", "avalanche-2" },
            { "MATIC", "matic-network" }
        };

        /// <summary>
        /// Constructor accepts API key for authentication
        /// </summary>
        public CoinGeckoApiService(string apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentException("API key is required", nameof(apiKey));
            }

            _apiKey = apiKey;
            _httpClient = new HttpClient();

            // Add API key to headers (RECOMMENDED method by CoinGecko)
            _httpClient.DefaultRequestHeaders.Add("x-cg-demo-api-key", _apiKey);
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "CryptoTrackerApp/1.0");
        }

        /// <summary>
        /// Fetches current market data for all coins we track
        /// This is the main method - ONE call gets all 8 coins!
        /// </summary>
        public async Task<List<Coin>> GetAllCoinsAsync()
        {
            try
            {
                // Build comma-separated list of coin IDs
                var coinIdsString = string.Join(",", _coinIds.Values);

                // CoinGecko API endpoint - gets multiple coins in one call!
                var url = $"{BASE_URL}/coins/markets?" +
                         $"vs_currency=usd&" +
                         $"ids={coinIdsString}&" +
                         $"order=market_cap_desc&" +
                         $"sparkline=false";

                // Make the API call
                var response = await _httpClient.GetFromJsonAsync<List<CoinGeckoMarketData>>(url);

                if (response == null || response.Count == 0)
                {
                    throw new Exception("No data received from CoinGecko API");
                }

                // Convert API models to our internal Coin models
                return response.Select(apiCoin => apiCoin.ToCoin()).ToList();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"API request failed: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching coin data: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Fetches 7-day price history for a specific coin
        /// Used for the coin details screen
        /// </summary>
        public async Task<List<PriceHistory>> GetPriceHistoryAsync(string symbol)
        {
            try
            {
                // Get the CoinGecko ID for this symbol
                if (!_coinIds.TryGetValue(symbol.ToUpper(), out string coinId))
                {
                    throw new ArgumentException($"Unknown coin symbol: {symbol}");
                }

                // Fetch 7 days of data
                var url = $"{BASE_URL}/coins/{coinId}/market_chart?" +
                         $"vs_currency=usd&" +
                         $"days=7&" +
                         $"interval=daily";

                var response = await _httpClient.GetFromJsonAsync<CoinGeckoChartData>(url);

                if (response == null || response.Prices == null || response.Prices.Count == 0)
                {
                    throw new Exception("No price history data received");
                }

                // Convert to PriceHistory objects
                var priceHistory = new List<PriceHistory>();

                // Group prices by day
                var dailyPrices = response.Prices
                    .Select(p => new
                    {
                        Timestamp = DateTimeOffset.FromUnixTimeMilliseconds((long)p[0]).DateTime,
                        Price = p[1]
                    })
                    .GroupBy(p => p.Timestamp.Date)
                    .OrderByDescending(g => g.Key)
                    .Take(7)
                    .ToList();

                foreach (var day in dailyPrices)
                {
                    var prices = day.Select(p => p.Price).ToList();
                    var date = day.Key;

                    var open = prices.First();
                    var close = prices.Last();
                    var high = prices.Max();
                    var low = prices.Min();

                    priceHistory.Add(new PriceHistory(date, open, high, low, close));
                }

                return priceHistory.OrderByDescending(p => p.Date).ToList();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"API request failed: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching price history: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Gets the CoinGecko ID for a symbol (used internally)
        /// </summary>
        public string GetCoinId(string symbol)
        {
            return _coinIds.TryGetValue(symbol.ToUpper(), out string coinId)
                ? coinId
                : null;
        }
    }
}
