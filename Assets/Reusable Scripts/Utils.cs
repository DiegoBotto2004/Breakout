using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Utils : MonoBehaviour
{
    /**
     * Includes aInt1 and aInt2
     */
    static public int GetRandomIntBetween(int int1, int int2)
    {
        return int1 + (int)Mathf.Floor(UnityEngine.Random.value * (int2 - int1 + 1));
    }


    static public T GetRandomListElement<T>(List<T> list)
    {
        return list[GetRandomIntBetween(0, list.Count - 1)];
    }


    static public void AddButtonClickListener(Transform parentTransform, string buttonName, UnityAction listener)
    {        
        Button playButton = parentTransform.Find(buttonName).GetComponent<Button>();
        playButton.onClick.AddListener(listener);        
    }

}
