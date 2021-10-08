using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        int _numOfMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;

        if (_numOfMusicPlayers > 1)
        {
            Destroy(this.gameObject);
        }

        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
