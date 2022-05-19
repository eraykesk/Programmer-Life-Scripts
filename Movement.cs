using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Animator animator;
    public GameObject InteractComputer, InteractChair,InteractCoffee, ComputerScreen,needrest,exitbutton;
    public bool usestamina, chargestamina, cancharge,cancoffee;
    float MovementSpeed = 4;
    public static Movement instance;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;
        if (movement != 0)
        {
            animator.SetInteger("Animate", 2);
        }
        else
        {
            animator.SetInteger("Animate", 0);
        }
        if (!Mathf.Approximately(0, movement))
        {
            transform.rotation = movement < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        }

        if (StaminaBar.instance.staminaBar.value < 20)
        {
            ComputerScreen.SetActive(false);
            InteractComputer.gameObject.SetActive(false);
            usestamina = false;
            needrest.SetActive(true);
        }
        else{
            needrest.SetActive(false);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Computer")
        {
            if (StaminaBar.instance.staminaBar.value>20)
            {
            InteractComputer.gameObject.SetActive(true);
            StaminaBar.instance.usingcomputer = true;
            }
        }
        if (other.gameObject.tag == "Chair")
        {
            if (StaminaBar.instance.staminaBar.value < 90)
            {
                InteractChair.gameObject.SetActive(true);
            }
            cancharge = true;
        }
        if (other.gameObject.tag == "Coffee")
        {
            InteractCoffee.gameObject.SetActive(true);
            cancoffee=true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Computer")
        {
            InteractComputer.gameObject.SetActive(false);
            StaminaBar.instance.usingcomputer = false;
        }
        if (other.gameObject.tag == "Chair")
        {
            InteractChair.gameObject.SetActive(false);
            cancharge = false;
            Movement.instance.chargestamina = false;
        }
        if (other.gameObject.tag == "Coffee")
        {
            InteractCoffee.gameObject.SetActive(false);
            cancoffee=false;
        }
    }
}
