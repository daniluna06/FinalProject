using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject Recipe;

    void Start()
    {
        Canvas.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Recipe1")
        {
            Recipe.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (other.tag =="Recipe2"){
            Recipe.transform.GetChild(1).gameObject.SetActive(true);      
        }
        else if (other.tag =="Recipe3"){
            Recipe.transform.GetChild(2).gameObject.SetActive(true);      
        }
	else if (other.tag =="Recipe4"){
            Recipe.transform.GetChild(3).gameObject.SetActive(true); 
	}    

        print("entered " + other.gameObject.name);
        Recipe.transform.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        print("leaving " + other.gameObject.name);
        Recipe.transform.gameObject.SetActive(false);
    }
}