using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grow1 : MonoBehaviour
{
    // with help from https://gamedev.stackexchange.com/questions/105378/how-to-change-the-transparency-of-an-object-in-using-code
    //
    // This object grows. In addition, the Alpha value (Transparency) shrinks. 
    // When Alpha hits 0, (i.e. it's invisible) the object returns to it's original size and alpha updates to partially visible
    // in short, it repeatedly grows, disappears, and starts again

    private Material currentMat;
    public float speed = .3f;
    public float disappear = .01f;
    public float killValue = .5f;
    public float newAlpha = .5f;
    Vector2 temp;
    Vector2 startSize;
    Vector2 startPos;
    
    // Start is called before the first frame update
    void Start()
    {
        currentMat = gameObject.GetComponent<Renderer>().material;
        startSize = transform.localScale;
        startPos = transform.position;
       
    }

    // Update is called once per frame
    void Update()
    {
        temp = transform.localScale;
        temp.x += speed;
        temp.y += speed;
        transform.localScale = temp;
        ChangeAlpha(disappear);
        // Measures if transparency at minimum threshold
        if(currentMat.color.a <= killValue)
        {
           // sets it to original size, shape, and tranparency of newAlpha
            transform.localScale = startSize;
            ChangeAlpha(-newAlpha);
            transform.position = startPos;

        }    
    }
    void ChangeAlpha(float alphaVal)
    {
        Color oldColor = currentMat.color;
        Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, oldColor.a - alphaVal);
        currentMat.SetColor("_Color", newColor);

    }
}
