using UnityEngine;

public class PlateRecipeAdvanceTrigger : MonoBehaviour
{
    [Header("Drag your RecipeUIController object here")]
    [SerializeField] private RecipeUIController recipeUI;

    private int lastAcceptedCompletionVersion = -1;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("[PlateRecipeAdvanceTrigger] Hit by: " + other.name + " tag=" + other.tag);

        // Only react to the cup collider
        if (!other.CompareTag("Cup"))
            return;

        // THIS is what "cup" is:
        CupState cup = other.GetComponentInParent<CupState>();
        if (cup == null)
        {
            Debug.Log("[PlateRecipeAdvanceTrigger] No CupState found on this collider or its parents.");
            return;
        }

        // Only advance if the drink is complete
        if (!cup.isComplete)
        {
            Debug.Log("[PlateRecipeAdvanceTrigger] Drink NOT complete yet.");
            return;
        }

        // Only advance once per completed drink
        if (cup.completedVersion == lastAcceptedCompletionVersion)
        {
            Debug.Log("[PlateRecipeAdvanceTrigger] Same completed drink detected again -> not advancing.");
            return;
        }

        lastAcceptedCompletionVersion = cup.completedVersion;
        Debug.Log("[PlateRecipeAdvanceTrigger] Completed drink accepted -> advancing recipe!");
        recipeUI.OnRecipeCompletedAdvance();

        // Optional: prevent re-submitting without re-making the drink
        cup.ResetDrink();
    }
}
