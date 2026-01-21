namespace foodBank2;

using System;

public class FoodItem
{
    // Properties to store food item information
    private string Name;
    private string Category;
    private int Quantity;
    
    //the method is built as public <datatype> <name> { get; set; } -- which means it will get and set params here
    DateTime ExpirationDate;

    // Constructor - this runs when you create a new FoodItem
    public FoodItem(string name, string category, int quantity, DateTime expirationDate)
    {
        this.Name = name;
        this.Category = category;
        this.Quantity = quantity;
        this.ExpirationDate = expirationDate;
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
    
    //make a get name method
    public string GetName()
    {
        return Name;
    }
}