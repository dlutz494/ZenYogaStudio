namespace YogaStudio.Tests
{
    using Moq;
    using System.Collections.Generic;
    using System.Linq;
    using YogaStudio.App.Data.Repositories;
    using YogaStudio.App.Models.EntityModels;

    public class MockContainer
    {
        public Mock<IRepository<User>> UserRepositoryMock { get; set; }

        public Mock<IRepository<Course>> CourseRepositoryMock { get; set; }

        public Mock<IRepository<Package>> PackageRepositoryMock { get; set; }

        public Mock<IRepository<Order>> OrderRepositoryMock { get; set; }

        public void PrepareMocks()
        {
            this.SetupFakeUsers();
            this.SetupFakeCourse();
            this.SetupFakePackages();
            this.SetupFakeOrders();
        }

        private void SetupFakeUsers()
        {
            //var fakeUsers = new List<User>()
            //{
            //    new User()
            //    {
            //       // Id = "00388700-d4da-41ce-b01f-e677177623d9",
            //        FName = "Mansour",
            //        LName = "Ben Khayal",
            //        City = "Waterloo",
            //        UserName = "MBK"
            //    },
            //    new User()
            //    {
            //      //  Id = "10388700-d4da-41ce-c01f-e677177626d9",
            //        FName = "john",
            //        LName = "johni",
            //        City = "Toronto",
            //        UserName = null
            //    }
            //};

            this.UserRepositoryMock = new Mock<IRepository<User>>();

            //this.UserRepositoryMock.Setup(r => r.All()).Returns(fakeUsers.AsQueryable());

            //this.UserRepositoryMock.Setup(r => r.Find(It.IsAny<int>()))
            //    .Returns((string id) =>
            //    {
            //        var user = fakeUsers.FirstOrDefault(f => f.Id == id);

            //        return user ?? null;
            //    });
            //this.UserRepositoryMock.Setup(r => r.Add(It.IsAny<User>())).Callback<User>((user) => fakeUsers.Add(user));
            //this.UserRepositoryMock.Setup(r => r.Remove(It.IsAny<User>())).Callback<User>((user) => fakeUsers.Remove(user));

        }

        private void SetupFakePackages()
        {
            var fakePackages = new List<Package>()
            {
                new Package()
                {
                    Id = 1,
                    Name = "Package 1"
                },
                new Package()
                {
                    Id = 2,
                    Name = "Package 2"
                },
                new Package()
                {
                    Id = 3,
                    Name = "Package 3"
                }

            };

            this.PackageRepositoryMock = new Mock<IRepository<Package>>();

            this.PackageRepositoryMock.Setup(r => r.All()).Returns(fakePackages.AsQueryable());

            this.PackageRepositoryMock.Setup(r => r.Find(It.IsAny<int>()))
                .Returns((int id) =>
                {
                    var package = fakePackages.FirstOrDefault(f => f.Id == id);

                    return package ?? null;
                });
            this.PackageRepositoryMock.Setup(r => r.Add(It.IsAny<Package>())).Callback<Package>((package) => fakePackages.Add(package));
            this.PackageRepositoryMock.Setup(r => r.Remove(It.IsAny<Package>())).Callback<Package>((package) => fakePackages.Remove(package));

        }

        private void SetupFakeOrders()
        {
            var fakeOrders = new List<Order>()
            {
                new Order()
                {
                    Id = 1
                },
                new Order()
                {
                    Id = 2
                },
                new Order()
                {
                    Id = 3
                }

            };

            this.OrderRepositoryMock = new Mock<IRepository<Order>>();

            this.OrderRepositoryMock.Setup(r => r.All()).Returns(fakeOrders.AsQueryable());

            this.OrderRepositoryMock.Setup(r => r.Find(It.IsAny<int>()))
                .Returns((int id) =>
                {
                    var order = fakeOrders.FirstOrDefault(f => f.Id == id);

                    return order ?? null;
                });
            this.OrderRepositoryMock.Setup(r => r.Add(It.IsAny<Order>())).Callback<Order>((order) => fakeOrders.Add(order));
            this.OrderRepositoryMock.Setup(r => r.Remove(It.IsAny<Order>())).Callback<Order>((order) => fakeOrders.Remove(order));

        }

        private void SetupFakeCourse()
        {
            var fakeCourses = new List<Course>()
            {
                new Course()
                {
                    Id = 1,
                    Name = "Course 1",
                    Price = 9.99m
                },
                new Course()
                {
                    Id = 1,
                    Name = "Course 2",
                    Price = 17.50m
                }
            };

            this.CourseRepositoryMock = new Mock<IRepository<Course>>();

            this.CourseRepositoryMock.Setup(r => r.All()).Returns(fakeCourses.AsQueryable());

            this.CourseRepositoryMock.Setup(r => r.Find(It.IsAny<int>()))
                .Returns((int id) =>
                {
                    var course = fakeCourses.FirstOrDefault(f => f.Id == id);

                    return course ?? null;
                });
            this.CourseRepositoryMock.Setup(r => r.Add(It.IsAny<Course>())).Callback<Course>((course) => fakeCourses.Add(course));
            this.CourseRepositoryMock.Setup(r => r.Remove(It.IsAny<Course>())).Callback<Course>((course) => fakeCourses.Remove(course));

        }
    }
}
