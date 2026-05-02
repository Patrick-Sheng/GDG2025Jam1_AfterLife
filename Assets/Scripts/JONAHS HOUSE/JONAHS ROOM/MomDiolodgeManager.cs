using System.Threading;
using UnityEngine;

public class MomDiolodgeManager : MonoBehaviour
{
    public DialogueManager dMan;
    public TextAsset MomDiolodge1;
    public TextAsset MomDiolodge2;

    private float MomTalkTimer = 1f;
    private float MomWalkInTimer = 1f;
    private float MomWaitTimer = 1f;
    private float TakeBlanketTimer = 1f;

    private bool MomWaitTimerBool = false;
    private bool momDiologue1played;
    private bool momDiologue2played;
    private bool animationPlayed;
    
    

    public GameObject MomSprite;


    private void Update()
    {
        if (StaticManager.StartAnimationDone == false)
        {
            MomTalkTimer = MomTalkTimer - Time.deltaTime;

        }
        if (MomTalkTimer < 0f && momDiologue1played == false)
        {
            DialogueManager.GetInstance().EnterDialogueMode(MomDiolodge1);
            momDiologue1played = true;
        }

        if (StaticManager.MomComeInside && dMan.dialogueIsPlaying == false)
        {
            StaticManager.MomComeInside = false;
            MomSprite.SetActive(true);
            MomWaitTimerBool = true;
        }

        if (MomWaitTimerBool)
        {
            MomWaitTimer = MomWaitTimer - Time.deltaTime;
            if (MomWaitTimer < 0 && momDiologue2played == false)
            {
                momDiologue2played = true;
                DialogueManager.GetInstance().EnterDialogueMode(MomDiolodge2);

            }
        }

        if (StaticManager.TakeBlanket == true)
        {
            TakeBlanketTimer = TakeBlanketTimer - Time.deltaTime;
            if (TakeBlanketTimer < 0 && animationPlayed == false && dMan.dialogueIsPlaying == false)
            {
                animationPlayed = true;
                MomSprite.GetComponent<Animator>().Play("walkOverToBed");
            }
        }

        if (StaticManager.ThrowBlanket == true && dMan.dialogueIsPlaying == false)
        {
            StaticManager.ThrowBlanket = false;
            MomSprite.GetComponent<Animator>().Play("MomThrow");
        }

        if (StaticManager.MumLeaveJonahRoom == true && dMan.dialogueIsPlaying == false)
        {
            StaticManager.MumLeaveJonahRoom = false;
            MomSprite.GetComponent<Animator>().Play("MomLeave");
        }


    }

}
