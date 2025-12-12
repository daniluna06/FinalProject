using UnityEngine;

public class RecipeUIController : MonoBehaviour
{
    public GameObject canvasRoot;     // your recipe canvas
    public GameObject[] recipePanels; // size 4

    private int recipeIndex = 0;

    private void Start()
    {
        ShowRecipe(0);
    }

    public void ShowRecipe(int index)
    {
        recipeIndex = Mathf.Clamp(index, 0, recipePanels.Length - 1);

        canvasRoot.SetActive(true);
        for (int i = 0; i < recipePanels.Length; i++)
            recipePanels[i].SetActive(i == recipeIndex);
    }

    public void OnIngredientAdded(Recipes.IngredientType ingredient)
    {
        // For now just ensure UI is visible.
        // Later you can update TMP text/icons within the active panel.
        canvasRoot.SetActive(true);
    }

    public void OnRecipeCompletedAdvance()
    {
        ShowRecipe(recipeIndex + 1);
    }
}
