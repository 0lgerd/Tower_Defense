using System;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneFader : MonoBehaviour
{
    public Image img;
    public AnimationCurve fadeCurve;

    // Start the fade-in effect on scene start
    private void Start()
    {
        try
        {
            StartCoroutine(FadeIn());
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in Start(): {ex.Message}");
        }
    }

    // Coroutine for fading in
    IEnumerator FadeIn()
    {
        float time = 1f;

        // Gradually decrease alpha value for fade-in effect
        while (time > 0f)
        {
            time -= Time.deltaTime;
            float alpha = fadeCurve.Evaluate(time);
            img.color = new Color(0f, 0f, 0f, alpha);
            yield return 0;
        }
    }

    // Trigger the fade-out effect and load the specified scene
    public void FadeTo(string scene)
    {
        try
        {
            StartCoroutine(FadeOut(scene));
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in FadeTo(): {ex.Message}");
        }
    }

    // Coroutine for fading out
    IEnumerator FadeOut(string scene)
    {
        float time = 0f;

        // Gradually increase alpha value for fade-out effect
        while (time < 1f)
        {
            time += Time.deltaTime;
            float alpha = fadeCurve.Evaluate(time);
            img.color = new Color(0f, 0f, 0f, alpha);
            yield return 0;
        }

        // Load the specified scene
        SceneManager.LoadScene(scene);

    }
}
