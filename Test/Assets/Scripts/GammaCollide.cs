using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GammaCollide : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        source.Play();
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
            source.Play();
        }
        
    }
}
   