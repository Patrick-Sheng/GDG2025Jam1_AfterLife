using UnityEngine;

public class JonahsRoomManager : MonoBehaviour
{
    public GameObject RealPlayerPos;
    public GameObject RealPlayer;
    public GameObject FakePlayer;

    public GameObject Blanket;
    void Start()
    {
        if (StaticManager.StartAnimationDone)
        {
            FakePlayer.SetActive(false);
            RealPlayer.SetActive(true);
            RealPlayer.transform.position = RealPlayerPos.transform.position;

            Blanket.GetComponent<SpriteRenderer>().sortingOrder = -1;
            Blanket.transform.position = new Vector2(-6.43f, 3.12f);
            Blanket.transform.rotation = Quaternion.Euler(0f, 0f, -89.645f);
        }
    }

}
