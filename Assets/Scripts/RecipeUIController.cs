using UnityEngine;

public class RecipeUIController : MonoBehaviour
{
    [Header("3D Cubes for Recipe Steps")]
    public GameObject[] recipePanels; // 3D objects representing recipe steps

    private int recipeIndex = 0;

    private void Awake()
    {
        // Safety check: ensure all cubes in the array are assigned
        if (recipePanels == null || recipePanels.Length == 0)
        {
            Debug.LogError("RecipeUIController: No cubes assigned in recipePanels array!");
            return;
        }

        for (int i = 0; i < recipePanels.Length; i++)
        {
            if (recipePanels[i] == null)
                Debug.LogError($"RecipeUIController: recipePanels[{i}] is not assigned!");
        }
    }

    private void Start()
    {
        // Ensure parent is active
        if (!gameObject.activeInHierarchy)
            gameObject.SetActive(true);

        // Make sure first cube is visible, others hidden
        recipeIndex = 0;
        ShowRecipe(recipeIndex);
    }

    public void ShowRecipe(int index)
    {
        // Clamp index to valid range
        recipeIndex = Mathf.Clamp(index, 0, recipePanels.Length - 1);

        for (int i = 0; i < recipePanels.Length; i++)
        {
            if (recipePanels[i] != null)
            {
                // Activate only the current cube
                recipePanels[i].SetActive(i == recipeIndex);
                Debug.Log($"[RecipeUIController] {recipePanels[i].name} (index {i}) active? {recipePanels[i].activeSelf}");

            }
        }
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