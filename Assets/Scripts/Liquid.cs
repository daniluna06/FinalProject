using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liquid : MonoBehaviour
{
    public Transform pot;               // assign your coffee pot here in the Inspector

    // 0–1: how strong the slosh is when the pot is upright
    public float sloshAmount = 1f;

    // Up to what tilt angle (in degrees) we allow slosh.
    // Beyond this, the liquid just follows the pot.
    public float maxTiltForSlosh = 45f;

    public float smooth = 5f;

    private Quaternion initialLocalRotation;

    private void Start()
    {
        initialLocalRotation = transform.localRotation;
    }

    private void Update()
    {
        if (pot == null) return;

        // Rotation that makes the liquid stay level with the world
        Quaternion levelRot = Quaternion.Inverse(pot.localRotation) * initialLocalRotation;

        // How tilted is the pot compared to world up?
        // 0° = straight up, 90° = sideways
        float tiltAngle = Vector3.Angle(pot.up, Vector3.up);

        // Compute how much slosh we should have based on tilt:
        // - When tiltAngle = 0  → factor = 1  (full slosh)
        // - When tiltAngle >= maxTiltForSlosh → factor = 0 (no slosh)
        float normalized = Mathf.Clamp01(tiltAngle / maxTiltForSlosh);
        float tiltFactor = 1f - normalized;

        // Final blend amount between "follow pot" and "stay level"
        float t = sloshAmount * tiltFactor; // 0–1, shrinks as tilt increases

        // Blend between:
        // initialLocalRotation = liquid fully follows pot
        // levelRot = liquid tries to stay level
        Quaternion targetRot = Quaternion.Slerp(initialLocalRotation, levelRot, t);

        // Smoothly move toward that blended rotation
        transform.localRotation = Quaternion.Slerp(
            transform.localRotation,
            targetRot,
            Time.deltaTime * smooth
        );
    }
}
