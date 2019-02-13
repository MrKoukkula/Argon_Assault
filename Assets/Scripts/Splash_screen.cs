using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash_screen : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("loadGame", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void loadGame()
    {
        SceneManager.LoadScene(1);
    }
}
