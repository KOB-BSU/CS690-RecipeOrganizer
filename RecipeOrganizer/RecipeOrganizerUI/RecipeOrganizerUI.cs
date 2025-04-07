namespace RecipeOrganizerUI;

using Recipe.Service;
using System.IO;

public class Program
{
    public static void Main(string[] args)
    {

        Recipe.Service.Substitutions substitutions = new Substitutions();

        // foreach (string key in substitutions.substitutionsDict.Keys){
        //     Console.WriteLine(key);        
        // }

        substitutions.ConsolePrintSubstititions();
        substitutions.AddSubstitution("egg", "better egg");
        substitutions.AddSubstitution("egg", "a lousy egg");
        substitutions.AddSubstitution("vanilla", "there is no substititon, you monster");
        substitutions.ConsolePrintSubstititions();
        substitutions.WriteToJSON();
        substitutions.ReadFromJSON();
        



        // foreach (string key in substitutions.substitutionsDict.Keys){
        //     Console.WriteLine(key);
        // }

        
        // Recipe.Service.GroceryList grocerylist = new GroceryList();

        // Console.WriteLine(grocerylist.glist);

        // Console.WriteLine(grocerylist.GDict.Count);

        // grocerylist.AddGroceryItem("THE GREATEST BANANA", "THERE CAN ONLY BE ONE");
        // grocerylist.AddGroceryItem("Less excellent bananas", "Literally a bunch");
        
        // grocerylist.AddTestGroceryItems();
        
        // Console.WriteLine(grocerylist.GDict.Count);

        // foreach(string k in grocerylist.GDict.Keys){
        //     Console.WriteLine(k);
        //     Console.WriteLine(grocerylist.GDict[k].ItemDescription);
        //     Console.WriteLine(grocerylist.GDict[k].ItemQuantity);            
        //     Console.WriteLine();
        // }

        
        // Console.WriteLine(grocerylist.GDict);

        // foreach(Recipe.Service.GroceryItem GI in grocerylist.GList){
        //     Console.WriteLine(GI.ItemDescription);
        //     Console.WriteLine(GI.ItemQuantity);
        // }

        // grocerylist.WriteToJSON();

        // grocerylist.ReadFromJSON();

        // grocerylist.GList.ForEach(Console.WriteLine);

        
        // Recipe.Service.Groceries groceries = new Groceries();
        // groceries.AddTestItemsGroceryList();
        // groceries.ConsolePrintGroceryList();

        // groceries.WriteGroceryListToJSON();

        // Console.WriteLine();
        // groceries.ReadGroceryListFromJSON();



        // string tmp = groceries.JSONSerializeGroceryList();
        // Console.WriteLine(tmp);

        // File.WriteAllText("groceries.json", tmp);

 

        

        // Console.WriteLine();
        // Console.WriteLine(Directory.GetFiles(@"..//"));






        Console.WriteLine("You are here.");
    }

}
