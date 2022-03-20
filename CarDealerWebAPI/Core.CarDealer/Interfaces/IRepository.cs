using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.Interfaces
{
    public interface IRepository<T>
    {
       T Create(T obj);
       void Delete(T obj);
       T Read(int id);
       T Update(T obj);
       void SaveChanges();
        Task SaveChangesAsync();
    }
}
