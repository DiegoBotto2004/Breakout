using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Sounds.instance.PlaySound(Sounds.SoundName.GameOverMusic);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
