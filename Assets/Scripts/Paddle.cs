using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private float normalXScale;
    public void Respawn()
    {
        Vector2 position = this.transform.position;
        position.x = 0;
        this.transform.position = position;
        this.transform.localScale = new Vector2(this.normalXScale, this.transform.localScale.y);
    }
    // Start is called before the first frame update
    void Start()
    {
        this.normalXScale = this.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 20;

        if (Input.GetKey(KeyCode.LeftArrow) && this.transform.position.x > -11.66f)
        {
            this.transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow) && this.transform.position.x < 11.66f)
        {
            this.transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.GetComponent<PowerUp>() != null)
        {
            PowerUp.PowerupType powerupType = collision.GetComponent<PowerUp>().GetPowerupType();
            Destroy(collision.gameObject);
            Sounds.instance.PlaySound(Sounds.SoundName.powerUp);
            if (powerupType == PowerUp.PowerupType.DoubleBall)
            {
                Game.instance.DuplicateBall();
            }
            else if (powerupType == PowerUp.PowerupType.LongPaddle)
            {
                float newWidth = this.transform.localScale.x + 0.6f;
                this.transform.localScale = new Vector2(newWidth, this.transform.localScale.y);
            }
        }
    }
}
