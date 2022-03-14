using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CarDealer.Interfaces
{
     public interface IRepository<T,K>
    {
        public void Create(T obj);
        public void Delete(T obj);
        public K Read(T obj);
        public void Update(T obj);

    }
}
