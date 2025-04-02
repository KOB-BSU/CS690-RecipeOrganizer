using System.Text.Json;
//https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/how-to

namespace Recipe.Service;

public class Recipes
{
    public class Recipe{
        public string? RecipeName {get;set;}
        public string[]? Ingredients {get;set;}
        public string[]? Quantities {get;set;}
        public string[]? Steps {get;set;}
        
    }

}

public class Substitutions
{
    public class Substitution{
        public string? RefIngredient {get;set;}
        public string[]? SubIngredient {get;set;}
    }

}

public class Groceries
{
    public class GroceryItem{
        public string? GroceryDescription {get;set;}
        public string? GroceryQuantity {get;set;}

        public bool GroceryInCart {get;set;}
        
    }

}