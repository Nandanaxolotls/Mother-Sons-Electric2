using UnityEngine;

public class LookAtArrow : MonoBehaviour
{
    public Transform target; // Assign the target to point toward
    public Transform playerCamera; // The VR camera

    void LateUpdate()
    {
        if (target == null || playerCamera == null) return;

        // Keep arrow always in front of the player camera
        transform.position = playerCamera.position + playerCamera.forward * 1.0f;

        // Slight adjust downward (optional)
        transform.position += Vector3.down * 0.2f;

        // Look at the target
        transform.LookAt(target.position);

        // Make arrow upright (optional)
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }
}
