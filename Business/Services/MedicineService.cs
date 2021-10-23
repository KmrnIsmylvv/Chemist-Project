using Business.Interfaces;
using DataAccess.Repositories;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
                return null;
            }

        }

        public List<Medicine> GetAll(string medicineTypeName)
        {
            MedicineType dbMedicineType = medicineTypeService.Get(medicineTypeName);
            if (dbMedicineType != null)
            {
                return medicineRepository.GetAll(m => m.Type.TypeName == dbMedicineType.TypeName);
            }
            else
            {
                return null;
            }
        }

        public Medicine Delete(int id)
        {
            Medicine dbMedicine = medicineRepository.Get(m => m.Id == id);
            if (dbMedicine != null)
            {
                medicineRepository.Delete(dbMedicine);
                return dbMedicine;
            }
            else
            {
                return null;
            }
        }

        public Medicine Get(int id)
        {
            return medicineRepository.Get(t => t.Id == id);
        }

        public Medicine Get(string name)
        {
            throw new NotImplementedException();
        }

      

        public List<Medicine> GetAll()
        {
            return medicineRepository.GetAll();
        }

        public Medicine Update(Medicine entity, string MedicineTypeName)
        {
            throw new NotImplementedException();
        }
    }
}
