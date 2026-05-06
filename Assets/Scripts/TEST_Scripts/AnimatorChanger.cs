using UnityEngine;

public class AnimatorChanger : MonoBehaviour
{
    [Header("Animator Reference")]
    public Animator animator;

    [Header("Animator Controllers")]
    public RuntimeAnimatorController controller1;
    public RuntimeAnimatorController controller2;

    private void Start()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
    }

    // Call this to switch to Controller 1
    public void SwitchToController1()
    {
        if (animator != null && controller1 != null)
        {
            animator.runtimeAnimatorController = controller1;
            Debug.Log("Switched to Controller 1");
        }
    }

    // Call this to switch to Controller 2
    public void SwitchToController2()
    {
        if (animator != null && controller2 != null)
        {
            animator.runtimeAnimatorController = controller2;
            Debug.Log("Switched to Controller 2");
        }
    }
}
