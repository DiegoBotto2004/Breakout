using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TitleScreen : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {

        Utils.AddButtonClickListener(parentTransform: this.transform, buttonName: "PlayButton", listener: () =>
        {
            SceneManager.LoadScene("MainGame");
        });

    }
}