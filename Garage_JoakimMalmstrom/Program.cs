using System;

namespace Garage_JoakimMalmstrom
{
    class Program
    {
        static void Main(string[] args)
        {
            bool startMenu = true;
            bool mainMenu = true;

            StartMenu(startMenu);

            MainMenu(mainMenu);
        }

        private static bool StartMenu(bool startMenu)
        {
            Console.WriteLine("Enter the park capacity of the garage");
            string input = Console.ReadLine();

            try
            {
                int.Parse(input);
                Console.WriteLine($"The park capacity is {input}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StartMenu(startMenu);
            }

            do
            {
                Console.WriteLine("Would you like to populate the garage from the start? (y/n)");
                input = Console.ReadLine();

                switch (input)
                {
                    case "y":
                        // Populate garage
                        startMenu = false;
                        break;
                    case "n":
                        // Empty garage
                        startMenu = false;
                        break;
                    default:
                        Console.WriteLine("Unknown command!");
                        break;
                }
                // Answer
            } while (startMenu);
            return startMenu;
        }

        private static void MainMenu(bool mainMenu)
        {
            Console.Clear();
            do
            {
                Console.WriteLine("1. Add a vehicle to the garage");
                Console.WriteLine("2. Remove a vehicle from the garage");
                Console.WriteLine("3. Retrieve a list of parked vehicles");
                Console.WriteLine("4. Look for a vehicle through licence plate");
                Console.WriteLine("5. Look for a vehicle through properties");
                Console.WriteLine("6. Quit application");
                Console.WriteLine("--------------------");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Add vehicle");
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Remove vehicle");
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Retrieve List");
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Licence plate search");
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine("Property search");
                        break;
                    case "6":
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Unknown command!");
                        break;
                }

            } while (mainMenu);
        }
    }
}
