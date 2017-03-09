using MessangerService.Data;
using MessangerService.Data.Context;
using MessengerService.BLL.Service;
using MessengerService.BLL.Types;
using MessengerService.Entities.Chat;
using MessengerService.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;



namespace MessengerService.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {

        public async Task<IEnumerable<MessageResponse>> Get(string userNameTo, string dateFrom)
        {
            ServiceLogic serviceLogic = new ServiceLogic();
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUserEntity>(SqlDbContext.Create()));
            var currentUserTask = await userManager.FindByNameAsync(User.Identity.Name);
            var userToTask = await userManager.FindByNameAsync(userNameTo);
            return serviceLogic.Get(currentUserTask.Id, userToTask.Id, DateTime.Parse(dateFrom));
        }

        public async Task<IHttpActionResult> Post([FromBody]Message message)
        {
            ServiceLogic serviceLogic = new ServiceLogic();
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUserEntity>(SqlDbContext.Create()));
            var userFromTask = await userManager.FindByNameAsync(User.Identity.Name);
            var userToTask = await userManager.FindByNameAsync(message.UserNameTo);
            serviceLogic.SendMessage(userFromTask.Id, userToTask.Id, DateTime.Now, message.MessageText);
            return Ok();
        }

        //// PUT api/values/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //public void Delete(int id)
        //{
        //}
    }
}
