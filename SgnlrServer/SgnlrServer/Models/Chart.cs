namespace SgnlrServer.Models
{
    public class Chart
    {
        public List<int> Data { get; set; }
        public string? Label { get; set; }
        public string? BackgroundColor { get; set; }

        public Chart()
        {
            Data = new List<int>();
        }
    }
}
