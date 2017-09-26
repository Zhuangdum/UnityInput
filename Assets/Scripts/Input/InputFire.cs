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
        Co_Fire = StartCoroutine(FireCoroutine());
    }

    IEnumerator FireCoroutine()
    {
        animator.SetBool("TouchDown", true);
        while (true)
        {
            if (fireAction != null)
                fireAction();
            yield return new WaitForSeconds(coldTime);
        }
    }

    public void StopFire()
    {
        Co_Fire = null;
        animator.SetBool("TouchDown", false);
        StopAllCoroutines();
    }
}
