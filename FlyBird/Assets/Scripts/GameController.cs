using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public  GameObject _gameOverText;

    public  bool _gameOver = false;
    
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameOver == true && Input.GetMouseButtonDown(0))
        {
            _gameOver = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }

    public void BirdDie()
    {
        
        _gameOverText.SetActive(true);
        _gameOver = true;
    }
}
