using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private const float SPEED = 3;
    private PowerupType type;
    public enum PowerupType
    {
        DoubleBall,
        LongPaddle
    }
    public PowerupType GetPowerupType()
    {
        return this.type;
    }
    // Start is called before the first frame update
    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, -SPEED);
        if (this.name.Contains("DoubleBallPowerup"))
        {
            this.type = PowerupType.DoubleBall;
        }
        else if (this.name.Contains("LongPaddlePowerup"))
        {
            this.type = PowerupType.LongPaddle;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
