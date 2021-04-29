namespace YogaStudio.App.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;
    using YogaStudio.App.Data.Interfaces;
    using YogaStudio.App.Models.EntityModels;

    public class YogaStudioContext : IdentityDbContext<User>, IYogaStudioContext
    {
        public YogaStudioContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual DbSet<Course> Courses { get; set; }

        public virtual DbSet<Package> Packages { get; set; }

        public virtual DbSet<Address> Addresses { get; set; }

        public virtual DbSet<TrainnerAvailability> TrainnerAvailabilities { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<OrderPackage> OrderPackages { get; set; }

        public virtual DbSet<Video> Videos { get; set; }

        public virtual DbSet<About> About { get; set; }

        public virtual DbSet<Contact> Contact { get; set; }

        public virtual DbSet<CreditCard> CreditCards { get; set; }

        public static YogaStudioContext Create()
        {
            return new YogaStudioContext();
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<Order>().HasKey(q => q.Id);
            builder.Entity<Package>().HasKey(q => q.Id);
            builder.Entity<OrderPackage>().HasKey(q =>
                new {
                    q.OrderId,
                    q.PackageId
                });

            builder.Entity<OrderPackage>()
                .HasRequired(t => t.Order)
                .WithMany(t => t.OrderPackages)
                .HasForeignKey(t => t.OrderId);

            builder.Entity<OrderPackage>()
                .HasRequired(t => t.Package)
                .WithMany(t => t.OrderPackages)
                .HasForeignKey(t => t.PackageId);

            base.OnModelCreating(builder);
        }
    }
}