using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;

namespace Recipe.Service;
//Recipe.Service contains classes for recipes, ingredient substitutions, and the grocery list
//These three classes share common functions for WriteToJSON and ReadFromJSON but they're individually pathed and customized to the corresponding data structure.
//All data used by each class is stored in a single dictionary (though they're structured differently), and is read/written from/to a unique, hard-pathed JSON file.
//This approach requires careful serialization/deserialization, but that's handled by the WriteToJSON and ReadFromJSON functions, respectively.

public class Recipes{
    public Dictionary<string, Dictionary<string, List<string>>> recipesDict;
    public Recipes(){
        recipesDict = new Dictionary<string, Dictionary<string, List<string>>>();
    }
    //Stores the recipesDict in recipes.json
    public void WriteToJSON(){
        string jsonString = JsonSerializer.Serialize(recipesDict);
        File.WriteAllText("recipes.json", jsonString);
    }
    //Reads the recipesDict from recipes.json
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
    //Creates the entry in recipesDict for a new recipe (recipeName), with empty lists for ingredients, instructions, and tags
    public void CreateEmptyRecipe(string recipeName){
        recipesDict[recipeName] = new Dictionary<string, List<string>>();
        recipesDict[recipeName]["ingredientsList"] = new List<string>();
        recipesDict[recipeName]["instructionsList"] = new List<string>();
        recipesDict[recipeName]["tagsList"] = new List<string>();
    }
    //Purges a recipe from the recipesDict if there's an entry matching recipeName
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
    //Appends an ingredient line to the ingredientsList list in recipesDict[recipeName]
    public void AddIngredientToRecipe(string recipeName, string ingredient){
        if(recipesDict.ContainsKey(recipeName)){
            recipesDict[recipeName]["ingredientsList"].Add(ingredient);
        }else{
            Console.WriteLine(recipeName+" is not a stored recipe.");
        }
        WriteToJSON();
    }
    //Empties the contents of the ingredientsList in recipesDict[recipeName]
    public void ClearRecipeIngredients(string recipeName){
        recipesDict[recipeName]["ingredientsList"] = new List<string>();
        WriteToJSON();
    }
    //Appends an instruction line to the instructionsList list in recipesDict[recipeName]
    public void AddInstructionToRecipe(string recipeName, string instruction){
        if(recipesDict.ContainsKey(recipeName)){
            recipesDict[recipeName]["instructionsList"].Add(instruction);
        }else{
            Console.WriteLine(recipeName+" is not a stored recipe.");
        }
        WriteToJSON();
    }
    //Empties the contents of the instructionsList in recipesDict[recipeName]
    public void ClearRecipeInstructions(string recipeName){
        recipesDict[recipeName]["instructionsList"] = new List<string>();
        WriteToJSON();
    }
    //Appends a tag to the tagssList list in recipesDict[recipeName]
    public void AddTagToRecipe(string recipeName, string tag){
        if(recipesDict.ContainsKey(recipeName)){
            recipesDict[recipeName]["tagsList"].Add(tag);
        }else{
            Console.WriteLine(recipeName+" is not a stored recipe.");
        }
        WriteToJSON();
    }
    //Empties the contents of the tagsList in recipesDict[recipeName]
    public void ClearRecipeTags(string recipeName){
        recipesDict[recipeName]["tagsList"] = new List<string>();
        WriteToJSON();
    }
    //Prints the entirety of a single recipe (recipeName) to the console assuming it exists in recipesDict
    public void ConsolePrintRecipe(string recipeName){
        if(recipesDict.ContainsKey(recipeName)){
            Console.WriteLine("-Recipe: "+recipeName);
            Console.WriteLine("-Ingredients:");
            Console.WriteLine(string.Join("\n", recipesDict[recipeName]["ingredientsList"]));
            Console.WriteLine("-Instructions:");
            Console.WriteLine(string.Join("\n", recipesDict[recipeName]["instructionsList"]));
            Console.WriteLine("-Tags:");
            Console.WriteLine(string.Join(",", recipesDict[recipeName]["tagsList"]));
        }else{
            Console.WriteLine(recipeName + " is not a stored recipe.");
        }
    }
    //Prints the names of all recipes to the console assuming recipesDict is non-empty
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
    //This method does double duty and can either print everything matching a specified tag (tag) or,
    // if given an empty string value for tag, prints a sorted list of recipe names to the console.
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
    //Adds a reference ingredient (refI) to substitutionsDict and appends a substitution ingredient (subI)
    //to the corresponding list.
    public void AddSubstitution(string refI, string subI){
        if(!substitutionsDict.ContainsKey(refI)){
            substitutionsDict[refI] = new List<string>();
        }
        substitutionsDict[refI].Add(subI);
        WriteToJSON();
    }
    //Deletes a reference ingredient (refI) from substitutionsDict and its substitution ingredient list.
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
    //Prints all stored substitutions to the console
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
    //Prints a single reference ingredient (refI) and its corresponding substitution ingredients list to the console
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
    //Writes substitutionsDict to substitutions.json after serialization
    public void WriteToJSON(){
        string jsonString = JsonSerializer.Serialize(substitutionsDict);
        File.WriteAllText("substitutions.json", jsonString);
    }
    //Rebuilds substitutionsDict from the deserialized contents of substitutions.json
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


