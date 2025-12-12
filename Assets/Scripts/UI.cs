using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject Canvas;

    void Start()
    {
        Canvas.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Turn off all recipe panels first so only one shows
        for (int i = 0; i < Canvas.transform.childCount; i++)
            Canvas.transform.GetChild(i).gameObject.SetActive(false);

        if (other.tag == "Recipe1") Canvas.transform.GetChild(0).gameObject.SetActive(true);
        else if (other.tag == "Recipe2") Canvas.transform.GetChild(1).gameObject.SetActive(true);
        else if (other.tag == "Recipe3") Canvas.transform.GetChild(2).gameObject.SetActive(true);
        else if (other.tag == "Recipe4") Canvas.transform.GetChild(3).gameObject.SetActive(true);

        Canvas.SetActive(true);
        print("entered " + other.gameObject.name);
    }

    private void OnTriggerExit(Collider other)
    {
        print("leaving " + other.gameObject.name);
        Canvas.SetActive(false);
    }
}
