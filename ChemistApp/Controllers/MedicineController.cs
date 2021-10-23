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

        public void Delete()
        {
            GetAll();
            Helper.ChangeTextColor(ConsoleColor.Yellow, "Enter Medicine Type Id: ");
            string input = Console.ReadLine();
            int medicineId;
            bool isTrue = int.TryParse(input, out medicineId);

            if (isTrue)
            {
                if (medicineService.Delete(medicineId) != null)
                {
                    Helper.ChangeTextColor(ConsoleColor.Green, "Medicine Type is deleted");
                    return;
                }
                else
                {
                    Helper.ChangeTextColor(ConsoleColor.Red, $"{medicineId} is not find");
                }
            }
            else
            {
                Helper.ChangeTextColor(ConsoleColor.Red, $"Please, select correct format");
            }
        }

        public void GetAll()
        {
            Helper.ChangeTextColor(ConsoleColor.Yellow, "All Medicine Types: ");
            foreach (Medicine item in medicineService.GetAll())
            {
                Helper.ChangeTextColor(ConsoleColor.Blue, $"{item.Id} - {item.Name} - {item.Price} azn");
            }
        }

        public void GetWithId()
        {
            GetAll();
            Helper.ChangeTextColor(ConsoleColor.Blue, "Enter Medicine  Id: ");
            string input = Console.ReadLine();
            int medicineId;
            bool isTrue = int.TryParse(input, out medicineId);

            if (isTrue)
            {
                Medicine medicine = medicineService.Get(medicineId);
                Helper.ChangeTextColor(ConsoleColor.Blue, $"Medicine Types which Id is {medicineId}");
                if (isTrue != null)
                {
                    Helper.ChangeTextColor(ConsoleColor.Cyan, $"{medicine.Name} {medicine.Price} Azn");
                }
                else
                {
                    Helper.ChangeTextColor(ConsoleColor.Red, $"Medicine couldnt find");
                }
            }
        }

        public void GetWithName()
        {
            Helper.ChangeTextColor(ConsoleColor.Blue, "Enter Medicine Nane: ");
            string input = Console.ReadLine();
            foreach (var item in medicineService.GetAll())
            {
                if (input.ToLower() == item.Name.ToLower())
                {
                    Helper.ChangeTextColor(ConsoleColor.Cyan, $"{item.Name} is exist");
                }
                else
                {
                    Helper.ChangeTextColor(ConsoleColor.Cyan, $"{item.Name} isn't exist");
                }
            }
        }
    }
}
