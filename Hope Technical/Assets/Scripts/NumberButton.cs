using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberButton : MonoBehaviour
{
    public TextMeshProUGUI text;

    public void SetNumber(int number)
    {
        text.text = number.ToString();
    }
}
