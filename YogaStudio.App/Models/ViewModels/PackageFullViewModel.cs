using System.Collections.Generic;

namespace YogaStudio.App.Models.ViewModels
{
    public class PackageFullViewModel
    {
        public PackageFullViewModel()
        {
            CourseViewModels = new HashSet<CourseViewModel>();
        }

        public PackageViewModel PackageViewModel { get; set; }

        public IEnumerable<CourseViewModel> CourseViewModels { get; set; }
    }
}