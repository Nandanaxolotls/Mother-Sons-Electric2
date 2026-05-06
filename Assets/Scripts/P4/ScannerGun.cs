
using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class ScannerGun : MonoBehaviour
{
    public GameObject Dummy;                // Already used
    public Renderer targetRenderer;         // Object whose color will change
    public Color highlightColor = Color.red; // Temporary color
    public float colorDuration = 2f;        // Duration in seconds

    public Color originalColor;

    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private bool returnToOrigin = false;

    public InputActionProperty selectAction;
    public event System.Action LabelScanned;

    private bool isHoldingTrigger = false;
    private bool isGrabbed = false;
    private GameObject currentTargetScrewPoint;
    private float holdTimer = 0f;
    private bool screwAttached = false;
    private bool colorChanging = false;

    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    private void OnEnable()
    {
        // Subscribe to grab events
        GetComponent<XRGrabInteractable>().selectEntered.AddListener(OnGrab);
        GetComponent<XRGrabInteractable>().selectExited.AddListener(OnRelease);
    }

    private void OnDisable()
    {
        // Unsubscribe from grab events
        GetComponent<XRGrabInteractable>().selectEntered.RemoveListener(OnGrab);
        GetComponent<XRGrabInteractable>().selectExited.RemoveListener(OnRelease);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        isGrabbed = true;
        returnToOrigin = false;
        Debug.Log("grabbed dril");
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        isGrabbed = false;
        isHoldingTrigger = false;
        returnToOrigin = true; // Start returning on release
        holdTimer = 0f;
    }

    void Update()
    {
        if (!isGrabbed) return; // ?? Don’t allow trigger logic unless grabbed

        if (selectAction.action != null)
        {
            isHoldingTrigger = selectAction.action.IsPressed();

            if (isHoldingTrigger )
            {
                ChangeColor();
            }

           
        }
    }

    private void ChangeColor()
    {
       // Dummy.SetActive(true);

        if (!colorChanging) // Prevent multiple overlapping calls
            StartCoroutine(ChangeColorRoutine());
    }

    private IEnumerator ChangeColorRoutine()
    {
        colorChanging = true;

        if (targetRenderer != null)
        {
            targetRenderer.material.color = highlightColor; // Change color
        }

        yield return new WaitForSeconds(colorDuration);

        if (targetRenderer != null)
        {
            targetRenderer.material.color = originalColor; // Revert
        }
        LabelScanned?.Invoke();
        colorChanging = false;
    }

    public void OnDrillTipTriggerEnter(Collider other)
    {



        if (other.CompareTag("Sticker") && screwAttached)
        {
            currentTargetScrewPoint = other.gameObject;
        }
    }

    public void OnDrillTipTriggerExit(Collider other)
    {
        if (other.gameObject == currentTargetScrewPoint)
        {
            currentTargetScrewPoint = null;
            holdTimer = 0f;
        }
    }

   
}
