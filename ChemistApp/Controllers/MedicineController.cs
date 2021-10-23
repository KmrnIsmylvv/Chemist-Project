using Business.Services;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Utilies.Helper;

namespace ChemistApp.Controllers
{
    public class MedicineController
    {
        private MedicineService medicineService { get; }

        public MedicineController()
        {
            medicineService = new MedicineService();
        }

        public void Create()
        {
            Helper.ChangeTextColor(ConsoleColor.Blue, "Select Possible Medicine Type: ");
            string typeName = Console.ReadLine();
            Helper.ChangeTextColor(ConsoleColor.Blue, "Enter Medicine Name: ");
            string medicineName = Console.ReadLine();
            Helper.ChangeTextColor(ConsoleColor.Blue, "Enter Medicine Price: ");
            int medicinePrice = int.Parse(Console.ReadLine());

            Medicine medicine = new Medicine { Name = medicineName, Price = medicinePrice };
            Medicine newMedicine = medicineService.Create(medicine, typeName);

            if (newMedicine != null)
            {
                Helper.ChangeTextColor(ConsoleColor.Green, $"New Medicine is created:" +
                    $" {newMedicine.Name} - {newMedicine.Price} Azn");
                return;
            }
            Helper.ChangeTextColor(ConsoleColor.Red, $"Couldnt find such as Medicine Type - {typeName}");
        }

        public void GetAllMedicinesWithTypeNames()
        {
            Helper.ChangeTextColor(ConsoleColor.Blue, "Select Possible Medicine Type: ");
            string typeName = Console.ReadLine();

            List<Medicine> medicines = medicineService.GetAll(typeName);

            if (medicineService != null)
            {
                Helper.ChangeTextColor(ConsoleColor.Blue, $"Type {typeName}: ");
                foreach (var item in medicines)
                {
                    Helper.ChangeTextColor(ConsoleColor.Green,
                        $"{item.Id} - {item.Name} - {item.Price} Azn");
                }
                return;
            }
            Helper.ChangeTextColor(ConsoleColor.Red, $"Couldnt find such as type {typeName}");
        }
    }
}
