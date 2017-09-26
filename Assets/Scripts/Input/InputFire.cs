using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InputFire : MonoBehaviour
{
    public UnityAction fireAction;
    [Range(0.2f, 1f)]
    public float coldTime = 1f;
    public Animator animator;

    //===============================
    private Coroutine _Co_Fire;
    private Coroutine Co_Fire
    {
        get{return _Co_Fire;}
        set
        {
            if (_Co_Fire != null)
                StopCoroutine(_Co_Fire);
            _Co_Fire = value;
        }
    }

    public void StartFire()
    {
        isLongPress = false;
        Co_Fire = StartCoroutine(FireCoroutine());
    }

    private bool isLongPress;
    IEnumerator FireCoroutine()
    {
        animator.SetBool("TouchDown", true);
        while (true)
        {
            yield return new WaitForSeconds(coldTime);
            isLongPress = true;
            if (fireAction != null)
                fireAction();
        }
    }

    public void StopFire()
    {
        if (!isLongPress)
            if (fireAction != null)
                fireAction();
        
        Co_Fire = null;
        animator.SetBool("TouchDown", false);
        isLongPress = false;
    }
}
