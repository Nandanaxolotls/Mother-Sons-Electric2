using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections.Generic;

public class NG1SnapPoint : MonoBehaviour
{
    [Tooltip("Tag of the object that should snap here")]
    public string targetTag = "Pickable";

    [Tooltip("If true, snapped object will match rotation too")]
    public bool snapRotation = true;

    [Tooltip("Offset from snap zone position (optional)")]
    public Vector3 positionOffset;

    [Tooltip("Offset from snap zone rotation (optional)")]
    public Vector3 rotationOffset;

    [Header("Objects to Activate in Order")]
    [Tooltip("Objects that will activate one by one when a tagged object is snapped")]
    public List<GameObject> objectsToActivate = new List<GameObject>();

    [Header("Snap Options")]
    [Tooltip("If enabled, the snapped object cannot be picked up again after snapping.")]
    public bool makeSnappedObjectUngrabable = true;

    private XRSocketInteractor socketInteractor;
    private XRGrabInteractable candidateInteractable;

    private int currentIndex = 0; // Tracks which object to activate next

    /// <summary>
    /// Invoked every time an object activates after a snap.
    /// </summary>
    public event System.Action<GameObject> OnObjectActivated;

    /// <summary>
    /// Invoked when all objects are activated (optional).
    /// </summary>
    public event System.Action AllObjectsActivated;

    private void Awake()
    {
        socketInteractor = GetComponent<XRSocketInteractor>();
    }

    private void OnTriggerEnter(Collider other)
    {
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
        XRGrabInteractable exited = other.GetComponent<XRGrabInteractable>();
        if (exited != null && exited == candidateInteractable)
        {
            candidateInteractable = null;
        }
    }

    private void SnapObject()
    {
        if (candidateInteractable == null) return;

        // Calculate snap transform
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

        // Remove the snapped object
        Destroy(candidateInteractable.gameObject);

        // Activate next object
        if (currentIndex < objectsToActivate.Count)
        {
            GameObject obj = objectsToActivate[currentIndex];
            if (obj != null)
            {
                obj.SetActive(true);
                Debug.Log($"Activated object {currentIndex + 1}: {obj.name}");

                // ?? Fire event every time an object activates
                OnObjectActivated?.Invoke(obj);
            }

            currentIndex++;

            // ?? Fire "all done" event when finished
            if (currentIndex >= objectsToActivate.Count)
            {
                Debug.Log("All objects in the list have been activated.");
                AllObjectsActivated?.Invoke();
            }
        }
        else
        {
            Debug.Log("All objects were already activated.");
        }

        // Disable the socket if needed
        if (socketInteractor != null)
            socketInteractor.enabled = false;
    }
}
