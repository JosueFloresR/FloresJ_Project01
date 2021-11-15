using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene2State : IStateBase
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
    /// Initializes a new instance of the <see cref="Scene2State"/> class.
    /// </summary>
    public Scene2State()
    {
        scene = GameScene.Scene2; //IMPORTANT:  make sure this matches Unity Scene Name
    }

    /// <summary>
    /// Similar to Unity Start() 
    /// exectued once, after scene is loaded - called from StateManager
    /// Used to initialize object references - can be used to cache object references
    /// </summary>
    public void InitializeObjectRefs()
    {
        btnOption1 = GameObject.Find("ButtonOption1").GetComponent<Button>();
        btnOption1.onClick.AddListener(LoadBeginScene);

        Debug.Log("Initialize Refs - BeginState");

        btnOption2 = GameObject.Find("ButtonOption2").GetComponent<Button>();
        btnOption2.onClick.AddListener(LoadMinigame);

        Debug.Log("Initialize Refs - MGState");
    }

    /// <summary>
    /// Event handler - called when endBtn is clicked
    /// Loads the end scene.
    /// public method can be executed by button onClick event
    /// </summary>
    public void LoadBeginScene()
    {
        Debug.Log("Leaving Scene2 going to BeginScene");
        StateManager.instanceRef.SwitchState(GameScene.BeginScene);
    }

    public void LoadMinigame()
    {
        Debug.Log("Leaving Scene2 going to Minigame");
        StateManager.instanceRef.SwitchState(GameScene.Minigame);
    }
} 

