using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{



    public List<Transform> points;
    int goalPoint = 0;
    public Transform platform;
    public float moveSpeed = 2;



    private void Update()
    {
        MoveToNextPoint();
    }

    void MoveToNextPoint()
    {
        //change the position of the plaftform
        platform.position = Vector2.MoveTowards(platform.position,points[goalPoint].position,Time.deltaTime * moveSpeed );
        //check if we are in very close proximity
        if (Vector2.Distance(platform.position, points[goalPoint].position) < 0.1f)
        {
            //if so change goal point to the next one
            if (goalPoint == points.Count - 1)
            
                goalPoint = 0;
            else goalPoint++;
            

            //Check if we reached the last point, reset to first point
            //0 1 2 3 (total 4)



        }
    }

}
/**
   public float speed = 2f; //speed of the platform
   public int startingPoint; //starting index (position of the platform)
   public Transform[] points; //An array of transfomr points (positions wehere the platform needs to move)

   private int i; //index of the array



   // Start is called before the first frame update
   void Start()
   {
       transform.position = points[startingPoint].position; //Settting the position of the platform to
                                                           //the position of the points using index "startingPoint"
   }

   // Update is called once per frame
   void Update()
   {


       if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
       {
           i++;
           if (i == points.length) //check if the platform was on teh last point after the index increase
           {
               i = 0; //reset the index
           }
       }
       //Moving the platform to the point position with the index "i"
       transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);

   } **/