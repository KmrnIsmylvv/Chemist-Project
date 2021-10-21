using DataAccess.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public class MedicineRepository : IRepository<Medicine>
    {
        public bool Create(Medicine entity)
        {
            try
            {
                DbContext.Medicines.Add(entity);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(Medicine entity)
        {
            DbContext.Medicines.Remove(entity);
            return true;
        }

        public Medicine Get(Predicate<Medicine> filter = null)
        {
            try
            {
                return filter == null ? DbContext.Medicines[0] : DbContext.Medicines.Find(filter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Medicine> GetAll(Predicate<Medicine> filter = null)
        {
            try
            {
                return filter == null ? DbContext.Medicines : DbContext.Medicines.FindAll(filter);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Update(Medicine entity)
        {
            try
            {
                Medicine dbMedicine = Get(m => m.Id == entity.Id);
                dbMedicine.Name = entity.Name;
                dbMedicine.Price = entity.Price;
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
