using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Imagifation.Models
{
    public class ImagifationContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BlockData> BlockData { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}