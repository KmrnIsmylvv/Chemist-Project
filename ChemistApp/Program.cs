using System;
using Utilies.Helper;
using Entities.Models;
using Business.Services;
namespace ChemistApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MedicineTypeService medicineTypeService = new MedicineTypeService();
            Helper.ChangeTextColor(ConsoleColor.Magenta, "Welcome");

            while (true)
            {
                Helper.ChangeTextColor(ConsoleColor.Green, "1- Create MedicineType, 2-Update MedicineType," +
                    "3- Delete MedicineType, 4-Get MedicineType with Id, 5- Get MedicineType with Name," +
                    " 6- All MedicineTypes ");
                Helper.ChangeTextColor(ConsoleColor.Yellow, "Select Option Number: ");

                string selectedMenu = Console.ReadLine();
                int menu;
                bool isTrue = int.TryParse(selectedMenu, out menu);

                if (isTrue && menu >= 1 && menu <= 7)
                {
                    switch (menu)
                    {
                        case 1:
                            Helper.ChangeTextColor(ConsoleColor.Cyan, "Enter MedicineType Name: ");
                            string name = Console.ReadLine();

                            MedicineType medicineType = new MedicineType { TypeName = name };
                            if (medicineTypeService.Create(medicineType) != null)
                            {
                                Helper.ChangeTextColor(ConsoleColor.Green, $"{medicineType.TypeName} created");
                                break;
                            }
                            else
                            {
                                Helper.ChangeTextColor(ConsoleColor.Red, "Something is wrong!!!");
                                break;
                            }
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case 5:
                            break;
                        case 6:
                            Helper.ChangeTextColor(ConsoleColor.Yellow, "All Medicine Types: ");
                            foreach (MedicineType item in medicineTypeService.GetAll())
                            {
                                Helper.ChangeTextColor(ConsoleColor.Blue, $"{item.Id} - {item.TypeName}");
                            }
                            break;

                    }
                }
                else
                {
                    Helper.ChangeTextColor(ConsoleColor.Red, "Select Correct Option");
                }

            }
        }
    }
}
