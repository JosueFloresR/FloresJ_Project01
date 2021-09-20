using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PickupType
{
    crate, crystal, rock, star                 //add as needed
}


public class PickUp : MonoBehaviour
{

    [SerializeField]  //allows modification in inspector 
    private int value;

    //read-only property
    public int Value
    {
        get { return value; }
    }


    public PickupType type; //what is the PickupType of this object

}// end class