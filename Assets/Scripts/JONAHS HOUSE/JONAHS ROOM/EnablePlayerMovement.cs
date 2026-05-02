using UnityEngine;

public class EnablePlayerMovement : MonoBehaviour
{
    public AudioSource source;

    public GameObject PlayerReal;
    public void EnablePlayersMovement()
    {
        source.Play();
        PlayerReal.SetActive(true);
        StaticManager.StartAnimationDone = true;
        gameObject.SetActive(false);
    }

}
