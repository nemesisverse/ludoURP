using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class StonePath : MonoBehaviour
{
    //StonePath  = StonePathForRed //

    [SerializeField] public List<Waypoint> Path = new List<Waypoint>();


    public int stoneID;
    public bool isLock ;
    public Waypoint Base;
    public Waypoint StartingPoint;
    public Waypoint EndingPoint;
    //public Waypoint CurrentNode;
    public Waypoint nextStep;

    int steps = 0;

    GameManager gameManager;


    public int currentNodeIndex = 0;






    // Start is called before the first frame update
    void Start()
    {
        GameObject otherObject = GameObject.Find("GameManagerr");

        if (otherObject != null)
        {
            gameManager = otherObject.GetComponent<GameManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
       // int roll = gameManager.RollDice();

       //EndStepOfRoll = Path[steps];
        //Debug.Log(EndStepOfRoll);
    }


    public IEnumerator Unlock()
    {
        float travelPercent = 0f;

        while (travelPercent < 1f)
        {
            travelPercent += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position,StartingPoint.transform.position, travelPercent);
            yield return new WaitForEndOfFrame();
        }
    }

   public IEnumerator MoveOnTrack(int steps)
   {
        int targetNodeIndex = currentNodeIndex + steps;
        

        if(targetNodeIndex < Path.Count)
        {
            float travelPercent = 0f;

            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime;

               
                    transform.position = Vector3.Lerp(transform.position, Path[targetNodeIndex].transform.position, travelPercent);


               //if ((transform.position - Path[targetNodeIndex].transform.position) == Vector3.zero)
               //{
               //    gameManager.RollDiceDelay();
               //
               //}

                yield return new WaitForEndOfFrame();
                    currentNodeIndex = targetNodeIndex;

             
            }




        }
    
   
   }



}


