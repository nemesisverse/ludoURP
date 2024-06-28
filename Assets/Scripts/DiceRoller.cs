using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiceRoller : MonoBehaviour
{
    //this script is for text in textmeshpro
    TMP_Text Text;

    //GameManager diceNumber;
 
        

        
    private void Start()
    {
        Text = GetComponent<TMP_Text>();
        Text.text = "Start";
    }


    private void Update()
    {
        
        //int Roll = diceNumber.RollDice();
        //Text.text = Roll.ToString();
    }
}
