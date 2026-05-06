using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class DrillMachine : MonoBehaviour
{
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private bool returnToOrigin = false;
    public float returnSpeed = 2f; // Tweak for faster/slower return

    public Transform drillTip;
    public GameObject drillScrew; // The screw on the drill tip
    public float rotationSpeed = 500f;

    public InputActionProperty selectAction;
    public event System.Action PickedScrew;

    private bool isHoldingTrigger = false;
    private bool isGrabbed = false;
    private GameObject currentTargetScrewPoint;
    private float holdTimer = 0f;
    private bool screwAttached = false;

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

        if (returnToOrigin)
        {
            transform.position = Vector3.Lerp(transform.position, originalPosition, Time.deltaTime * returnSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, originalRotation, Time.deltaTime * returnSpeed);

            // Stop once close enough
            if (Vector3.Distance(transform.position, originalPosition) < 0.01f &&
                Quaternion.Angle(transform.rotation, originalRotation) < 1f)
            {
                returnToOrigin = false;
            }
        }
        if (selectAction.action != null)
        {
            isHoldingTrigger = selectAction.action.IsPressed();

            if (isHoldingTrigger && screwAttached)
            {
                RotateDrillTip();
            }

            if (isHoldingTrigger && currentTargetScrewPoint != null && screwAttached)
            {
                holdTimer += Time.deltaTime;
                if (holdTimer >= 2f)
                {
                    PlaceScrew();
                    CloseArrow();
                }
            }
            else
            {
                holdTimer = 0f;
            }
        }
    }

    private void RotateDrillTip()
    {
        drillTip.Rotate(Vector3.left, rotationSpeed * Time.deltaTime);
    }

    public void OnDrillTipTriggerEnter(Collider other)
    {
        if (other.CompareTag("Screw"))
        {
            Debug.Log("Replacing screw with: " + other.name);
           // Destroy(other.gameObject);

            if (!drillScrew.activeSelf)
                drillScrew.SetActive(true);
            PickedScrew?.Invoke();
            screwAttached = true;
        }



        if (other.CompareTag("ScrewPoint") && screwAttached)
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

    private void PlaceScrew()
    {
        Transform screwOnPoint = currentTargetScrewPoint.transform.Find("PlacedScrew");
        if (screwOnPoint != null)
        {
            screwOnPoint.gameObject.SetActive(true);
        }

        drillScrew.SetActive(false);
        screwAttached = false;
        holdTimer = 0f;
    }
    private void CloseArrow()
    {
        Transform ArrowOnPoint = currentTargetScrewPoint.transform.Find("Arrow");
        if (ArrowOnPoint != null)
        {
            ArrowOnPoint.gameObject.SetActive(false);
        }

        drillScrew.SetActive(false);
        screwAttached = false;
        holdTimer = 0f;
    }
}
