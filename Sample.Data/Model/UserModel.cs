using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Data.Model
{
   public class UserModel
    {
        public partial class User
        {
            public long UserID { get; set; }
            public string UserFirstName { get; set; }
            public string UserLastName { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public string MobileNo { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public bool Active { get; set; }
            public DateTime CreatedODate { get; set; }
            public int Role { get; set; }
        }

        public class RequestLogin
        {
            public string UserName { get; set; }
            public string Password { get; set; }
            public int Role { get; set; }
        }
    }
   public class UserLoginDetails
   {
       public long UserID { get; set; }
       public long UserRoleID { get; set; }
       public string UserName { get; set; }
   }

}
