using Business.Interfaces;
using DataAccess.Repositories;
using Entities.Models;
using System;
using System.Collections.Generic;

namespace Business.Services
{
    public class MedicineTypeService : IMedicineType
    {
        public MedicineTypeRepository medicineTypeRepository { get; set; }
        private static int count { get; set; }

        
        public MedicineTypeService()
        {
            medicineTypeRepository = new MedicineTypeRepository();
        }
        public MedicineType Create(MedicineType medicineType)
        {
            try
            {
                medicineType.Id = count;
                MedicineType isExist = medicineTypeRepository.Get(m => m.TypeName.ToLower()
                  == medicineType.TypeName.ToLower());
                if (isExist != null)
                    return null;
                medicineTypeRepository.Create(medicineType);
                count++;
                return medicineType;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public MedicineType Delete(int Id)
        {
            MedicineType dbMedicineType = medicineTypeRepository.Get(t => t.Id == Id);
            if (dbMedicineType != null)
            {
                medicineTypeRepository.Delete(dbMedicineType);
                return dbMedicineType;
            }
            else
            {
                return null;
            }
        }

        public MedicineType Get(int Id)
        {
            throw new NotImplementedException();
        }

        public MedicineType Get(string name)
        {
           return medicineTypeRepository.Get(t => t.TypeName.ToLower() == name.ToLower());
        }

        public List<MedicineType> GetAll()
        {
            return medicineTypeRepository.GetAll();
        }

        public MedicineType Update(int Id, MedicineType medicineType)
        {
            throw new NotImplementedException();
        }
    }
}
