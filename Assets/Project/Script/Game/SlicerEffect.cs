using UnityEngine;


using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlicerEffect : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public LineRenderer lineRenderer;
    private bool isDrawing = false;

    private void Awake()
    {
        lineRenderer.positionCount = 0;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDrawing = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDrawing)
        {
            Vector2 localPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(GetComponent<RectTransform>(), eventData.position, eventData.pressEventCamera, out localPoint);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, localPoint);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDrawing = false;
        lineRenderer.positionCount = 0;
    }
}