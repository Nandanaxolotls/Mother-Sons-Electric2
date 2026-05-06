using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FollowingScript : MonoBehaviour
{
    [Header("The target object to follow (like a virtual parent)")]
    public Transform target;
   // public FireSafetyStepManager gameManager;

    [Header("Follow Options")]
    public bool followPosition = true;
    public bool followRotation = true;
    public Vector3 positionOffset;
    public Vector3 rotationOffset;

    private XRGrabInteractable grabInteractable;
    private bool isGrabbed = false;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        grabInteractable = GetComponent<XRGrabInteractable>();

        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnGrab);
            grabInteractable.selectExited.AddListener(OnRelease);
        }
    }

    void LateUpdate()
    {
        if (target == null || isGrabbed) return;

        if (followPosition)
            transform.position = target.TransformPoint(positionOffset);

        if (followRotation)
            transform.rotation = target.rotation * Quaternion.Euler(rotationOffset);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        isGrabbed = true;

        // Disable gravity while being held
        if (rb != null)
        {
            rb.useGravity = false;
            rb.isKinematic = false;
        }
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        // isGrabbed = false;
        //gameManager.OnPinPulled();jfgvjhfgfuugfuyuyuyuy
        // Enable gravity after releasing
        if (rb != null)
        {
            rb.useGravity = true;
            rb.isKinematic = false;
        }
    }

    private void OnDestroy()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrab);
            grabInteractable.selectExited.RemoveListener(OnRelease);
        }
    }
}
