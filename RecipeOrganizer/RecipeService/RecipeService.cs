using System.Text.Json;
//https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/how-to
using System;
using System.Collections.Generic;
using System.IO;


namespace Recipe.Service;

public class Recipes
{
    public class Recipe{
        public string? RecipeName {get;set;}
        public List<string> Ingredients {get;set;}
        public List<string> Quantities {get;set;}
        public List<string> Steps {get;set;}

        public Recipe(string recipename){
            RecipeName = recipename;
            Ingredients = new List<string>();
            Quantities = new List<string>();
            Steps = new List<string>();
        }

        public void AddIngredientQuantity(string ingredient, string quantity){
            Ingredients.Add(ingredient);
            Quantities.Add(quantity);            
        }

        public void AddStep(string step){
            Steps.Add(step);            
        }

    }

}

// public class Substitutions
// {
//     public class Substitution{
//         public string? RefIngredient {get;set;}
//         public string[]? SubIngredient {get;set;}
//     }
// }



public class GroceryList{

    // public Dictionary<string, string> GList {get;set;}
    public Dictionary<string, string> GList = new Dictionary<string, string>();

    public void AddGroceryItem(string item, string quantity){
        if(GList.ContainsKey(item)){
            GList[item] = quantity;
        }else{
            GList.Add(item, quantity);
        }            
    }

    public void RemoveGroceryItem(string item, string quantity){
        if(GList.ContainsKey(item)){
            GList.Remove(item);
        }
    }

    public void ConsolePrintGroceryList(){
        Console.WriteLine();
        foreach(KeyValuePair<string, string> kvp in GList){
            Console.WriteLine("{1}:{0}", kvp.Key, kvp.Value);
        }
        Console.WriteLine();
    }

    public void AddTestItemsGroceryList(){
        AddGroceryItem("pigeon eggs", "baker's dozen");
        AddGroceryItem("free-range mushrooms", "platoon");
        AddGroceryItem("the smelliest of fish", "entire school");            
    }

    // public void JSONSerializeGroceryList(){
    //     string jsonString = JsonSerializer.Serialize(GList);
    //     Console.WriteLine();
    //     Console.WriteLine(jsonString);
    //     Console.WriteLine();        
    // }
    public string JSONSerializeGroceryList(){
        string jsonString = JsonSerializer.Serialize(GList);
        return jsonString;
    }




}










// public class Groceries
// {
//     public class GroceryList{

//         // public Dictionary<string, string> GList {get;set;}
//         public Dictionary<string, string> GList = new Dictionary<string, string>();

//         public void AddGroceryItem(string item, string quantity){
//             if(GList.ContainsKey(item)){
//                 GList[item] = quantity;
//             }else{
//                 GList.Add(item, quantity);
//             }            
//         }

//         public void RemoveGroceryItem(string item, string quantity){
//             if(GList.ContainsKey(item)){
//                 GList.Remove(item);
//             }
//         }

//         public void ConsolePrintGroceryList(){
//             Console.WriteLine();
//             foreach(KeyValuePair<string, string> kvp in GList){
//                 Console.WriteLine("{0}:{1}", kvp.Key, kvp.Value);
//             }
//             Console.WriteLine();
//         }

//         public void AddTestItemsGroceryList(){
//             AddGroceryItem("pigeon eggs", "baker's dozen");
//             AddGroceryItem("free-range mushrooms", "platoon");
//             AddGroceryItem("the smelliest of fish", "entire school");            
//         }





//         // public List<string> GroceryDescriptions {get;set;}
//         // public List<string> GroceryQuantities {get;set;}
//         // public List<bool> GroceryInCart {get;set;}

//         // public GroceryList(){
//         //     GroceryDescriptions = new List<string>();
//         //     GroceryQuantities = new List<string>();
//         //     GroceryInCart = new List<bool>();
//         // }

//         // public void ClearGroceryList(){
//         //     GroceryDescriptions = new List<string>();
//         //     GroceryQuantities = new List<string>();
//         //     GroceryInCart = new List<bool>();
//         // }

//         // public void AddGroceryItem(string description, string quantity){
//         //     GroceryDescription.Add(description);
//         //     GroceryQuantity.Add(quantity);            
//         // }
//     }
// }