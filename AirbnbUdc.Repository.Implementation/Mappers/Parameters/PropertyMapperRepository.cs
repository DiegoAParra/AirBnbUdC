using AirbnbUdc.Repository.Contracts.DbModel.Parameters;
using AirbnbUdc.Repository.Implementation.DataModel;
using System.Collections.Generic;

namespace AirbnbUdc.Repository.Implementation.Mappers.Parameters
{
    public class PropertyMapperRepository : BaseMapperRepository<Property, PropertyDbModel>
    {
        public override PropertyDbModel MapperT1toT2(Property input)
        {
            CityMapperRepository cityMapper = new CityMapperRepository();
            PropertyOwnerMapperRepository propertyOwnerMapper = new PropertyOwnerMapperRepository();
            return new PropertyDbModel
            {
                Id = (int)input.Id,
                PropertyAddress = input.PropertyAddress,
                City = cityMapper.MapperT1toT2(input.City),
                CustomerAmount = input.CustomerAmount,
                Price = (double)input.Price,
                Latitude = input.Latitude,
                Longitude = input.Longitude,
                PropertyOwner = propertyOwnerMapper.MapperT1toT2(input.PropertyOwner),
                CheckinData = input.CheckinData,
                CheckoutData = input.CheckoutData,
                Details = input.Details,
                Pets = input.Pets,
                Freezer = input.Freezer,
                LaundryService = input.LaundryService
            };
        }

        public override IEnumerable<PropertyDbModel> MapperT1toT2(IEnumerable<Property> input)
        {
            IList<PropertyDbModel> list = new List<PropertyDbModel>();
            foreach (var item in input)
            {
                list.Add(MapperT1toT2(item));
            }
            return list;
        }

        public override Property MapperT2toT1(PropertyDbModel input)
        {
            return new Property
            {
                Id = input.Id,
                PropertyAddress = input.PropertyAddress,
                CityId = input.City.Id,
                CustomerAmount = input.CustomerAmount,
                Price = (decimal)input.Price,
                Latitude = input.Latitude,
                Longitude = input.Longitude,
                OwnerId = input.PropertyOwner.Id,
                CheckinData = input.CheckinData,
                CheckoutData = input.CheckoutData,
                Details = input.Details,
                Pets = input.Pets,
                Freezer = input.Freezer,
                LaundryService = input.LaundryService
            };
        }

        public override IEnumerable<Property> MapperT2toT1(IEnumerable<PropertyDbModel> input)
        {
            IList<Property> list = new List<Property>();
            foreach (var item in input)
            {
                list.Add(MapperT2toT1(item));
            }
            return list;
        }
    }
}
