using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MGState : IStateBase
{

    /// <summary>
    /// The scene.
    /// </summary>
    private GameScene scene;

    /// <summary>
    /// Gets the scene number - enum
    /// </summary>
    /// <value>The scene.</value>
    public GameScene Scene
    {
        get { return scene; }
    }

    //GameScene objectRefs
    private Button btnOption1, btnOption2;

    /// <summary>
    /// Initializes a new instance of the <see cref="MGState"/> class.
    /// </summary>
    public MGState()
    {
        scene = GameScene.Minigame; //IMPORTANT:  make sure this matches Unity Scene Name
    }

    /// <summary>
    /// Similar to Unity Start() 
    /// exectued once, after scene is loaded - called from StateManager
    /// Used to initialize object references - can be used to cache object references
    /// </summary>
    public void InitializeObjectRefs()
    {
        btnOption1 = GameObject.Find("ButtonOption1").GetComponent<Button>();
        btnOption1.onClick.AddListener(LoadScene2);

        Debug.Log("Initialize Refs - Scene2State");

        btnOption2 = GameObject.Find("ButtonOption2").GetComponent<Button>();
        btnOption2.onClick.AddListener(LoadScene4);

        Debug.Log("Initialize Refs - Scene4State");
    }

    /// <summary>
    /// Event handler - called when endBtn is clicked
    /// Loads the end scene.
    /// public method can be executed by button onClick event
    /// </summary>
    public void LoadScene2()
    {
        Debug.Log("Leaving MGScene going to Scene2");
        StateManager.instanceRef.SwitchState(GameScene.Scene2);
    }
    public void LoadScene4()
    {
        Debug.Log("Leaving MGScene going to Scene4");
        StateManager.instanceRef.SwitchState(GameScene.Scene4);
    }
}
