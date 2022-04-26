using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxDeath : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject Fox;
    public GameObject Explosion;
    private GameObject Hero;
    public Vector3 ExplodingObject;
    private GameObject HeroGlow;
    private GameObject RedGamma;
    public AudioSource source;
    void Start()
    {
        Fox = GameObject.Find("Fox");
        Hero = GameObject.Find("Hero");
        HeroGlow = GameObject.Find("HeroGlow");
        RedGamma = GameObject.Find("RedGamma");
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "Hero")
        {
            if(HeroGlow.GetComponent<SpriteRenderer>().enabled == true)
            {
                if (source != null)
                {
                    source.Play();
                }
                ExplodingObject.Set(Fox.transform.position.x, Fox.transform.position.y, 0);
                Instantiate(Explosion, ExplodingObject, Quaternion.identity);
                
                
                Destroy(Fox);
                Destroy(RedGamma);
            }
        }
    }

}
