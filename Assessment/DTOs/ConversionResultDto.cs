namespace Assessment.DTOs
{
    public class ConversionResultDto
    {
        public double Value { get; set; }
        public string FromUnit { get; set; } = string.Empty;
        public string ToUnit { get; set; } = string.Empty;
        public double Result { get; set; }
        public string Category { get; set; } = string.Empty;

    }
}
