using Business.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services
{
    public class MedicineService : IMedicine
    {
        public Medicine Create(Medicine entity, string MedicineTypeName)
        {
            throw new NotImplementedException();
        }

        public Medicine Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Medicine Get(int id)
        {
            throw new NotImplementedException();
        }

        public Medicine Get(string name)
        {
            throw new NotImplementedException();
        }

        public List<Medicine> GetAll(string medicineTypeName)
        {
            throw new NotImplementedException();
        }

        public List<Medicine> GetAll()
        {
            throw new NotImplementedException();
        }

        public Medicine Update(Medicine entity, string MedicineTypeName)
        {
            throw new NotImplementedException();
        }
    }
}
