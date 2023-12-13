using AirbnbUdc.Repository.Contracts.DbModel.Parameters;
using AirbnbUdC.Application.Contracts.DTO.Parameters;
using System.Collections.Generic;

namespace AirbnbUdc.Application.Implementation.Mappers.Paremeters
{
    public class PropertyMultimediaMapperApplication : MapperBaseApplication<PropertyMultimediaDbModel, PropertyMultimediaDTO>
    {
        public override PropertyMultimediaDTO MapperT1toT2(PropertyMultimediaDbModel input)
        {
            PropertyMapperApplication propertyMapper = new PropertyMapperApplication();
            MultimediaTypeMapperApplication multimediaTypeMapper = new MultimediaTypeMapperApplication();
            return new PropertyMultimediaDTO
            {
                Id = input.Id,
                MultimediaName = input.MultimediaName,
                MultimediaLink = input.MultimediaLink,
                Property = propertyMapper.MapperT1toT2(input.Property),
                MultimediaType = multimediaTypeMapper.MapperT1toT2(input.MultimediaType)
            };
        }

        public override IEnumerable<PropertyMultimediaDTO> MapperT1toT2(IEnumerable<PropertyMultimediaDbModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1toT2(item);
            }
        }

        public override PropertyMultimediaDbModel MapperT2toT1(PropertyMultimediaDTO input)
        {
            PropertyMapperApplication propertyMapper = new PropertyMapperApplication();
            MultimediaTypeMapperApplication multimediaTypeMapper = new MultimediaTypeMapperApplication();
            return new PropertyMultimediaDbModel
            {
                Id = input.Id,
                MultimediaName = input.MultimediaName,
                MultimediaLink = input.MultimediaLink,
                Property = propertyMapper.MapperT2toT1(input.Property),
                MultimediaType = multimediaTypeMapper.MapperT2toT1(input.MultimediaType)
            };
        }

        public override IEnumerable<PropertyMultimediaDbModel> MapperT2toT1(IEnumerable<PropertyMultimediaDTO> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2toT1(item);
            }
        }
    }
}
