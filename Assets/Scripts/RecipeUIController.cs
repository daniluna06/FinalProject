using UnityEngine;

public class RecipeUIController : MonoBehaviour
{
    public GameObject[] recipePanels; // 3D objects representing recipe steps
    private int recipeIndex = 0;

    private void Start()
    {
        recipeIndex = 0;
        ShowRecipe(recipeIndex);
    }

    public void ShowRecipe(int index)
    {
        recipeIndex = Mathf.Clamp(index, 0, recipePanels.Length - 1);

        for (int i = 0; i < recipePanels.Length; i++)
            recipePanels[i].SetActive(i == recipeIndex);
    }

    public void OnIngredientAdded(Recipes.IngredientType ingredient)
    {
        // Advance to next cube
        recipeIndex++;
        recipeIndex = Mathf.Clamp(recipeIndex, 0, recipePanels.Length - 1);
        ShowRecipe(recipeIndex);
    }

    public void OnRecipeCompletedAdvance()
    {
        recipeIndex++;
        recipeIndex = Mathf.Clamp(recipeIndex, 0, recipePanels.Length - 1);
        ShowRecipe(recipeIndex);
    }

    public void ResetRecipe()
    {
        recipeIndex = 0;
        ShowRecipe(recipeIndex);
    }
}
