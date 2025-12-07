using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;
using Oculus.Interaction;
using Oculus.Interaction.Collections;

public class PlacementCheck : MonoBehaviour
{
    public Transform targetPlace;
    public bool isSolved;

    private Rigidbody rigidbody;
    private BoxCollider boxCollider;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, targetPlace.position);

        if (distance < 0.05f && !isSolved)
        {
            IEnumerable<GrabInteractor> setInteractors = transform.GetChild(0).GetComponent<GrabInteractable>().Interactors;
            foreach (GrabInteractor interactor in setInteractors)
            {
                interactor.Unselect();
            }
            transform.SetPositionAndRotation(targetPlace.position, targetPlace.rotation);
            targetPlace.gameObject.SetActive(false);

            rigidbody.constraints = RigidbodyConstraints.FreezeAll;

            boxCollider.enabled = false;
            isSolved = true;
        }
    }
}
