using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
    [Header("场景物体")]
    public GameObject target;
    [Header("输入模块")]
    public StrategyController inputController;

    [Header("UI Element")]
    public Dropdown dropDown;
    private void Start()
    {
        //初始化每个输入模块
        inputController.InitInputController();
        //设置默认模块
        inputController.SetStrategy(InputType.Normal);
        //注册和监听相关事件
        StrategyNormal strategy = (StrategyNormal)inputController.currentStrategy;
        strategy.inputFire.fireAction += PlayerFire;
        //初始化攻击模式的UI显示
    }
    private void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        Debug.DrawRay(ray.origin, ray.direction, Color.red);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 1000f))
        {
            target.transform.position = hitInfo.point;
        }
        else
        {
            target.transform.position = Vector3.zero;
        }
    }

    //玩家触发开火事件
    public void PlayerFire()
    {
        Debug.Log("=================Player Fire==================");
    }

    //玩家触发开火事件，同时获得蓄力值
    public void PlayerFire(float chargeValue)
    {
        Debug.Log("=================Player Charge Vlaue=================="+chargeValue);
    }

    //玩家拖拽按钮
    public void PlayerDrag(Vector2 dragDelta)
    {
//        Debug.Log("=================dragDelta================"+dragDelta);
        player.transform.RotateAround(player.transform.position, Vector3.up, angle*dragDelta.x);
        if (dragDelta.y != 0)
        {
            float angles = Mathf.Acos(Vector3.Dot(player.transform.up, mainCamera.forward))*Mathf.Rad2Deg;
            if(angles-angle*dragDelta.y<150 && angles-angle*dragDelta.y>30)
                mainCamera.RotateAround(player.transform.position, mainCamera.right, -angle*dragDelta.y);
        }
        if(dragDelta.x!=0)
            mainCamera.RotateAround(player.transform.position, player.transform.up, angle*dragDelta.x);
    }

    //控制玩家运动逻辑
    [Header("玩家相关")]
    public GameObject player;
    public GameObject bullet;
    public Transform mainCamera;
    [Header("操作相关")]
    public float angle = 10f;

    //切换武器是， 更换武器的类型， 取消之前的监听， 注册监听新的事件
    public void SwitchWeapon()
    {
        switch (dropDown.value)
        {
            case 0:
                inputController.SetStrategy(InputType.Normal);
                StrategyNormal strategyNormal = (StrategyNormal)inputController.currentStrategy;
                strategyNormal.inputFire.fireAction += PlayerFire;
                break;
            case 1:
                inputController.SetStrategy(InputType.Fire);
                StrategyFire strategyFire = (StrategyFire)inputController.currentStrategy;
                strategyFire.inputFire.fireAction += PlayerFire;
                strategyFire.inputThrow.dragAction += PlayerDrag;
                break;
            case 2:
                inputController.SetStrategy(InputType.Charge);
                StrategyCharge strategyCharge = (StrategyCharge)inputController.currentStrategy;
                strategyCharge.inputCharge.fireAction += PlayerFire;
                strategyCharge.inputThrow.dragAction += PlayerDrag;
                break;
            case 3:
                inputController.SetStrategy(InputType.Throw);
                StrategyThrow strategyThrow = (StrategyThrow)inputController.currentStrategy;
                strategyThrow.inputThrow.dragAction += PlayerDrag;
                break;
        }
    }
}
