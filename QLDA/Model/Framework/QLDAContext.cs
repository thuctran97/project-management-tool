namespace Model.Framework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QLDAContext : DbContext
    {
        public QLDAContext()
            : base("name=QLDAContext")
        {
        }

        public virtual DbSet<UserLogin> UserLogins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserLogin>().Property(e => e.Account).IsUnicode(false);
            modelBuilder.Entity<UserLogin>().Property(e => e.Password).IsUnicode(false);
        }
    }
}
