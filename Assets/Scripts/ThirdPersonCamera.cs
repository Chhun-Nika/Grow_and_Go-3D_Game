using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [Header("Target")]
    public Transform target;   // Player character

    [Header("Camera Settings")]
    public Vector3 offset = new Vector3(0f, 3f, -6f);
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (target == null) return;

        // Desired camera position
        Vector3 desiredPosition = target.position + target.rotation * offset;

        // Smooth movement
        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime
        );

        // Always look at the player
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}
