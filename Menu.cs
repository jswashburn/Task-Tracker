using System;


namespace TaskTracker
{
    public static class Menu
    {


        public static void ShowMainMenu()
        {
            //is public the correct access modifier
            while (true)
            {
                Console.WriteLine("=============== Main Menu ==============");
                Console.WriteLine("1. Tasks");
                Console.WriteLine("2. Employees");
                Console.WriteLine("3. Quit");
                Console.WriteLine("========================================");

                int userInput = int.Parse(Console.ReadLine()); //tryparse didnt work? use the out reference?
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
        }

        public static void ShowEmployeeMenu()
        {
            Console.WriteLine("=============== Employee Menu ==============");
            Console.WriteLine("1. Show All Employees");
            Console.WriteLine("2. Create Employee");
            Console.WriteLine("3. Delete Employee");
            Console.WriteLine("4. Return to Main Menu");
            Console.WriteLine("============================================");

            int userInput = int.Parse(Console.ReadLine()); //tryparse didnt work? use the out reference?

            switch (userInput)
            {
                case 1:
                    Console.WriteLine("1. Show All Employees: ");
                    Console.WriteLine("========================================");
                    // Employee.showEmployees();
                    Console.WriteLine("========================================");
                    Console.ReadLine();
                    break;
                //for each employee in employee list have that employee object print its staus
                case 2:
                    Console.WriteLine("2. Create an Employee: ");
                    Console.WriteLine("========================================");
                    //Employee newEmployee = new Employee();
                    //newEmployee.setEmployeeValues();
                    //employeeTracker.listOfEmployees.Add(newEmployee); This should be taken care of with the method in the class
                    Console.WriteLine("========================================");
                    Console.ReadLine();
                    break;
                //call a method called createEmployee() from the employee class and add it to a list
                case 3:
                    Console.WriteLine("3. Delete Employee");
                    Console.WriteLine("========================================");
                    //Employee.deleteEmployee();
                    Console.WriteLine("========================================");
                    Console.ReadLine();
                    break;
                //search the employee list and find if the named employee exists, then remove it
                case 4:
                    Console.WriteLine("4. Return to Main Menu");
                    Console.WriteLine("========================================");
                    Console.ReadLine();
                    break;
                default:
                    //user did not enter a valid selection, reload menu
                    Console.WriteLine("invalid user input, please try again");
                    break;
            }

        }

    }
}