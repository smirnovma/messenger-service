using MessengerService.Entities.Chat;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MessangerService.Data.Context
{
    //public class ApplicationUser : IdentityUser
    //{
    //    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
    //    {
    //        // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
    //        var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
    //        // Add custom user claims here
    //        return userIdentity;
    //    }
    //}

    public class SqlDbContext : IdentityDbContext<ApplicationUserEntity>
    {
        public SqlDbContext()
            : base("name = SqlConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SqlDbContext, Migration.Configuration>());
        }

        public DbSet<MessageEntity> Messages { get; set; }

        public static SqlDbContext Create()
        {
            return new SqlDbContext();
        }
    }
}
