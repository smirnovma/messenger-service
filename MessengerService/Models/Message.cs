using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessengerService.Models
{
    public class Message
    {
        public string UserNameTo { get; set; }
        public string MessageText { get; set; }
    }
}