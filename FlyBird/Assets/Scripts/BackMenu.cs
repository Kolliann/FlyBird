using UnityEngine;
using UnityEngine.SceneManagement;

public class BackMenu: MonoBehaviour
{
    public void BackMenuOther()
    {
        SceneManager.LoadScene("Menu");
    }
}