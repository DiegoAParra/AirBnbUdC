using AirbnbUdC.Application.Contracts.DTO.Parameters;
using System.Collections.Generic;

namespace AirbnbUdC.Application.Contracts.Contracts.Parameters
{
    public interface ICustomerApplication
    {
        CustomerDTO CreateRecord(CustomerDTO record);
        int DeleteRecord(int recordId);
        int UpdateRecord(CustomerDTO record);
        CustomerDTO GetRecord(int recordId);
        IEnumerable<CustomerDTO> GetAllRecords(string filter);
    }
}
