using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreathBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxBreath(int breath)
    {
        slider.maxValue = breath;
        slider.value = breath;
    }

     public void SetBreath(int breath)
    {
        slider.value = breath;
    }
}
