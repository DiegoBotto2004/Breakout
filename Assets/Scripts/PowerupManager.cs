using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PowerupManager : MonoBehaviour
{

    [SerializeField] private GameObject doubleBallPowerup;
    [SerializeField] private GameObject longPaddlePowerup;
    static public PowerupManager instance;
    

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void MaybeCreatePowerup(Vector2 position)
    {
        float random = Random.value;

        float chanceOfDoubleBallPowerup = 0.15f;
        float chanceOfLongPaddlePowerup = 0.1f;

        if (random < chanceOfDoubleBallPowerup)
        {
            CreatePowerup(doubleBallPowerup, position);
        }
        else if (random < chanceOfDoubleBallPowerup + chanceOfLongPaddlePowerup)
        {
            CreatePowerup(longPaddlePowerup, position);
        }
    }

    private void CreatePowerup(GameObject prefab, Vector2 position)
    {
        GameObject powerupGameObject = Instantiate(original: prefab);
        powerupGameObject.transform.position = position;
    }
}
