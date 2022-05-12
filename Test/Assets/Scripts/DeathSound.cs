using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSound : MonoBehaviour
{

    private GameObject HealthBar;
    public AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        HealthBar = GameObject.Find("HB");
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(HealthBar.transform.localScale.x == 0)
        {
            if(source != null)
            {
                source.Play();
            }
        }
    }
}
