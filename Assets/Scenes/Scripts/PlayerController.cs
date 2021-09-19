using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //create custom data-type
    public enum HeroState { idle = 0, walk = 1, jump = 2 } //custom data-type 
    public HeroState currentHeroState;  //variable to keep track of current animation state

    private bool facingRight = true; // initialize when declare (first way),  false by default

    private Animator animator; //obj-reference variable to access the animator component on this gameObject

    //inspector is the second way to initialize a value

    // Start is called before the first frame update
    private void Start()
    {
        facingRight = true; //final way to initialize, overrides all prior settings
        animator = GetComponent<Animator>(); //<T>  //call a method - make connection to component on gameObject in Unity scene
        animator.SetInteger("HeroState", (int)HeroState.idle);
    }

    //Fixed update used for physics, to give smooth motion, called at consistent time increments
    void FixedUpdate()
    {
        float inputX = Input.GetAxis("Horizontal"); // key input:  -1, 0, 1
        bool isWalking = Mathf.Abs(inputX) > 0;

        //check for spacebar or w, up keys to indicate vertical jump
        bool jumpPressed = Input.GetButtonDown("Jump") || Input.GetAxis("Vertical") > 0;


        if (isWalking)
        {
            animator.SetInteger("HeroState", (int)HeroState.walk);
        }
        else
        {
            animator.SetInteger("HeroState", (int)HeroState.idle);
        }


        if (jumpPressed)
        {
            animator.SetInteger("HeroState", (int)HeroState.jump);
        }

    }


}  //end class PlayerController