using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerService.Entities.Chat
{
    public class MessageEntity : AbstractEntity
    {
        public string UserFromId { get; set; }
        [ForeignKey("UserFromId")]
        public virtual ApplicationUserEntity ApplicationUserFrom { get; set; }
        public string UserToId { get; set; }
        [ForeignKey("UserToId")]
        public virtual ApplicationUserEntity ApplicationUserTo { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }

        //public MessageEntity()
        //{
        //    ApplicationUserFrom = new HashSet<ApplicationUserEntity>;
        //    ApplicationUserTo = new HashSet<ApplicationUserEntity>;
        //}
    }
}
