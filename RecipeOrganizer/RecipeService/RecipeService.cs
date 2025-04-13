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
    public void ReadFromJSON(){
        if(File.Exists("recipes.json")){
            string jsonString = File.ReadAllText("recipes.json");
            Console.WriteLine(jsonString);
            var deserializedDict = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, List<string>>>>(jsonString)!;
            if(deserializedDict.Count > 0){
                recipesDict = deserializedDict;
            }
        }
    }
    public void CreateEmptyRecipe(string recipeName){
        recipesDict[recipeName] = new Dictionary<string, List<string>>();
        recipesDict[recipeName]["ingredientsList"] = new List<string>();
        recipesDict[recipeName]["instructionsList"] = new List<string>();
        recipesDict[recipeName]["tagsList"] = new List<string>();
    }

    public void RemoveRecipe(string recipeName){
        if(recipesDict.ContainsKey(recipeName)){
            recipesDict.Remove(recipeName);
            Console.WriteLine("Removed "+recipeName);
        }
        if(recipesDict.Count == 0){
            Console.WriteLine("That was the last recipe.");
        }
        WriteToJSON();
    }

    public void AddIngredientToRecipe(string recipeName, string ingredient){
        if(recipesDict.ContainsKey(recipeName)){
            recipesDict[recipeName]["ingredientsList"].Add(ingredient);
        }else{
            Console.WriteLine(recipeName+" is not a stored recipe.");
        }
        WriteToJSON();
    }

    public void AddInstructionToRecipe(string recipeName, string instruction){
        if(recipesDict.ContainsKey(recipeName)){
            recipesDict[recipeName]["instructionsList"].Add(instruction);
        }else{
            Console.WriteLine(recipeName+" is not a stored recipe.");
        }
        WriteToJSON();
    }
    public void AddTagToRecipe(string recipeName, string tag){
        if(recipesDict.ContainsKey(recipeName)){
            recipesDict[recipeName]["tagsList"].Add(tag);
        }else{
            Console.WriteLine(recipeName+" is not a stored recipe.");
        }
        WriteToJSON();
    }

    public void ConsolePrintRecipe(string recipeName){
        if(recipesDict.ContainsKey(recipeName)){
            Console.WriteLine("-Recipe: "+recipeName);
            Console.WriteLine("-Ingredients:");
            Console.WriteLine(string.Join("\n", recipesDict[recipeName]["ingredientsList"]));
            Console.WriteLine("-Instructions:");
            Console.WriteLine(string.Join("\n", recipesDict[recipeName]["instructionsList"]));
        }else{
            Console.WriteLine(recipeName + " is not a stored recipe.");
        }
    }

    public void ConsolePrintRecipeNames(){
        if(recipesDict.Count > 0){
            Console.WriteLine("-Recipe names:");
            foreach(string recipeName in recipesDict.Keys){
                Console.WriteLine(recipeName);
            }
        }else{
            Console.WriteLine("You have no stored recipes.");
        }
    }

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


