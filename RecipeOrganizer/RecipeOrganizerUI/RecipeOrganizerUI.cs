namespace RecipeOrganizerUI;

using Recipe.Service;
using System.IO;

public class Program
{
    public static void Main(string[] args)
    {
        Console.Clear();
        Recipe.Service.Substitutions substitutions = new Substitutions();
        Recipe.Service.Groceries groceries = new Groceries();
        
        substitutions.ReadFromJSON();

        groceries.ReadFromJSON();

        bool exitApp = false;
        
        while (!exitApp){
            Console.Clear();
            Console.WriteLine("Ingredient Substitutions");
            Console.WriteLine(" 1 - View Substitutions");
            Console.WriteLine(" 2 - Add Substitutions");
            Console.WriteLine(" 3 - Remove Substitutions");            
            Console.WriteLine("Grocery List");
            Console.WriteLine(" 4 - View Grocery List");
            Console.WriteLine(" 5 - Add Grocery List Item");
            Console.WriteLine(" 6 - Remove Grocery List Item");
            Console.WriteLine("X - Exit");
            
            var modeVar = Console.ReadLine()!;
            var garbageVar = ""!;

            Console.Clear();
            switch(modeVar.ToUpper()){
                case "1":
                    Console.Clear();
                    substitutions.ConsolePrintAllSubstititions();
                    Console.WriteLine("Press any key to continue");
                    garbageVar = Console.ReadLine();
                    break;
                    
                case "2":
                    Console.Clear();
                    Console.WriteLine("Enter ingredient to substitute");
                    var ingredientToSubstitute = Console.ReadLine()!;
                    Console.WriteLine("Enter substitution ingredient");
                    var substitutionIngredient = Console.ReadLine()!;
                    substitutions.AddSubstitution(ingredientToSubstitute, substitutionIngredient);
                    Console.WriteLine("Added "+substitutionIngredient+" as substitute for "+ingredientToSubstitute);
                    Console.WriteLine("Press any key to continue");
                    garbageVar = Console.ReadLine();
                    break;

                case "3":
                    Console.Clear();
                    Console.WriteLine("Enter ingredient substitution to remove");
                    var ingredientSubstitutionToRemove = Console.ReadLine()!;
                    substitutions.DeleteSubstitution(ingredientSubstitutionToRemove);
                    Console.WriteLine("Press any key to continue");
                    garbageVar = Console.ReadLine();
                    break;

                case "4":
                    Console.Clear();
                    Console.WriteLine("Grocery List (Item [quantity])");
                    groceries.ConsolePrintAllGroceries();
                    Console.WriteLine("Press any key to continue");
                    garbageVar = Console.ReadLine();
                    break;

                case "5":
                    Console.Clear();
                    Console.WriteLine("Enter grocery item to add");
                    var groceryItemToAdd = Console.ReadLine()!;
                    Console.WriteLine("Enter grocery item quantity");
                    var groceryQuantityToAdd = Console.ReadLine()!;
                    groceries.AddGrocery(groceryItemToAdd, groceryQuantityToAdd);
                    Console.WriteLine("Added "+groceryItemToAdd+" ["+ groceryQuantityToAdd +"]");
                    Console.WriteLine("Press any key to continue");
                    garbageVar = Console.ReadLine();
                    break;

                case "6":
                    Console.Clear();
                    Console.WriteLine("Enter grocery item to remove");
                    var groceryItemToRemove = Console.ReadLine()!;
                    groceries.RemoveGrocery(groceryItemToRemove);
                    Console.WriteLine("Removed "+groceryItemToRemove);
                    Console.WriteLine("Press any key to continue");
                    garbageVar = Console.ReadLine();
                    break;                   

                case "X":
                    Console.Clear();
                    exitApp = true;
                    break;

                    
            }         
        }













        // Recipe.Service.Substitutions substitutions = new Substitutions();
        // substitutions.ReadFromJSON();


        // substitutions.ConsolePrintAllSubstititions();
        // substitutions.AddSubstitution("egg", "better egg");
        // substitutions.AddSubstitution("egg", "a lousy egg");
        // substitutions.AddSubstitution("vanilla", "there is no substititon, you monster");
        // substitutions.ConsolePrintAllSubstititions();
        // substitutions.DeleteSubstitution("vanilla");
        // substitutions.ConsolePrintAllSubstititions();
        // substitutions.WriteToJSON();
        // substitutions.ReadFromJSON();
        // substitutions.ConsolePrintAllSubstititions();

        // Recipe.Service.Groceries groceries = new Groceries();
        // groceries.ReadFromJSON();
        // groceries.AddGrocery("eggs", "dozen");
        // groceries.AddGrocery("apples", "6");
        // groceries.AddGrocery("oatmeal", "4 lbs");
        // groceries.ConsolePrintAllGroceries();
        // groceries.RemoveGrocery("apples");
        // groceries.WriteToJSON();
        
        




        
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






        Console.WriteLine("Goodbye. (Your patience is appreciated.)");
        
    }

}
