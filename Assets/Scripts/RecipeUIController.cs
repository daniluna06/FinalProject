using UnityEngine;

public class RecipeUIController : MonoBehaviour
{
    public GameObject[] recipePanels; // 3D objects
    private int recipeIndex = 0;

    private void Start()
    {
        ShowRecipe(0);
    }

    public void ShowRecipe(int index)
    {
        recipeIndex = Mathf.Clamp(index, 0, recipePanels.Length - 1);

        for (int i = 0; i < recipePanels.Length; i++)
            recipePanels[i].SetActive(i == recipeIndex);
    }

    public void OnIngredientAdded(Recipes.IngredientType ingredient)
    {
        ShowRecipe(recipeIndex); 
    }

    public void OnRecipeCompletedAdvance()
    {
        ShowRecipe(recipeIndex + 1);
    }
}
