namespace YogaStudio.App.Models.EntityModels
{
    using System.ComponentModel.DataAnnotations;

    public class Video
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public string VideoURL { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}