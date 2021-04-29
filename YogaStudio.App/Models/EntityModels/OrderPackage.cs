namespace YogaStudio.App.Models.EntityModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class OrderPackage
    {
        public OrderPackage()
        {
            this.Units = 1;
        }

        [Key, Column(Order = 0)]
        public int OrderId { get; set; }

        [Key, Column(Order = 1)]
        public int PackageId { get; set; }

        public virtual Order Order { get; set; }

        public virtual Package Package { get; set; }

        public int Units { get; set; }
    }
}