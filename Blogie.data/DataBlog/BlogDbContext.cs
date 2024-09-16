using Blogie.core.BlogInfo;
using Blogie.core.UserInfo;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogie.data.DataBlog
{
    public class BlogDbContext : IdentityDbContext
	{
		public BlogDbContext(DbContextOptions<BlogDbContext> Options) : base(Options) { }
        public  DbSet<UserData> UserDatas { get; set; }
        public  DbSet<BlogData> BlogDatas { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
