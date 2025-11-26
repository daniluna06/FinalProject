using UnityEngine;

public class Stream : MonoBehaviour
{
    public float maxLength = 2f;
    public LineRenderer lineRenderer;

    // How much sideways wobble (world units)
    public float wobbleAmplitude = 0.02f;

    // How fast it wiggles
    public float wobbleFrequency = 10f;

    private bool pouring = false;

    private void Awake()
    {
        if (lineRenderer == null)
            lineRenderer = GetComponent<LineRenderer>();

        if (lineRenderer != null)
        {
            // We now want 3 points: start, middle, end
            lineRenderer.positionCount = 3;
            lineRenderer.enabled = false;
        }
    }

    public void Begin()
    {
        pouring = true;
        if (lineRenderer != null)
            lineRenderer.enabled = true;
    }

    public void End()
    {
        pouring = false;
        if (lineRenderer != null)
            lineRenderer.enabled = false;

        Destroy(gameObject, 0.1f);
    }

    private void Update()
    {
        if (!pouring || lineRenderer == null) return;

        // Start at the spout
        Vector3 start = transform.position;

        // For now, no collider needed:
        // Just go straight down by maxLength
        Vector3 end = start + Vector3.down * maxLength;

        // Middle point halfway between start and end
        Vector3 middle = (start + end) * 0.5f;

        // Choose a sideways direction to wobble in.
        // transform.right = "sideways" relative to the pot/stream object.
        Vector3 wobbleDir = transform.right;

        // Compute wobble offset using a sine wave over time
        float wobble = Mathf.Sin(Time.time * wobbleFrequency) * wobbleAmplitude;

        // Apply wobble sideways to the middle point
        middle += wobbleDir * wobble;

        // Assign all 3 positions to the LineRenderer
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, middle);
        lineRenderer.SetPosition(2, end);
    }
}
