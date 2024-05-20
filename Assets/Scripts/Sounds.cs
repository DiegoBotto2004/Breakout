using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public enum SoundName
    {
        WallHit,
        BlockHit,
        PaddleHit,
        GameOver,
        powerUp,
        GameOverMusic
    }
    public void PlaySound(SoundName soundName)
    {
        Transform soundTransform = this.transform.Find(soundName.ToString());
        AudioSource audioSource = soundTransform.GetComponent<AudioSource>();
        audioSource.Play();
    }
    static public Sounds instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
