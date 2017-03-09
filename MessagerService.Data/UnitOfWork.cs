using MessagerService.Data.SqlRepository;
using MessangerService.Data.Context;
using MessengerService.Entities.Chat;
using MessengerService.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessangerService.Data
{
    public class UnitOfWork : IDisposable
    {
        private SqlDbContext db = SqlDbContext.Create();
        private IRepository<MessageEntity> messageRepository;
        public IRepository<MessageEntity> MessageRepository
        {
            get
            {
                return messageRepository ?? (messageRepository = new MessageRepository(db));
            }
        }
        public static UnitOfWork Create()
        {
            return new UnitOfWork();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    db.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~UnitOfWork() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
