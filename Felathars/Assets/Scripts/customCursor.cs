using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    [SerializeField] private Transform playerModel;
    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        Cursor.visible = false;
    }

    private void Update()
    {
        rectTransform.position = Input.mousePosition;
        float rotation = -playerModel.eulerAngles.y;
        rectTransform.rotation = Quaternion.Euler(0f, 0f, rotation);
    }
}