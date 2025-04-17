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
        Recipe.Service.Recipes recipes = new Recipes();
        substitutions.ReadFromJSON();
        groceries.ReadFromJSON();
        recipes.ReadFromJSON();


        bool exitApp = false;
        
        while (!exitApp){
            Console.Clear();
            Console.WriteLine(" [key] - Mode");            
            Console.WriteLine("-Ingredient Substitutions");
            Console.WriteLine(" [1] - View Substitutions");
            Console.WriteLine(" [2] - Add Substitutions");
            Console.WriteLine(" [3] - Remove Substitutions");            
            Console.WriteLine("-Grocery List");
            Console.WriteLine(" [4] - View Grocery List");
            Console.WriteLine(" [5] - Add Grocery List Item");
            Console.WriteLine(" [6] - Remove Grocery List Item");
            Console.WriteLine("-Recipes");
            Console.WriteLine(" [7] - Find Recipes");
            Console.WriteLine(" [8] - View Recipe");
            Console.WriteLine(" [9] - Add/Edit Recipe");
            Console.WriteLine(" [0] - Remove Recipe");
            Console.WriteLine("-Exit Program");            
            Console.WriteLine(" [X] - Exit");
            Console.WriteLine();
            Console.WriteLine("(Type the key for your selected mode, then the enter key.)");
            
            var modeVar = Console.ReadLine()!;
            var subModeVar = "";
            var garbageVar = ""!;

            Console.Clear();
            switch(modeVar.ToUpper()){
                case "1":
                    Console.Clear();
                    substitutions.ConsolePrintAllSubstititions();
                    Console.WriteLine("Press enter to continue.");
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
                    Console.WriteLine("Press enter to continue.");
                    garbageVar = Console.ReadLine();
                    break;

                case "3":
                    Console.Clear();
                    Console.WriteLine("Enter ingredient (being substituted) to remove");
                    var ingredientSubstitutionToRemove = Console.ReadLine()!;
                    substitutions.DeleteSubstitution(ingredientSubstitutionToRemove);
                    Console.WriteLine("Press enter to continue.");
                    garbageVar = Console.ReadLine();
                    break;

                case "4":
                    Console.Clear();
                    groceries.ConsolePrintAllGroceries();
                    Console.WriteLine("Press enter to continue.");
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
                    Console.WriteLine("Press enter to continue.");
                    garbageVar = Console.ReadLine();
                    break;

                case "6":
                    Console.Clear();
                    Console.WriteLine("Enter grocery item to remove");
                    var groceryItemToRemove = Console.ReadLine()!;
                    groceries.RemoveGrocery(groceryItemToRemove);
                    Console.WriteLine("Press enter to continue.");
                    garbageVar = Console.ReadLine();
                    break;

                case "7":
                    Console.Clear();
                    Console.WriteLine("Input a tag to search and hit 'enter' or press 'enter' to view all recipe names.");
                    var searchTag = Console.ReadLine()!;
                    recipes.FindRecipes(searchTag);
                    Console.WriteLine("Press enter to continue.");
                    garbageVar = Console.ReadLine();
                    break;

                case "8":
                    Console.Clear();
                    Console.WriteLine("Enter a recipe name:");
                    var lookupRecipeName = Console.ReadLine()!;
                    recipes.ConsolePrintRecipe(lookupRecipeName);
                    Console.WriteLine("Press enter to continue.");
                    garbageVar = Console.ReadLine();
                    break;

                case "9":
                    Console.Clear();
                    Console.WriteLine("Enter recipe name (new or previously stored):");
                    var addEditRecipeName = Console.ReadLine()!;
                    if(recipes.recipesDict.ContainsKey(addEditRecipeName)){
                        Console.Clear();
                        Console.WriteLine("(Editing "+addEditRecipeName+")");
                        Console.WriteLine("[key] - Recipe Edit Option");
                        Console.WriteLine(" [1] - Re-enter Ingredients");
                        Console.WriteLine(" [2] - Re-enter Instructions");
                        Console.WriteLine(" [3] - Re-enter Tags");
                        Console.WriteLine(" [X] - Cancel");
                        Console.WriteLine();
                        Console.WriteLine("(Type the key for your selected edit, then the enter key.)");
                        subModeVar = Console.ReadLine()!;
                        Console.Clear();
                        switch(subModeVar.ToUpper()){
                            case "1":
                                Console.Clear();
                                bool allIngredientsEntered = false;
                                Console.WriteLine("Type in your recipe ingredients and hit 'enter'. Hit 'enter' again when all ingredients are entered.");
                                Console.WriteLine("(Recommended format is quantity then ingredient.)");
                                recipes.ClearRecipeIngredients(addEditRecipeName);
                                while(!allIngredientsEntered){
                                    var enteredIngredient = Console.ReadLine()!;
                                    if(enteredIngredient.Length == 0){
                                        allIngredientsEntered = true;
                                    }else{
                                        recipes.AddIngredientToRecipe(addEditRecipeName, enteredIngredient);
                                    }
                                }
                                break;

                            case "2":
                                Console.Clear();
                                bool allInstructionsEntered = false;
                                Console.WriteLine("Re-enter your recipe instructions and hit 'enter'. Hit 'enter' again when all instructions are entered.");
                                recipes.ClearRecipeInstructions(addEditRecipeName);
                                while(!allInstructionsEntered){
                                    var enteredInstruction = Console.ReadLine()!;
                                    if(enteredInstruction.Length == 0){
                                        allInstructionsEntered = true;
                                    }else{
                                        recipes.AddInstructionToRecipe(addEditRecipeName, enteredInstruction);
                                    }
                                }
                                break;

                            case "3":
                                Console.Clear();
                                bool allTagsEntered = false;
                                Console.WriteLine("Re-enter your recipe tags and hit 'enter'. Hit 'enter' again when all tags are entered.");
                                recipes.ClearRecipeTags(addEditRecipeName);
                                while(!allTagsEntered){
                                    var enteredTag = Console.ReadLine()!;
                                    if(enteredTag.Length == 0){
                                        allTagsEntered = true;
                                    }
                                    else{
                                        recipes.AddTagToRecipe(addEditRecipeName, enteredTag);
                                    }
                                }
                                break;

                            

                        }

                        
                    }else{
                        Console.Clear();
                        Console.WriteLine("Adding "+addEditRecipeName+" as new reicpe.");
                        recipes.CreateEmptyRecipe(addEditRecipeName);
                        bool allIngredientsEntered = false;
                        Console.WriteLine("Type in your recipe ingredients and hit 'enter'. Hit 'enter' again when all ingredients are entered.");
                        Console.WriteLine("(Recommended format is quantity then ingredient.)");                        
                        while(!allIngredientsEntered){
                            var enteredIngredient = Console.ReadLine()!;
                            if(enteredIngredient.Length == 0){
                                allIngredientsEntered = true;
                            }else{
                                recipes.AddIngredientToRecipe(addEditRecipeName, enteredIngredient);
                            }
                        }
                        bool allInstructionsEntered = false;
                        Console.WriteLine("Type in your recipe instructions and hit 'enter'. Hit 'enter' again when all instructions are entered.");
                        while(!allInstructionsEntered){
                            var enteredInstruction = Console.ReadLine()!;
                            if(enteredInstruction.Length == 0){
                                allInstructionsEntered = true;
                            }else{
                                recipes.AddInstructionToRecipe(addEditRecipeName, enteredInstruction);
                            }
                        }
                        bool allTagsEntered = false;
                        Console.WriteLine("Type in your recipe tags and hit 'enter'. Hit 'enter' again when all tags are entered.");
                        while(!allTagsEntered){
                            var enteredTag = Console.ReadLine()!;
                            if(enteredTag.Length == 0){
                                allTagsEntered = true;
                            }
                            else{
                                recipes.AddTagToRecipe(addEditRecipeName, enteredTag);
                            }
                        }
                        Console.WriteLine(addEditRecipeName+" has been stored in recipes.");
                    }
                    subModeVar = "";                    
                    Console.WriteLine("Press enter to continue.");
                    garbageVar = Console.ReadLine();
                    break;
                case "0":
                    Console.Clear();
                    Console.WriteLine("Enter name of recipe to remove");
                    var recipeToRemove = Console.ReadLine()!;
                    recipes.RemoveRecipe(recipeToRemove);
                    Console.WriteLine("Press enter to continue.");
                    garbageVar = Console.ReadLine();
                    break;

                case "X":
                    Console.Clear();
                    exitApp = true;
                    break;                    
            }         
        }
        Console.WriteLine("Goodbye. (Your patience is appreciated.)");
    }

}
