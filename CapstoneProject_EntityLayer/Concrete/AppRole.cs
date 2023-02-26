using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_EntityLayer.Concrete
{
    public class AppRole : IdentityRole<int>
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
 