using System;
using UnityEngine;
using UnityEngine.UI;

public class SliderBar : MonoBehaviour
{
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    public void SetMaxValue(int maxValue)
    {
        _slider.maxValue = maxValue;
        _slider.value = maxValue;
    }
    public void SetValue(int val)
    {
        _slider.value = val;
    }
}
