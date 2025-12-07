using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCup : MonoBehaviour
{
    private bool hasBeenDestroyed = false;
    private void OnTriggerEnter(Collider other)
    {
        if (hasBeenDestroyed) return;
        hasBeenDestroyed = true;

        CupManager manager = FindObjectOfType<CupManager>();
        manager.CupDestroyed();

        Destroy(gameObject);
        Debug.Log("Cup Destroyed");
    }
}