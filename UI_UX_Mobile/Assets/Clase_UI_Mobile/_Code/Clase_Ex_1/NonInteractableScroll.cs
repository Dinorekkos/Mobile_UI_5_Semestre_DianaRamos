using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NonInteractableScroll : ScrollRect
{
    public override void OnInitializePotentialDrag(UnityEngine.EventSystems.PointerEventData eventData)
    {
        // Do nothing to disable dragging
    }
    public override void OnBeginDrag(PointerEventData eventData) { }
    public override void OnDrag(PointerEventData eventData) { }
    public override void OnEndDrag(PointerEventData eventData) { }
}
