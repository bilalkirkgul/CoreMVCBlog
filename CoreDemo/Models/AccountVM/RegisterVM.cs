using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Models.AccountVM
{
    public class RegisterVM
    {
        public string UserName { get; set; }       
        public string UserImg { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordTwo { get; set; }
    }
}
