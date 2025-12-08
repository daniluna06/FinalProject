using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; // Required for SequenceEqual

public class RecipeCheck : MonoBehaviour
{
    [Header("Status")]
    public string currentRecipe = "Making...";
    
    // We use a List because we need to add/remove items dynamically
    public List<Recipes.IngredientType> runningIngredients = new List<Recipes.IngredientType>();

    [Header("Configuration")]
    // Drag your "Recipe 4" (and all other recipe assets) into this list in the Inspector
    public List<Recipes> knownRecipes; 

    void Update()
    {
        // --- TESTING INPUTS ---
        // Press keys to simulate pouring ingredients
        if (Input.GetKeyDown(KeyCode.Z)) AddIngredient(Recipes.IngredientType.Coffee);
        if (Input.GetKeyDown(KeyCode.X)) AddIngredient(Recipes.IngredientType.WholeMilk);
        if (Input.GetKeyDown(KeyCode.C)) AddIngredient(Recipes.IngredientType.VanillaSyrup);
        if (Input.GetKeyDown(KeyCode.V)) AddIngredient(Recipes.IngredientType.CaramelSyrup);
        
        // Press Space to dump the cup
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            runningIngredients.Clear();
            currentRecipe = "Empty";
            Debug.Log("Cup emptied.");
        }
    }

    // Call this function when liquid hits the cup (or via key press)
    public void AddIngredient(Recipes.IngredientType ingredient)
    {
        runningIngredients.Add(ingredient);
        Debug.Log($"Added {ingredient}. Total layers: {runningIngredients.Count}");
        
        CheckForMatch();
    }

    void CheckForMatch()
    {
        bool foundMatch = false;

        foreach (Recipes recipe in knownRecipes)
        {
            // STRICT ORDER CHECK
            // Checks if the lists have the same count AND the same items in the same order
            if (runningIngredients.Count == recipe.requiredIngredients.Count &&
                runningIngredients.SequenceEqual(recipe.requiredIngredients))
            {
                currentRecipe = recipe.recipeName;
                Debug.Log($"<color=green>RECIPE COMPLETE: {currentRecipe}</color>");
                foundMatch = true;
                break; // Stop looking, we found it
            }
        }

        if (!foundMatch)
        {
            currentRecipe = "No Match Yet";
        }
    }
}