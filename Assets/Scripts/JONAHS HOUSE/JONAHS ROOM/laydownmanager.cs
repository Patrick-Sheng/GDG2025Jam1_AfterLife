using UnityEngine;

public class laydownmanager : MonoBehaviour
{
    public GameObject layingdown;
    

    public DialogueManager dm;
    public SpriteRenderer playerSp;
    public PlayerController playerC;
    public BoxCollider2D playerBC;
    void Update()
    {
        if (StaticManager.LayDownJonah && !dm.dialogueIsPlaying)
        {
            print("happening");
            playerSp.enabled = false;
            playerC.enabled = false;
            playerBC.enabled = false;
            layingdown.SetActive(true);

            if (Input.GetKeyDown(KeyCode.C))
            { 
               playerSp.enabled = true;
                playerC.enabled = true;
                playerBC.enabled = true;
               layingdown.SetActive(false);
                StaticManager.LayDownJonah = false;
            }

        }
    }
}
