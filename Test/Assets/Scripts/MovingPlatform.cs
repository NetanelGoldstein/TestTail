using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    /**
     * 
     *with help from tutorials from https://www.youtube.com/c/Antarsoft
    * platforms move left and right , timed interval
    * **/
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
            


        }
    }

}
