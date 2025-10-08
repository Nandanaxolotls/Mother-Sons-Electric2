using UnityEngine;

public class ObjectActivator : MonoBehaviour
{
    [Header("Objects to Control (Assign in Inspector)")]
    public GameObject[] objects;

    /// <summary>
    /// Activates the object at the given index (1-based or 0-based).
    /// </summary>
    public void ActivateObject(int index)
    {
        if (!IsValidIndex(index)) return;

        objects[index].SetActive(true);
        Debug.Log($"{objects[index].name} activated.");
    }

    /// <summary>
    /// Deactivates the object at the given index.
    /// </summary>
    public void DeactivateObject(int index)
    {
        if (!IsValidIndex(index)) return;

        objects[index].SetActive(false);
        Debug.Log($"{objects[index].name} deactivated.");
    }

    /// <summary>
    /// Toggles the object's active state at the given index.
    /// </summary>
    public void ToggleObject(int index)
    {
        if (!IsValidIndex(index)) return;

        bool current = objects[index].activeSelf;
        objects[index].SetActive(!current);
        Debug.Log($"{objects[index].name} toggled to {!current}.");
    }

    private bool IsValidIndex(int index)
    {
        if (index < 0 || index >= objects.Length)
        {
            Debug.LogWarning($"Invalid index {index}. Must be between 0 and {objects.Length - 1}.");
            return false;
        }
        return true;
    }
}
