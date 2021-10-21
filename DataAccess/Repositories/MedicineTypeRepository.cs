using DataAccess.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
;

namespace DataAccess.Repositories
{
    public class MedicineTypeRepository : IRepository<MedicineType>
    {
        public bool Create(MedicineType entity)
        {
            try
            {
                DbContext.MedicineTypes.Add(entity);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(MedicineType entity)
        {
            DbContext.MedicineTypes.Remove(entity);
            return true;
        }

        public MedicineType Get(Predicate<MedicineType> filter = null)
        {
            try
            {
                return filter == null ? DbContext.MedicineTypes[0] : DbContext.MedicineTypes.Find(filter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<MedicineType> GetAll(Predicate<MedicineType> filter = null)
        {
            try
            {
                return filter == null ? DbContext.MedicineTypes : DbContext.MedicineTypes.FindAll(filter);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Update(MedicineType entity)
        {
            try
            {
                MedicineType dbMedicineType = Get(m => m.Id == entity.Id);
                dbMedicineType = entity;
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
