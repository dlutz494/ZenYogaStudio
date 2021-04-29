namespace YogaStudio.App.Models.BindingModels
{
    public class PackageBindingModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }

        public string TrainnerId { get; set; }
    }
}