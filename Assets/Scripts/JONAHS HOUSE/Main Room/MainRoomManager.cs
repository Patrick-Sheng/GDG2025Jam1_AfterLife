using UnityEngine;

public class MainRoomManager : MonoBehaviour
{
    public DialogueManager DM;

    public TextAsset FamilyTalk;
    public TextAsset FamilyTalk2;
    public TextAsset MomPanic;

    public GameObject sittingDown;
    public GameObject Player;
    private float timer = 4f;
    private float timer2 = 2f;
    private float timer3 = 6f;
    private bool timerstart;
    void Update()
    {
        if (StaticManager.EatCereal)
        {
            if (GameObject.FindGameObjectWithTag("Music") != null)
            {
                Destroy(GameObject.FindGameObjectWithTag("Music"));

            }
            sittingDown.SetActive(true);
            Player.GetComponent<SpriteRenderer>().enabled = false;
            Player.GetComponent<BoxCollider2D>().enabled = false;
            Player.GetComponent<PlayerController>().enabled = false;
            timerstart = true;
            StaticManager.EatCereal = false;
        }

        if (timerstart)
        {
            timer = timer - Time.deltaTime;
            if (timer < 0)
            {
                DialogueManager.GetInstance().EnterDialogueMode(FamilyTalk);
                timerstart = false;
                
            }
        }

        if (StaticManager.familytalk1Done && !DM.dialogueIsPlaying)
        {
            timer2 = timer2 - Time.deltaTime;
            if (timer2 < 0)
            {
                StaticManager.familytalk1Done = false;
                DialogueManager.GetInstance().EnterDialogueMode(FamilyTalk2);

            }
        }
        if (StaticManager.familytalk2Done && !DM.dialogueIsPlaying)
        {
            timer3 = timer3 - Time.deltaTime;
            if (timer3 < 0)
            {
                StaticManager.familytalk2Done = false;
                DialogueManager.GetInstance().EnterDialogueMode(MomPanic);
            }
        }

    }
}
