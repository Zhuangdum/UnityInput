using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 投掷输入类型
/// </summary>
public class StrategyThrow : AbstractStrategy
{
    public InputThrow inputThrow;
    public override void ExitInput()
    {
        inputThrow.dragAction = null;
        base.ExitInput();
    }
}
