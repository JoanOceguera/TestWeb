using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TestWeb.Models
{
    public class UserService
    {
        public IEnumerable<ApplicationUser> GetAll()
        {
            var result = new List<ApplicationUser>();
            using (var ctx = new ApplicationDbContext())
            {
                result = ctx.ApplicationUsers.ToList();
            }
            return result;
        }
    }
}