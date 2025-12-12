using UnityEngine;
using System.Collections;

public class CupController : MonoBehaviour
{
    [Header("References")]
    public CupFill cupFill;               // drag your CupFill component
    public RecipeCheck recipeCheck;       // drag your RecipeCheck component
    public RecipeUIController recipeUI;   // drag UI controller (step 4)
    public Renderer coffeeRenderer;       // renderer of the liquid cylinder
    public int liquidMaterialIndex = 0;   // if multiple materials, set correct index

    [Header("Colors")]
    public Color coffeeColor = new Color(0.25f, 0.12f, 0.06f);
    public Color latteColor  = new Color(0.55f, 0.40f, 0.25f);
    public float milkBlendSeconds = 1.0f;

    private Material liquidMat;
    private Coroutine colorRoutine;

    private void Awake()
    {
        if (cupFill == null) cupFill = GetComponent<CupFill>();
        if (recipeCheck == null) recipeCheck = GetComponent<RecipeCheck>();

        if (coffeeRenderer != null)
        {
            // IMPORTANT: use .materials so we get an instance, not shared asset
            var mats = coffeeRenderer.materials;
            if (liquidMaterialIndex >= 0 && liquidMaterialIndex < mats.Length)
                liquidMat = mats[liquidMaterialIndex];
        }
    }

    public void AddCoffee(float dt)
    {
        if (cupFill != null) cupFill.AddCoffee(dt);
    }

    public void RegisterIngredient(Recipes.IngredientType ingredient)
    {
        // Send to recipe logic
        if (recipeCheck != null) recipeCheck.AddIngredient(ingredient);

        // Update UI right away
        if (recipeUI != null) recipeUI.OnIngredientAdded(ingredient);

        // Visual color blending when milk is added
        if (ingredient == Recipes.IngredientType.WholeMilk ||
            ingredient == Recipes.IngredientType.OatMilk ||
            ingredient == Recipes.IngredientType.AlmondMilk)
        {
            BlendToLatte();
        }
    }

    private void BlendToLatte()
    {
        if (liquidMat == null) return;

        if (colorRoutine != null) StopCoroutine(colorRoutine);
        colorRoutine = StartCoroutine(LerpColor(liquidMat.color, latteColor, milkBlendSeconds));
    }

    private IEnumerator LerpColor(Color from, Color to, float seconds)
    {
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / Mathf.Max(0.0001f, seconds);
            liquidMat.color = Color.Lerp(from, to, t);
            yield return null;
        }
        liquidMat.color = to;
    }
}
