using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandlerScript : MonoBehaviour
{
    [SerializeField] private Slider _speedSlider;
    [SerializeField] private Text _currentSpeedText;

    public void UpdateText()
    {
        _currentSpeedText.text = "Текущая скорость " + _speedSlider.value;
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
