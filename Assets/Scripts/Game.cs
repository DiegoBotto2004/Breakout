using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    private enum State
    {
        WaitingToStart,
        Playing,
        GameOverScreen
    }

    static public Game instance;

    [SerializeField] private GameOverScreen gameOverScreen;
    private State state;
    private List<Ball> balls;
    private Paddle paddle;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        this.state = State.WaitingToStart;
        this.balls = new List<Ball>();
        this.balls.Add(GameObject.FindObjectOfType<Ball>());
        this.paddle = GameObject.FindObjectOfType<Paddle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.state == State.WaitingToStart)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.state = State.Playing;
                this.balls[0].StartMoving();
            }
        }
    }

    public void LostBall(Ball lostBall)
    {
        if (this.state == State.Playing)
        {
            if (this.balls.Count == 1)
            {
                Sounds.instance.PlaySound(Sounds.SoundName.GameOver);
                this.state = State.GameOverScreen;
                Lives.instance.SubtractLives();
                this.state = State.WaitingToStart;
                this.paddle.Respawn();
                this.balls[0].Respawn();
            }
            else
            {
                Destroy(lostBall.gameObject);
                this.balls.Remove(lostBall);
            }
        }
    }
    public void GameOver()
    {
        if (this.state == State.Playing)
        {
            this.state = State.WaitingToStart;
            this.balls[0].Respawn();
            this.paddle.Respawn();
        }
    }

    public void PlayGame()
    {
        this.state = State.WaitingToStart;
    }
    public void DuplicateBall()
    {
        GameObject ballDuplicateGameObject = Instantiate(this.balls[0].gameObject);
        Ball ballDuplicate = ballDuplicateGameObject.GetComponent<Ball>();
        ballDuplicate.StartMoving();
        this.balls.Add(ballDuplicate);
    }
    public void RestartGame()
    {
        this.state = State.WaitingToStart;
        this.balls[0].Respawn();
        this.paddle.Respawn();
    }
    public void NextLevel()
    {
        LevelManager.instance.NextLevel();
        SceneManager.LoadScene("MainGame");
    }
}
