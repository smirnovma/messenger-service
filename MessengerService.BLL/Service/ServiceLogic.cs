using MessangerService.Data;
using MessangerService.Data.Context;
using MessengerService.BLL.Types;
using MessengerService.Entities.Chat;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerService.BLL.Service
{
    public class ServiceLogic
    {
        public void SendMessage(string userFromId, string userToId, DateTime date, string message)
        {
            using (var unitOfWork = UnitOfWork.Create())
            {
                unitOfWork.MessageRepository.Create(new MessageEntity()
                {
                    UserFromId = userFromId,
                    UserToId = userToId,
                    Date = date,
                    Message = message
                });
                unitOfWork.Save();
            }
        }
        public IEnumerable<MessageResponse> GetAll(string userId)
        {
            using (var unitOfWork = UnitOfWork.Create())
            {
                List<MessageResponse> messageResponseList = new List<MessageResponse>();
                var messages = unitOfWork.MessageRepository.GetEntities().Where(p => p.UserFromId == userId || p.UserToId == userId).ToList();
                foreach (var item in messages)
                {
                    messageResponseList.Add(new MessageResponse() { Id = item.Id, Date = item.Date, Message = item.Message, UserLoginFrom = item.ApplicationUserFrom.UserName, UserLoginTo = item.ApplicationUserTo.UserName });
                }
                return messageResponseList;
            }
        }
        public IEnumerable<MessageResponse> Get(string userFromId, string userToId, DateTime date)
        {
            using (var unitOfWork = UnitOfWork.Create())
            {
                List<MessageResponse> messageResponseList = new List<MessageResponse>();
                var messages = unitOfWork.MessageRepository.GetEntities().Where(p => (p.Date > date) && ((p.UserFromId == userFromId && p.UserToId == userToId) || (p.UserFromId == userToId && p.UserToId == userFromId))).ToList();
                foreach (var item in messages)
                {
                    messageResponseList.Add(new MessageResponse() {Id = item.Id, Date = item.Date, Message = item.Message, UserLoginFrom = item.ApplicationUserFrom.UserName, UserLoginTo = item.ApplicationUserTo.UserName });
                }
                return messageResponseList;
            }
        }
    }
}
