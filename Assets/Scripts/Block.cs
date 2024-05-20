using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Block : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Ball>() != null) 
        {
            PowerupManager.instance.MaybeCreatePowerup(this.transform.position);
            Destroy(this.gameObject);
            Sounds.instance.PlaySound(Sounds.SoundName.BlockHit);
            Score.instance.AddScore(Score.SCORE_PER_BLOCK);
        }
        if (GetBlockCount() - 1 == 0)
        {
            Game.instance.NextLevel();
        }
    }
    private int GetBlockCount()
    {
        return GameObject.FindObjectsOfType<Block>().Count();
    }
}
