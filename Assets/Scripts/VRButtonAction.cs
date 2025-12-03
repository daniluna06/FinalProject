using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRButtonAction : MonoBehaviour
{
    public MilkDispenser dispenser;
    public Material milkMaterial;
    public float pourDuration = 0.5f;
    public void OnButtonPressed()
    {
        if (dispenser == null || milkMaterial == null)
            return;

        dispenser.DispenseOnce(milkMaterial, pourDuration);

        Debug.Log("BUTTON PRESSED");
    }
    public void OnToggleChanged(bool isOn)
    {
        if (isOn)
        {
            OnPress();
        }
    }
}
