using AirbnbUdc.Repository.Contracts.DbModel.Parameters;
using System.Collections.Generic;

namespace AirbnbUdc.Repository.Contracts.Contracts.Parameters
{
    public interface IPropertyRepository
    {
        PropertyDbModel CreateRecord(PropertyDbModel record);
        int DeleteRecord(int recordId);
        int UpdateRecord(PropertyDbModel record);
        PropertyDbModel GetRecord(int recordId);
        IEnumerable<PropertyDbModel> GetAllRecords(string filter);
        IEnumerable<PropertyDbModel> GetAllRecordsByCityId(int cityId);
        IEnumerable<PropertyDbModel> GetAllRecordsByPropertyOwnerId(int propertyOwnerId);
    }
}
