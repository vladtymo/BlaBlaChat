using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        // репозиторії таблиць
        IRepository<User> UsertRepository { get; }
        IRepository<Messages> MessagesRepository { get; }
        IRepository<Chat> ChatReposetory { get; }
        // метод для збереження змін в базі даних
        void Save();
    }
}
