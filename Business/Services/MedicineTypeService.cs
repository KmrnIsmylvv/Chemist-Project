using Business.Interfaces;
using DataAccess.Repositories;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services
{
    class MedicineTypeService : IMedicineType
    {
        public MedicineTypeRepository medicineTypeRepository { get; set; }
        private static int count{ get; set; }
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
            throw new NotImplementedException();
        }

        public MedicineType Get(int Id)
        {
            throw new NotImplementedException();
        }

        public MedicineType Get(string name)
        {
            throw new NotImplementedException();
        }

        public List<MedicineType> GetAll()
        {
            throw new NotImplementedException();
        }

        public MedicineType Update(int Id, MedicineType medicineType)
        {
            throw new NotImplementedException();
        }
    }
}
