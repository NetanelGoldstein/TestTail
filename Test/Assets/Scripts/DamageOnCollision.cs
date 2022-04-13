using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
    //This script can be attached to an game object with a 2d collider.
    // it will deduct whatever "Damage" is set to from the Health Bar
    // It also has an audio source component that can sound on contact

    public AudioSource source;
    private GameObject HealthBar;
    private Vector2 HealthTransform;
    public float Damage = .3f;
   
    void Start()
    {
        source = GetComponent<AudioSource>();
        HealthBar = GameObject.Find("HB");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        // checks if hit hero, and if ray is still visible
        if(col.gameObject.name == "Hero" && this.GetComponent<Renderer>().material.color.a >= .1) // color.a >=1 means at least 10% visible
        
        {

            Debug.Log("Hit Hero");
            if(source != null)
            {
                source.Play();
            }
            Vector2 temp;
            
            temp = HealthBar.transform.localScale;
            temp.x -= Damage;
            if (temp.x < 0)
            {
                temp.x = 0;
            }
            HealthBar.transform.localScale = temp;
        }
        
    }
}
   