using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [Tooltip("In seconds")][SerializeField] float levelLoadDelay = 1f;
    [Tooltip("Expolsion particle")] [SerializeField] GameObject explosion;
    void OnTriggerEnter(Collider other)
    {
        startDeathSequence();
    }

    private void startDeathSequence()
    {
        SendMessage("OnPlayerDeath");
        explosion.SetActive(true);
        Invoke("reloadScene", levelLoadDelay);
    }

    private void reloadScene()
    {
        SceneManager.LoadScene(1);
    }
}
