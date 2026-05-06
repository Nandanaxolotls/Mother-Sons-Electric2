using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class DrawerHandleP2Elextric : MonoBehaviour
{
    [Header("References")]
    public Transform object2; // Only rotation
    public GameObject Tooltip1;

    [Header("Target Rotation")]
    public float object2TargetXRot = 180f;

    [Header("Input")]
    public InputActionProperty selectAction;

    [Header("Animation Settings")]
    public float rotateDuration = 1f;

    public event System.Action onReachedOriginal;
    public event System.Action onReachedDesired;

    private bool isHovered = false;
    private bool isInDesiredPosition = false;
    private bool isLocked = false;
    private bool isPermanantlyLocked = false;

    private Quaternion object2OriginalRot;

    private Coroutine activeRoutine;

    void Start()
    {
        if (object2 != null)
            object2OriginalRot = object2.localRotation;
    }

    public void OnHoverEntered(HoverEnterEventArgs args) => isHovered = true;
    public void OnHoverExited(HoverExitEventArgs args) => isHovered = false;

    void Update()
    {
        if (isHovered && selectAction.action.WasPressedThisFrame())
        {
            TogglePosition();
        }
    }

    private void TogglePosition()
    {
        if (Tooltip1 != null)
            Tooltip1.SetActive(false);

        if (isPermanantlyLocked) return;
        if (isInDesiredPosition && isLocked) return;

        if (activeRoutine != null)
            StopCoroutine(activeRoutine);

        if (!isInDesiredPosition)
        {
            // Rotate to target
            activeRoutine = StartCoroutine(RotateObject2(
                Quaternion.Euler(object2TargetXRot, 0f, 0f),
                true
            ));
        }
        else
        {
            // Rotate back to original
            activeRoutine = StartCoroutine(RotateObject2(
                object2OriginalRot,
                false
            ));
        }

        isInDesiredPosition = !isInDesiredPosition;
    }

    private IEnumerator RotateObject2(Quaternion targetRot, bool goingToDesired)
    {
        Quaternion startRot = object2.localRotation;
        float elapsed = 0f;

        while (elapsed < rotateDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / rotateDuration);
            object2.localRotation = Quaternion.Slerp(startRot, targetRot, t);
            yield return null;
        }

        object2.localRotation = targetRot;

        // Events + Locking
        if (goingToDesired)
        {
            isLocked = true;
            onReachedDesired?.Invoke();
        }
        else
        {
            isLocked = false;
            onReachedOriginal?.Invoke();
        }
    }

    public void Unlock() => isLocked = false;
    public void PermanantlyLock() => isPermanantlyLocked = true;
}
