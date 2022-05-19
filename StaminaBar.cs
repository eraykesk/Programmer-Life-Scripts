using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider staminaBar;
    private float maxstamina = 100;
    private float currentstamina;
    public float speed = 1;
    public bool usingcomputer;
    public static StaminaBar instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        currentstamina = maxstamina;
        staminaBar.maxValue = maxstamina;
        staminaBar.value = maxstamina;

    }
    private void Update()
    {
        if (Movement.instance.usestamina == true)
        {
            currentstamina -= speed * Time.deltaTime;
            staminaBar.value = currentstamina;
        }
        if (Movement.instance.chargestamina == true)
        {
            currentstamina += speed * Time.deltaTime;
            staminaBar.value = currentstamina;
        }
    }
}
