namespace YogaStudio.App.Models.EntityModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class TrainnerAvailability
    {
        [Key]
        public int Id { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public string TrainnerId { get; set; }

        public virtual User Trainner { get; set; }
    }
}