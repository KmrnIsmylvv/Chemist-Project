﻿using Business.Services;
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

        public void GetAll()
        {
            Helper.ChangeTextColor(ConsoleColor.Yellow, "All Medicine Types: ");
            foreach (MedicineType item in medicineTypeService.GetAll())
            {
                Helper.ChangeTextColor(ConsoleColor.Blue, $"{item.Id} - {item.TypeName}");
            }
        }

        public void Delete()
        {
            GetAll();
            Helper.ChangeTextColor(ConsoleColor.Yellow, "Enter Medicine Type Id: ");
            string input = Console.ReadLine();
            int medicineTypeId;
            bool isTrue = int.TryParse(input, out medicineTypeId);
            if (isTrue)
            {
                if (medicineTypeService.Delete(medicineTypeId) != null)
                {
                    Helper.ChangeTextColor(ConsoleColor.Green, "Medicine Type is deleted");
                    return;
                }
                else
                {
                    Helper.ChangeTextColor(ConsoleColor.Red, $"{medicineTypeId} is not find");
                }
            }
            else
            {
                Helper.ChangeTextColor(ConsoleColor.Red, $"Please, select correct format");
            }
        }

        public void GetWithName()
        {
            Helper.ChangeTextColor(ConsoleColor.Blue, "Enter Medicine Type Name: ");
            string input = Console.ReadLine();
            foreach (var item in medicineTypeService.GetAll())
            {
                if (input.ToLower() == item.TypeName.ToLower())
                {
                    Helper.ChangeTextColor(ConsoleColor.Cyan, $"{item.TypeName} is exist");
                }
                else
                {
                    Helper.ChangeTextColor(ConsoleColor.Cyan, $"{item.TypeName} isn't exist");
                }
            }
        }

        public void GetWithId()
        {
            GetAll();
            Helper.ChangeTextColor(ConsoleColor.Blue, "Enter Medicine Type Id: ");
            string input = Console.ReadLine();
            int typeId;
            bool isTrue = int.TryParse(input, out typeId);
            if (isTrue)
            {
                MedicineType medicineType = medicineTypeService.Get(typeId);
                Helper.ChangeTextColor(ConsoleColor.Blue, $"Medicine Types which Id is {typeId}");
                if (isTrue != null)
                {
                    Helper.ChangeTextColor(ConsoleColor.Cyan, medicineType.TypeName);
                }
                else
                {
                    Helper.ChangeTextColor(ConsoleColor.Red, $"Catrgory couldnt find");
                }

            }
        }
    }
}
