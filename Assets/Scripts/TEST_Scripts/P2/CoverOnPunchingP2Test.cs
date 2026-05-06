using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections.Generic;

public class CoverOnPunchingP2Test : MonoBehaviour
{
    [Header("Allowed Tags")]
    [Tooltip("Objects with any of these tags can snap here")]
    public List<string> allowedTags = new List<string>();

    [Tooltip("If true, snapped object will match rotation too")]
    public bool snapRotation = true;

    public Vector3 positionOffset;
    public Vector3 rotationOffset;

    [Header("Objects to Activate in Order")]
    public List<GameObject> objectsToActivate = new List<GameObject>();

    public bool makeSnappedObjectUngrabable = true;

    private XRSocketInteractor socketInteractor;
    private XRGrabInteractable candidateInteractable;

    private int currentIndex = 0;

    public event System.Action<GameObject> OnObjectActivated;
    public event System.Action AllObjectsActivated;

    private void Awake()
    {
        socketInteractor = GetComponent<XRSocketInteractor>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // ? Not allowed tag? Ignore
        if (!allowedTags.Contains(other.tag)) return;

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

        // Destroy the snapped object
        Destroy(candidateInteractable.gameObject);

        // Deactivate previous 3 every time 4th (7th, 10th...) activates
        if (currentIndex > 0 && currentIndex % 3 == 0)
        {
            int start = currentIndex - 3;
            for (int i = start; i < currentIndex; i++)
            {
                if (i >= 0 && i < objectsToActivate.Count && objectsToActivate[i] != null)
                {
                    objectsToActivate[i].SetActive(false);
                    Debug.Log($"Deactivated {objectsToActivate[i].name}");
                }
            }
        }

        // Activate next object
        if (currentIndex < objectsToActivate.Count)
        {
            GameObject obj = objectsToActivate[currentIndex];
            if (obj != null)
            {
                obj.SetActive(true);
                Debug.Log($"Activated {obj.name}");
                OnObjectActivated?.Invoke(obj);
            }

            currentIndex++;

            if (currentIndex >= objectsToActivate.Count)
            {
                Debug.Log("All objects activated.");
                AllObjectsActivated?.Invoke();
            }
        }

        if (socketInteractor != null)
            socketInteractor.enabled = false;
    }
}
