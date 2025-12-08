using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourDetector : MonoBehaviour
{
    [Header("Pour Settings")]
    public float pourThreshold = 45f;      // angle in degrees
    public Transform origin;              // where the stream comes out
    public GameObject streamPrefab;       // prefab with a Stream script

    private bool isPouring = false;
    private Stream currentStream = null;

    private void Update()
    {
        float angle = CalculatePourAngle();
        // pour when tilted more than threshold
        bool pourCheck = angle > pourThreshold;

        if (isPouring != pourCheck)
        {
            isPouring = pourCheck;

            if (isPouring)
            {
                StartPour();
            }
            else
            {
                EndPour();
            }
        }
    }

    private void StartPour()
    {
        currentStream = CreateStream();
        if (currentStream != null)
        {
            currentStream.Begin();
        }
    }

    private void EndPour()
    {
        Debug.Log("End Pour");
        if (currentStream != null)
        {
            currentStream.End();
            currentStream = null;
        }
    }

    // Angle between pot's "up" and world down
    private float CalculatePourAngle()
    {
        // -transform.up is the direction the opening of the pot points
        // Vector3.down is world down
        return Vector3.Angle(-transform.up, Vector3.down);
    }

    private Stream CreateStream()
    {
        if (streamPrefab == null || origin == null)
        {
            return null;
        }

        GameObject streamObject = Instantiate(
            streamPrefab,
            origin.position,
            Quaternion.identity,
            transform
        );

        return streamObject.GetComponent<Stream>();
    }
}
