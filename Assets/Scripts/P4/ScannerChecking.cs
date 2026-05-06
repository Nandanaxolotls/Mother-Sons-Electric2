using UnityEngine;

public class ScannerChecking : MonoBehaviour
{
    public event System.Action Scanned;


    [Header("Player Tag")]
    public string playerTag = "Player"; // Make sure your player has this tag

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            Debug.Log("Player arrived at the location!");

            Scanned?.Invoke();
        }
    }
}
