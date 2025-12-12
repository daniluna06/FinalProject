using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Completed"))
        {
            if (gameManager != null)
                gameManager.ShowCompletionPanel();
            else
                Debug.LogError("GameManager not found in the scene!");
        }
    }
}
