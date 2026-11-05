using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartManager : MonoBehaviour
{
    public bool scene;

    public void start()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
