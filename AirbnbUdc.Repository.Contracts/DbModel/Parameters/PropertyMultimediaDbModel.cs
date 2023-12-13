namespace AirbnbUdc.Repository.Contracts.DbModel.Parameters
{
    public class PropertyMultimediaDbModel
    {
        public int Id { get; set; }
        public int MultimediaName { get; set; }
        public string MultimediaLink { get; set; }
        public PropertyDbModel Property { get; set; }
        public MultimediaTypeDbModel MultimediaType { get; set; }
    }
}
