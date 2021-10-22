using Business.Services;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Utilies.Helper;

namespace ChemistApp.Controllers
{
    public class MedicineTypeController
    {
        public MedicineTypeService medicineTypeService { get; }

        public MedicineTypeController()
        {
            medicineTypeService = new MedicineTypeService();
        }

        public void Create()
        {
            Helper.ChangeTextColor(ConsoleColor.Cyan, "Enter MedicineType Name: ");
            string name = Console.ReadLine();

            MedicineType medicineType = new MedicineType { TypeName = name };
            if (medicineTypeService.Create(medicineType) != null)
            {
                Helper.ChangeTextColor(ConsoleColor.Green, $"{medicineType.TypeName} created");
                return;
            }
            else
            {
                Helper.ChangeTextColor(ConsoleColor.Red, "Something is wrong!!!");
                return;
            }
        }

        public void GetAllMedicineType()
        {
            Helper.ChangeTextColor(ConsoleColor.Yellow, "All Medicine Types: ");
            foreach (MedicineType item in medicineTypeService.GetAll())
            {
                Helper.ChangeTextColor(ConsoleColor.Blue, $"{item.Id} - {item.TypeName}");
            }
        }
    }
}
