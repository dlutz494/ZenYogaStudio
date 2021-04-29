namespace YogaStudio.App.Models.EntityModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class TrainnerStudent
    {
        [Key, Column(Order = 0)]
        [Required]
        public string TrainnerId { get; set; }

        [Key, Column(Order = 1)]
        [Required]
        public string StudentId { get; set; }

        public virtual User Trainner { get; set; }

        public virtual User Student { get; set; }
    }
}