namespace YogaStudio.App.Data.UnitOfWork
{
    using YogaStudio.App.Data.Repositories;
    using YogaStudio.App.Models.EntityModels;

    public interface IYogaStudioData
    {
        IRepository<User> Users { get; }

        IRepository<Address> Addresses { get; }

        IRepository<Course> Courses { get; }

        IRepository<Order> Orders { get; }

        IRepository<Package> Packages { get; }

        IRepository<OrderPackage> OrderPackages { get; }

        IRepository<TrainnerAvailability> TrainnerAvailabilities { get; }

        IRepository<Video> Videos { get; }

        IRepository<About> Abouts { get; }

        IRepository<Contact> Contact { get; }

        IRepository<CreditCard> CreditCards { get; }

        int SaveChanges();
    }
}