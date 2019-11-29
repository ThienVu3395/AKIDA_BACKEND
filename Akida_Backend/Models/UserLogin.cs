using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Akida_Backend.Models
{
    public class UserLogin
    {
        public int ID_User { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Activated { get; set; }
        public System.DateTime Created_Time { get; set; }
        public int AKIDA_Number { get; set; }
        public string Phone { get; set; }
        public int Role { get; set; }
    }
}