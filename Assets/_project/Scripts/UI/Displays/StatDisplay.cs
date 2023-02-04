using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class StatDisplay : MonoBehaviour
{
    [SerializeField]
    protected TextMeshProUGUI amountText;

    protected Action onValueChanged;

    public virtual void SetAmount(string amount)
    {
        amountText.text = amount;
    }

    public virtual void SetAmount(int amount, string suffix, string prefix)
    {
        amountText.text = prefix + amount.ToString() + suffix;
    }
}
