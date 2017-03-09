using MessangerService.Data.Context;
using MessengerService.Entities.Chat;
using MessengerService.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagerService.Data.SqlRepository
{
    public class MessageRepository : IRepository<MessageEntity>
    {
        private SqlDbContext db;

        public MessageRepository()
        {
            db = new SqlDbContext();
        }
        public MessageRepository(SqlDbContext sqlDbContext)
        {
            db = sqlDbContext;
        }

        public void Create(IEnumerable<MessageEntity> items)
        {
            foreach (var item in items)
            {
                db.Messages.Add(item);
            }
        }

        public void Create(MessageEntity item)
        {
            db.Messages.Add(item);
        }

        public void Delete(int id)
        {
            MessageEntity messageEntity = db.Messages.Find(id);
            if (messageEntity != null)
            {
                db.Messages.Remove(messageEntity);
            }
        }

        public IQueryable<MessageEntity> GetEntities()
        {
            return db.Messages;
        }

        public MessageEntity GetEntity(int id)
        {
            return db.Messages.Find(id);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(MessageEntity item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
