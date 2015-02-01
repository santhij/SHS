namespace HealthSystemsDemo.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SHSModel : DbContext
    {
        public SHSModel()
            : base("name=SHSModel")
        {
        }

        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Industry> Industries { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .Property(e => e.ClientIdentifier)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Address1)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Address2)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Zip)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Phone1)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Phone2)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.WebSite)
                .IsUnicode(false);

            modelBuilder.Entity<Feedback>()
                .Property(e => e.UserId)
                .IsFixedLength();

            modelBuilder.Entity<Feedback>()
                .Property(e => e.MainFeature)
                .IsUnicode(false);

            modelBuilder.Entity<Feedback>()
                .Property(e => e.AreaOfImprovement)
                .IsUnicode(false);

            modelBuilder.Entity<Feedback>()
                .Property(e => e.FurtherFeedback)
                .IsUnicode(false);

            modelBuilder.Entity<Industry>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Industry>()
                .HasMany(e => e.Feedbacks)
                .WithRequired(e => e.Industry)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithMany(e => e.Roles)
                .Map(m => m.ToTable("UserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));
        }
    }
}
