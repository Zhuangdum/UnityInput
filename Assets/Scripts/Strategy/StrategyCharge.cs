using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 蓄力输入类型
/// </summary>
public class StrategyCharge : AbstractStrategy 
{
    public InputCharge inputCharge;
    public InputThrow inputThrow;

    public override void ExitInput()
    {
        inputCharge.fireAction = null;
        inputThrow.dragAction = null;
        base.ExitInput();
    }
}
