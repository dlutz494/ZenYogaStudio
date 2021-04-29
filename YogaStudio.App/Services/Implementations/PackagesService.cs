namespace YogaStudio.App.Services.Implementations
{
    using AutoMapper;
    using System.Collections.Generic;
    using System.Linq;
    using YogaStudio.App.Data.UnitOfWork;
    using YogaStudio.App.Models.EntityModels;
    using YogaStudio.App.Models.ViewModels;
    using YogaStudio.App.Services.Interfaces;

    public class PackagesService : Service, IPackagesService
    {
        public PackagesService(IYogaStudioData data)
           : base(data)
        {
        }

        public PackagesService(IYogaStudioData data, User user)
            : base(data, user)
        {
        }

        public IEnumerable<PackageViewModel> GetAllPackages()
        {
            IEnumerable<Package> packages = this.Data.Packages.All();
            IEnumerable<PackageViewModel> viewModels = Mapper.Instance.Map<IEnumerable<Package>, IEnumerable<PackageViewModel>>(packages);
            return viewModels;
        }

        public PackageViewModel PackageDetails(int packageId)
        {
            Package package = this.Data.Packages.All().FirstOrDefault(g => g.Id == packageId);
            PackageViewModel viewModel = Mapper.Instance.Map<Package, PackageViewModel>(package);
            return viewModel;
        }
    }
}