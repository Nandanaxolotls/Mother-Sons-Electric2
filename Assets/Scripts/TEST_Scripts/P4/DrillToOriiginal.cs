using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DrillToOriiginal : MonoBehaviour
{
    public float returnSpeed = 3f;  // Speed of returning movement
    private XRGrabInteractable grabInteractable;

    private Vector3 startPos;
    private Quaternion startRot;

    private bool isReturning = false;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Save starting position & rotation
        startPos = transform.position;
        startRot = transform.rotation;
    }

    private void OnEnable()
    {
        grabInteractable.selectExited.AddListener(OnReleased);
        grabInteractable.selectEntered.AddListener(OnGrabbed);
    }

    private void OnDisable()
    {
        grabInteractable.selectExited.RemoveListener(OnReleased);
        grabInteractable.selectEntered.RemoveListener(OnGrabbed);
    }

    private void OnGrabbed(SelectEnterEventArgs args)
    {
        isReturning = false; // Stop return when grabbed
    }

    private void OnReleased(SelectExitEventArgs args)
    {
        isReturning = true; // Start return
    }

    private void Update()
    {
        if (isReturning)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                startPos,
                returnSpeed * Time.deltaTime
            );

            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                startRot,
                returnSpeed * 50f * Time.deltaTime
            );

            // Stop once it reaches original point
            if (Vector3.Distance(transform.position, startPos) < 0.01f)
            {
                isReturning = false;
            }
        }
    }
}
