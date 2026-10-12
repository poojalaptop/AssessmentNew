namespace Assessment.Models
{
    public class Unit
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Symbol { get; set; } = string.Empty;
        public double Factor { get; set; }
        public double Offset { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
