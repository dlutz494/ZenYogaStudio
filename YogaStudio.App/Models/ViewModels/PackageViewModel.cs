using System.Collections.Generic;
using YogaStudio.App.Models.EntityModels;

namespace YogaStudio.App.Models.ViewModels
{
    public class PackageViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }

        public IEnumerable<Course> Courses { get; set; }

        public User Trainner { get; set; }
    }
}