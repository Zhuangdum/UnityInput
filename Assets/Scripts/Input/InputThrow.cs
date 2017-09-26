using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InputThrow : TouchInput
{
    public RectTransform pointer;
    public RectTransform inputArea;
    private Vector2 originCenter;

    public UnityAction<Vector2> dragAction;
    //拖拽中
    public override void OnDrag(PointerEventData eventData)
    {
        float maxDrag = Mathf.Max(inputArea.rect.width, inputArea.rect.height)+Mathf.Max(pointer.rect.width, pointer.rect.height);
        if ((eventData.position - originCenter).magnitude >= maxDrag / 2)
            pointer.position = originCenter + (eventData.position - originCenter).normalized * maxDrag / 2;
        else
            pointer.position = eventData.position;
        
        //派发拖拽事件
        base.OnDrag(eventData);
        if (dragAction != null)
            dragAction(eventData.delta);
    }
    //按钮被按下
    public override void OnPointerDown(PointerEventData eventData)
    {
        originCenter = pointer.position;
        pointer.anchoredPosition = Vector2.zero;

        base.OnPointerDown(eventData);
    }

    //按钮抬起
    public override void OnPointerUp(PointerEventData eventData)
    {
        pointer.anchoredPosition = Vector2.zero;
        base.OnPointerUp(eventData);
    }
}
