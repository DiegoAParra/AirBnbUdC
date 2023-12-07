using AirbnbUdC.Application.Contracts.DTO.Parameters;
using System.Collections.Generic;

namespace AirbnbUdC.Application.Contracts.Contracts.Parameters
{
    public interface IPropertyApplication
    {
        PropertyDTO CreateRecord(PropertyDTO record);
        int DeleteRecord(int recordId);
        int UpdateRecord(PropertyDTO record);
        PropertyDTO GetRecord(int recordId);
        IEnumerable<PropertyDTO> GetAllRecords(string filter);
        IEnumerable<PropertyDTO> GetAllRecordsByCityId(int cityId);
        IEnumerable<PropertyDTO> GetAllRecordsByPropertyOwnerId(int propertyOwnerId);
    }
}
