using Business.Interfaces;
using DataAccess.Repositories;
using Entities.Models;
using System;
using System.Collections.Generic;
using Utilies.Exceptions;

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
            catch (MedicineTypeExceptions ex)
            {
                Console.WriteLine("There isnt such as type", ex.Message);
                return default;
            }
        }

        public MedicineType Delete(int Id)
        {
            MedicineType dbMedicineType = medicineTypeRepository.Get(t => t.Id == Id);
            try
            {
                if (dbMedicineType != null)
                {
                    medicineTypeRepository.Delete(dbMedicineType);
                    return dbMedicineType;
                }
                else
                {
                    throw new MedicineException("There isnt such as type");
                }
            }
            catch (MedicineTypeExceptions ex)
            {
                Console.WriteLine("There isnt such as type", ex.Message);
                return default;
            }
            
        }

        public MedicineType Get(int Id)
        {
            return medicineTypeRepository.Get(t => t.Id == Id);
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
            MedicineType dbMedicineType = medicineTypeRepository.Get(t => t.Id == Id);
            try
            {
                if (dbMedicineType != null)
                {
                    medicineTypeRepository.Update(medicineType);
                    return medicineType;
                }
                else
                {
                    throw new MedicineException("There isnt such as type");
                }
            }
            catch (MedicineTypeExceptions ex)
            {

                Console.WriteLine("There isnt such as type", ex.Message);
                return default; 
            }
           
        }
    }
}
