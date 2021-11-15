//Josue Flores
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   //Required for modifying any UI element

public class MiniGameManager : MonoBehaviour
{

    enum MiniGameState { idle, active, win, lose }

    [SerializeField]
    MiniGameState curGameState;

    [SerializeField]
    Spawner spawner;

    [SerializeField]
    Button startButton; //Button component on the StartButton gameObject

    [SerializeField]
    Text resultsText;   //Text component on the ResultsText gameObject

    [SerializeField]
    CanvasGroup resultsPanelCG; //canvas group component on the ResultsPanel

    [SerializeField]
    CanvasGroup OptionsPanelCG; //OptionsPanel

    [SerializeField]
    int winScore = 30;


    // Start is called before the first frame update
     public void Start()
    {
        curGameState = MiniGameState.idle;
        Utility.ShowCG(resultsPanelCG); //make sure panel is visible
        Utility.HideCG(OptionsPanelCG);
        resultsText.text = "Score " + winScore + " To Win";
        startButton.onClick.AddListener(ReStartGame);
    }

    // Update is called once per frame
     public void Update()
    {
        if (curGameState == MiniGameState.active)
        {
            if (GameData.instanceRef.Health > 0)
            {
                if (GameData.instanceRef.Score >= winScore)
                {
                    //won the game
                    curGameState = MiniGameState.win;
                    GameWin();
                    resultsText.text = "You are a winner";
                }
            }
            else  //lost due to health
            {
                curGameState = MiniGameState.lose;
                resultsText.text = "You lost, so sorry, try again";
                GameOver();
            }

        } //end if
    } //end Update

    /// <summary>
    /// Restart the game
    /// </summary>
    /// Syntax for a method to be executed by a Unity Event
    /// MUST BE PUBLIC to be executed by Unity EVENT
    public void ReStartGame()  //important syntax
    {
        GameData.instanceRef.ResetGameData();  //use singleton variable to call public method
        Utility.HideCG(resultsPanelCG); //toggle to hide panel
        curGameState = MiniGameState.active;
        startButton.gameObject.SetActive(false);
        //start spawner
        spawner.activeSpawning = true;
        spawner.StartSpawning();
    }

    /// <summary>
    /// Games the over.
    /// Private since only executed from within this class
    /// </summary>
    /// void GameWin()
    public void GameWin()
    {
        Utility.ShowCG(OptionsPanelCG);
        Utility.ShowCG(resultsPanelCG);
        Text btnTxt = startButton.GetComponentInChildren<Text>();
    btnTxt.text = "Play Again";
        spawner.activeSpawning = false;
        spawner.DestroySpawnedObjects();

    }
private void GameOver()
    {
        Utility.ShowCG(resultsPanelCG); //toggle to make visible
        ///TODO stop spawner, destroy all spawned objects
        spawner.StopAllSpawning();

        startButton.gameObject.SetActive(true);
        /// Get Text that is the child of the StartButton 
        Text btnText = startButton.GetComponentInChildren<Text>();
        btnText.text = "Play Again";
    }

}//end class
