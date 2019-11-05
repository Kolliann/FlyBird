using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Text text;

    private void Start()
    {
        text.text = String.Format("Best: {0}", PlayerPrefs.GetInt("BestScore"));
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExistGame()
    {
#if UNITY_EDITOR
        Debug.Log("Quit work");
#endif
        Application.Quit();
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}