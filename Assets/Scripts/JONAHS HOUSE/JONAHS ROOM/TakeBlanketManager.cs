using UnityEngine;

public class TakeBlanketManager : MonoBehaviour
{

    public TextAsset GETUP;
    public TextAsset GetReady;

    public GameObject Player;
    public GameObject Blanket;
    public GameObject MotherBlanketPos;
    public GameObject ThrowPosG;
    public GameObject ThrowPosG2;

    private bool throwNow;

    public void PlayerGetsOutOfBed()
    {
        //Player.GetComponent<Animator>().enabled = true;
        Player.GetComponent<Animator>().Play("GetOutOfBed");
    }
    public void GetReadyNow()
    {
        Blanket.GetComponent<SpriteRenderer>().sortingOrder = -1;
        GetComponent<SpriteRenderer>().sortingOrder = 3;
        DialogueManager.GetInstance().EnterDialogueMode(GetReady);
    }
    public void TakeBlanket()
    {
        print("is this happening????");
        Blanket.transform.position = MotherBlanketPos.transform.position;
        Blanket.transform.rotation = MotherBlanketPos.transform.rotation;
    }
    public void GetUp()
    {
        DialogueManager.GetInstance().EnterDialogueMode(GETUP);
    }

    public void ThrowPos()
    {


        Blanket.GetComponent<SpriteRenderer>().sortingOrder = 2;

        Blanket.transform.position = ThrowPosG.transform.position;
        Blanket.transform.rotation = ThrowPosG.transform.rotation;
    }

    public void Throw()
    {
        Blanket.GetComponent<Animator>().enabled = true;
        Blanket.GetComponent<Animator>().Play("Throwed");
        //Blanket.transform.position = ThrowPosG2.transform.position;
        //Blanket.transform.rotation = ThrowPosG2.transform.rotation;
    }


}
