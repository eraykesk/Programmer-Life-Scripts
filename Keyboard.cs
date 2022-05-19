using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && StaminaBar.instance.usingcomputer && StaminaBar.instance.staminaBar.value>=20)
        {
            Movement.instance.ComputerScreen.SetActive(true);
            Movement.instance.usestamina=true;
            Movement.instance.exitbutton.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Movement.instance.ComputerScreen.SetActive(false);
            Movement.instance.usestamina=false;
            Movement.instance.exitbutton.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.E) && StaminaBar.instance.staminaBar.value<90)
        {
            if(Movement.instance.cancharge==true){
                StaminaBar.instance.speed=1;
            Movement.instance.chargestamina=true;
            }
        }
        if(Input.GetKeyDown(KeyCode.E)&&Movement.instance.cancoffee==true){
            StaminaBar.instance.staminaBar.value+=10;
        }
    }
}
