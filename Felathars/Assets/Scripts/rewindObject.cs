using NUnit.Framework;
using System.Runtime.CompilerServices;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class rewindObject : MonoBehaviour
{
    private bool isRewinding = false;
    private List<TransformData> history = new List<TransformData>();
    [SerializeField] playerController player;
    [SerializeField] private float recordTime = 5f;
    [SerializeField] Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.GetComponent<Rigidbody>();
        player.GetComponent<playerController>();
        rewindManager.rewindObject = this;
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
        history.Insert(0, new TransformData(transform.position, transform.rotation, player.HP, player.tempHP));
    }

    void Rewind() {
        if (history.Count > 0) {
            TransformData data = history[0];
            transform.position = data.position;
            transform.rotation = data.rotation;
            player.HP = data.pastHealth;
            player.tempHP = data.pastTemp;
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
        public float pastHealth;
        public float pastTemp;
        public TransformData(Vector3 pos, Quaternion rot, float hp, float temphp) {
            position = pos;
            rotation = rot;
            pastHealth = hp;
            pastTemp = temphp;

        }
    }
}
