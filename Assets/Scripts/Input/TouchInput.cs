using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/// <summary>
/// 说明：unity的UI组件里的position其实是相对与屏幕分辨率而言的（世界坐标概念）， anchorposition是相对于父物体的（本地坐标概念）
/// </summary>
public class TouchInput : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    public UnityEvent OnStartDragEvent;
    public UnityEvent OnDragEvent;
    public UnityEvent OnEndDragEvent;
    public UnityEvent OnTouchDownEvent;
    public UnityEvent OnTouchEvent;
    public UnityEvent OnTouchUpEvent;
    public UnityEvent OnPointerEnterEvent;
    public UnityEvent OnPointerClickEvent;
    public UnityEvent OnPointerExitEvent;

    public bool useDeadZone;
    public float deadZone = 0.01f;
    private Vector2 startPos;
    //开始拖拽
    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("start drag");
        //deadzone
        startPos = eventData.position;
        if (OnDragEvent != null)
            OnDragEvent.Invoke();
    }

    //拖拽中
    public virtual void OnDrag(PointerEventData eventData)
    {
        if(!useDeadZone || (eventData.position-startPos).magnitude>=deadZone)
        {
            //派发拖拽事件
            if (OnStartDragEvent != null)
                OnStartDragEvent.Invoke();
        }
    }

    //结束拖拽
    public virtual void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("end drag");
        //deadzone
        startPos = Vector2.zero;
        if (OnEndDragEvent != null)
            OnEndDragEvent.Invoke();
    }

    //按钮被按下
    public virtual void OnPointerDown(PointerEventData eventData)
    {
//        Debug.Log("touch down");
        if (OnTouchDownEvent != null)
            OnTouchDownEvent.Invoke();
    }

    //按钮抬起
    public virtual void OnPointerUp(PointerEventData eventData)
    {
//        Debug.Log("touch up");
        if (OnTouchUpEvent != null)
            OnTouchUpEvent.Invoke();
    }

    //鼠标进入触控区域内
    public virtual void OnPointerEnter(PointerEventData eventData)
    {
//        Debug.Log("pointer enter");
        if (OnPointerEnterEvent != null)
            OnPointerEnterEvent.Invoke();
    }

    //鼠标在触控区域内时， 点击按钮
    public virtual void OnPointerClick(PointerEventData eventData)
    {
//        Debug.Log("click");
        if (OnPointerClickEvent != null)
            OnPointerClickEvent.Invoke();
    }

    //鼠标离开触控区域
    public virtual void OnPointerExit(PointerEventData eventData)
    {
//        Debug.Log("pointer exit");
        if (OnPointerExitEvent != null)
            OnPointerExitEvent.Invoke();
    }
}
