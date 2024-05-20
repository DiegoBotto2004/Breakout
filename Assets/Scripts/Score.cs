using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    int score;
    static public Score instance;
    public const int SCORE_PER_BLOCK = 100;
    void Start()
    {
        instance = this;
        this.score = 0;
    }
    public void AddScore(int scoreToAdd)
    {
        this.score += scoreToAdd;
        GetComponent<TextMeshProUGUI>().text = this.score.ToString();
    }
}
