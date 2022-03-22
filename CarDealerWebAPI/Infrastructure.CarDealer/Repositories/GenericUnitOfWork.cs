using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.CarDealer.Repositories
{
    public class GenericUnitOfWork<Context> where Context : DbContext
    {
        private Context _context;
        private Dictionary<string, Context> _repositories;

        public GenericUnitOfWork(Context context)
        {
            _context = context;
            _repositories = new Dictionary<string, Context>();
        }

        public Context context { get { return _context; } }


            

            



    }
}
