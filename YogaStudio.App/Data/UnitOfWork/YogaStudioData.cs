namespace YogaStudio.App.Data.UnitOfWork
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using YogaStudio.App.Data.Interfaces;
    using YogaStudio.App.Data.Repositories;
    using YogaStudio.App.Models.EntityModels;

    public class YogaStudioData : IYogaStudioData
    {
        private readonly IYogaStudioContext dbContext;

        private readonly IDictionary<Type, object> repositories;

        private IUserStore<User> userStore;

        public YogaStudioData(IYogaStudioContext context)
        {
            this.dbContext = context;
            this.repositories = new Dictionary<Type, object>();
        }
        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public IRepository<Course> Courses
        {
            get
            {
                return this.GetRepository<Course>();
            }
        }
        public IRepository<Address> Addresses
        {
            get
            {
                return this.GetRepository<Address>();
            }
        }

        public IRepository<Package> Packages
        {
            get
            {
                return this.GetRepository<Package>();
            }
        }

        public IRepository<Order> Orders
        {
            get { return this.GetRepository<Order>(); }
        }

        public IRepository<OrderPackage> OrderPackages
        {
            get { return this.GetRepository<OrderPackage>(); }
        }

        public IRepository<TrainnerAvailability> TrainnerAvailabilities
        {
            get { return this.GetRepository<TrainnerAvailability>(); }
        }

        public IRepository<Video> Videos
        {
            get { return this.GetRepository<Video>(); }
        }

        public IRepository<About> Abouts
        {
            get { return this.GetRepository<About>(); }
        }

        public IRepository<Contact> Contact
        {
            get { return this.GetRepository<Contact>(); }
        }

        public IRepository<CreditCard> CreditCards
        {
            get { return this.GetRepository<CreditCard>(); }
        }

        public IUserStore<User> UserStore
        {
            get
            {
                if (this.userStore == null)
                {
                    this.userStore = new UserStore<User>();
                }

                return this.userStore;
            }
        }

        public int SaveChanges()
        {
            return this.dbContext.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericEfRepository<T>);
                this.repositories.Add(
                    typeof(T),
                    Activator.CreateInstance(type, this.dbContext));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}