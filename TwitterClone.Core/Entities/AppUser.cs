using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClone.Core.Entities
{
    public class AppUser : IdentityUser
    {
        public string Fullname { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
