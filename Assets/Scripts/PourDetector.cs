using UnityEngine;

public class PourDetector : MonoBehaviour
{
    [Header("Pour Settings")]
    public float pourThreshold = 45f;
    public Transform origin;
    public GameObject streamPrefab;

    [Header("Targeting")]
    public float cupDetectDistance = 0.6f;     // adjust
    public LayerMask cupLayerMask;             // set to Cup layer (recommended)

    private bool isPouring = false;
    private Stream currentStream = null;

    private CupController currentCup = null;   // NEW
    private bool registeredThisPour = false;   // NEW

    private void Update()
    {
        float angle = CalculatePourAngle();
        bool pourCheck = angle > pourThreshold;

        if (isPouring != pourCheck)
        {
            isPouring = pourCheck;

            if (isPouring) StartPour();
            else EndPour();
        }

        // While pouring, fill cup if we have one
        if (isPouring && currentCup != null)
        {
            currentCup.AddCoffee(Time.deltaTime);
        }
    }

    private void StartPour()
    {
        registeredThisPour = false;
        currentCup = FindCupUnderOrigin();

        // Register coffee ONCE when pour starts (if cup is present)
        if (currentCup != null && !registeredThisPour)
        {
            registeredThisPour = true;
            currentCup.RegisterIngredient(Recipes.IngredientType.Coffee);
        }

        currentStream = CreateStream();
        if (currentStream != null) currentStream.Begin();
    }

    private void EndPour()
    {
        if (currentStream != null)
        {
            currentStream.End();
            currentStream = null;
        }

        currentCup = null;
        registeredThisPour = false;
    }

    private CupController FindCupUnderOrigin()
    {
        if (origin == null) return null;

        if (Physics.Raycast(origin.position, Vector3.down, out RaycastHit hit, cupDetectDistance, cupLayerMask))
        {
            return hit.collider.GetComponentInParent<CupController>();
        }
        return null;
    }

    private float CalculatePourAngle()
    {
        return Vector3.Angle(-transform.up, Vector3.down);
    }

    private Stream CreateStream()
    {
        if (streamPrefab == null || origin == null) return null;

        GameObject streamObject = Instantiate(streamPrefab, origin.position, Quaternion.identity, transform);
        return streamObject.GetComponent<Stream>();
    }
}
