namespace AirbnbUdC.Application.Contracts.DTO.Parameters
{
    public class PropertyDTO
    {
        public int Id { get; set; }
        public string PropertyAddress { get; set; }
        public CityDTO City { get; set; }
        public int CustomerAmount { get; set; }
        public double Price { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public PropertyOwnerDTO PropertyOwner { get; set; }
        public string CheckinData { get; set; }
        public string CheckoutData { get; set; }
        public string Details { get; set; }
        public bool Pets { get; set; }
        public bool Freezer { get; set; }
        public bool LaundryService { get; set; }
    }
}
