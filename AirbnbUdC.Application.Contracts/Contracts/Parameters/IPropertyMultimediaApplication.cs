using AirbnbUdC.Application.Contracts.DTO.Parameters;
using System.Collections.Generic;

namespace AirbnbUdC.Application.Contracts.Contracts.Parameters
{
    public interface IPropertyMultimediaApplication
    {
        PropertyMultimediaDTO CreateRecord(PropertyMultimediaDTO record);
        int DeleteRecord(int recordId);
        int UpdateRecord(PropertyMultimediaDTO record);
        PropertyMultimediaDTO GetRecord(int recordId);
        IEnumerable<PropertyMultimediaDTO> GetAllRecords(string filter);
        IEnumerable<PropertyMultimediaDTO> GetAllRecordsByPropertyId(int propertyId);
        IEnumerable<PropertyMultimediaDTO> GetAllRecordsByMultimediaTypeId(int multimediaTypeId);
    }
}
