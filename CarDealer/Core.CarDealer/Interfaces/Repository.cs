using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.Interfaces
{
     public interface IRepository<T>
    {
        public  void Create(T obj);
        public void Delete(T obj);
        public Task<T>? Read(int id);
        public void Update(T obj);

    }
}
