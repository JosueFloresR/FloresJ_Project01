using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement; //add to all State Files

public class BeginState : IStateBase
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
    /// Initializes a new instance of the <see cref="BeginState"/> class.
    /// </summary>
    public BeginState()
    {
        scene = GameScene.BeginScene; //IMPORTANT:  make sure this matches Unity Scene Name
    }

    /// <summary>
    /// Similar to Unity Start() 
    /// exectued once, after scene is loaded - called from StateManager
    /// Used to initialize object references - can be used to cache object references
    /// </summary>
    public void InitializeObjectRefs()
    {
        btnOption1 = GameObject.Find("ButtonOption1").GetComponent<Button>();
        btnOption1.onClick.AddListener(LoadEndScene);

        Debug.Log("Initialize Refs - BeginState");
    }

    /// <summary>
    /// Event handler - called when endBtn is clicked
    /// Loads the end scene.
    /// public method can be executed by button onClick event
    /// </summary>
    public void LoadEndScene()
    {
        Debug.Log("Leaving BeginScene going to EndScene");
        StateManager.instanceRef.SwitchState(GameScene.EndScene);  
    }
} //end class BeginState

