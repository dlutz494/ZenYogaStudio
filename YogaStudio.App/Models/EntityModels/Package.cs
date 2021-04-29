namespace YogaStudio.App.Models.EntityModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Package
    {
        public Package()
        {
            this.Courses = new HashSet<Course>();
            this.OrderPackages = new HashSet<OrderPackage>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        [Required]
        public string Image { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<OrderPackage> OrderPackages { get; set; }

        public string TrainnerId { get; set; }

        public virtual User Trainner { get; set; }
    }
}