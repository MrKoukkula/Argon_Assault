using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash_screen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= 4)
        {
            SceneManager.LoadScene(1);
        }
    }
}
