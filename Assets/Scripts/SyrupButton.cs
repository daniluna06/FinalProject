using UnityEngine;

public class SyrupButton : MonoBehaviour
{
    public SyrupDispenser dispenser;
    public Material syrupMaterial;
    public float pourDuration = 0.5f;

    public void OnPress()
    {
        if (dispenser == null || syrupMaterial == null)
            return;

        dispenser.DispenseOnce(syrupMaterial, pourDuration);
    }

    public void OnToggleChanged(bool isOn)
    {
        if (isOn)
        {
            OnPress();
        }
    }
}
