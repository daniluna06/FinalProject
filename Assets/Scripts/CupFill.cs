using UnityEngine;

public class CupFill : MonoBehaviour
{
    // Drag your CupCoffee cylinder here in the Inspector
    public Transform coffeeLiquid;

    // How fast the cup fills (0 to 1 per second)
    public float fillSpeed = 0.5f;

    // 0 = empty, 1 = full
    [Range(0f, 1f)]
    public float fillLevel = 0f;

    private Vector3 fullScale;
    private Vector3 emptyScale;

    public bool IsFull => fillLevel >= 0.999f;

    private void Start()
    {
        if (coffeeLiquid == null)
        {
            Debug.LogWarning("CupFill: coffeeLiquid is not assigned.");
            return;
        }

        // Whatever scale you set in the editor = FULL
        fullScale = coffeeLiquid.localScale;

        // Make "empty" basically flat
        // Use a *very* small Y so it's visually gone
        emptyScale = new Vector3(fullScale.x, 0.0001f, fullScale.z);

        // Start completely empty
        fillLevel = 0f;
        coffeeLiquid.localScale = emptyScale;
    }

    public void AddCoffee(float deltaTime)
    {
        if (coffeeLiquid == null || IsFull) return;

        fillLevel = Mathf.Clamp01(fillLevel + fillSpeed * deltaTime);
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        if (coffeeLiquid == null) return;

        // Lerp from "invisible" to full height
        Vector3 newScale = Vector3.Lerp(emptyScale, fullScale, fillLevel);
        coffeeLiquid.localScale = newScale;
    }
}
