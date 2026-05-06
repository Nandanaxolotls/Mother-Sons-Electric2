using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FrontOnAssySnapPointP2Test : MonoBehaviour
{
    [Header("Tag Settings")]
    [Tooltip("Tag for GOOD type objects.")]
    public string goodTag = "Good";

    [Tooltip("Tag for DEFECT type objects.")]
    public string defectTag = "Defect";

    [Header("Snap Options")]
    [Tooltip("If true, snapped object will match rotation too")]
    public bool snapRotation = true;

    [Tooltip("Offset from snap zone position (optional)")]
    public Vector3 positionOffset;

    [Tooltip("Offset from snap zone rotation (optional)")]
    public Vector3 rotationOffset;

    [Tooltip("Object to activate after snapping.")]
    public GameObject GoodobjectToActivate;
    public GameObject NGobjectToActivate;


    [Tooltip("Disable grabbing after snap.")]
    public bool makeSnappedObjectUngrabable = true;

    private XRSocketInteractor socketInteractor;
    private XRGrabInteractable candidateInteractable;

    // Event sends string "Good" or "Defect"
    public event System.Action<string> ChipSnapped;

    private void Awake()
    {
        socketInteractor = GetComponent<XRSocketInteractor>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Accept only Good or Defect tags
        if (!other.CompareTag(goodTag) && !other.CompareTag(defectTag)) return;

        XRGrabInteractable interactable = other.GetComponent<XRGrabInteractable>();
        if (interactable != null)
        {
            candidateInteractable = interactable;
            SnapObject(other.tag); // Pass the tag to determine good/defect
        }
    }

    private void OnTriggerExit(Collider other)
    {
        XRGrabInteractable exited = other.GetComponent<XRGrabInteractable>();
        if (exited != null && exited == candidateInteractable)
        {
            candidateInteractable = null;
        }
    }

    private void SnapObject(string objectTag)
    {
        if (candidateInteractable == null) return;

        // Calculate snap position
        Vector3 snapPosition = transform.position + positionOffset;
        Quaternion snapRotationQuat = snapRotation
            ? transform.rotation * Quaternion.Euler(rotationOffset)
            : candidateInteractable.transform.rotation;

        // Stop motion
        Rigidbody rb = candidateInteractable.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        // Destroy incoming object

        // Activate replacement


        // Invoke event with string
        if (objectTag == goodTag)
        {
            ChipSnapped?.Invoke("Good");
            Debug.Log("Good object snapped.");
            if (GoodobjectToActivate != null)
            {
                GoodobjectToActivate.SetActive(true);
            }
        }
        else if (objectTag == defectTag)
        {
            ChipSnapped?.Invoke("Defect");
            Debug.Log("Defect object snapped.");
            if (NGobjectToActivate != null)
            {
                NGobjectToActivate.SetActive(true);
            }
        }

        // Disable socket
        if (socketInteractor != null)
            socketInteractor.enabled = false;
        Destroy(candidateInteractable.gameObject);

        // Disable this snap point
        gameObject.SetActive(false);

    }

    private void OnObjectGrabbedAgain(SelectEnterEventArgs args)
    {
        if (socketInteractor != null && !socketInteractor.enabled)
        {
            socketInteractor.enabled = true;
            Debug.Log("Socket re-enabled after object was grabbed again.");
        }

        if (candidateInteractable != null)
        {
            candidateInteractable.selectEntered.RemoveListener(OnObjectGrabbedAgain);
        }
    }
}
