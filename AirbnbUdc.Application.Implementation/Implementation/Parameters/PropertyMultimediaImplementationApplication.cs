using AirbnbUdc.Application.Implementation.Mappers.Paremeters;
using AirbnbUdc.Repository.Contracts.Contracts.Parameters;
using AirbnbUdc.Repository.Contracts.DbModel.Parameters;
using AirbnbUdc.Repository.Implementation.Implementation.Parameters;
using AirbnbUdC.Application.Contracts.Contracts.Parameters;
using AirbnbUdC.Application.Contracts.DTO.Parameters;
using System.Collections.Generic;

namespace AirbnbUdc.Application.Implementation.Implementation.Parameters
{
    public class PropertyMultimediaImplementationApplication : IPropertyMultimediaApplication
    {
        IPropertyMultimediaRepository _propertyMultimediaRepository;

        public PropertyMultimediaImplementationApplication()
        {
            this._propertyMultimediaRepository = new PropertyMultimediaImplementationRepository();
        }

        public PropertyMultimediaDTO CreateRecord(PropertyMultimediaDTO record)
        {
            PropertyMultimediaMapperApplication mapper = new PropertyMultimediaMapperApplication();
            PropertyMultimediaDbModel mapped = mapper.MapperT2toT1(record);
            PropertyMultimediaDbModel created = this._propertyMultimediaRepository.CreateRecord(mapped);
            return mapper.MapperT1toT2(created);
        }

        public int DeleteRecord(int recordId)
        {
            int deleted = this._propertyMultimediaRepository.DeleteRecord(recordId);
            return deleted;
        }

        public IEnumerable<PropertyMultimediaDTO> GetAllRecords(string filter)
        {
            PropertyMultimediaMapperApplication mapper = new PropertyMultimediaMapperApplication();
            IEnumerable<PropertyMultimediaDbModel> records = this._propertyMultimediaRepository.GetAllRecords(filter);
            return mapper.MapperT1toT2(records);
        }

        public IEnumerable<PropertyMultimediaDTO> GetAllRecordsByPropertyId(int propertyId)
        {
            PropertyMultimediaMapperApplication mapper = new PropertyMultimediaMapperApplication();
            IEnumerable<PropertyMultimediaDbModel> records = this._propertyMultimediaRepository.GetAllRecordsByPropertyId(propertyId);
            return mapper.MapperT1toT2(records);
        }

        public IEnumerable<PropertyMultimediaDTO> GetAllRecordsByMultimediaTypeId(int multimediaTypeId)
        {
            PropertyMultimediaMapperApplication mapper = new PropertyMultimediaMapperApplication();
            IEnumerable<PropertyMultimediaDbModel> records = this._propertyMultimediaRepository.GetAllRecordsByMultimediaTypeId(multimediaTypeId);
            return mapper.MapperT1toT2(records);
        }

        public PropertyMultimediaDTO GetRecord(int recordId)
        {
            PropertyMultimediaMapperApplication mapper = new PropertyMultimediaMapperApplication();
            PropertyMultimediaDbModel record = this._propertyMultimediaRepository.GetRecord(recordId);
            return mapper.MapperT1toT2(record);
        }

        public int UpdateRecord(PropertyMultimediaDTO record)
        {
            PropertyMultimediaMapperApplication mapper = new PropertyMultimediaMapperApplication();
            PropertyMultimediaDbModel mapped = mapper.MapperT2toT1(record);
            int updated = this._propertyMultimediaRepository.UpdateRecord(mapped);
            return updated;
        }
    }
}
