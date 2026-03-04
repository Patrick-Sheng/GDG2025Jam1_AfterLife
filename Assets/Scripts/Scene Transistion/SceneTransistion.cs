using UnityEngine;
using UnityEngine.SceneManagement;



public class SceneTransistion : MonoBehaviour
{


    public string SceneName;

    private void Awake()
    {

    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {

            if (gameObject.tag == "gotohevenmain")
            {
                StaticManager.gatetoheaven = true;
            }
            if (gameObject.name == "FromJonahsRoom")
            {
                StaticManager.goingFromRoom = "FromJonahsRoom";
            }
            if (gameObject.name == "FromLuciasRoom")
            {
                StaticManager.goingFromRoom = "FromLuciasRoom";
            }
            if (gameObject.name == "FromBathRoom")
            {
                StaticManager.goingFromRoom = "FromBathRoom";
            }
            if (gameObject.name == "FromMainRoom")
            {
                StaticManager.goingFromRoom = "FromMainRoom";
            }


            StaticManager.nextScene = SceneName;

            GameObject FadeObj = GameObject.FindGameObjectWithTag("Fade");
            Animator animator = FadeObj.GetComponent<Animator>();

            

            animator.Play("FadeIn");
        }
        


    }



}
