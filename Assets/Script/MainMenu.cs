using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public string leveLoad = "Level";

    public SceneFader sceneFader;
    
    public void Play()
    {
        sceneFader.FadeTo(leveLoad);
    }

    public void Quit()
    {
        Debug.Log("Exitiing..");
        Application.Quit();
    }
}
