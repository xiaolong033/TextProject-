using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;
namespace Dorm.Model
{
    public class DormEntity:DbContext
    {
       public DormEntity() : base("con")
        {
            Database.SetInitializer<DormEntity>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<MyDorm> MyDorms { get; set; }

        public DbSet<Admin> Admins { get; set; }
    }
}
