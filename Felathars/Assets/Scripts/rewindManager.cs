using NUnit.Framework;
using UnityEngine;

public class rewindManager : MonoBehaviour
{
    public static rewindObject rewindObject;
    private static bool isRewinding = false;
  


    public void StartRewindAll() {
        isRewinding = true;
        rewindObject.StartRewind();
    }

    public void StopRewindAll() {
        isRewinding = false;
        rewindObject.StopRewind();
   
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.F)) {
            StartRewindAll();
        }
        if (Input.GetKeyUp(KeyCode.F)){
            StopRewindAll();
        }
    
    }
}
