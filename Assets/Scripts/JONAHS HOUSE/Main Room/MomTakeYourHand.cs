using UnityEngine;

public class MomTakeYourHand : MonoBehaviour
{
    public DialogueManager dm;

    public GameObject chairSitting;
    public GameObject dragging;

    public void takeyou()
    {
        chairSitting.SetActive(false);
        dragging.SetActive(true);
    }

    public void fadetonext()
    {
        string SceneName = "EndTemp";
        StaticManager.nextScene = SceneName;

        GameObject FadeObj = GameObject.FindGameObjectWithTag("Fade");
        Animator animator = FadeObj.GetComponent<Animator>();

        animator.Play("FadeIn");
    }
    private void Update()
    {
        if (StaticManager.momGrabsyou && !dm.dialogueIsPlaying)
        {
            StaticManager.momGrabsyou = false;
            GetComponent<Animator>().Play("MomNEEDTOLEAVE");
        }
    }

}
