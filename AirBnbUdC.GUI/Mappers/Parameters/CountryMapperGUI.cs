using AirbnbUdC.Application.Contracts.DTO.Parameters;
using AirBnbUdC.GUI.Models.Parameters;
using System.Collections.Generic;

namespace AirBnbUdC.GUI.Mappers.Parameters
{
    public class CountryMapperGUI : MapperBaseGUI<CountryDTO, CountryModel>
    {
        public override CountryModel MapperT1toT2(CountryDTO input)
        {
            if (input == null)
            {
                return new CountryModel();
            }
            return new CountryModel
            {
                Id = input.Id,
                Name = input.Name,
            };
        }

        public override IEnumerable<CountryModel> MapperT1toT2(IEnumerable<CountryDTO> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1toT2(item);
            }
        }

        public override CountryDTO MapperT2toT1(CountryModel input)
        {
            if(input == null)
            {
                return new CountryDTO();
            }
            return new CountryDTO
            {
                Id = input.Id,
                Name = input.Name,
            };
        }

        public override IEnumerable<CountryDTO> MapperT2toT1(IEnumerable<CountryModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2toT1(item);
            }
        }
    }
}