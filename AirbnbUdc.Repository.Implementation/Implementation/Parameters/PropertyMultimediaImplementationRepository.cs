using AirbnbUdc.Repository.Contracts.Contracts.Parameters;
using AirbnbUdc.Repository.Contracts.DbModel.Parameters;
using AirbnbUdc.Repository.Implementation.DataModel;
using AirbnbUdc.Repository.Implementation.Mappers.Parameters;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AirbnbUdc.Repository.Implementation.Implementation.Parameters
{
    public class PropertyMultimediaImplementationRepository : IPropertyMultimediaRepository
    {
        /// <summary>
        /// Método para crear un registro de Property en la base de datos
        /// </summary>
        /// <param name="record">Registro a guardar</param>
        /// <returns>El registro guardado con id cuando se guarda o sin Id cuando no. O una excepción</returns>
        public PropertyMultimediaDbModel CreateRecord(PropertyMultimediaDbModel record)
        {
            try
            {
                using (Core_DBEntities db = new Core_DBEntities())
                {
                    if (!db.PropertyMultimedia.Any(x => x.MultimediaName == record.MultimediaName))
                    {
                        PropertyMultimediaMapperRepository mapper = new PropertyMultimediaMapperRepository();
                        PropertyMultimedia dbRecord = mapper.MapperT2toT1(record);
                        db.PropertyMultimedia.Add(dbRecord);
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
                    PropertyMultimedia record = db.PropertyMultimedia.FirstOrDefault(x => x.Id == recordId);
                    if (record != null)
                    {
                        db.PropertyMultimedia.Remove(record);
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

        public IEnumerable<PropertyMultimediaDbModel> GetAllRecords(string filter)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var records = (
                    from p in db.PropertyMultimedia
                    where p.MultimediaName.ToString().Contains(filter)
                    select p
                    );

                PropertyMultimediaMapperRepository mapper = new PropertyMultimediaMapperRepository();
                return mapper.MapperT1toT2(records);
            }
        }

        public IEnumerable<PropertyMultimediaDbModel> GetAllRecordsByPropertyId(int propertyId)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var records = (from p in db.PropertyMultimedia
                               where p.PropertyId == propertyId
                               select p);
                PropertyMultimediaMapperRepository mapper = new PropertyMultimediaMapperRepository();
                return mapper.MapperT1toT2(records);
            }
        }

        public IEnumerable<PropertyMultimediaDbModel> GetAllRecordsByMultimediaTypeId(int multimediaTypeId)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var records = (from p in db.PropertyMultimedia
                               where p.MultimediaTypeId == multimediaTypeId
                               select p);
                PropertyMultimediaMapperRepository mapper = new PropertyMultimediaMapperRepository();
                return mapper.MapperT1toT2(records);
            }
        }

        public PropertyMultimediaDbModel GetRecord(int recordId)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var record = db.PropertyMultimedia.Find(recordId);

                PropertyMultimediaMapperRepository mapper = new PropertyMultimediaMapperRepository();
                return mapper.MapperT1toT2(record);
            }
        }

        public int UpdateRecord(PropertyMultimediaDbModel record)
        {
            try
            {
                using (Core_DBEntities db = new Core_DBEntities())
                {
                    PropertyMultimediaMapperRepository mapper = new PropertyMultimediaMapperRepository();
                    PropertyMultimedia dbRecord = mapper.MapperT2toT1(record);
                    db.PropertyMultimedia.Attach(dbRecord);
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
