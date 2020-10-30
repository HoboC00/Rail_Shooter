using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class MusicPlayer : MonoBehaviour
{
    // Start is called before the first frame update
   

    void Awake()
    {
        int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;
        if (numMusicPlayers > 1)
        {

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    
}
