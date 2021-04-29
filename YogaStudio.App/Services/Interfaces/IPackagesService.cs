namespace YogaStudio.App.Services.Interfaces
{
    using System.Collections.Generic;
    using YogaStudio.App.Models.ViewModels;

    public interface IPackagesService
    {
        IEnumerable<PackageViewModel> GetAllPackages();

        PackageViewModel PackageDetails(int packageId);
    }
}
