using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum InputType
{
    Default = 0,
    Normal = 1,
    Fire = 2,
    Charge = 3,
    Throw = 4
}
public class AbstractStrategy : MonoBehaviour 
{
    public InputType inputType;

//    //按下
//    public virtual void TouchDown(){}
//    //抬起
//    public virtual void TouchUp(){}
//    //按住
//    public virtual void Touching(){}
//    //拖拽
//    public virtual void Drag(){}

    //初始化各个输入模块
    public virtual void InitInput()
    {
        this.gameObject.SetActive(false);
    }
    //进入输入
    public virtual void EnterInput()
    {
        this.gameObject.SetActive(true);
    }
    //退出输入模块
    public virtual void ExitInput()
    {
        this.gameObject.SetActive(false);
    }
}