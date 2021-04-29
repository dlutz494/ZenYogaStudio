namespace YogaStudio.App.Models.EntityModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Course
    {
        public Course()
        {
            //this.Students = new HashSet<User>();
            this.Videos = new HashSet<Video>();
            this.Packages = new HashSet<Package>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int? AddressId { get; set; }

        [ForeignKey("AddressId")]
        public virtual Address Address { get; set; }

        //public virtual ICollection<User> Students { get; set; }

        public virtual ICollection<Video> Videos { get; set; }

        public virtual ICollection<Package> Packages { get; set; }
    }
}