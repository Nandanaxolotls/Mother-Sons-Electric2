using UnityEngine;

public class DestroyNotifyer : MonoBehaviour
{
    public System.Action<GameObject> OnDestroyed;

    private void OnDestroy()
    {
        OnDestroyed?.Invoke(gameObject);
    }
}
