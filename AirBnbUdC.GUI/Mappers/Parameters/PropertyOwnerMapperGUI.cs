using AirbnbUdC.Application.Contracts.DTO.Parameters;
using AirBnbUdC.GUI.Models.Parameters;
using System.Collections.Generic;

namespace AirBnbUdC.GUI.Mappers.Parameters
{
    public class PropertyOwnerMapperGUI : MapperBaseGUI<PropertyOwnerDTO, PropertyOwnerModel>
    {
        public override PropertyOwnerModel MapperT1toT2(PropertyOwnerDTO input)
        {
            return new PropertyOwnerModel
            {
                Id = input.Id,
                FirstName = input.FirstName,
                FamilyName = input.FamilyName,
                Email = input.Email,
                Cellphone = input.Cellphone,
                Photo = input.Photo,
            };
        }

        public override IEnumerable<PropertyOwnerModel> MapperT1toT2(IEnumerable<PropertyOwnerDTO> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1toT2(item);
            }
        }

        public override PropertyOwnerDTO MapperT2toT1(PropertyOwnerModel input)
        {
            if (input == null)
            {
                return new PropertyOwnerDTO();
            }
            return new PropertyOwnerDTO
            {
                Id = input.Id,
                FirstName = input.FirstName,
                FamilyName = input.FamilyName,
                Email = input.Email,
                Cellphone = input.Cellphone,
                Photo = input.Photo,
            };
        }

        public override IEnumerable<PropertyOwnerDTO> MapperT2toT1(IEnumerable<PropertyOwnerModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2toT1(item);
            }
        }
    }
}