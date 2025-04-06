using System.Text.Json;
//https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/how-to
using System;
using System.Collections.Generic;


namespace Recipe.Service;

public class Recipes
{
    public class Recipe{
        public string? RecipeName {get;set;}
        public List<string>? Ingredients {get;set;}
        public List<string>? Quantities {get;set;}
        public List<string>? Steps {get;set;}

        public Recipe(string recipename){
            RecipeName = recipename;
        }

        // public void AddIngredientQuantity(ingredient, quantity){
            
        // }
    }

    



}

// public class Substitutions
// {
//     public class Substitution{
//         public string? RefIngredient {get;set;}
//         public string[]? SubIngredient {get;set;}
//     }
// }

// public class Groceries
// {
//     public class GroceryItem{
//         public string? GroceryDescription {get;set;}
//         public string? GroceryQuantity {get;set;}
//         public bool GroceryInCart {get;set;}
        
//     }
// }