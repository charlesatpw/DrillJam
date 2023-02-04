using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class SliderStatDisplay : StatDisplay
{
    [SerializeField]
    protected Slider statSlider;

    public void Init(Action valueChangeCallback, int minValue, int maxValue)
    {
        onValueChanged = valueChangeCallback;
        statSlider.minValue = minValue;
        statSlider.maxValue = maxValue;
    }

    public override void SetAmount(int amount)
    {
        if (statSlider.value != amount)
        {
            onValueChanged?.Invoke();
        }

        statSlider.value = amount;
    }
}
