using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupManager : MonoBehaviour
{
    public GameObject cupPrefab;
    public Transform spawnPoint;

    private GameObject currentCup;

    private void Start()
    {
    }

    public void SpawnCup()
    {
        if (currentCup == null)
        {
            currentCup = Instantiate(cupPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }

    public void CupDestroyed()
    {
        currentCup = null;
        SpawnCup();
    }
}