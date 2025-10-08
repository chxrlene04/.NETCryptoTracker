using System;
using System.Collections.Generic;
using System.Linq;
using WinFormsApp.Models;

namespace WinFormsApp.Services
{
    // implements ICryptoService
    public class CryptoService : ICryptoService
    {
        // Dummy data for now - will be replaced with API calls later
        private List<Coin> _coins;

        public CryptoService()
        {
            InitializeDummyData();
        }

        private void InitializeDummyData()
        {
            // Realistic dummy data
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
        }

        public List<Coin> GetTrendingCoins()
        {
            //sort by 24h change descending
            return _coins
                .OrderByDescending(c => c.Change24h)
                .ToList();
        }

        public Coin GetCoinBySymbol(string symbol)
        {
            //
            return _coins.FirstOrDefault(c =>
                c.Symbol.Equals(symbol, StringComparison.OrdinalIgnoreCase));
        }

        public void RefreshPrices()
        {
            
            var random = new Random();
            foreach (var coin in _coins)
            {
                var changePercent = (decimal)(random.NextDouble() * 10 - 5); 
                coin.CurrentPrice *= (1 + changePercent / 100);
                coin.Change24h = changePercent;
            }
        }
        public List<Coin> GetAllCoins()
        {
            return _coins;
        }

    }
}