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
    //Needs test
    public void WriteToJSON(){
        string jsonString = JsonSerializer.Serialize(recipesDict);
        File.WriteAllText("recipes.json", jsonString);
    }
    //Needs test
    public void ReadFromJSON(){
        if(File.Exists("recipes.json")){
            string jsonString = File.ReadAllText("recipes.json");
            // Console.WriteLine(jsonString);
            var deserializedDict = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, List<string>>>>(jsonString)!;
            if(deserializedDict.Count > 0){
                recipesDict = deserializedDict;
            }
        }
    }
    //Needs test
    public void CreateEmptyRecipe(string recipeName){
        recipesDict[recipeName] = new Dictionary<string, List<string>>();
        recipesDict[recipeName]["ingredientsList"] = new List<string>();
        recipesDict[recipeName]["instructionsList"] = new List<string>();
        recipesDict[recipeName]["tagsList"] = new List<string>();
    }

    //Needs test
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

    //Needs test
    public void AddIngredientToRecipe(string recipeName, string ingredient){
        if(recipesDict.ContainsKey(recipeName)){
            recipesDict[recipeName]["ingredientsList"].Add(ingredient);
        }else{
            Console.WriteLine(recipeName+" is not a stored recipe.");
        }
        WriteToJSON();
    }

    //Needs test
    public void ClearRecipeIngredients(string recipeName){
        recipesDict[recipeName]["ingredientsList"] = new List<string>();
        WriteToJSON();
    }

    //Needs test
    public void AddInstructionToRecipe(string recipeName, string instruction){
        if(recipesDict.ContainsKey(recipeName)){
            recipesDict[recipeName]["instructionsList"].Add(instruction);
        }else{
            Console.WriteLine(recipeName+" is not a stored recipe.");
        }
        WriteToJSON();
    }

    //Needs test
    public void ClearRecipeInstructions(string recipeName){
        recipesDict[recipeName]["instructionsList"] = new List<string>();
        WriteToJSON();
    }

    //Needs test
    public void AddTagToRecipe(string recipeName, string tag){
        if(recipesDict.ContainsKey(recipeName)){
            recipesDict[recipeName]["tagsList"].Add(tag);
        }else{
            Console.WriteLine(recipeName+" is not a stored recipe.");
        }
        WriteToJSON();
    }

    //Needs test
    public void ClearRecipeTags(string recipeName){
        recipesDict[recipeName]["tagsList"] = new List<string>();
        WriteToJSON();
    }

    //Needs test
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

    //Needs test
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

    //Needs test
    public void FindRecipes(string tag){
        if(recipesDict.Count > 0){
            if(tag.Length == 0){
                var allRecipeNames = new List<string>(recipesDict.Keys);
                allRecipeNames.Sort();
                Console.WriteLine("-All Stored Recipe Names:");
                Console.WriteLine(string.Join("\n", allRecipeNames));
            }else{
                var foundRecipes = new List<string>();
                foreach(string recipeName in recipesDict.Keys){
                    if(recipesDict[recipeName]["tagsList"].Contains(tag)){
                        foundRecipes.Add(recipeName);
                    }
                }
                Console.WriteLine("Recipes tagged as '"+tag+"'");
                Console.WriteLine(string.Join("\n", foundRecipes));                
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

    //Needs test
    public void AddSubstitution(string refI, string subI){
        if(!substitutionsDict.ContainsKey(refI)){
            substitutionsDict[refI] = new List<string>();
        }
        substitutionsDict[refI].Add(subI);
        WriteToJSON();
    }

    //Needs test
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

    //Needs test
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

    //Needs test
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


    //Needs test
    public void WriteToJSON(){
        string jsonString = JsonSerializer.Serialize(substitutionsDict);
        File.WriteAllText("substitutions.json", jsonString);
    }

    //Needs test
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
    //Needs test
    public void AddGrocery(string gItem, string gQuantity){
        groceriesDict[gItem] = gQuantity;
        WriteToJSON();
    }
    //Needs test
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

    //Needs test
    public void ConsolePrintGrocery(string gItem){
        if(groceriesDict.ContainsKey(gItem)){
            string gQuantity = groceriesDict[gItem];
            Console.WriteLine(gItem+" ["+gQuantity+"]");
        }
    }
    
    //Needs test
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

    //Needs test
    public void WriteToJSON(){
        string jsonString = JsonSerializer.Serialize(groceriesDict);
        File.WriteAllText("groceries.json", jsonString);
    }

    //Needs test
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


