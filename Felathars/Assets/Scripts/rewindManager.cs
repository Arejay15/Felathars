using NUnit.Framework;
using UnityEngine;

public class rewindManager : MonoBehaviour
{
    private static List<rewindObject> rewindObjects = new List<rewindObject>();
    private static bool isRewinding = false;
    public static void Register(rewindObject obj) {
        if (!rewindObjects.contains(obj)) rewindObjects.Add(obj);
    }

    public static void Unregister(rewindObject obj) {
        rewindObjects.Remove(obj);
    }

    public void StartRewindAll() {
        isRewinding = true;
        foreach (var obj in rewindObjects) {
            obj.StartRewind();
        }
    }

    public void StopRewindAll() {
        isRewinding = false;
        foreach (var obj in rewindObjects) {
            obj.StopRewind();
        }
    }

    void Update() {
        if (Input.GetButtonDown("Beanback")) {
            StartRewindAll();
        }
        if (Input.GetButtonUp("Beanback")){
            StopRewindAll();
        }
    
    }
}
