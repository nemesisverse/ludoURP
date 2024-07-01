using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;
using TMPro;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{

    /// <summary>
    public TextMeshProUGUI Text;
    /// </summary>

   public GameObject GameManagerr1;

    bool switchingPlayer;

    public bool hasturn;
    public bool haswon;
    //public bool isLock;
    public bool isSafe;
    StonePath stonepath;

    int steps = 0;


    public StonePath[] mystones;
    public enum player_types
    {
        cpu,
        human ,
        noplayer,
    }
           

    public player_types playertype;

    public enum states
    {
        Roll_Dice,
        Waiting,
        Switch_Player
    }

    public states state;
    public int active_player;

    public static int rollnum;
    public int RollDice()
    {
        int roll = Random.Range(1, 7);
        Debug.Log(roll);
        Text.text = roll.ToString();



        int chooseStone = Random.Range(0, 4);

        if (roll == 6)
        {
            //unlock
            //move stone  by 6

            if (mystones[chooseStone].isLock == true)
            {
                mystones[chooseStone].StartCoroutine(mystones[chooseStone].Unlock());
                mystones[chooseStone].isLock = false;


            }

            else
            {
                if (mystones[chooseStone].isLock == false)
                {


                    mystones[chooseStone].StartCoroutine(mystones[chooseStone].MoveOnTrack(roll));
              

                }
            }

           

        }
        else 
        {
           
            // isLock == false
            //check which one is unlock to play the move

            for (int i = 0; i < 4; i++)
            { 
                if(mystones[i].isLock == false)
                {
                    mystones[i].StartCoroutine(mystones[i].MoveOnTrack(roll));
                    break;
                }
                
            
            }

            


            


        }


        return roll;
    }

    public IEnumerator RollDiceDelay()
    {
        
        yield return new WaitForSeconds(0);
        RollDice();


    }


   


    public IEnumerator SwitchPlayer()
    {
       // if(switchingPlayer)
       // {
       //     yield break;
       // }
       //
       // switchingPlayer = true;
        yield return new WaitForSeconds(1.3f);
        GameManagerr1.SetActive(true);
        gameObject.SetActive(false);


        //switchingPlayer = false;



    }

 

    void Start()
    {
        if (Text == null)
        {
            Text = GameObject.Find("DiceRolled").GetComponent<TextMeshProUGUI>();
            Text.text = "start";
        }
        playertype = player_types.cpu;

        GameObject otherGameManager1 = GameObject.Find("GameManagerr1");
    }

    // Update is called once per frame
    void Update()
    {//initially state var is developed to store the value of enum index of states and 
        //default its 0 i guess , it has to be something so its 0 lets take
       
            if (playertype == player_types.cpu)
            {
                switch (state)
                {
                    case states.Roll_Dice:
                        {
                        StartCoroutine(RollDiceDelay());
                        StartCoroutine(SwitchPlayer());
                        state = states.Waiting;
                        }

                        break;

                    case states.Waiting:
                        {


                        }
                        break;
                    case states.Switch_Player:
                        {

                        }
                        break;
                }

            }


 

    }
}
