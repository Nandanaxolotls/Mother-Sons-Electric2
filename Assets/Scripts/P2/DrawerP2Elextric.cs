using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class DrawerP2Elextric : MonoBehaviour
{
    [Header("References")]
    public Transform object1; // Only movement
    public GameObject Tooltip1;

    [Header("Target Values")]
    public float object1TargetX = -1.3412f;

    [Header("Input")]
    public InputActionProperty selectAction;

    [Header("Animation Settings")]
    public float moveDuration = 1f;

    public event System.Action onReachedOriginal;
    public event System.Action onReachedDesired;

    private bool isHovered = false;
    private bool isInDesiredPosition = false;
    private bool isLocked = false;
    private bool isPermanantlyLocked = false;

    private Vector3 object1OriginalPos;
    private Coroutine activeRoutine;

    void Start()
    {
        if (object1 != null)
            object1OriginalPos = object1.localPosition;
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
            // Move to desired
            activeRoutine = StartCoroutine(MoveObject1(
                new Vector3(object1TargetX, object1OriginalPos.y, object1OriginalPos.z),
                true
            ));
        }
        else
        {
            // Move to original
            activeRoutine = StartCoroutine(MoveObject1(
                object1OriginalPos,
                false
            ));
        }

        isInDesiredPosition = !isInDesiredPosition;
    }

    private IEnumerator MoveObject1(Vector3 targetPos, bool goingToDesired)
    {
        Vector3 startPos = object1.localPosition;
        float elapsed = 0f;

        while (elapsed < moveDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / moveDuration);
            object1.localPosition = Vector3.Lerp(startPos, targetPos, t);
            yield return null;
        }

        object1.localPosition = targetPos;

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
