using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ObjectListTracker
{
    public string listName;
    public List<GameObject> objectsToTrack;
    [HideInInspector] public int destroyedCount;
    public UnityEngine.Events.UnityEvent onAllDestroyed;  // Callback in inspector
}

public class MultiDestroyManager : MonoBehaviour
{
    public List<ObjectListTracker> lists;

    private void Start()
    {
        foreach (var tracker in lists)
        {
            foreach (var obj in tracker.objectsToTrack)
            {
                if (obj != null)
                {
                    var notifier = obj.AddComponent<DestroyNotifyer>();
                    notifier.OnDestroyed += (destroyedObj) =>
                        HandleDestroyedObject(tracker, destroyedObj);
                }
            }
        }
    }

    private void HandleDestroyedObject(ObjectListTracker tracker, GameObject destroyedObj)
    {
        tracker.destroyedCount++;

        if (tracker.destroyedCount >= tracker.objectsToTrack.Count)
        {
            tracker.onAllDestroyed?.Invoke();
        }
    }
}
