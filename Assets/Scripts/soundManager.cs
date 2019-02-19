using UnityEngine;

public class soundManager : MonoBehaviour
{
    private void Awake()
    {
        int numMusicPlayers = FindObjectsOfType<soundManager>().Length;
        if (numMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
        
    }

}
