using UnityEngine;

public class ProximityDetector : MonoBehaviour
{
    public GameObject popUpPanel;
    public string playerTag = "Player";

    [Header("Behavior")]
    public bool hideOnStart = false;

    private void Start()
    {
        if (popUpPanel != null && hideOnStart)
            popUpPanel.SetActive(false);

        Debug.Log("[ProximityDetector] Start. Panel assigned? " + (popUpPanel != null));
    }

    private bool IsPlayer(Collider other)
    {
        if (other.CompareTag(playerTag)) return true;
        if (other.attachedRigidbody && other.attachedRigidbody.CompareTag(playerTag)) return true;
        if (other.transform.root && other.transform.root.CompareTag(playerTag)) return true;
        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("[ProximityDetector] Enter by: " + other.name + " (tag: " + other.tag + ")");
        if (IsPlayer(other) && popUpPanel != null)
        {
            popUpPanel.SetActive(true);
            Debug.Log("[ProximityDetector] Panel shown.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("[ProximityDetector] Exit by: " + other.name + " (tag: " + other.tag + ")");
        if (IsPlayer(other) && popUpPanel != null)
        {
            popUpPanel.SetActive(false);
            Debug.Log("[ProximityDetector] Panel hidden.");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (IsPlayer(other) && popUpPanel != null && !popUpPanel.activeSelf)
            popUpPanel.SetActive(true);
    }



}
