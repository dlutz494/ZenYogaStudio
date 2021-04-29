namespace YogaStudio.Tests.Services
{   
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using YogaStudio.App.Data.UnitOfWork;
    using YogaStudio.App.Services.Implementations;
    using System.Linq;
    using AutoMapper;
    using Moq;
    using YogaStudio.App.Models.EntityModels;
    using YogaStudio.App.Models.ViewModels;
    using YogaStudio.App.Models.BindingModels;

    [TestClass]
    public class PackagesServiceTests
    {
        private MockContainer mocks;
        private Mock<IYogaStudioData> dbMock;
        private PackagesService _service;

        private void ConfigureMapper()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<Package, PackageViewModel>();
                expression.CreateMap<PackageBindingModel, Package>();
            });
        }

        [TestInitialize]
        public void Init()
        {
            this.ConfigureMapper();

            this.dbMock = new Mock<IYogaStudioData>();
            this.mocks = new MockContainer();
            this.mocks.PrepareMocks();

            this.dbMock.Setup(c => c.Packages).Returns(this.mocks.PackageRepositoryMock.Object);
            this._service = new PackagesService(this.dbMock.Object);
        }

        [TestMethod]
        public void GetAllPackages_ShouldReturnAllPackages()
        {
            var packages = this._service.GetAllPackages();
            Assert.IsNotNull(packages);
            Assert.AreEqual(3, packages.Count());
            Assert.AreEqual("Package 1", packages.FirstOrDefault().Name);
        }

        [TestMethod]
        public void GetEditPackageWithValidId_ShouldReturnGivenPackage()
        {
            var package = this._service.PackageDetails(1);
            Assert.IsNotNull(package);
            Assert.AreEqual(1, package.Id);
            Assert.AreEqual("Package 1", package.Name);
        }

    }
}
