using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Singleton Object to store all GameData
/// Is not destroyed when changing scenes
/// </summary>
public class GameData : MonoBehaviour
{
    public static GameData instanceRef; //null //variable that can point to a GameData object

    private int score;
    private int health;

    //TODO - Add properties: Score, Health

    // Awake is called before Start() is called on any GameObject
    // Other objects have dependencies on this object so it must be created first
    void Awake()
    {
        if (instanceRef == null)  //this code hasn't been executed before
        {
            instanceRef = this; //point to object instance currently executing this code
            DontDestroyOnLoad(this.gameObject); //don't destroy the gameObject this is attached to
        }
        else  //this object is not the first, it's an imposter that must be destroyed
        {
            DestroyImmediate(this.gameObject);
            Debug.Log("Destroy GameData Imposter");
        }

        //initialize after destroying imposters
        score = 0;
        health = 100;


    } //end Awake

    //will be executed in PlayerController when colliding with a collectible
    public void Add(int value)
    {
        score += value;
        Debug.Log("Score updated: " + score); //display score in console
    }

    public void TakeDamage(int value)
    {
        health -= value;
        Debug.Log("health updated: " + health); //display health in console
        if (health <= 0)
        {
            Debug.Log("Health less than 0"); //display health in console

        }
    }

    //called when restarting the miniGame
    public void ResetGameData()
    {
        score = 0;
        health = 100;
    }


}//end class GameData
