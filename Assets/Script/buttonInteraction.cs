using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class buttonInteraction : MonoBehaviour
{
    [SerializeField] private Image myButton;
    [SerializeField] private Color downColor;
    [SerializeField] private Color defaultColor;


    public GameObject particle;
    public Transform spawnPoint;

    public void SpawnObject()
    {
            
        Instantiate(particle, spawnPoint.position, spawnPoint.rotation); //spawns particles
        
    }
    void Start()
    {
        myButton.color = defaultColor; //sets color to default on start
        downColor.a = 1; //sets alpha, doesnt seem to work without this
    }

    // Update is called once per frame
    void Update()
    {
        //myButton.color = defaultColor;
        if (Input.GetKey(KeyCode.E)) //for testing, replace with VR poke interaction
        {
            myButton.color = downColor; //sets color to new color while pressed
            print("test"); //replace with behavior function
            SpawnObject();
        }

        else{
            myButton.color = defaultColor; //returns button to original color
        }
        
    }

}
