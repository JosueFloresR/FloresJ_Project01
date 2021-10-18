//Josue Flores
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script component to update Score and Health Display

public class PlayerStats : MonoBehaviour
{

    //make connection with Text elements in the inspector
    [SerializeField]
    Text healthText;

    [SerializeField]
    Text scoreText;
    // Use this for initialization

    void Start()
    {
        UpdateDisplay();
    }

    void Update()
    { //called every frame - polling to see if data changed
        UpdateDisplay();
    }

    //This will eventually be executed as an event-listener so it is declared
    //as a public method
    public void UpdateDisplay()
    {
        healthText.text = "Health: " + GameData.instanceRef.Health;
        scoreText.text = "Score: " + GameData.instanceRef.Score;
    }
} // end Class