using AirbnbUdC.Application.Contracts.DTO.Parameters;
using System.Collections.Generic;

namespace AirbnbUdC.Application.Contracts.Contracts.Parameters
{
    public interface IPropertyOwnerApplication
    {
        PropertyOwnerDTO CreateRecord(PropertyOwnerDTO record);
        int DeleteRecord(int recordId);
        int UpdateRecord(PropertyOwnerDTO record);
        PropertyOwnerDTO GetRecord(int recordId);
        IEnumerable<PropertyOwnerDTO> GetAllRecords(string filter);
    }
}
