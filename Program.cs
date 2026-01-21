// Program.cs
using System;
using System.Collections.Generic;
using foodBank2;

class Program
{
    // List to store all food items in inventory
    static List<FoodItem> inventory = new List<FoodItem>();

    static void Main(string[] args)
    {
        Console.WriteLine("===================================");
        Console.WriteLine("Food Bank Inventory Management System");
        Console.WriteLine("===================================\n");

        //set a boolean so that it will continue looping while it is true
        bool running = true;

        // Main program loop
        while (running)
        {
            DisplayMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddFoodItem();
                    break;
                case "2":
                    DeleteFoodItem();
                    break;
                case "3":
                    PrintInventory();
                    break;
                case "4":
                    Console.WriteLine("\nThank you for using the Food Bank Inventory System!");
                    running = false;
                    break;
                default:
                    Console.WriteLine("\nInvalid choice! Please enter a number between 1 and 4.\n");
                    break;
            }
        }
    }

    // Display the menu options
    static void DisplayMenu()
    {
        Console.WriteLine("===== MENU =====");
        Console.WriteLine("1. Add Food Item");
        Console.WriteLine("2. Delete Food Item");
        Console.WriteLine("3. Print List of Current Food Items");
        Console.WriteLine("4. Exit the Program");
        Console.Write("\nEnter your choice (1-4): ");
    }

    // Add a new food item to inventory
    static void AddFoodItem()
    {
        Console.WriteLine("\n--- Add New Food Item ---");

        // Get food name
        Console.Write("Enter food name: ");
        string name = Console.ReadLine();

        // Validate name is not empty ERROR HANDLING
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Error: Name cannot be empty!\n");
            return;
        }

        // Get category
        Console.Write("Enter category (e.g., Canned Goods, Dairy, Produce): ");
        string category = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(category))
        {
            Console.WriteLine("Error: Category cannot be empty!\n");
            return;
        }

        // Get quantity with error handling
        int quantity = 0;
        bool validQuantity = false;

        while (!validQuantity)
        {
            Console.Write("Enter quantity: ");
            string quantityInput = Console.ReadLine();

            if (int.TryParse(quantityInput, out quantity))
            {
                if (quantity > 0)
                {
                    validQuantity = true;
                }
                else
                {
                    Console.WriteLine("Error: Quantity must be greater than 0!");
                }
            }
            else
            {
                Console.WriteLine("Error: Please enter a valid number!");
            }
        }

        // Get expiration date with error handling
        DateTime expirationDate = DateTime.Now;
        bool validDate = false;

        while (!validDate)
        {
            Console.Write("Enter expiration date (MM/DD/YYYY): ");
            string dateInput = Console.ReadLine();

            if (DateTime.TryParse(dateInput, out expirationDate))
            {
                validDate = true;
            }
            else
            {
                Console.WriteLine("Error: Please enter a valid date in MM/DD/YYYY format!");
            }
        }

        // Create new FoodItem using constructor and add to inventory
        FoodItem newItem = new FoodItem(name, category, quantity, expirationDate);
        inventory.Add(newItem);

        Console.WriteLine($"\n✓ Successfully added {name} to inventory!\n");
    }

    // Delete a food item from inventory
    static void DeleteFoodItem()
    {
        Console.WriteLine("\n--- Delete Food Item ---");

        if (inventory.Count == 0)
        {
            Console.WriteLine("Inventory is empty! Nothing to delete.\n");
            return;
        }

        // Display all items with numbers
        for (int i = 0; i < inventory.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {inventory[i]}");
        }

        // Get user choice
        Console.Write($"\nEnter the number of the item to delete (1-{inventory.Count}): ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int choice))
        {
            if (choice >= 1 && choice <= inventory.Count)
            {
                string itemName = inventory[choice - 1].GetName();
                inventory.RemoveAt(choice - 1);
                //the $ sign means that it is the equivalent of a f string in python and lets you put your variables into the string
                Console.WriteLine($"\n✓ Successfully deleted {itemName} from inventory!\n");
            }
            else
            {
                Console.WriteLine($"Error: Please enter a number between 1 and {inventory.Count}!\n");
            }
        }
        else
        {
            Console.WriteLine("Error: Please enter a valid number!\n");
        }
    }

    // Print all food items in inventory
    static void PrintInventory()
    {
        Console.WriteLine("\n--- Current Food Bank Inventory ---");

        if (inventory.Count == 0)
        {
            Console.WriteLine("Inventory is currently empty.\n");
            return;
        }

        Console.WriteLine($"\nTotal Items: {inventory.Count}\n");
        Console.WriteLine(new string('-', 80));

        for (int i = 0; i < inventory.Count; i++)
        {
            FoodItem item = inventory[i];
            string status = item.IsExpired() ? " [EXPIRED]" : "";
            Console.WriteLine($"{i + 1}. {item}{status}");
        }

        Console.WriteLine(new string('-', 80));
        Console.WriteLine();
    }
}