using System;
using System.Collections.Generic;
using System.Text;

namespace Utilies.Helper
{
    public class Helper
    {
        public static void ChangeTextColor(ConsoleColor color,string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        //"1- Create MedicineType, 2-Update MedicineType," +
        //            "3- Delete MedicineType, 4-Get MedicineType with Id, 5- Get MedicineType with Name," +
        //            " 6- All MedicineTypes ");
        public enum Menu
        {
            CreateMedicineType,
            UpdateMedicineType,
            DeleteMedicineType,
            GetMedicineTypeWithId,
            GetMedicineTypeWithName,
            AllMedicineTypes
        }
    }
}
