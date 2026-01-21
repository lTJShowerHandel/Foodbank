namespace foodBank2;

using System;

public class FoodItem
{
    // Properties to store food item information
    public string Name { get; set; }
    public string Category { get; set; }
    public int Quantity { get; set; }
    
    //the method is built as public <datatype> <name> { get; set; } -- which means it will get and set params here
    public DateTime ExpirationDate { get; set; }

    // Constructor - this runs when you create a new FoodItem
    public FoodItem(string name, string category, int quantity, DateTime expirationDate)
    {
        Name = name;
        Category = category;
        Quantity = quantity;
        ExpirationDate = expirationDate;
    }

    // Method to display food item information in a nice format
    public override string ToString()
    {
        return $"Name: {Name,-20} | Category: {Category,-15} | Quantity: {Quantity,3} | Expires: {ExpirationDate.ToShortDateString()}";
    }

    // Method to check if item is expired
    public bool IsExpired()
    {
        return ExpirationDate < DateTime.Now;
    }
}