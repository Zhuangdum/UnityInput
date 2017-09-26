using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 普通攻击输入类型
/// </summary>
public class StrategyFire : AbstractStrategy
{
    public InputFire inputFire;
    public InputThrow inputThrow;

    public override void ExitInput()
    {
        inputFire.fireAction = null;
        inputThrow.dragAction = null;
        base.ExitInput();
    }
}
