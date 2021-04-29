using System.ComponentModel.DataAnnotations;

namespace YogaStudio.App.Models.EntityModels
{
    public class About
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public string Image { get; set; }
    }
}