using NUnit.Framework;
using System.Runtime.CompilerServices;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class rewindObject : MonoBehaviour
{
    private bool isRewinding = false;
    private Rigidbody rb;
    private List<TransformData> history = new List<TransformData>();
    [SerializeField] private float recordTime = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.GetComponent<Rigidbody>();
        rewindManager.Register(this);
    }

    void OnDestroy()
    {
        rewindManager.Unregister(this);    
    }

    private void FixedUpdate()
    {
        if (isRewinding) Rewind();
        else Record();
    }
    
    void Record() {
        if (history.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
        {
            history.RemoveAt(history.Count - 1);
        }
        history.Insert(0, new TransformData(transform.position, transform.rotation));
    }

    void Rewind() {
        if (history.Count > 0) {
            TransformData data = history[0];
            transform.position = data.position;
            transform.rotation = data.rotation;
            history.RemoveAt(0);
        }
    }

    public void StartRewind() {
        isRewinding = true;
        if (rb != null) rb.isKinematic = true;
    }
    public void StopRewind(){
        isRewinding = false;
        if (rb != null) rb.isKinematic = false;
    }

    private struct TransformData {
        public Vector3 position;
        public Quaternion rotation;

        public TransformData(Vector3 pos, Quaternion rot) {
            position = pos;
            rotation = rot;
        }
    }
}
