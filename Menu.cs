using System;
using static TaskTracker.Program;
using static TaskTracker.Task;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace TaskTracker
{
    public static class Menu
    {
        public static int Check(string input)
        {
            int output;
            while(!int.TryParse(input, out output))
            {
                Console.Write("Please enter a valid input: ");
                input = Console.ReadLine();
            }return output;
        }

        public static void ShowMainMenu()
        {
            //is public the correct access modifier
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=============== Main Menu ==============");
                Console.WriteLine("1. Tasks");
                Console.WriteLine("2. Employees");
                Console.WriteLine("3. Quit");
                Console.WriteLine("========================================");

                int userInput = Check(Console.ReadLine()); //tryparse didnt work? use the out reference?
                Console.Clear();

                switch (userInput)  //Look up using enums here, so the user can type anser instead of number
                {
                    case 1:
                        //user selected tasks
                        ShowTaskMenu();
                        break;
                    case 2:
                        //user selected employees
                        ShowEmployeeMenu();
                        break;
                    case 3:
                        //user selected quit, close the program
                        Console.WriteLine("exiting....");
                        Thread.Sleep(4000);
                        Environment.Exit(0);
                        break;
                    default:
                        //user did not enter a valid selection, reload menu
                        Console.WriteLine("invalid user input, please try again");
                        break;
                }
                Console.Clear();
            }
        }


        public static void ShowTaskMenu()
        {
            Console.WriteLine("=============== Task Menu ==============");
            Console.WriteLine("1. View Active Tasks");
            Console.WriteLine("2. Show Completed Tasks");
            Console.WriteLine("3. Create Task");
            Console.WriteLine("4. Return to Main Menu");
            Console.WriteLine("========================================");
            Console.ReadLine();
            int userInput = Check(Console.ReadLine());
            switch (userInput)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("1. View Active Tasks");
                    Console.WriteLine("========================================");
                    if (TotalTask.Count != 0)


                        Console.WriteLine("========================================\nTo continue press enter...");
                    Console.ReadLine();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("2. Show Completed Tasks");
                    Console.WriteLine("========================================");

                    Console.WriteLine("========================================\nTo continue press enter...");
                    Console.ReadLine();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("3. Create Task");
                    Console.WriteLine("========================================");

                    Console.WriteLine("========================================\nTo continue press enter...");
                    Console.ReadLine();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("4. Return to Main Menu");
                    Console.WriteLine("========================================");

                    Console.WriteLine("========================================\nTo continue press enter...");
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Invalid user input, please try again");
                    break;



            }
        }

        public static void ShowEmployeeMenu()
        {
            Console.WriteLine("=============== Employee Menu ==============");
            Console.WriteLine("1. Show All Employees");
            Console.WriteLine("2. Create Employee");
            Console.WriteLine("3. Delete Employee");
            Console.WriteLine("4. Return to Main Menu");
            Console.WriteLine("============================================");

            int userInput = Check(Console.ReadLine()); //tryparse didnt work? use the out reference?

            switch (userInput)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("1. Show All Employees: ");
                    Console.WriteLine("========================================");
                    if (Employees.Count != 0)
                    {
                        Employees.ForEach(Console.WriteLine);
                    }
                    else Console.WriteLine("There are no employees in your list");
                    Console.WriteLine("========================================\nTo continue press enter...");
                    Console.ReadLine();
                    break;
                //for each employee in employee list have that employee object print its staus
                case 2:
                    Console.Clear();
                    Console.WriteLine("2. Create an Employee: ");
                    Console.WriteLine("========================================");

                    Console.Write("Please enter name: ");
                    string name = Console.ReadLine().ToLower();
                    Console.Write("Please enter employee birthday in MM\\DD\\YYYY format:\nMonth: ");
                    int month = Check(Console.ReadLine());
                    Console.Write("Day: ");
                    int day = Check(Console.ReadLine());
                    Console.Write("Year: ");
                    int year = Check(Console.ReadLine());

                    DateTime birthday = new DateTime(year, month, day);
                    Employee newEmployee = new Employee(name, birthday);
                    Employees.Add(newEmployee);

                    Console.WriteLine("========================================\nTo continue press enter...");
                    Console.ReadLine();
                    break;
                //call a method called createEmployee() from the employee class and add it to a list
                case 3:
                    Console.WriteLine("3. Delete Employee");
                    Console.WriteLine("========================================");

                    Console.Write("Please enter employee name: ");
                    string delete = Console.ReadLine().ToLower();

                    bool t = true;
                    for (int i = 0; i < Employees.Count; i++)
                    {
                        if (Employees[i].Name == delete)
                        {
                            Employees.Remove(Employees[i]);
                            Console.WriteLine($"{delete} has been removed");
                            t = false;
                        }
                    }
                    if (t)
                    {
                        Console.WriteLine("That name does not exist");
                    }

                    Console.WriteLine("========================================\nTo continue press enter...");
                    Console.ReadLine();
                    break;
                //search the employee list and find if the named employee exists, then remove it
                case 4:
                    Console.WriteLine("4. Return to Main Menu");
                    Console.WriteLine("========================================");
                    break;
                default:
                    Console.WriteLine("Invalid user input, please try again");
                    break;
            }

        }

    }
}