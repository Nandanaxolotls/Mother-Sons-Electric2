using UnityEngine;

public class MagnifyingP1Test : MonoBehaviour
{
    [Header("Allowed Tags")]
    public string[] allowedTags = { "Player", "Tool" }; // Add as many as you want

    public event System.Action Checked;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the other object's tag is in the allowedTags list
        foreach (string tag in allowedTags)
        {
            if (other.CompareTag(tag))
            {
                Debug.Log("Valid object arrived: " + tag);
                Checked?.Invoke();
                return; // Stop after first match
            }
        }
    }
}
