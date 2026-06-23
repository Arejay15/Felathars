using UnityEngine;

public class EnemyIndicator : MonoBehaviour
{
   [SerializeField] private GameObject locatedEnemy;
   [SerializeField] private Transform player;

    private RectTransform pointerRectTransform;

    private void Awake()
    {
        pointerRectTransform = transform.Find("Pointer").GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (locatedEnemy == null || player == null) return;
        Vector3 targetPosition = locatedEnemy.transform.position;
        Vector3 dir = (targetPosition - player.position).normalized;
        float angle = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;
        angle -= 90f;
        pointerRectTransform.localEulerAngles = new Vector3(0, 0, angle);
        float borderSize = 25f;
        Vector3 targetScreenPoint = Camera.main.WorldToScreenPoint(targetPosition);

        if (targetScreenPoint.z < 0)
        {
            pointerRectTransform.gameObject.SetActive(false);
            return;
        }

        bool isOffScreen =
            targetScreenPoint.x <= borderSize || targetScreenPoint.x >= Screen.width - borderSize ||
            targetScreenPoint.y <= borderSize || targetScreenPoint.y >= Screen.height - borderSize;

        pointerRectTransform.gameObject.SetActive(isOffScreen);

        if (isOffScreen)
        {
            Vector3 cappedTargetScreenPosition = targetScreenPoint;
            cappedTargetScreenPosition.x = Mathf.Clamp(cappedTargetScreenPosition.x, borderSize, Screen.width - borderSize);
            cappedTargetScreenPosition.y = Mathf.Clamp(cappedTargetScreenPosition.y, borderSize, Screen.height - borderSize);
            pointerRectTransform.position = cappedTargetScreenPosition;
        }
    }
}
