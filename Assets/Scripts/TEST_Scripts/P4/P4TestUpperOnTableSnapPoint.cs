using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class P4TestUpperOnTableSnapPoint : MonoBehaviour
{
    [Tooltip("Tag of the good object that should snap here")]
    public string targetTag = "Pickable";

    [Tooltip("Tag for defected object that should NOT snap")]
    public string defectTag = "Defected";

    public bool snapRotation = true;
    public Vector3 positionOffset;
    public Vector3 rotationOffset;
    public GameObject objectToActivateAfterSnap;

    [Header("Snap Options")]
    public bool makeSnappedObjectUngrabable = true;

    private XRSocketInteractor socketInteractor;
    private XRGrabInteractable candidateInteractable;

    public event System.Action UpperOnMachineSnapped;

    private void Awake()
    {
        socketInteractor = GetComponent<XRSocketInteractor>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Case 1: Defected object ? show tooltip but do NOT snap
        if (other.CompareTag(defectTag))
        {
            Debug.Log("Defected object detected – showing tooltip.");

            Transform tooltip = other.transform.Find("Tooltip");
            if (tooltip != null)
                tooltip.gameObject.SetActive(true);
            else
                Debug.LogWarning("Tooltip not found in defected object!");

            return; // DO NOT SNAP
        }

        // Case 2: Good object ? snap normally
        if (!other.CompareTag(targetTag)) return;

        XRGrabInteractable interactable = other.GetComponent<XRGrabInteractable>();
        if (interactable != null)
        {
            candidateInteractable = interactable;
            SnapObject();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (candidateInteractable != null && other.GetComponent<XRGrabInteractable>() == candidateInteractable)
            candidateInteractable = null;
    }

    private void SnapObject()
    {
        if (candidateInteractable == null) return;

        Vector3 snapPosition = transform.position + positionOffset;
        Quaternion snapRotationQuat = snapRotation
            ? transform.rotation * Quaternion.Euler(rotationOffset)
            : candidateInteractable.transform.rotation;

        Rigidbody rb = candidateInteractable.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        Destroy(candidateInteractable.gameObject);

        if (objectToActivateAfterSnap != null)
        {
            objectToActivateAfterSnap.SetActive(true);
            UpperOnMachineSnapped?.Invoke();
        }

        if (socketInteractor != null)
            socketInteractor.enabled = false;

        Debug.Log("Good object snapped. Replacement activated.");

        gameObject.SetActive(false);
    }
}
