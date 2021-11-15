using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene4State : IStateBase
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
    /// Initializes a new instance of the <see cref="Scene4State"/> class.
    /// </summary>
    public Scene4State()
    {
        scene = GameScene.Scene4; //IMPORTANT:  make sure this matches Unity Scene Name
    }

    /// <summary>
    /// Similar to Unity Start() 
    /// exectued once, after scene is loaded - called from StateManager
    /// Used to initialize object references - can be used to cache object references
    /// </summary>
    public void InitializeObjectRefs()
    {
        btnOption1 = GameObject.Find("ButtonOption1").GetComponent<Button>();
        btnOption1.onClick.AddListener(LoadMinigame);

        Debug.Log("Initialize Refs - MGState");

        btnOption2 = GameObject.Find("ButtonOption2").GetComponent<Button>();
        btnOption2.onClick.AddListener(LoadEndScene);

        Debug.Log("Initialize Refs - EndState");
    }

    /// <summary>
    /// Event handler - called when endBtn is clicked
    /// Loads the end scene.
    /// public method can be executed by button onClick event
    /// </summary>
    public void LoadEndScene()
    {
        Debug.Log("Leaving Scene4 going to EndScene");
        StateManager.instanceRef.SwitchState(GameScene.EndScene);
    }
    public void LoadMinigame()
    {
        Debug.Log("Leaving Scene4 going to Minigame");
        StateManager.instanceRef.SwitchState(GameScene.Minigame);
    }
}