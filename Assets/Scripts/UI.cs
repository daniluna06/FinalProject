using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject Recipe;

    void Start()
    {
        Recipe.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Turn off all recipe panels first so only one shows
        for (int i = 0; i < Recipe.transform.childCount; i++)
            Recipe.transform.GetChild(i).gameObject.SetActive(false);

        if (other.tag == "Recipe1") Recipe.transform.GetChild(0).gameObject.SetActive(true);
        else if (other.tag == "Recipe2") Recipe.transform.GetChild(1).gameObject.SetActive(true);
        else if (other.tag == "Recipe3") Recipe.transform.GetChild(2).gameObject.SetActive(true);
        else if (other.tag == "Recipe4") Recipe.transform.GetChild(3).gameObject.SetActive(true);

        Recipe.SetActive(true);
        print("entered " + other.gameObject.name);
    }

    private void OnTriggerExit(Collider other)
    {
        print("leaving " + other.gameObject.name);
        Recipe.SetActive(false);
    }
}
