using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    [SerializeField] private GameObject blockPrefab;
    [SerializeField] private List<Color> colors;
    // Start is called before the first frame update
    void Start()
    {
        float x = -11.96f;
        float y = 5.67f;
        float xDistance = 1.53f;
        float yDistance = 0.61f;

        for (int i = 0; i < 16; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                GameObject gameObject = Instantiate(this.blockPrefab);
                Vector2 position = new Vector2();
                position.x = x + i * xDistance;
                position.y = y - j * yDistance;
                gameObject.transform.position = position;

                gameObject.GetComponent<SpriteRenderer>().color = this.colors[j];
            }
            
        }
       
    }
}
