using UnityEngine;

public class PlateRecipeAdvanceTrigger : MonoBehaviour
{
    [Header("Drag your RecipeUIController object here")]
    [SerializeField] private RecipeUIController recipeUI;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("[PlateRecipeAdvanceTrigger] Hit by: " + other.name + " tag=" + other.tag);

        if (other.CompareTag("Cup"))
        {
            Debug.Log("[PlateRecipeAdvanceTrigger] Cup detected -> advance recipe");
            recipeUI.OnRecipeCompletedAdvance();
        }
    }
}
