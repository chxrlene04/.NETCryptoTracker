
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using WinFormsApp.Models;

namespace WinFormsApp.Services
{
    // Implements IDataService
    public class TransactionService : IDataService<Transaction>
    {
       
        private List<Transaction> _transactions;

        public TransactionService()
        {
            _transactions = new List<Transaction>();
        }

        public List<Transaction> GetAll()
        {
            return _transactions;
        }

        public void Add(Transaction item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            _transactions.Add(item);
        }

        public void Update(int index, Transaction item)
        {
            if (index < 0 || index >= _transactions.Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            _transactions[index] = item;
        }

        public void Delete(int index)
        {
            if (index < 0 || index >= _transactions.Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            _transactions.RemoveAt(index);
        }

      
        public List<Transaction> GetTransactionsByCoin(string symbol)
        {
            return _transactions
                .Where(t => t.CoinSymbol.Equals(symbol, StringComparison.OrdinalIgnoreCase))
                .OrderByDescending(t => t.Date)
                .ToList();
        }

       
        public decimal GetTotalInvested()
        {
           
            return _transactions
                .Where(t => t.Type == TransactionType.Buy)
                .Sum(t => t.TotalValue);
        }

        public void SaveToFile(string filepath)
        {
            try
            {
                var json = JsonSerializer.Serialize(_transactions, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
                File.WriteAllText(filepath, json);
            }
            catch (Exception ex)
            {
                throw new IOException($"Failed to save transactions: {ex.Message}", ex);
            }
        }

        public void LoadFromFile(string filepath)
        {
            try
            {
                if (File.Exists(filepath))
                {
                    var json = File.ReadAllText(filepath);
                    _transactions = JsonSerializer.Deserialize<List<Transaction>>(json)
                                  ?? new List<Transaction>();
                }
            }
            catch (Exception ex)
            {
                throw new IOException($"Failed to load transactions: {ex.Message}", ex);
            }
        }
    }
}