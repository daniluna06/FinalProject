using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Completed"))
        {
            FindObjectOfType<GameManager>().ShowCompletionPanel();
        }
    }
}