using AirbnbUdc.Repository.Contracts.Contracts.Parameters;
using AirbnbUdc.Repository.Contracts.DbModel.Parameters;
using AirbnbUdc.Repository.Implementation.DataModel;
using AirbnbUdc.Repository.Implementation.Mappers.Parameters;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AirbnbUdc.Repository.Implementation.Implementation.Parameters
{
    public class PropertyImplementationRepository : IPropertyRepository
    {
        /// <summary>
        /// Método para crear un registro de Property en la base de datos
        /// </summary>
        /// <param name="record">Registro a guardar</param>
        /// <returns>El registro guardado con id cuando se guarda o sin Id cuando no. O una excepción</returns>
        public PropertyDbModel CreateRecord(PropertyDbModel record)
        {
            try
            {
                using (Core_DBEntities db = new Core_DBEntities())
                {
                    if (!db.Property.Any(x => x.PropertyAddress.Equals(record.PropertyAddress)))
                    {
                        PropertyMapperRepository mapper = new PropertyMapperRepository();
                        Property dbRecord = mapper.MapperT2toT1(record);
                        db.Property.Add(dbRecord);
                        db.SaveChanges();
                        record.Id = (int)dbRecord.Id;
                    }
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
            return record;
        }

        public int DeleteRecord(int recordId)
        {
            try
            {
                using (Core_DBEntities db = new Core_DBEntities())
                {
                    Property record = db.Property.FirstOrDefault(x => x.Id == recordId);
                    if (record != null)
                    {
                        db.Property.Remove(record);
                        db.SaveChanges();
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<PropertyDbModel> GetAllRecords(string filter)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var records = (
                    from p in db.Property
                    where p.PropertyAddress.Contains(filter)
                    select p
                    );

                PropertyMapperRepository mapper = new PropertyMapperRepository();
                return mapper.MapperT1toT2(records);
            }
        }

        public IEnumerable<PropertyDbModel> GetAllRecordsByCityId(int cityId)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var records = (from p in db.Property
                               where p.CityId == cityId
                               select p);
                PropertyMapperRepository mapper = new PropertyMapperRepository();
                return mapper.MapperT1toT2(records);
            }
        }

        public IEnumerable<PropertyDbModel> GetAllRecordsByPropertyOwnerId(int propertyOwnerId)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var records = (from p in db.Property
                               where p.OwnerId == propertyOwnerId
                               select p);
                PropertyMapperRepository mapper = new PropertyMapperRepository();
                return mapper.MapperT1toT2(records);
            }
        }

        public PropertyDbModel GetRecord(int recordId)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var record = db.Property.Find(recordId);

                PropertyMapperRepository mapper = new PropertyMapperRepository();
                return mapper.MapperT1toT2(record);
            }
        }

        public int UpdateRecord(PropertyDbModel record)
        {
            try
            {
                using (Core_DBEntities db = new Core_DBEntities())
                {
                    PropertyMapperRepository mapper = new PropertyMapperRepository();
                    Property dbRecord = mapper.MapperT2toT1(record);
                    db.Property.Attach(dbRecord);
                    db.Entry(dbRecord).State = EntityState.Modified;
                    return db.SaveChanges();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
    }
}
