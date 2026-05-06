using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections.Generic;

public class CoverSnapEventData
{
    public int activatedIndex;       // 1,2,3
    public GameObject activatedObject;

    public CoverSnapEventData(int index, GameObject obj)
    {
        activatedIndex = index;
        activatedObject = obj;
    }
}

public class CoverToSolderingTest : MonoBehaviour
{
    public string targetTag = "Pickable";

    public bool snapRotation = true;
    public Vector3 positionOffset;
    public Vector3 rotationOffset;

    [Header("Objects to Activate RANDOMLY (3 total)")]
    public List<GameObject> randomObjects = new List<GameObject>();

    public bool makeSnappedObjectUngrabable = true;

    private XRSocketInteractor socketInteractor;
    private XRGrabInteractable candidateInteractable;

    public event System.Action<CoverSnapEventData> CoversnappedToSoldering;
    private Dictionary<GameObject, int> randomObjectsInspectorIndex = new Dictionary<GameObject, int>();


    private void Awake()
    {
        socketInteractor = GetComponent<XRSocketInteractor>();
        // Store original inspector index for each object
        for (int i = 0; i < randomObjects.Count; i++)
        {
            randomObjectsInspectorIndex[randomObjects[i]] = i;
        }
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

    private int currentIndex = 0;   // Tracks which object is next

    private void SnapObject()
    {
        if (candidateInteractable == null) return;

        Rigidbody rb = candidateInteractable.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        Destroy(candidateInteractable.gameObject);

        GameObject chosen = null;
        int activatedIndex = -1;

        // ? Activate object according to Inspector order
        if (currentIndex < randomObjects.Count)
        {
            chosen = randomObjects[currentIndex];
            chosen.SetActive(true);

            activatedIndex = currentIndex + 1; // Convert 0 ? 1, 1 ? 2, 2 ? 3

            Debug.Log($"Activated object {activatedIndex}: {chosen.name}");

            currentIndex++; // Move to next object for future snap
        }
        else
        {
            Debug.Log("All objects already activated.");
        }

        // --- SEND EVENT ---
        CoversnappedToSoldering?.Invoke(
            new CoverSnapEventData(activatedIndex, chosen)
        );

        if (socketInteractor != null)
            socketInteractor.enabled = false;

        gameObject.SetActive(false);
    }

}
