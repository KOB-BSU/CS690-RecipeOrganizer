namespace RecipeOrganizerUI;

using Recipe.Service;
using System.IO;

public class Program
{
    public static void Main(string[] args)
    {
 

        Recipe.Service.GroceryList groceries = new GroceryList();
        groceries.AddTestItemsGroceryList();
        groceries.ConsolePrintGroceryList();
        string tmp = groceries.JSONSerializeGroceryList();
        Console.WriteLine(tmp);

        File.WriteAllText("groceries.json", tmp);

 

        

        // Console.WriteLine();
        // Console.WriteLine(Directory.GetFiles(@"..//"));






        Console.WriteLine("You are here.");
    }

}
