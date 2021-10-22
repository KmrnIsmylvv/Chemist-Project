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
            Helper.ChangeTextColor(ConsoleColor.Magenta, "Welcome");

            while (true)
            {
                ShowMenu();
                string selectedMenu = Console.ReadLine();
                int menu;
                bool isTrue = int.TryParse(selectedMenu, out menu);

                if (isTrue && menu >= 1 && menu <= 7)
                {
                    switch (menu)
                    {
                        case (int)Helper.Menu.CreateMedicineType:
                            medicineTypeController.Create();
                            break;
                        case (int)Helper.Menu.UpdateMedicineType:
                            break;
                        case (int)Helper.Menu.DeleteMedicineType:
                            medicineTypeController.Delete();
                            break;
                        case (int)Helper.Menu.GetMedicineTypeWithId:
                            break;
                        case (int)Helper.Menu.GetMedicineTypeWithName:

                            break;
                        case (int)Helper.Menu.AllMedicineTypes:
                            medicineTypeController.GetAll();
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
                   " 6- All MedicineTypes, 0- Exit ");
            Helper.ChangeTextColor(ConsoleColor.Yellow, "Select Option Number: ");
        }
    }
}
