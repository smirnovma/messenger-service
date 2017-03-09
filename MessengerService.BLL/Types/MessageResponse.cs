using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerService.BLL.Types
{
    public class MessageResponse
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
        public string UserLoginFrom { get; set; }
        public string UserLoginTo { get; set; }
    }
}
