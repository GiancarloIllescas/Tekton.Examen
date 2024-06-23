namespace Tekton.Examen.Application.DTO
{
    public class ProductDto
    {
        private float _finalPrice;

        public int ProductId { get; set; }
        public string Name { get; set; }

        public string StatusName { get; set; }

        public int Stock { get; set; }

        public string Description { get; set; }

        public float Price { get; set; }

        public int Discount { get; set; }

        public Double FinalPrice { get; set; }
    }
}