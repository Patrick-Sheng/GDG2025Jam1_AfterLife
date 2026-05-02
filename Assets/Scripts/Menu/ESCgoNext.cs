using UnityEngine;
using UnityEngine.SceneManagement;

public class ESCgoNext : MonoBehaviour
{
    public void GoToNextEscape()
    {
        SceneManager.LoadScene("Controls Explain");
    }
}
