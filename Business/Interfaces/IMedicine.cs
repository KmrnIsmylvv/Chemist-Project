using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interfaces
{
    public interface IMedicine
    {
        Medicine Create(Medicine entity, string MedicineTypeName);

        Medicine Delete(int id);

        Medicine Update(Medicine entity, string MedicineTypeName);

        Medicine Get(int id);

        Medicine Get(string name);

        List<Medicine> GetAll(string medicineTypeName);

        List<Medicine> GetAll();
    }
}
