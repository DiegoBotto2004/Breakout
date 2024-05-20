using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    static private int currentLevelNumber = 1;
    internal static LevelManager instance;
    private void Awake()
    {
        instance = this;

        RefreshLevels();
    }
    private void RefreshLevels()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        // Itero sobre los hijos del LevelManager
        {
            Transform levelTransform = this.transform.GetChild(i);
            // Si el hijo en el que estoy es el nivel actual, prenderlo, si no, apagarlo
            if (i + 1 == LevelManager.currentLevelNumber)
            {
                levelTransform.gameObject.SetActive(true);
            }
            else
            {
                levelTransform.gameObject.SetActive(false);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextLevel()
    {
        LevelManager.currentLevelNumber++;
    }
    public Level GetCurrentLevel()
    {
        Transform levelTransform =
        this.transform.GetChild(LevelManager.currentLevelNumber - 1);
        return levelTransform.GetComponent<Level>();
    }
}
