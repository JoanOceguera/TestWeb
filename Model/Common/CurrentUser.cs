using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Web;

namespace Model
{
    public class CurrentUser
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public int area { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public int exp { get; set; }

        public static CurrentUser Get
        {
            get
            {
                var user = HttpContext.Current.User;

                if (user == null)
                {
                    return null;
                }
                else if (string.IsNullOrEmpty(user.Identity.GetUserId()))
                {
                    return null;                  
                }

                var jUser = ((ClaimsIdentity)user.Identity).FindFirst(ClaimTypes.UserData).Value;

                return JsonConvert.DeserializeObject<CurrentUser>(jUser);
            }
        }
    }
}
