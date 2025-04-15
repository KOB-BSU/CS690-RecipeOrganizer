using System.Reflection.Metadata.Ecma335;

namespace RecipeOrganizer.Tests;

using Recipe.Service;
public class RecipeServiceTests
{
    Recipe.Service.Substitutions substitutions = new Substitutions();
    Recipe.Service.Groceries groceries = new Groceries();
    Recipe.Service.Recipes recipes = new Recipes();

    [Fact]
    public void SubstitutionsTests(){
        substitutions.AddSubstitution("testRefIngredient", "testSubstituteIngredient");
        substitutions.ConsolePrintSubstititions("testRefIngredient");
        substitutions.DeleteSubstitution("testRefIngredient");
        substitutions.ConsolePrintSubstititions("testRefIngredient");
        substitutions.WriteToJSON();
        substitutions.ReadFromJSON();
        substitutions.ConsolePrintAllSubstititions();
        //If this point is reached without an exception, the test is considered passed.
        //For additional details, see: https://xunit.net/docs/comparisons#note5
        //These methods are all voids, so the assertion being tested is the absence of an exception    
    }

    [Fact]
    public void GroceriesTests(){
        groceries.AddGrocery("testRefIngredient", "testRefQuantity");
        groceries.ConsolePrintGrocery("testRefIngredient");
        groceries.RemoveGrocery("testRefIngredient");
        groceries.ConsolePrintGrocery("testRefIngredient");
        groceries.WriteToJSON();
        groceries.ReadFromJSON();
        groceries.ConsolePrintAllGroceries();
        //If this point is reached without an exception, the test is considered passed.
        //For additional details, see: https://xunit.net/docs/comparisons#note5  
        //These methods are all voids, so the assertion being tested is the absence of an exception            
    }

    [Fact]
    public void RecipesTests(){
        recipes.CreateEmptyRecipe("testRefRecipeName");
        
        recipes.AddIngredientToRecipe("testRefRecipeName", "testRefIngredient1");
        recipes.ClearRecipeIngredients("testRefRecipeName");
        recipes.AddIngredientToRecipe("testRefRecipeName", "testRefIngredient1");
        recipes.AddIngredientToRecipe("testRefRecipeName", "testRefIngredient2");
        
        recipes.AddInstructionToRecipe("testRefRecipeName", "testRefInstruction1");
        recipes.ClearRecipeInstructions("testRefRecipeName");
        recipes.AddInstructionToRecipe("testRefRecipeName", "testRefInstruction1");
        recipes.AddInstructionToRecipe("testRefRecipeName", "testRefInstruction2");
        
        recipes.AddTagToRecipe("testRefRecipeName", "testRefTag1");
        recipes.ClearRecipeTags("testRefRecipeName");
        recipes.AddTagToRecipe("testRefRecipeName", "testRefTag1");
        recipes.AddTagToRecipe("testRefRecipeName", "testRefTag2");
        
        recipes.ConsolePrintRecipe("testRefRecipeName");
        
        recipes.FindRecipes("testRefTag1");
        recipes.FindRecipes("");
        recipes.ConsolePrintRecipeNames();

        recipes.RemoveRecipe("testRefRecipeName");
        recipes.WriteToJSON();
        recipes.ReadFromJSON();
        //If this point is reached without an exception, the test is considered passed.
        //For additional details, see: https://xunit.net/docs/comparisons#note5  
        //These methods are all voids, so the assertion being tested is the absence of an exception    
    }
}