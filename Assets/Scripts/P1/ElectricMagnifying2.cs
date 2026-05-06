using UnityEngine;

public class ElectricMagnifying2 : MonoBehaviour
{
    [Header("Game Manager Reference")]
    public SMP1M4 gameManager; // Assign in inspector

    [Header("Player Tag")]
    public string playerTag = "Player"; // Make sure your player has this tag

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            Debug.Log("Player arrived at the location!");

            if (gameManager != null)
            {
                gameManager.MagnifyingChecked2();
            }
        }
    }
}
