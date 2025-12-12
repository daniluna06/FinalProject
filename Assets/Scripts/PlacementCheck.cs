using UnityEngine;
using Oculus.Interaction;

public class PlacementCheck : MonoBehaviour
{
    public Transform targetPlace;

    public float solvedDistance = 0.05f;   // Distance to snap/solve
    public float unsolvedDistance = 0.07f; // Distance required to "un-solve"
    
    public bool isSolved;

    private Rigidbody rb;
    private Collider col;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        if (targetPlace == null)
            targetPlace = GameObject.Find("cupPlace").transform;
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, targetPlace.position);

        // ------------------------------------------------------------
        // SOLVE (when cup gets close to placement point)
        // ------------------------------------------------------------
        if (!isSolved && distance < solvedDistance)
        {
            SnapToPlace();
        }

        // ------------------------------------------------------------
        // UNSOLVE (when cup is moved away again)
        // ------------------------------------------------------------
        if (isSolved && distance > unsolvedDistance)
        {
            RestoreCup();
        }
    }

    void SnapToPlace()
    {
        // Release from any grab interactors
        var interactable = GetComponent<GrabInteractable>();
        if (interactable != null)
        {
            foreach (var interactor in interactable.Interactors)
                if (interactor is GrabInteractor gi)
                    gi.Unselect();
        }

        // Move & lock in place
        transform.SetPositionAndRotation(targetPlace.position, targetPlace.rotation);
        rb.constraints = RigidbodyConstraints.FreezeAll;
        col.enabled = false;

        isSolved = true;
        Debug.Log("Cup placed: solved = true");
    }

    void RestoreCup()
    {
        // Allow physics + grabbing again
        rb.constraints = RigidbodyConstraints.None;
        col.enabled = true;
        targetPlace.gameObject.SetActive(true);

        isSolved = false;
        Debug.Log("Cup removed: solved = false");
    }
}
