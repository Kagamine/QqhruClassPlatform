using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Qqhru.Models
{
    public class QqhruContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Research> Researches { get; set; }

        public QqhruContext() : base("mysqldb") { }
    }
}
