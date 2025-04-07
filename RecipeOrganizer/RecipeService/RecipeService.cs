using System.Text.Json;
using System.Text.Json.Serialization;
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


public class GroceryItem{
    public string? ItemDescription {get;set;}
    public string? ItemQuantity {get;set;}

    public GroceryItem(string description, string quantity){
        [JsonPropertyName("ItemDescription")]
        ItemDescription = description;
        
        [JsonPropertyName("ItemQuantity")]
        ItemQuantity = quantity;
    }

}

public class GroceryList{
    public Dictionary<string, GroceryItem> GDict {get;set;}

    public GroceryList(){
        GDict = new Dictionary<string, GroceryItem>();
    }

    public void AddGroceryItem(string description, string quantity){
        GDict.Add(description, new GroceryItem(description, quantity));
    }


     public void AddTestGroceryItems(){
        AddGroceryItem("pigeon eggs", "baker's dozen");
        AddGroceryItem("free-range mushrooms", "platoon");
        AddGroceryItem("the smelliest of fish", "entire school");
        AddGroceryItem("THE GREATEST BANANA", "THERE CAN ONLY BE ONE");
        AddGroceryItem("less excellent bananas", "a bunch");                
    }

    public void WriteToJSON(){
        string jsonString = JsonSerializer.Serialize<Dictionary<string, GroceryItem>>(GDict);
        File.WriteAllText("groceries.json", jsonString);
    }

    public void ReadFromJSON(){
        string jsonString = File.ReadAllText("groceries.json");
        Console.WriteLine(jsonString);

        var options = new JsonSerializerOptions{IncludeFields = true};

        GDict = JsonSerializer.Deserialize<Dictionary<string, GroceryItem>>(jsonString, options);
    }

    // public void ReadFromJSON(){
    //     string jsonString = File.ReadAllText("groceries.json");
    //     Console.WriteLine(jsonString);
    //     Console.WriteLine();
    //     // GList = JsonSerializer.Deserialize<List<GroceryItem>>(jsonString);
    //     GList = JsonSerializer.Deserialize<List<GroceryItem>>(jsonString);
        
        
    // }



}







// public class Groceries{

//     // public Dictionary<string, string> GroceryList {get;set;}
//     public Dictionary<string, string> GroceryList = new Dictionary<string, string>();

//     public void AddGroceryItem(string item, string quantity){
//         if(GroceryList.ContainsKey(item)){
//             GroceryList[item] = quantity;
//         }else{
//             GroceryList.Add(item, quantity);
//         }            
//     }

//     public void RemoveGroceryItem(string item, string quantity){
//         if(GroceryList.ContainsKey(item)){
//             GroceryList.Remove(item);
//         }
//     }

//     public void ConsolePrintGroceryList(){
//         Console.WriteLine();
//         foreach(KeyValuePair<string, string> kvp in GroceryList){
//             Console.WriteLine("{1}:{0}", kvp.Key, kvp.Value);
//         }
//         Console.WriteLine();
//     }

//     public void AddTestItemsGroceryList(){
//         AddGroceryItem("pigeon eggs", "baker's dozen");
//         AddGroceryItem("free-range mushrooms", "platoon");
//         AddGroceryItem("the smelliest of fish", "entire school");            
//     }

//     // public void JSONSerializeGroceryList(){
//     //     string jsonString = JsonSerializer.Serialize(GroceryList);
//     //     Console.WriteLine();
//     //     Console.WriteLine(jsonString);
//     //     Console.WriteLine();        
//     // }
//     public string JSONSerializeGroceryList(){
//         string jsonString = JsonSerializer.Serialize(GroceryList);
//         return jsonString;
//     }

//     public void WriteGroceryListToJSON(){
//         string jsonString = JSONSerializeGroceryList();
//         File.WriteAllText("groceries.json", jsonString);
//     }

//     public string ReadGroceryListFromJSON(){
//         string jsonString = File.ReadAllText("groceries.json");
//         GroceryList = JsonSerializer.Deserialize<Groceries>(jsonString);
//     }




// }




