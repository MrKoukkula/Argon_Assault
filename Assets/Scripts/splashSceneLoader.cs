using UnityEngine;
using UnityEngine.SceneManagement;

public class splashSceneLoader : MonoBehaviour
{
    void Start()
    {
        Invoke("loadGame", 5f);
    }


    void loadGame()
    {
        SceneManager.LoadScene(1);
    }
}
