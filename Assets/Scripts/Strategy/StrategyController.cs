using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class StrategyController : MonoBehaviour 
{
    public List<AbstractStrategy> strategiesList;
    private AbstractStrategy _currentStrategy;
    public AbstractStrategy currentStrategy
    {
        get{ return _currentStrategy;}
        set
        {
            if (_currentStrategy != null)
                _currentStrategy.ExitInput();
            if (value != null)
                value.EnterInput();
            _currentStrategy = value;
        }
    }
    public void SetStrategy(InputType type)
    {
        currentStrategy = strategiesList.FirstOrDefault(s => s.inputType == type);
    }

    public void InitInputController()
    {
        foreach (var item in strategiesList)
        {
            item.InitInput();
        }
    }
}
