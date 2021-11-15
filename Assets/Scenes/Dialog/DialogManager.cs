using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Dialog manager.
/// Put this script on a panel with canvasGroup, 
/// Important:  remove SpriteRenderer from Panel
/// required child objects: dialogText, speakerName, nextDialogBtn
/// </summary>
public class DialogManager : MonoBehaviour
{

    public CanvasGroup nextPanelToOpenCG;  //next panel to open, set in Inspector
    public Button openDialogBtn; //Button that will open Dialog
    public bool showOnStart = false;

    private Button nextBtn;
    private CanvasGroup dialogPanelCG;
    private Text dialogText, speakerName; //speakerName;
    private Image speakerImage;


    public ConversationList convList; //attach scriptable object in Inspector
    private Queue<ConversationEntry> conversationsQueue = new Queue<ConversationEntry>();

    // Use this for initialization
    void Start()
    {


        dialogPanelCG = GetComponent<CanvasGroup>(); //used to show/hide panel

        Text[] textChildren = GetComponentsInChildren<Text>();
        Image[] imageChildren = GetComponentsInChildren<Image>();

        dialogText = textChildren[0];
        speakerName = textChildren[2];
        speakerImage = imageChildren[4]; //fifth child image - in SpeakerPanel

        nextBtn = GetComponentInChildren<Button>();
        nextBtn.onClick.AddListener(GetNextDialog);

        InitializeDialog(); //call once in Start
        //checkbox that can be set in inspector, if checked, then this is not exected
        if (!showOnStart)
        {
            Utility.HideCG(dialogPanelCG);
            if (openDialogBtn != null) //if opening dialog with a Button, Populate OpenDialogButton in the Inspector 
            {
                openDialogBtn.onClick.AddListener(ShowDialogPanel);
            }
        }
        else
        { //if showing on scene load, get first Dialog 
            Utility.ShowCG(dialogPanelCG);
        }
    } //end of Start


    //Populates the Queue with ConversationEntries 
    //from the ConvList scriptableObject's Conversation variable.
    //Also calls GetNextDialog to populate initial conversation data for first conversation
    void InitializeDialog()
    {
        foreach (ConversationEntry item in convList.Conversation)
        {
            conversationsQueue.Enqueue(item); //put each string -item in the queue
        }
        GetNextDialog();  //get first item
    } //end method


    /// <summary>
    /// Opens the dialog.
    /// this method is called if there is an 
    /// openDialog button set in the Inspector
    /// otherwise, select checkbox showOnStart 
    /// </summary>
    public void ShowDialogPanel()
    {
        Utility.ShowCG(dialogPanelCG);
        openDialogBtn.gameObject.SetActive(false);

    } //end method


    /// <summary>
    /// Nexts the dialog.
    /// Sets UI elements: speakerName, speakerImage, dialogText
    /// </summary>
    /// <returns><c>true</c>, if dialog there is more dialog, <c>false</c> otherwise.</returns>
    public void GetNextDialog()
    {
        if (conversationsQueue.Count > 0)
        {
            ConversationEntry item = conversationsQueue.Dequeue();
            speakerName.text = item.speakerName;
            if (speakerImage != null)
            { //if not using Sprite
                speakerImage.sprite = item.speakerImg;
            }
            StopAllCoroutines();
            string curSentence = item.dialogTxt;
            StartCoroutine(TypeSentence(curSentence));
        }
        else //no more conversations
        {
            Utility.HideCG(dialogPanelCG); // close panel
            if (nextPanelToOpenCG != null) //check to see if valid gameObject was set in inspector
            {
                Utility.ShowCG(nextPanelToOpenCG);
            }
        }

    } //end GetNextDialog method

    //this allows single characters to be added to look like typed text
    IEnumerator TypeSentence(string sentence)
    {
        dialogText.text = ""; //clear previous sentance
        foreach (char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(0.05f); ;
        }
    }//end TypeSentence method

} // end class