using UnityEngine;
using UnityEngine.SceneManagement;

public class BacktoMenu : MonoBehaviour
{
    public bool scene;

    public void start()
    {
        SceneManager.LoadScene("StartScene");
    }
}
