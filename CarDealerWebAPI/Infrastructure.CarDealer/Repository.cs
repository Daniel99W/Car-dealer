using Core.CarDealer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.CarDealer
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected AnnouncesContext _announcesContext;

        public Repository(AnnouncesContext announcesContext)
        {
            _announcesContext = announcesContext;
        }
        public virtual T Create(T obj)
        {
            return _announcesContext.Add(obj).Entity;
        }

        public virtual void Delete(T obj)
        {
            _announcesContext.Remove(obj);
        }

        public virtual async Task<T>? Read(int id)
        {
            return await _announcesContext.FindAsync<T>(id);
        }

        public void SaveChanges()
        {
            _announcesContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
           await _announcesContext.SaveChangesAsync();
        }

        public virtual T Update(T obj)
        {
            return _announcesContext.Update(obj).Entity;
        }

        public async virtual Task<IEnumerable<T>> GetItems()
        {
            return await _announcesContext.Set<T>().ToListAsync();
        }
    }
}
