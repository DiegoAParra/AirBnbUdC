using AirbnbUdC.Application.Contracts.DTO.Parameters;
using AirBnbUdC.GUI.Models.Parameters;
using System.Collections.Generic;

namespace AirBnbUdC.GUI.Mappers.Parameters
{
    public class PropertyMultimediaMapperGUI : MapperBaseGUI<PropertyMultimediaDTO, PropertyMultimediaModel>
    {
        public override PropertyMultimediaModel MapperT1toT2(PropertyMultimediaDTO input)
        {
            PropertyMapperGUI propertyMapper = new PropertyMapperGUI();
            MultimediaTypeMapperGUI multimediaTypeMapper = new MultimediaTypeMapperGUI();
            return new PropertyMultimediaModel
            {
                Id = input.Id,
                MultimediaName = input.MultimediaName,
                MultimediaLink = input.MultimediaLink,
                Property = propertyMapper.MapperT1toT2(input.Property),
                MultimediaType = multimediaTypeMapper.MapperT1toT2(input.MultimediaType)
            };
        }

        public override IEnumerable<PropertyMultimediaModel> MapperT1toT2(IEnumerable<PropertyMultimediaDTO> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1toT2(item);
            }
        }

        public override PropertyMultimediaDTO MapperT2toT1(PropertyMultimediaModel input)
        {
            PropertyMapperGUI propertyMapper = new PropertyMapperGUI();
            MultimediaTypeMapperGUI multimediaTypeMapper = new MultimediaTypeMapperGUI();
            return new PropertyMultimediaDTO
            {
                Id = input.Id,
                MultimediaName = input.MultimediaName,
                MultimediaLink = input.MultimediaLink,
                Property = propertyMapper.MapperT2toT1(input.Property),
                MultimediaType = multimediaTypeMapper.MapperT2toT1(input.MultimediaType)
            };
        }

        public override IEnumerable<PropertyMultimediaDTO> MapperT2toT1(IEnumerable<PropertyMultimediaModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2toT1(item);
            }
        }
    }
}