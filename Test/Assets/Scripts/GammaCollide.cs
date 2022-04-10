using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GammaCollide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Test Start Log");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "Hero")
        {
            Debug.Log("Hit Hero");
        }
        
    }
}
