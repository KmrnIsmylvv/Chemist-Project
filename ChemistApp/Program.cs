using System;
using Utilies.Helper;
using Entities.Models;
using Business.Services;
using ChemistApp.Controllers;

namespace ChemistApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MedicineTypeController medicineTypeController = new MedicineTypeController();
            MedicineController medicineController = new MedicineController();
            Helper.ChangeTextColor(ConsoleColor.Magenta, "Welcome");

            while (true)
            {
                ShowMenu();
                string selectedMenu = Console.ReadLine();
                int menu;
                bool isTrue = int.TryParse(selectedMenu, out menu);

                if (isTrue && menu >= 1 && menu <= 15)
                {
                    switch (menu)
                    {
                        case (int)Helper.Menu.CreateMedicineType:
                            medicineTypeController.Create();
                            break;
                        case (int)Helper.Menu.UpdateMedicineType:
                            medicineTypeController.Update();
                            break;
                        case (int)Helper.Menu.DeleteMedicineType:
                            medicineTypeController.Delete();
                            break;
                        case (int)Helper.Menu.GetMedicineTypeWithId:
                            medicineTypeController.GetWithId();
                            break;
                        case (int)Helper.Menu.GetMedicineTypeWithName:
                            medicineTypeController.GetWithName();
                            break;
                        case (int)Helper.Menu.AllMedicineTypes:
                            medicineTypeController.GetAll();
                            break;
                        case (int)Helper.Menu.CreateMedicine:
                            medicineTypeController.GetAll();
                            medicineController.Create();
                            break;
                        case (int)Helper.Menu.GetAllMedicinesWithTypeNames:
                            medicineController.GetAllMedicinesWithTypeNames();
                            break;
                        case (int)Helper.Menu.GetAllMedicines:
                            medicineController.GetAll();
                            break;
                        case (int)Helper.Menu.DeleteMedicine:
                            medicineController.Delete();
                            break;
                        case (int)Helper.Menu.GetMedicineWithId:
                            medicineController.GetWithId();
                            break;
                        case (int)Helper.Menu.GetMedicineWithName:
                            medicineController.GetWithName();
                            break;
                    }
                }
                else if (menu == 0)
                {
                    Helper.ChangeTextColor(ConsoleColor.DarkCyan, "Bye Bye");
                    break;
                }
                else
                {
                    Helper.ChangeTextColor(ConsoleColor.Red, "Select Correct Option");
                }
            }
        }
        static void ShowMenu()
        {
            Helper.ChangeTextColor(ConsoleColor.Green, "1- Create MedicineType, 2-Update MedicineType," +
                   "3- Delete MedicineType, 4-Get MedicineType with Id, 5- Get MedicineType with Name," +
                   " 6- All MedicineTypes, 7- Create Medicine,8- Get All Medicines With Type Name," +
                   "9- All Medicines,10- Delete Medicine,11- Get Medicine With Id," +
                   "12- Get Medicine With Name, 0- Exit ");
            Helper.ChangeTextColor(ConsoleColor.Yellow, "Select Option Number: ");
        }
    }
}
