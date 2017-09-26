using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 普通攻击输入类型
/// </summary>
public class StrategyNormal : AbstractStrategy
{
    public InputFire inputFire;

    public override void ExitInput()
    {
        inputFire.fireAction = null;
        base.ExitInput();
    }
}
