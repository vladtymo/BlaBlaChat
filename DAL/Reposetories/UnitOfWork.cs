using Dal;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Reposetories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ChatDatabaseModel context;

        private GenericRepository<User> userRepository = null;
        private GenericRepository<Messages> messageRepository = null;
        private GenericRepository<Chat> chatReposetory = null;

        public UnitOfWork(ChatDatabaseModel context)
        {
            this.context = context;
        }

        public void Save()
        {
            context.SaveChanges();
        }
        public IRepository<User> UsertRepository
        {
            get
            {
                // lazy loading - екземпляр об'єкта створюється лише в момент
                // коли відбувається до нього доступ
                if (userRepository == null)
                    userRepository = new GenericRepository<User>(context);
                return userRepository;
            }
        }

        public IRepository<Messages> MessageRepository
        {
            get
            {
                if (messageRepository == null)
                    messageRepository = new GenericRepository<Messages>(context);
                return messageRepository;
            }
        }
        public IRepository<Chat> ChatRepository
        {
            get
            {
                if (chatReposetory == null)
                    chatReposetory = new GenericRepository<Chat>(context);
                return chatReposetory;
            }
        }

        public IRepository<Messages> MessagesRepository => throw new NotImplementedException();

        public IRepository<Chat> ChatReposetory => throw new NotImplementedException();

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
