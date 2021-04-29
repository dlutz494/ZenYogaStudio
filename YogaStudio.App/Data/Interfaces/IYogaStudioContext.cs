namespace YogaStudio.App.Data.Interfaces
{
    using System.Data.Entity;
    using YogaStudio.App.Models.EntityModels;

    public interface IYogaStudioContext
    {
        DbSet<Address> Addresses { get; set; }

        DbSet<Course> Courses { get; set; }

        DbSet<Package> Packages { get; set; }

        DbSet<Order> Orders { get; set; }

        DbSet<TrainnerAvailability> TrainnerAvailabilities { get; set; }

        DbSet<Video> Videos { get; set; }

        DbSet<OrderPackage> OrderPackages { get; set; }

        DbSet<About> About { get; set; }

        DbSet<Contact> Contact { get; set; }

        DbSet<CreditCard> CreditCards { get; set; }

        int SaveChanges();
    }
}
