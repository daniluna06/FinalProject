using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRButtonAction : MonoBehaviour
{
    public void OnButtonPressed(ParticleSystem part){
        part = GetComponent<ParticleSystem>();
        part.Play();
        Debug.Log("BUTTON PRESSED");
    }
}
