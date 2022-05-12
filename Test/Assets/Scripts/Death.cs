using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private GameObject HealthBar;
    private Vector2 HealthTransform;
    private GameObject Hero;
    public Vector3 ExplodingObject;
    public GameObject Explosion;
    private bool NotKilledYet = true;
    public AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        HealthBar = GameObject.Find("HB");
        Hero = GameObject.Find("Hero");
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(HealthBar.transform.localScale.x <= 0)
        {
            // The following makes sure the death animation is only triggeres once and not on every frame
            if (NotKilledYet)
            {
                ExplodingObject.Set(Hero.transform.position.x, Hero.transform.position.y, 0);
                Instantiate(Explosion, ExplodingObject, Quaternion.identity);
                
                if(source != null)
                {
                    source.Play();
                }
                Destroy(Hero);
                NotKilledYet = false;
            }
        }
    }
}
