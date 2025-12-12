using UnityEngine;
using UnityEngine.UI; // Required for UI elements

public class GameManager : MonoBehaviour
{
    public GameObject cef; // Reference to the UI Panel GameObject

    // Start is called before the first frame update
    void Start()
    {
        // Ensure the panel is hidden at the start of the game
        if (cef != null)
        {
            cef.SetActive(false);
        }
    }

    // This method is called to show the completion panel
    public void ShowCompletionPanel()
    {
        if (cef != null)
        {
            cef.SetActive(true); // Makes the panel visible
            // Optional: add code to stop the game time, etc.
            Time.timeScale = 0f; // Pause the game
        }
    }

    // Optional: A method to hide the panel and continue/restart the game
    public void HideCompletionPanel()
    {
        if (cef != null)
        {
            cef.SetActive(false);
            Time.timeScale = 1f; // Resume the game
            // Optional: add code to load the next level or restart
        }
    }
}