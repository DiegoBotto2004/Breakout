using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private float ballSpeed = 9;
    [SerializeField] [Range(0, 1)] private float doubleBallPowerupChance = 0.1f;
    [SerializeField] [Range(0, 1)] private float longPaddlePowerupChance = 0.06f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public float GetBallSpeed()
    {
        return this.ballSpeed;
    }
    public float GetDoubleBallPowerUpChange()
    {
        return this.doubleBallPowerupChance;
    }
    public float GetlongPaddlePowerupChance()
    {
        return this.longPaddlePowerupChance;
    }
}
