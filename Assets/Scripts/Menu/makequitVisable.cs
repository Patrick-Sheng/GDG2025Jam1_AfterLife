using UnityEngine;

public class makequitVisable : MonoBehaviour
{
    public GameObject QuitText;
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            QuitText.SetActive(true);
        }
        else
        {
            QuitText.SetActive(false);
        }
    }
}
