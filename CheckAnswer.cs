using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CheckAnswer : MonoBehaviour
{
    public TMP_InputField tMP_InputField;
    public TextMeshProUGUI dialogboxtext, question,citylevel;
    public GameObject finishgame;
    public Image image;
    public Sprite correct, wrong;
    int questionindex = 0;
    private string[] questions = new string[]{
    "Write the python code that prints 'hello world' to the screen.",
    "Write the c# code that prints the sum of the numbers a and b",
    "Write the code that for loops the variable 'example' from 1 to 10.",
    "Write the c# code that prints the square root of 25 to the screen.",
    "Write the C# code that prints today's date and time to the screen."
    };

    private string[] answers = new string[] { 
    "print(\"hello world\")", 
    "Console.WriteLine(a+b);",
    "for example in range(1,11)",
    "Console.WriteLine(Math.Sqrt(25));",
    "Console.WriteLine(DateTime.Now);"
    };
    private string[] city = new string[] { 
    "Istanbul",
    "Berlin",
    "Dublin",
    "Londra",
    "San Fransisco"
    };

    private void Start()
    {
        question.text = questions[questionindex];
        citylevel.text=city[questionindex];
    }
    public void Check()
    {
        if (tMP_InputField.text == answers[questionindex])
        {
            dialogboxtext.text = "Correct Answer!!";
            image.sprite = correct;
            if (questionindex+1 < questions.Length)
            {
                questionindex++;
                question.text = questions[questionindex];
                citylevel.text=city[questionindex];
            }
            else{
                finishgame.SetActive(true);
            }

            
        }
        else
        {
            dialogboxtext.text = "Wrong Answer!!";
            image.sprite = wrong;
            StaminaBar.instance.speed*=2;
        }
    }
}
