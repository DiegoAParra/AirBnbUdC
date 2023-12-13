using AirbnbUdC.Application.Contracts.DTO.Parameters;
using AirBnbUdC.GUI.Models.Parameters;
using System.Collections.Generic;

namespace AirBnbUdC.GUI.Mappers.Parameters
{
    public class MultimediaTypeMapperGUI : MapperBaseGUI<MultimediaTypeDTO, MultimediaTypeModel>
    {
        public override MultimediaTypeModel MapperT1toT2(MultimediaTypeDTO input)
        {
            if (input == null)
            {
                return new MultimediaTypeModel();
            }
            return new MultimediaTypeModel
            {
                Id = input.Id,
                MultimediaTypeName = input.MultimediaTypeName,
            };
        }

        public override IEnumerable<MultimediaTypeModel> MapperT1toT2(IEnumerable<MultimediaTypeDTO> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1toT2(item);
            }
        }

        public override MultimediaTypeDTO MapperT2toT1(MultimediaTypeModel input)
        {
            if(input == null)
            {
                return new MultimediaTypeDTO();
            }
            return new MultimediaTypeDTO
            {
                Id = input.Id,
                MultimediaTypeName = input.MultimediaTypeName,
            };
        }

        public override IEnumerable<MultimediaTypeDTO> MapperT2toT1(IEnumerable<MultimediaTypeModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2toT1(item);
            }
        }
    }
}