using UnityEngine;

public class CupState : MonoBehaviour
{
    public bool isComplete = false;   // set true when the drink is finished
    public int completedVersion = 0;  // increments each time a new drink is completed

    public void MarkComplete()
    {
        isComplete = true;
        completedVersion++;
    }

    public void ResetDrink()
    {
        isComplete = false;
    }
}
