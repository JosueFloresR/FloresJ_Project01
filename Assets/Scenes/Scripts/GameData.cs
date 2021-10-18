//Josue Flores
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData instanceRef;  //null    singleton global variable

    private int score;
    private int health;

    public int Score   //PROPERTY
    {
        get { return score; } //read Only Access
    }

    public int Health
    {
        get { return health; }  ///readOnly access

    }

    //TODO Add Properties for Score, Health

    void Awake()
    {
        if (instanceRef == null)
        {
            instanceRef = this;   //the object currently executing the code
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            DestroyImmediate(this.gameObject);
            Debug.Log(" Destroyed GameData Imposter ");
        }

        score = 0;
        health = 100;


    } //end of awake

    //Increases Score, called in PlayerController
    public void Add(int value)
    {
        score += value;
        Debug.Log("Score updated " + score);
    }

    public void TakeDamage(int value)
    {
        health -= value; //subtract points from health
        Debug.Log("Health updated " + health);
        if (health <= 0)
        {
            Debug.Log("Health is ZERO gameOver ");
        }
    }

    public void ResetGameData()
    {
        score = 0;
        health = 100;
    }

}// end of GameData
