using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// 实现方式改为通过蓄力时间来调整， 所以之前的方式一和二可能会过期
/// </summary>
public class InputCharge : MonoBehaviour
{
    //最小蓄力时间
    public float min_Time;

//实现方式一
//    //每秒蓄力增量
//    public float delta_Force;
//
//    public float delta_Time = 1f;

//============================实现方式二==================================
//    private float startTime;
//    private float calcTime;

//============================实现方式三==================================
    public float timeScale = 0.5f;

    public UnityAction<float> fireAction;

    public Image backImage;

    private float chargedTime;

    private Coroutine _Co_Charge;
    private Coroutine Co_Charge
    {
        get{return _Co_Charge;}
        set
        {
            if (_Co_Charge != null)
                StopCoroutine(_Co_Charge);
            _Co_Charge = value;
        }
    }

    public void StartCharge()
    {
        chargedTime = 0;
        backImage.fillAmount = 0;
        Co_Charge = StartCoroutine(ChargeCoroutine());
        //========实现方式二================
//        startTime = Time.time;
//        calcTime = Time.time;
    }

    IEnumerator ChargeCoroutine()
    {
        //============================实现方式一==================================
//        while (true)
//        {
//            if (chargedForce < max_Force)
//            {
//                chargedForce += delta_Force;
//                //9.5+5>10, 如果没有预防， 那么会出现有一帧的蓄力值大于最大值
//                if (chargedForce >= max_Force)
//                    chargedForce = max_Force;
//            }
//            else
//                chargedForce = max_Force;
//            Debug.Log("charge value===>>>>" + chargedForce);
//            backImage.fillAmount = chargedForce / max_Force;
//            yield return new WaitForSeconds(delta_Time);
//        }

        //============================实现方式二==================================
//        while (true)
//        {
//            if ((Time.time - startTime) >= delta_Time)
//            {
//                if (chargedForce < max_Force)
//                {
//                    chargedForce += delta_Force;
//                    //9.5+5>10, 如果没有预防， 那么会出现有一帧的蓄力值大于最大值
//                    if (chargedForce >= max_Force)
//                        chargedForce = max_Force;
//                }
//                else
//                    chargedForce = max_Force;
//                Debug.Log("charge value===>>>>" + chargedForce);
//                startTime = Time.time;
//            }
//            backImage.fillAmount = (Time.time-calcTime) / max_Force;
//            yield return null;
//        }

        //============================实现方式三==================================
        while (true)
        {
            if (chargedTime < min_Time)
            {
                chargedTime += Time.deltaTime*timeScale;
                //9.5+5>10, 如果没有预防， 那么会出现有一帧的蓄力时间大于最大值
                if (chargedTime >= min_Time)
                    chargedTime = min_Time;
            }
            else
                chargedTime = min_Time;
            backImage.fillAmount = chargedTime / min_Time;
            yield return null;
        }
    }

    public void StopCharge()
    {
        if (chargedTime < 1)
        {
            //玩家取消选中目标
        }
        else
        {
            //玩家确定选中目标， 并开火
            if (fireAction != null)
                fireAction(chargedTime);   
        }
        Co_Charge = null;
        chargedTime = 0;
        backImage.fillAmount = 0;
        //========实现方式二================
//        startTime = 0;
//        calcTime = 0;
    }
}
