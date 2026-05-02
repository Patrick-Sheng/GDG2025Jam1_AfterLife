using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlsManager : MonoBehaviour
{
    public Sprite YesSelected;
    public Sprite NoSelected;

    public GameObject ControllsImage;
    private bool selectedBoolYes;
    void Update()
    {

        if (selectedBoolYes)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                SceneManager.LoadScene("JonahsRoom");
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (!selectedBoolYes)
            {

                ControllsImage.GetComponent<SpriteRenderer>().sprite = YesSelected;
                selectedBoolYes = true;

            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (selectedBoolYes)
            {

                ControllsImage.GetComponent<SpriteRenderer>().sprite = NoSelected;
                selectedBoolYes = false;

            }
        }
    }
}
