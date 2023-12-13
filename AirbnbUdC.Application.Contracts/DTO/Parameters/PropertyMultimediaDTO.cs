namespace AirbnbUdC.Application.Contracts.DTO.Parameters
{
    public class PropertyMultimediaDTO
    {
        public int Id { get; set; }
        public int MultimediaName { get; set; }
        public string MultimediaLink { get; set; }
        public PropertyDTO Property { get; set; }
        public MultimediaTypeDTO MultimediaType { get; set; }
    }
}
