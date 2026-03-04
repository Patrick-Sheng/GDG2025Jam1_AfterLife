using UnityEngine;

public class WhiteDoorMomBlock : MonoBehaviour
{
    public GameObject Player;
    public TextAsset MomCantLeave;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.transform.position = new Vector2
                (Player.transform.position.x, Player.transform.position.y - 0.2f);

            DialogueManager.GetInstance().EnterDialogueMode(MomCantLeave);
            
        }
    }
}
