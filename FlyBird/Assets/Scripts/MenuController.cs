using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
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