using Core.CarDealer.Interfaces;
using Core.CarDealer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.CarDealer.Repositories
{
    public class UnitOfWorkMessages : IUnitOfWork
    {

        public IRepositoryMessage _repositoryMessage { get; private set; }
        public IRepositoryMessageTo _repositoryMessageTo { get; private set; }

        public UnitOfWorkMessages(IRepositoryMessage repositoryMessage,
            IRepositoryMessageTo repositoryMessageTo)
        {
            _repositoryMessage = repositoryMessage;
            _repositoryMessageTo = repositoryMessageTo;
        }
    }
}
