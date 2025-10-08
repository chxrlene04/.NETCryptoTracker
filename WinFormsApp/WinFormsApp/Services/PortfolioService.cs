using WinFormsApp.Models;
using System.Collections.Generic;
using System.Linq;


namespace WinFormsApp.Services
{
    public class PortfolioService
    {
        private readonly TransactionService _transactionService;
        private readonly CryptoService _cryptoService;

       
        public PortfolioService(TransactionService transactionService,
                               CryptoService cryptoService)
        {
            _transactionService = transactionService;
            _cryptoService = cryptoService;
        }

        // Calculate portfolio from transactions 
        public List<PortfolioItem> GetPortfolio()
        {
            var transactions = _transactionService.GetAll();

            // Group transactions by coin symbol
            var groupedTransactions = transactions
                .GroupBy(t => t.CoinSymbol)
                .Select(group => new
                {
                    Symbol = group.Key,
                    TotalAmount = group.Sum(t =>
                        t.Type == TransactionType.Buy ? t.Amount : -t.Amount),
                    TotalInvested = group
                        .Where(t => t.Type == TransactionType.Buy)
                        .Sum(t => t.TotalValue),
                    BuyAmount = group
                        .Where(t => t.Type == TransactionType.Buy)
                        .Sum(t => t.Amount)
                })
                .Where(g => g.TotalAmount > 0)
                .ToList();

            // Create portfolio items with current prices
            var portfolio = new List<PortfolioItem>();
            foreach (var group in groupedTransactions)
            {
                var coin = _cryptoService.GetCoinBySymbol(group.Symbol);
                if (coin != null)
                {
                    var avgBuyPrice = group.BuyAmount > 0
                        ? group.TotalInvested / group.BuyAmount
                        : 0;

                    portfolio.Add(new PortfolioItem(
                        group.Symbol,
                        group.TotalAmount,
                        avgBuyPrice,
                        coin.CurrentPrice
                    ));
                }
            }

            return portfolio;
        }

        
        public decimal GetTotalPortfolioValue()
        {
            return GetPortfolio().Sum(p => p.TotalValue);
        }

        public decimal GetTotalInvested()
        {
            return GetPortfolio().Sum(p => p.TotalInvested);
        }

        public decimal GetTotalProfitLoss()
        {
            return GetTotalPortfolioValue() - GetTotalInvested();
        }

        public int GetAssetCount()
        {
            return GetPortfolio().Count;
        }
    }
}