namespace RecipeOrganizerUI;

using Recipe.Service;

public class Program
{
    public static void Main(string[] args)
    {

        Recipe.Service.GroceryList groceries = new GroceryList();
        groceries.AddTestItemsGroceryList();
        groceries.ConsolePrintGroceryList();
        string tmp = groceries.JSONSerializeGroceryList();
        Console.Write(tmp);




        Console.WriteLine("You are here.");
    }

}
