using TMPro;
using UnityEngine;
using Ink.Runtime;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;




public class DialogueManager : MonoBehaviour
{
    private bool switch1;

    public AudioSource typing;

    [SerializeField] private float typingSpeed = 0.04f;
     
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    [SerializeField] private TextMeshProUGUI displayNameText;

    [SerializeField] Animator portraitAnimator;

    private Animator layoutAnimator;


    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    


    
    
    private TextMeshProUGUI[] choicesText;





    private const string SPEAKER_TAG = "speaker";
    private const string PORTRAIT_TAG = "portrait";
    private const string LAYOUT_TAG = "layout";




    public Story currentStory;

    public bool dialogueIsPlaying { get; private set; }


    private static DialogueManager instance;

    private bool canContinueToNextLine = false;


    private Coroutine displayLineCoroutine;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Found more than one DIalogue Manager in the scene");
        }
        instance = this;

        layoutAnimator = dialoguePanel.GetComponent<Animator>();
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        //layoutAnimator = dialoguePanel.GetComponent<Animator>();

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }


    }

    private void Update()
    {
        //chat gpt code LOL

        // end of chat gpt code 

        //return when dialogue isnt playing
        if (!dialogueIsPlaying)
        {
            return;
        }

        //if (dialogueIsPlaying && !currentStory.canContinue && !currentStory.currentChoices.Any())
        //{
        //    ExitDialogueMode();
        //}

        //cgpt
        //if (dialogueIsPlaying &&
        //!currentStory.canContinue &&
        //!currentStory.currentChoices.Any() &&
        // canContinueToNextLine)       // wait until the line has fully printed
        //{
        //    ExitDialogueMode();
        //}

        //currentStory.currentChoices.Count == 0
        if (canContinueToNextLine && Input.GetKeyDown(KeyCode.C))
        {
            ContinueStory();
        }



    }
    public void EnterAtKnot(TextAsset inkJSON, string knotName)
    {
        currentStory = new Story(inkJSON.text);
        currentStory.BindExternalFunction("moneynumber", () => StaticManager.NumDollars);
        

        currentStory.ChoosePathString(knotName);

        dialogueIsPlaying = true;

        // ��� UI boilerplate you had in EnterDialogueMode ���
        displayNameText.text = "???";
        portraitAnimator.Play("default");
        layoutAnimator.Play("default");
        dialoguePanel.SetActive(true);
        Canvas.ForceUpdateCanvases();
        // ������������������������������������������������

        ContinueStory();
    }
    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        currentStory.BindExternalFunction("moneynumber", () => StaticManager.NumDollars);



        dialogueIsPlaying = true;

        displayNameText.text = "???";
        portraitAnimator.Play("default");

        layoutAnimator.Play("default");

        //dialoguePanel.SetActive(false);
        dialoguePanel.SetActive(true);

        //StartCoroutine(RefreshLayout());

        Canvas.ForceUpdateCanvases();





        ContinueStory();




    }

    private void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";

        //FindObjectOfType<DialogueTrigger>().ResetTrigger();
        //StaticManager.resettrigger = true;

        StartCoroutine(CoroutineExample());




    }
    private IEnumerator CoroutineExample()
    {
        Debug.Log("Coroutine started!");

        
        yield return new WaitForSeconds(0.2f);
        StaticManager.resettrigger = false;
        
    }
    public void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            //dialogueText.text = currentStory.Continue();

            if (displayLineCoroutine != null)
            {
                StopCoroutine(displayLineCoroutine);
            }

            displayLineCoroutine = StartCoroutine(DisplayLine(currentStory.Continue()));

            //chat gpt told me to move this somewhere else 
            //HandleTags(currentStory.currentTags);


            //dialogueText.text = nextLine;

            
            // removed
            StartCoroutine(RefreshUI());

            

            //handle tags


        }
        else
        {
            ExitDialogueMode();
        }
    }


    private IEnumerator RefreshUI()
    {
        // Wait for end of frame to ensure all UI elements are active
        yield return new WaitForEndOfFrame();

        // Force all necessary updates
        dialogueText.ForceMeshUpdate();
        LayoutRebuilder.ForceRebuildLayoutImmediate(dialogueText.rectTransform);
        if (dialogueText.transform.parent != null)
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(dialogueText.transform.parent.GetComponent<RectTransform>());
        }
        Canvas.ForceUpdateCanvases();
    }


    private IEnumerator DisplayLine(string line)
    {
        //empty the dialogue text
        dialogueText.text = "";

        HideChoices();
        


        canContinueToNextLine = false;
        if (currentStory.currentTags.Count > 0)
            HandleTags(currentStory.currentTags);

        foreach (char letter in line.ToCharArray())
        {

            
            if (Input.GetKey(KeyCode.X))
            {
                dialogueText.text = line;
                break;
                // set the boolean to false here
            }
            typing.pitch = Random.Range(0.9f, 1.1f);
            typing.PlayOneShot(typing.clip);
<<<<<<< HEAD
=======
            //dialogueText.ForceMeshUpdate(true);
>>>>>>> 8f8a6473ce294b9c7f461d810ec7a2b4977d803c

            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }



        DisplayChoices();

        canContinueToNextLine = true;
    }

    private IEnumerator RebuildDialogueLayout()
    {
        // 1) wait one frame so the layoutAnimator has actually resized your RectTransforms
        yield return null;

        // 2) sample your layoutAnimator again (just in case)
        //    — you can pass your last tagValue in here if you store it, or just replay default then play
        //    (but we’ll assume your Play(tagValue, 0f) + Update(0f) in HandleTags already ran)

        // 3) toggle every RectMask2D to nuke its cached clip rect
        var masks = dialoguePanel.GetComponentsInChildren<RectMask2D>(true);
        foreach (var m in masks) m.enabled = false;
        Canvas.ForceUpdateCanvases();
        foreach (var m in masks) m.enabled = true;

        // 4) toggle any LayoutGroup to force it to reflow
        var layoutGroups = dialoguePanel.GetComponentsInChildren<LayoutGroup>(true);
        foreach (var lg in layoutGroups)
        {
            lg.enabled = false;
            lg.enabled = true;
        }

        // 5) toggle the TMP component itself so it dirties its layout
        dialogueText.enabled = false;
        dialogueText.enabled = true;

        // 6) now absolutely rebuild everything
        Canvas.ForceUpdateCanvases();
        var panelRT = dialoguePanel.GetComponent<RectTransform>();
        LayoutRebuilder.ForceRebuildLayoutImmediate(panelRT);
        LayoutRebuilder.ForceRebuildLayoutImmediate(dialogueText.rectTransform);

        // 7) and finally force TMP to regenerate & wrap its mesh
        dialogueText.ForceMeshUpdate();
    }
    private void HideChoices()
    {
        foreach (GameObject choiceButton in choices)
        {
            choiceButton.SetActive(false);
        }
    }

    private void HandleTags(List<string> currentTags)
    {
        // loop thought each tag 
        foreach (string tag in currentTags)
        {

            if(tag.Trim() == "GoToArcadeRoom")
            {
                ExitDialogueMode();
                dialogueIsPlaying = false;
                dialoguePanel.SetActive(false);

                SceneManager.LoadScene("TestArcade");
                Debug.Log("niceTag has passed!");
                continue; // Skip to next tag
            }

            if (tag.Trim() == "Example of tag")
            {
                // DO CODE HERE
                continue; // Skip to next tag
            }
            if (tag.Trim() == "MomComeInside")
            {
                StaticManager.MomComeInside = true;
                // DO CODE HERE
                continue; // Skip to next tag
            }
            if (tag.Trim() == "TakeBlanket")
            {
                StaticManager.TakeBlanket = true;
                // DO CODE HERE
                continue; // Skip to next tag
            }
            if (tag.Trim() == "ThrowBlanket")
            {
                StaticManager.ThrowBlanket = true;
                // DO CODE HERE
                continue; // Skip to next tag
            }
            if (tag.Trim() == "MumLeaveJonahRoom")
            {
                StaticManager.MumLeaveJonahRoom = true;
                // DO CODE HERE
                continue; // Skip to next tag
            }
            if (tag.Trim() == "EatCereal")
            {
                StaticManager.EatCereal = true;
                // DO CODE HERE
                continue; // Skip to next tag
            }
            if (tag.Trim() == "familytalk1Done")
            {
                StaticManager.familytalk1Done = true;
                continue;
            }
            if (tag.Trim() == "familytalk2Done")
            {
                StaticManager.familytalk2Done = true;
                continue;
            }
            if (tag.Trim() == "momGrabsyou")
            {
                StaticManager.momGrabsyou = true;
                continue;
            }
            if (tag.Trim() == "LayDownJonah")
            {
                StaticManager.LayDownJonah = true;
                continue;
            }

            
            string[] splitTag = tag.Split(":");
            if (splitTag.Length != 2)
            {
                Debug.LogError("Tag Could Not Be parsed: " + tag);
                continue;
            }

            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey)
            {
                case SPEAKER_TAG:
                    displayNameText.text = tagValue;
                    break;
                case PORTRAIT_TAG:
                    portraitAnimator.Play(tagValue);
                    break;
                //case LAYOUT_TAG:
                //    layoutAnimator.Play(tagValue);
                //    break;
                case LAYOUT_TAG:
                    // 1) jump the animator to the first frame of the new layout clip
                    layoutAnimator.Play(tagValue, -1, 0f);
                    layoutAnimator.Update(0f);

                    // 2) kick off a tiny coroutine that waits one frame, then rebuilds everything
                    StartCoroutine(RebuildDialogueLayout());
                    break;
                default:
                    Debug.LogWarning("Tag came but isnt being handled" + tag);
                    break;
            }
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More Choices Were given than the current UI system can support");
        }

        int index = 0;

        foreach(Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }

        StartCoroutine(SelectFirstChoice());
    }

    private void ForceImmediateRebuild()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(dialogueText.rectTransform);
        dialogueText.ForceMeshUpdate();
    }
    private IEnumerator SelectFirstChoice()

    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);

    }
    public void MakeChoice(int choiceIndex)
    {
        if (canContinueToNextLine)
        {
            currentStory.ChooseChoiceIndex(choiceIndex);

            //chat gpt told me to add this guys
            ContinueStory();

        }

    }

}
