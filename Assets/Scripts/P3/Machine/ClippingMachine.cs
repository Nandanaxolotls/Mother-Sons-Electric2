using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ClippingMachine : MonoBehaviour
{
    [Header("References")]
    public Transform targetObject; // The object to rotate
    public GameManager gameManager;

    [Header("Target Rotation Values")]
    public int XValue;
   

    [Header("Input")]
    public InputActionProperty selectAction;

    [Header("Animation Settings")]
    public float rotationDuration = 1f; // Time to complete the rotation
    public float waitDuration = 2f;     // Wait time before returning

    public enum RotationDirection { Clockwise, Anticlockwise }
    [Tooltip("Choose rotation direction for this object")]
    public RotationDirection rotationDirection = RotationDirection.Clockwise;

    public event System.Action onReachedOriginal;
    public event System.Action onReachedDesired;

    private bool isHovered = false;
    private bool isRunning = false; // prevents multiple triggers while animating
    private bool isLocked = false;
    private Vector3 originalRotation;
    private Coroutine rotationCoroutine;

    void Start()
    {
        if (targetObject != null)
            originalRotation = targetObject.localEulerAngles;
    }

    public void OnHoverEntered(HoverEnterEventArgs args) => isHovered = true;
    public void OnHoverExited(HoverExitEventArgs args) => isHovered = false;

    void Update()
    {
        if (!isLocked && isHovered && selectAction.action.WasPressedThisFrame() && !isRunning)
        {
            StartCoroutine(RunRotationSequence());
        }
    }
    public void StartClipping()
    {
            StartCoroutine(RunRotationSequence());

    }

    private IEnumerator RunRotationSequence()
    {
        
        isRunning = true;
        yield return new WaitForSeconds(2);
        // Determine target rotation
        Vector3 targetRotation = (rotationDirection == RotationDirection.Clockwise)
            ? new Vector3(XValue,90, -90)
            : new Vector3(-XValue, 90, -90);

        // Step 1: Rotate to desired
        yield return StartCoroutine(SmoothRotate(targetRotation));
        onReachedDesired?.Invoke();

        // Step 2: Wait for 2 seconds
        yield return new WaitForSeconds(waitDuration);

        // Step 3: Return to original
        yield return StartCoroutine(SmoothRotate(originalRotation));
        onReachedOriginal?.Invoke();
        isLocked = true;
        isRunning = false;
    }
    public void Unlock()
    {
        isLocked = false;
    }

    private IEnumerator SmoothRotate(Vector3 targetRotation)
    {
        Quaternion startRotation = targetObject.localRotation;
        Quaternion endRotation = Quaternion.Euler(targetRotation);
        float elapsed = 0f;

        while (elapsed < rotationDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / rotationDuration);
            targetObject.localRotation = Quaternion.Slerp(startRotation, endRotation, t);
            yield return null;
        }

        targetObject.localRotation = endRotation; // Ensure final rotation is exact
    }
}
