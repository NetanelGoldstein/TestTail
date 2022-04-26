using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnGlow : MonoBehaviour
{
    //This script can be attached to an game object with a 2d collider.
    // i

    public AudioSource source;
    private GameObject HeroGlow;
    public int SetCounterTo;
    float counter;
    

    void Start()
    {
        source = GetComponent<AudioSource>();
        HeroGlow = GameObject.Find("HeroGlow");
        HeroGlow.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // This counts down counter, when it hits zero, the glow turns off
        if(counter > 0)
        {
            counter--;
        }
        if(counter == 0)
        {
            HeroGlow = GameObject.Find("HeroGlow");
            HeroGlow.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        // checks hero hit MagicPower, turns on hero glow
        if (col.gameObject.name == "Hero")

        {
            HeroGlow = GameObject.Find("HeroGlow");
            HeroGlow.GetComponent<SpriteRenderer>().enabled = true;
            if (source != null)
            {
                source.Play();
            }
            Debug.Log("TurnOnGlow Script registered collision");
            counter = SetCounterTo;
            
            
            
        }

    }
}
