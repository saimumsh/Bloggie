using Microsoft.AspNetCore.Http;
using Blogie.core.UserInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;



namespace Blogie.core.BlogInfo
{
    public class BlogData : BaseEntity
    {
        public string? Title { get; set; }
        public string? Summary { get; set; }
        public string? Thumnail { get; set; }
        public string? Details { get; set; }
       // public UserData UserData { get; set; }
       // [ForeignKey(nameof(UserDataID))]
       // public int UserDataID { get; set; }


    }
}
