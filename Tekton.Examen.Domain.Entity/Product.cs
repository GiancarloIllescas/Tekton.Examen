namespace Tekton.Examen.Domain.Entity
{
    public class Product
    {
        public Product()
        {
            this.Description = "";
            this.Name = "";
        }

        public int ProductId { get; set; }
        public string Name { get; set; }

        public int Status { get; set; }

        public string StatusName { get; set; }

        public int Stock { get; set; }

        public string Description { get; set; }

        public float Price { get; set; }
    }
}