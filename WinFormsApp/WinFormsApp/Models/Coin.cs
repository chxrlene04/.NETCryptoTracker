using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp.Models
{
    // crypto info
    public class Coin
    {
        public string Name { get; set; }         // like "Bitcoin"
        public string Symbol { get; set; }       // like "BTC"
        public decimal CurrentPrice { get; set; }
        public decimal Change24h { get; set; }    // Percentage change
        public decimal MarketCap { get; set; }
        public int MarketCapRank { get; set; }
        public decimal Volume { get; set; }

        public Coin(string name, string symbol, decimal currentPrice,
                   decimal change24h, decimal marketCap, decimal volume)
        {
            Name = name;
            Symbol = symbol;
            CurrentPrice = currentPrice;
            Change24h = change24h;
            MarketCap = marketCap;
            Volume = volume;
        }

        public Coin(string name, string symbol, int marketCapRank, decimal price)
        {
            Name = name;
            Symbol = symbol;
            MarketCapRank = marketCapRank;
            CurrentPrice = price;
        }

       

        public Coin(string name, string symbol) : this(name, symbol, 0, 0, 0, 0) { }


    }
}
