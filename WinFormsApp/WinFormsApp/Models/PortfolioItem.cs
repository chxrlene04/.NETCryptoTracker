using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp.Models
{
    // Represents a holding in the portfolio
    public class PortfolioItem
    {
        public string CoinSymbol { get; set; }
        public decimal Amount { get; set; }           // total coins owned
        public decimal AverageBuyPrice { get; set; }  // avg price paid
        public decimal CurrentPrice { get; set; }     // curretn market price

        // calculate properties
        public decimal TotalValue => Amount * CurrentPrice;
        public decimal TotalInvested => Amount * AverageBuyPrice;
        public decimal ProfitLoss => TotalValue - TotalInvested;
        public decimal ProfitLossPercentage => TotalInvested > 0
            ? (ProfitLoss / TotalInvested) * 100
            : 0;

        public PortfolioItem(string coinSymbol, decimal amount,
                            decimal averageBuyPrice, decimal currentPrice)
        {
            CoinSymbol = coinSymbol;
            Amount = amount;
            AverageBuyPrice = averageBuyPrice;
            CurrentPrice = currentPrice;
        }
    }
}
