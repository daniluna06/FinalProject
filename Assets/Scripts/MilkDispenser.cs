using UnityEngine;

public class MilkDispenser : MonoBehaviour
{
    [Header("Stream Setup")]
    [SerializeField] private Stream milkStreamPrefab;   // (or MilkStream if you made that class)
    [SerializeField] private Transform spawnPoint;      // where the milk comes out

    [Header("Audio")]
    [SerializeField] private AudioSource pourAudio;

    private Stream activeStream;

    public void StartPour()
    {
        Debug.Log("[MilkDispenser] StartPour() called");

        if (activeStream != null)
        {
            Debug.Log("[MilkDispenser] Already pouring, ignore.");
            return;
        }

        if (milkStreamPrefab == null)
        {
            Debug.LogError("[MilkDispenser] milkStreamPrefab is NULL!");
            return;
        }

        if (spawnPoint == null)
        {
            Debug.LogError("[MilkDispenser] spawnPoint is NULL!");
            return;
        }

        // Spawn a new stream at the spout
        activeStream = Instantiate(milkStreamPrefab, spawnPoint.position, spawnPoint.rotation);
        Debug.Log("[MilkDispenser] Instantiated stream: " + activeStream.name);

        activeStream.Begin();
        Debug.Log("[MilkDispenser] Called Begin() on stream.");

        if (pourAudio != null && !pourAudio.isPlaying)
        {
            pourAudio.Play();
            Debug.Log("[MilkDispenser] Playing pour audio.");
        }
    }

    public void StopPour()
    {
        Debug.Log("[MilkDispenser] StopPour() called");

        if (activeStream != null)
        {
            activeStream.End();  // this already disables the LineRenderer & destroys itself
            Debug.Log("[MilkDispenser] End() called on stream, clearing reference.");
            activeStream = null;
        }

        if (pourAudio != null && pourAudio.isPlaying)
        {
            pourAudio.Stop();
            Debug.Log("[MilkDispenser] Stopping pour audio.");
        }
    }
}
