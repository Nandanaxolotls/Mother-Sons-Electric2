using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class SolderingMachine : MonoBehaviour
{
    [Header("References")]
    public Transform object1; // moves on Z
    public Transform object2; // moves on X/Y
    public GameManager gameManager;
    public ParticleSystem myParticles;
    public GameObject Tooltip5;

    [System.Serializable]
    public class StepTargets
    {
        public float object1ZTarget;
        public float object2YTarget;
        public float object2XTarget;
        public float object2YSecondTarget;
    }

    public StepTargets[] stepTargets; // assign 5 in inspector


    [Header("Animation Settings")]
    public float moveDuration = 1f;     // time for each move
    public float waitBetweenSteps = 1f; // pause between steps

    [Header("Input")]
    public InputActionProperty selectAction;

    public event System.Action onProcessComplete;

    private bool isHovered = false;
    private Vector3 obj1OriginalPos;
    private Vector3 obj2OriginalPos;
    private Coroutine processCoroutine;

    void Start()
    {
        if (object1 != null) obj1OriginalPos = object1.localPosition;
        if (object2 != null) obj2OriginalPos = object2.localPosition;
    }

    public void OnHoverEntered(HoverEnterEventArgs args) => isHovered = true;
    public void OnHoverExited(HoverExitEventArgs args) => isHovered = false;

    void Update()
    {
        if (isHovered && selectAction.action.WasPressedThisFrame())
        {
            Call();
        }
    }

    public void Call()
    {
        Tooltip5.SetActive(false);
        if (processCoroutine != null) StopCoroutine(processCoroutine);
        processCoroutine = StartCoroutine(ProcessSequence(5)); // run 2 times
    }

    private IEnumerator ProcessSequence(int repeatCount)
    {
        for (int i = 0; i < repeatCount; i++)
        {
            StepTargets t = stepTargets[i];

            // Step 1
            yield return StartCoroutine(MoveTo(object1, new Vector3(obj1OriginalPos.x, obj1OriginalPos.y, t.object1ZTarget)));

            // Step 2
            yield return StartCoroutine(MoveTo(object2, new Vector3(obj2OriginalPos.x, t.object2YTarget, obj2OriginalPos.z)));

            yield return new WaitForSeconds(waitBetweenSteps);

            // Step 3
            yield return StartCoroutine(MoveTo(object2, obj2OriginalPos));

            // Step 4
            yield return StartCoroutine(MoveTo(object2, new Vector3(t.object2XTarget, obj2OriginalPos.y, obj2OriginalPos.z)));

            // Step 5
            yield return StartCoroutine(MoveTo(object2, new Vector3(t.object2XTarget, t.object2YSecondTarget, obj2OriginalPos.z)));

            if (myParticles != null)
            {
                myParticles.Play();
                yield return new WaitForSeconds(1f);
                myParticles.Stop();
            }

            yield return new WaitForSeconds(1);

            // Step 6
            yield return StartCoroutine(MoveTo(object2, new Vector3(t.object2XTarget, obj2OriginalPos.y, obj2OriginalPos.z)));

            yield return new WaitForSeconds(waitBetweenSteps);

            // Step 7
            yield return StartCoroutine(MoveTo(object2, obj2OriginalPos));

            // Step 8
            yield return StartCoroutine(MoveTo(object1, obj1OriginalPos));
        }

        onProcessComplete?.Invoke();
    }


    private IEnumerator MoveTo(Transform obj, Vector3 targetPos)
    {
        if (obj == null) yield break;
        Vector3 start = obj.localPosition;
        float elapsed = 0f;

        while (elapsed < moveDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / moveDuration);
            obj.localPosition = Vector3.Lerp(start, targetPos, t);
            yield return null;
        }
        obj.localPosition = targetPos;
    }
}
