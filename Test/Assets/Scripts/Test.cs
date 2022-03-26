using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * This is a test comment 3
 */

public class Test : MonoBehaviour
{
    //integer representing the players health
    int _playerHealth = 100;

    //Inside a property, you need at least one get and set method
    //This property establishes the player's health
    public int PlayerHealth {

        get{
            return _playerHealth;
        }
    
        set{
            _playerHealth = value;
        }

    }
    //This property will display the player's health as a percentage
    public string DisplayHealthPercentage{

        get{
            string health =  _playerHealth.ToString() + "%";
            return health;
        }

    }



    // Start is called before the first frame update
    void Start()
    {
        TakeDamage(50);

        //Outputs information to the console in Unity for testing

       // Debug.Log(DisplayHealthPercentage);
       // Debug.Log(ShowDamage());
       Debug.Log(PlayerHealth);
       
    }

     void TakeDamage(int damage){//the parentheses show this is a method versus property
        
        PlayerHealth -= damage;//takes 10 points of damage

    }

/*
    int ShowDamage(){
        PlayerHealth -= 10;
        return PlayerHealth;
    }
*/
    
}
