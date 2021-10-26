using Business.Interfaces;
using DataAccess.Repositories;
using Entities.Models;
using System;
using System.Collections.Generic;
using Utilies.Exceptions;

namespace Business.Services
{
    public class MedicineService : IMedicine
    {

        private MedicineRepository medicineRepository { get; }
        private MedicineTypeService medicineTypeService { get; }

        private static int count { get; set; }

        public MedicineService()
        {
            medicineRepository = new MedicineRepository();
            medicineTypeService = new MedicineTypeService();
        }
        public Medicine Create(Medicine medicine, string medicineTypeName)
        {
           
            try
            {
                MedicineType dbmedicineType = medicineTypeService.Get(medicineTypeName);
                if (dbmedicineType != null)
                {
                    medicine.Type = dbmedicineType;
                    medicine.Id = count;
                    medicineRepository.Create(medicine);
                    count++;
                    return medicine;
                }
                else
                {
                    throw new MedicineException("There isnt such as type");
                }

            }
            catch (MedicineException ex)
            {
                Console.WriteLine("There isnt such as type", ex.Message);
                return default;
            }
        }
        public List<Medicine> GetAll(string medicineTypeName)
        {
            MedicineType dbMedicineType = medicineTypeService.Get(medicineTypeName);

            try
            {
                if (dbMedicineType != null)
                {
                    return medicineRepository.GetAll(m => m.Type.TypeName == dbMedicineType.TypeName);
                }
                else
                {
                    throw new MedicineException("There isnt such as medicine");
                }
            }
            catch (MedicineException ex)
            {
                Console.WriteLine("There isnt such as medicine", ex.Message);
                return default;
            }
            
        }

        public Medicine Delete(int id)
        {

            Medicine dbMedicine = medicineRepository.Get(m => m.Id == id);
            try
            {
                if (dbMedicine != null)
                {
                    medicineRepository.Delete(dbMedicine);
                    return dbMedicine;
                }
                else
                {
                    throw new MedicineException("There isnt such as medicine");
                }
            }
            catch (MedicineException ex)
            {
                Console.WriteLine("There isnt such as medicine", ex.Message);
                return default;
            }
        }
        public Medicine Get(int id)
        {
            return medicineRepository.Get(t => t.Id == id);
        }
        public Medicine Get(string name)
        {
            return medicineRepository.Get(m => m.Name.ToLower() == name.ToLower());
        }
        public List<Medicine> GetAll()
        {
            return medicineRepository.GetAll();
        }
        public Medicine Update(Medicine medicine, int price)
        {
            Medicine dbMedicine = medicineRepository.Get(m => m.Id == medicine.Id);
            try
            {
                if (dbMedicine != null)
                {
                    medicineRepository.Update(medicine, price);
                    return medicine;
                }
                else
                {
                    throw new MedicineException("There isnt such as medicine");
                }
            }
            catch (MedicineException ex)
            {
                Console.WriteLine("There isnt such as medicine", ex.Message);
                return default;
            }
           
        }
    }
}
