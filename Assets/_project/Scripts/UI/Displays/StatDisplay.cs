using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatDisplay : MonoBehaviour
{
    [SerializeField]
    protected TextMeshProUGUI amountText;

    public void SetAmountText(string amount)
    {
        amountText.text = amount;
    }

}
