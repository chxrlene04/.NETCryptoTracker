using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WinFormsApp.Models
{
    public class Transaction
    {
        public DateTime Date { get; set; }
        public TransactionType Type { get; set; }
        public string CoinSymbol { get; set; }
        public decimal Amount { get; set; }
        public decimal PricePerCoin { get; set; }

        public decimal TotalValue => Amount * PricePerCoin;

        public Transaction(DateTime date, TransactionType type, string coinSymbol,
                          decimal amount, decimal pricePerCoin)
        {
            Date = date;
            Type = type;
            CoinSymbol = coinSymbol;
            Amount = amount;
            PricePerCoin = pricePerCoin;
        }
    }

    public enum TransactionType
    {
        Buy,
        Sell
    }
}