using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Epsic.Authx.Models
{
    public class RegistrationRequest
    {
        //[Required]
        public string Name { get; set; }

        //[Required]
        public string Email { get; set; }

        //[Required]
        public string Password { get; set; }
    }
}
