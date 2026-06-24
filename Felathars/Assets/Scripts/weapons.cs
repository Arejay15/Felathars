using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu]

public class weapons : ScriptableObject
{
    public enum Mode { Single, Burst, Spread }
    [SerializeField] public Mode mode;
    [SerializeField] public gamemanager.ColorType colorType;
    [SerializeField, Range(0.1f, 3f)] public float fireRate;
    [SerializeField] public GameObject bullet;
    [SerializeField] public Color materialColor = Color.white;
    [Header("If Burst")]
    [SerializeField, Range(0.05f, 0.5f)] public float burstSpeed = 0.1f;
    [Header("If Burst/Spread")]
    [SerializeField, Range(2, 15)] public int shotNum;
    [Header("If Spread")]
    [SerializeField, Range(5, 45)] public int spreadAngle;


    






}
