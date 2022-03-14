using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.Interfaces
{
     public interface IRepository<T,K>
    {
        public  void Create(T obj);
        public void Delete(T obj);
        public Task<K>? Read(int id);
        public void Update(T obj);

    }
}
