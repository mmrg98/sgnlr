using SgnlrServer.Models;

namespace SgnlrServer.DataStorage
{
    public class DataManager
    {
        public static List<Chart> GetData()
        {
            var r = new Random();
            return new List<Chart>()
        {
            new Chart { Data = new List<int> { r.Next(1, 40) }, Label = "Data1", BackgroundColor = "#5491DA" },
            new Chart{ Data = new List<int> { r.Next(1, 40) }, Label = "Data2", BackgroundColor = "#E74C3C" },
            new Chart { Data = new List<int> { r.Next(1, 40) }, Label = "Data3", BackgroundColor = "#82E0AA" },
            new Chart { Data = new List<int> { r.Next(1, 40) }, Label = "Data4", BackgroundColor = "#E5E7E9" }
        };
        }
    }
}
