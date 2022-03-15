namespace Pizza.Core.Entities
{
    public class Pizza
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Weight { get; set; }

        public int Diameter { get; set; }

        public decimal Price { get; set; }

        public string Recipe { get; set; }

        public byte[] Image { get; set; }
    }
}
