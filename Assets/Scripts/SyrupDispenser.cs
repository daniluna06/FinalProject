using System.Collections;
using UnityEngine;

public class SyrupDispenser : MonoBehaviour
{
    [Header("Setup")]
    public Transform syrupOrigin;
    public GameObject syrupStreamPrefab;

    [Header("Pour Settings")]
    public float defaultPourDuration = 0.5f;

    private bool isPouring = false;

    public void DispenseOnce(Material syrupMaterial, float pourDuration = -1f)
    {
        if (isPouring || syrupOrigin == null || syrupStreamPrefab == null || syrupMaterial == null)
            return;

        if (pourDuration <= 0f)
            pourDuration = defaultPourDuration;

        StartCoroutine(PourRoutine(syrupMaterial, pourDuration));
    }

    private IEnumerator PourRoutine(Material syrupMaterial, float duration)
    {
        isPouring = true;

        GameObject streamObj = Instantiate(
            syrupStreamPrefab,
            syrupOrigin.position,
            Quaternion.identity,
            transform
        );

        Stream stream = streamObj.GetComponent<Stream>();
        LineRenderer lr = streamObj.GetComponent<LineRenderer>();

        if (lr != null)
            lr.material = syrupMaterial;

        if (stream != null)
            stream.Begin();

        yield return new WaitForSeconds(duration);

        if (stream != null)
            stream.End();

        isPouring = false;
    }
}
