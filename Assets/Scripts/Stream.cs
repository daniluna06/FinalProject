using UnityEngine;

public class Stream : MonoBehaviour
{
    public float maxLength = 2f;
    public LineRenderer lineRenderer;

    // How much sideways wobble (world units)
    public float wobbleAmplitude = 0.02f;

    // How fast it wiggles
    public float wobbleFrequency = 10f;
	
	// How fast the cup fills when hit by this stream
	public float fillRate = 0.25f;
	
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

        // Raycast straight down to find where the stream hits
        RaycastHit hit;
        Vector3 end = start + Vector3.down * maxLength;

        if (Physics.Raycast(start, Vector3.down, out hit, maxLength))
        {
            end = hit.point;

            // See if we hit a cup
            CupFill cup = hit.collider.GetComponentInParent<CupFill>();

            if (cup != null)
			{
				cup.AddCoffee(Time.deltaTime * fillRate);

				// If cup is now full, we can optionally stop this stream
				if (cup.IsFull)
				{
					End();
					return;
				}
			}
        }

        // Middle point halfway between start and end
        Vector3 middle = (start + end) * 0.5f;

        // Wobble sideways (relative to the pot/stream transform)
        Vector3 wobbleDir = transform.right;
        float wobble = Mathf.Sin(Time.time * wobbleFrequency) * wobbleAmplitude;
        middle += wobbleDir * wobble;

        // Set the 3 positions
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, middle);
        lineRenderer.SetPosition(2, end);
    }
}
