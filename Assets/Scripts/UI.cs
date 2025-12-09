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
        if(other.tag == "Recipe1")
        {
            Canvas.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (other.tag =="Recipe2"){
            Canvas.transform.GetChild(1).gameObject.SetActive(true);      
        }
        else if (other.tag =="Recipe3"){
            Canvas.transform.GetChild(2).gameObject.SetActive(true);      
        }
	else if (other.tag =="Recipe4"){
            Canvas.transform.GetChild(3).gameObject.SetActive(true); 
	}    

        print("entered " + other.gameObject.name);
        Canvas.transform.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        print("leaving " + other.gameObject.name);
        Canvas.transform.gameObject.SetActive(false);
    }
}