using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement; //add to all State Files

public class EndState : IStateBase
{

    private GameScene scene;

    //add commenets
    public GameScene Scene
    {
        get { return scene; }
    }

    //GameScene objectRefs
    private Button btnOption1, btnOption2;

    //constructor  // add comments
    public EndState()
    {
        scene = GameScene.EndScene;
    }


    //Like Start()  - executed once when scene is first loaded
    public void InitializeObjectRefs()
    {
        btnOption1 = GameObject.Find("ButtonOption1").GetComponent<Button>();
        btnOption1.onClick.AddListener(LoadMinigame);
        Debug.Log("InitializeObj Refs - MGState");

        btnOption2 = GameObject.Find("ButtonOption2").GetComponent<Button>();
        btnOption2.onClick.AddListener(LoadBeginScene);
        Debug.Log("InitializeObj Refs - BeginState");
    }


    public void LoadMinigame()
    {
        Debug.Log("Leaving EndScene, going to Minigame");
        StateManager.instanceRef.SwitchState(GameScene.Minigame);

    }
    public void LoadBeginScene()
    {
        Debug.Log("Leaving EndScene, going to BeginScene");
        StateManager.instanceRef.SwitchState(GameScene.BeginScene);

    }
} //end class:  EndState