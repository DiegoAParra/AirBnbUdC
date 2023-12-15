using System.Collections.Generic;

namespace AirBnbUdC.GUI.Models.Parameters
{
    public class HomePropertyModel
    {
        public int Id { get; set; }
        public string PropertyAddress { get; set; }
        public string CityName { get; set; }
        public int CustomerAmount { get; set; }
        public double Price { get; set; }
        public List<string> MultimediaLinks { get; set; }
    }
}