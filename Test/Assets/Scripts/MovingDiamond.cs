using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingDiamond : MonoBehaviour
{
    /**
    * with help from tutorials from https://www.youtube.com/c/Antarsoft
    * Diamond of death moves with platform
    * **/

    public List<Transform> points;
    int goalPoint = 0;
    public Transform diamond;
    public float moveSpeed = 2;



    private void Update()
    {
        MoveToNextPoint();
    }

    void MoveToNextPoint()
    {
        //change the position of the plaftform
        diamond.position = Vector2.MoveTowards(diamond.position, points[goalPoint].position, Time.deltaTime * moveSpeed);
        //check if we are in very close proximity
        if (Vector2.Distance(diamond.position, points[goalPoint].position) < 0.1f)
        {
            //if so change goal point to the next one
            if (goalPoint == points.Count - 1)

                goalPoint = 0;
            else goalPoint++;



        }
    }
}
