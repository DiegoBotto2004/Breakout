using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lives : MonoBehaviour
{
    // Start is called before the first frame update
    int lives;
    static public Lives instance;
    [SerializeField] private GameOverScreen gameOverScreen; 

    void Start()
    {
        instance = this;
        this.lives = 3;
    }
    public void SubtractLives()
    {
        this.lives --;
        GetComponent<TextMeshProUGUI>().text = this.lives.ToString();
        if (lives == 0 ) 
        {
            this.gameOverScreen.gameObject.SetActive(true);
        }
    }
}
