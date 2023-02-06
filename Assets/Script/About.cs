using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class About : MonoBehaviour
{
    public void PressAbout()
    {
        SceneManager.LoadScene("About");
    }

    public void BackToStartScene()
    {
        SceneManager.LoadScene("Start Screen");
    }
}
