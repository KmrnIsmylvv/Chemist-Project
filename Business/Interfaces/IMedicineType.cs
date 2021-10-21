using Entities.Models;
using System.Collections.Generic;
namespace Business.Interfaces
{
    public interface IMedicineType
    {
        MedicineType Create(MedicineType medicineType);
        MedicineType Update(int Id, MedicineType medicineType);
        MedicineType Delete(int Id);
        MedicineType Get(int Id);
        MedicineType Get(string name);
        List<MedicineType> GetAll();
    }
}
