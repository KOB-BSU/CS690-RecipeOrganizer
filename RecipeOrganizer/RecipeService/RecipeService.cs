using System.Text.Json;
using System.Text.Json.Serialization;
//https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/how-to
using System;
using System.Collections.Generic;
using System.IO;


namespace Recipe.Service;

public class Recipes{
    public Dictionary<string, Dictionary<string, List<string>>> recipesDict;
    public Recipes(){
        recipesDict = new Dictionary<string, Dictionary<string, List<string>>>();
    }

    public void WriteToJSON(){
        string jsonString = JsonSerializer.Serialize(recipesDict);
        File.WriteAllText("recipes.json", jsonString);
    }

    public void AddRecipe(){
        // Console.Clear();
        Console.WriteLine("Enter new recipe name:");
        string newRecipeName = Console.ReadLine()!;
        // if(newRecipeName != ""){
        //     recipesDict[newRecipeName] = new Dictionary<string, List<string>>();
        //     recipesDict[newRecipeName]["ingredients"] = new List<string>();
        //     recipesDict[newRecipeName]["steps"] = new List<string>();
        //     recipesDict[newRecipeName]["tags"] = new List<string>();            
        // }
    }

    // public List<string> RecipeIngredientEntry(){
    //     Console.Clear();
    //     Console.WriteLine("Enter quantities and ingredients one line at a time.");
    //     Console.WriteLine("(Press 'enter' on an empty line to finish.)");
    //     bool lastEntry = false;
    //     List<string> ingredientList = new List<string>();
    //     string ingredientLine = "";
    //     while(!lastEntry){
    //         ingredientLine = Console.ReadLine();
    //         if(ingredientLine == ""){
    //             lastEntry = true;
    //         }else{
    //             ingredientList.Add(ingredientLine);
    //         }
    //     }
    //     return(ingredientList);        
    // }
     
    
}


public class Substitutions{

    public Dictionary<string, List<string>> substitutionsDict;

    public Substitutions(){
        substitutionsDict = new Dictionary<string, List<string>>();
    }

    public void AddSubstitution(string refI, string subI){
        if(!substitutionsDict.ContainsKey(refI)){
            substitutionsDict[refI] = new List<string>();
        }
        substitutionsDict[refI].Add(subI);
        WriteToJSON();
    }

    public void DeleteSubstitution(string refI){
        if(substitutionsDict.ContainsKey(refI)){
            substitutionsDict.Remove(refI);
            Console.WriteLine("Removed "+refI);
        }
        if(substitutionsDict.Count == 0){
            Console.WriteLine("That was the final substitutable ingredient. Your list is now empty.");
        }
        WriteToJSON();
    }

    public void ConsolePrintAllSubstititions(){
        if(substitutionsDict.Count > 0){
            foreach(string refI in substitutionsDict.Keys){
                ConsolePrintSubstititions(refI);
                Console.WriteLine();
            }
        }else{
            Console.WriteLine("There are no stored substitutions.");
        }
    }

    public void ConsolePrintSubstititions(string refI){
        if(substitutionsDict.ContainsKey(refI)){
            Console.WriteLine("Substitutions for "+refI+":");
            foreach(string subI in substitutionsDict[refI]){
                Console.WriteLine(subI);
            }
        }else{
            Console.WriteLine(refI+" does not have any stored substitutes.");
        }
    }


    public void WriteToJSON(){
        string jsonString = JsonSerializer.Serialize(substitutionsDict);
        File.WriteAllText("substitutions.json", jsonString);
    }

    public void ReadFromJSON(){
        if(File.Exists("substitutions.json")){
            string jsonString = File.ReadAllText("substitutions.json");
            // Console.WriteLine(jsonString);
            var deserializedDict = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(jsonString)!;
            if(deserializedDict.Count > 0){
                substitutionsDict = deserializedDict;
            }
        }
    }
}


public class Groceries{
    public Dictionary<string, string> groceriesDict;
    public Groceries(){
        groceriesDict = new Dictionary<string, string>();
    }
    public void AddGrocery(string gItem, string gQuantity){
        groceriesDict[gItem] = gQuantity;
        WriteToJSON();
    }
    public void RemoveGrocery(string gItem){
        if(groceriesDict.ContainsKey(gItem)){
            groceriesDict.Remove(gItem);
            Console.WriteLine("Removed "+gItem);
        }
        if(groceriesDict.Count == 0){
            Console.WriteLine("That was the final grocery item. Your list is now empty.");
        }
        WriteToJSON();
    }

    public void ConsolePrintGrocery(string gItem){
        if(groceriesDict.ContainsKey(gItem)){
            string gQuantity = groceriesDict[gItem];
            Console.WriteLine(gItem+" ["+gQuantity+"]");
        }
    }
    
    public void ConsolePrintAllGroceries(){
        if(groceriesDict.Count > 0){
            Console.WriteLine("Grocery List (Item [quantity])");
            foreach(string gItem in groceriesDict.Keys){
                ConsolePrintGrocery(gItem);
            }
        }else{
            Console.WriteLine("There are no groceries on your list.");
        }
    }

    public void WriteToJSON(){
        string jsonString = JsonSerializer.Serialize(groceriesDict);
        File.WriteAllText("groceries.json", jsonString);
    }

    public void ReadFromJSON(){
        if(File.Exists("groceries.json")){
            string jsonString = File.ReadAllText("groceries.json");
            // Console.WriteLine(jsonString);
            var deserializedDict = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonString)!;
            if(deserializedDict.Count > 0){
                groceriesDict = deserializedDict;
            }
        }
    }

}


