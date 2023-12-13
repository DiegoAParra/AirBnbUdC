using AirbnbUdc.Repository.Contracts.DbModel.Parameters;
using System.Collections.Generic;

namespace AirbnbUdc.Repository.Contracts.Contracts.Parameters
{
    public interface IPropertyMultimediaRepository
    {
        PropertyMultimediaDbModel CreateRecord(PropertyMultimediaDbModel record);
        int DeleteRecord(int recordId);
        int UpdateRecord(PropertyMultimediaDbModel record);
        PropertyMultimediaDbModel GetRecord(int recordId);
        IEnumerable<PropertyMultimediaDbModel> GetAllRecords(string filter);
        IEnumerable<PropertyMultimediaDbModel> GetAllRecordsByPropertyId(int propertyId);
        IEnumerable<PropertyMultimediaDbModel> GetAllRecordsByMultimediaTypeId(int multimediaTypeId);
    }
}
