using UnityEngine;

public class ui_switch : MonoBehaviour
{
    public GameObject Canvas;
    private int index = 0;

    void Start()
    {
        Canvas.SetActive(false);

        int count = Canvas.transform.childCount;

        // Hide all children
        for (int i = 0; i < count; i++)
            Canvas.transform.GetChild(i).gameObject.SetActive(false);

        // Start with first child
        if (count > 0)
        {
            index = 0;
            Canvas.transform.GetChild(index).gameObject.SetActive(true);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Canvas.SetActive(true);

            int count = Canvas.transform.childCount;

            // Hide current
            Canvas.transform.GetChild(index).gameObject.SetActive(false);

            // Move to next (wrap)
            index = (index + 1) % count;

            // Show next
            Canvas.transform.GetChild(index).gameObject.SetActive(true);

            Debug.Log("Showing child index: " + index);
        }
    }
}