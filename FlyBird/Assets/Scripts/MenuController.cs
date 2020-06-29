using System;
using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    
    public Text text;
    public Text textCoins;

    private void Start()
    {
        
        text.text = String.Format("Best: {0}", PlayerPrefs.GetInt("BestScore"));
        textCoins.text = String.Format("Coins: {0}", PlayerPrefs.GetInt("Coins"));
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OpenShop()
    {
        SceneManager.LoadScene("Shop");
    }
    
    public void OpenPrestige()
    {
        SceneManager.LoadScene("Prestige");
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