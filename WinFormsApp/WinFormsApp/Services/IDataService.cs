using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp.Services
{
    // Interface for data operations 
    public interface IDataService<T>
    {
        List<T> GetAll();
        void Add(T item);
        void Update(int index, T item);
        void Delete(int index);
        void SaveToFile(string filepath);
        void LoadFromFile(string filepath);
    }
}
