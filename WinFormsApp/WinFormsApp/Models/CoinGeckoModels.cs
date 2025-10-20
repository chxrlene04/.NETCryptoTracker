using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WinFormsApp.Models
{
    /// Response model for CoinGecko /coins/markets endpoint
    /// Maps to the JSON structure returned by the API
    public class CoinGeckoMarketData
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("current_price")]
        public decimal CurrentPrice { get; set; }

        [JsonPropertyName("market_cap")]
        public decimal MarketCap { get; set; }

        [JsonPropertyName("total_volume")]
        public decimal TotalVolume { get; set; }

        [JsonPropertyName("price_change_percentage_24h")]
        public decimal PriceChangePercentage24h { get; set; }


        /// Converts CoinGecko API data to our internal Coin model
        public Coin ToCoin()
        {
            return new Coin(
                Name,
                Symbol.ToUpper(),
                CurrentPrice,
                PriceChangePercentage24h,
                MarketCap,
                TotalVolume
            );
        }



        /// Response model for CoinGecko /coins/{id}/market_chart endpoint
        /// Used for historical price data
        public class CoinGeckoChartData
        {
            [JsonPropertyName("prices")]
            public List<List<decimal>> Prices { get; set; }

            public CoinGeckoChartData()
            {
                Prices = new List<List<decimal>>();
            }
        }

        /// Represents a single price point in history
        /// Used for the 7-day price history display
        public class PriceHistory
        {
            public DateTime Date { get; set; }
            public decimal Open { get; set; }
            public decimal High { get; set; }
            public decimal Low { get; set; }
            public decimal Close { get; set; }
            public decimal ChangePercentage { get; set; }

            public PriceHistory(DateTime date, decimal open, decimal high, decimal low, decimal close)
            {
                Date = date;
                Open = open;
                High = high;
                Low = low;
                Close = close;

                // Calculate percentage change
                if (open > 0)
                {
                    ChangePercentage = ((close - open) / open) * 100;
                }
            }
        }
    }
}
