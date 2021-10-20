using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public static class DbContext
    {
        public static List<Medicine> Medicines { get;  }
        public static List<MedicineType> MedicineTypes { get; }

        static DbContext()
        {
            Medicines = new List<Medicine>();
            MedicineTypes = new List<MedicineType>();
        }
    }
}
