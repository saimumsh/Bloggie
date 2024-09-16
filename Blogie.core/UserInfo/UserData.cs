using Blogie.core.BlogInfo;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogie.core.UserInfo
{
    public class UserData : IdentityUser
    {         
        public string? ProfilePic { get; set; }
       // List<BlogData> BlogDatas { get; set; }  


    }
}
