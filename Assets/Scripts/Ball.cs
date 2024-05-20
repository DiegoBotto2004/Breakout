using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    private Vector2 velocity;
    void Start()
    {

    }
    public void StartMoving()
    {
        this.velocity = new Vector2(0, 1);
        this.velocity.x = -0.5f + Random.value;
        this.velocity = this.velocity.normalized * GetSpeed();
    }
    public void Respawn()
    {
        this.velocity = Vector2.zero;
        this.transform.position = new Vector2(0, -3f);
    }

    void Update()
    {
        Vector2 position = this.transform.position;
        position += this.velocity * Time.deltaTime;
        this.transform.position = position;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "TopWall")
        {
            this.velocity.y = -GetSpeed();
            Sounds.instance.PlaySound(Sounds.SoundName.WallHit);
        }
        else if (collider.gameObject.name == "LeftWall")
        {
            this.velocity.x = GetSpeed();
            Sounds.instance.PlaySound(Sounds.SoundName.WallHit);
        }
        else if (collider.gameObject.name == "RightWall")
        {
            this.velocity.x = -GetSpeed();
            Sounds.instance.PlaySound(Sounds.SoundName.WallHit);
        }
        else if (collider.gameObject.name == "Paddle")
        {
            float xDifference = this.transform.position.x -
            collider.transform.position.x;
            this.velocity.x = xDifference * GetSpeed() * 2.7f;
            this.velocity.y = GetSpeed();
            Sounds.instance.PlaySound(Sounds.SoundName.PaddleHit);
        }
        else if (collider.gameObject.name.Contains("Block"))
        {
            this.velocity.y = -GetSpeed();
        }
        else if (collider.gameObject.name == "BottomWall")
        {
            Game.instance.LostBall(this);
        }
        this.velocity = this.velocity.normalized * GetSpeed();
    }
    private float GetSpeed()
    {
        return LevelManager.instance.GetCurrentLevel().GetBallSpeed();
    }
}
