using AirbnbUdc.Application.Implementation.Mappers.Paremeters;
using AirbnbUdc.Repository.Contracts.Contracts.Parameters;
using AirbnbUdc.Repository.Contracts.DbModel.Parameters;
using AirbnbUdc.Repository.Implementation.Implementation.Parameters;
using AirbnbUdC.Application.Contracts.Contracts.Parameters;
using AirbnbUdC.Application.Contracts.DTO.Parameters;
using System.Collections.Generic;

namespace AirbnbUdc.Application.Implementation.Implementation.Parameters
{
    public class PropertyImplementationApplication : IPropertyApplication
    {
        IPropertyRepository _propertyRepository;

        public PropertyImplementationApplication(IPropertyRepository PropertyImplementationR)
        {
            this._propertyRepository = PropertyImplementationR;
        }

        public PropertyDTO CreateRecord(PropertyDTO record)
        {
            PropertyMapperApplication mapper = new PropertyMapperApplication();
            PropertyDbModel mapped = mapper.MapperT2toT1(record);
            PropertyDbModel created = this._propertyRepository.CreateRecord(mapped);
            return mapper.MapperT1toT2(created);
        }

        public int DeleteRecord(int recordId)
        {
            int deleted = this._propertyRepository.DeleteRecord(recordId);
            return deleted;
        }

        public IEnumerable<PropertyDTO> GetAllRecords(string filter)
        {
            PropertyMapperApplication mapper = new PropertyMapperApplication();
            IEnumerable<PropertyDbModel> records = this._propertyRepository.GetAllRecords(filter);
            return mapper.MapperT1toT2(records);
        }

        public IEnumerable<PropertyDTO> GetAllRecordsByCityId(int cityId)
        {
            PropertyMapperApplication mapper = new PropertyMapperApplication();
            IEnumerable<PropertyDbModel> records = this._propertyRepository.GetAllRecordsByCityId(cityId);
            return mapper.MapperT1toT2(records);
        }

        public IEnumerable<PropertyDTO> GetAllRecordsByPropertyOwnerId(int propertyOwnerId)
        {
            PropertyMapperApplication mapper = new PropertyMapperApplication();
            IEnumerable<PropertyDbModel> records = this._propertyRepository.GetAllRecordsByPropertyOwnerId(propertyOwnerId);
            return mapper.MapperT1toT2(records);
        }

        public PropertyDTO GetRecord(int recordId)
        {
            PropertyMapperApplication mapper = new PropertyMapperApplication();
            PropertyDbModel record = this._propertyRepository.GetRecord(recordId);
            return mapper.MapperT1toT2(record);
        }

        public int UpdateRecord(PropertyDTO record)
        {
            PropertyMapperApplication mapper = new PropertyMapperApplication();
            PropertyDbModel mapped = mapper.MapperT2toT1(record);
            int updated = this._propertyRepository.UpdateRecord(mapped);
            return updated;
        }
    }
}
