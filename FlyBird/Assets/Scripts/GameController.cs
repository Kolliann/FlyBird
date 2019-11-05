using System;
using System.Security.Cryptography.X509Certificates;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //A reference to our game control script so we can access it statically.
    public static GameController Instance;

    [FormerlySerializedAs("_gameOverText")]
    public GameObject GameOverText;

    [FormerlySerializedAs("_gameOver")]
    public bool GameOver = false;

    public float ScrollSpeed = -1.5f;

    private int _score = 0;
    private int _CoinsScore = 0;

    [FormerlySerializedAs("scoreText")] public Text ScoreText;
    [FormerlySerializedAs("coinsText")] public Text CoinsText;

    // Start is called before the first frame update
    private void Awake()
    {
        //If we don't currently have a game control...
        if (Instance == null)
        {
            //...set this one to be it...
            Instance = this;
        }
        //...otherwise...
        else if (Instance != this)
        {
            //...destroy this one because it is a duplicate.
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins"));
        _CoinsScore = PlayerPrefs.GetInt("Coins");
        CoinsText.text = "Coins: " + _CoinsScore;
    }

    // Update is called once per frame
    void Update()
    {

        /*
         //If the game is over and the player has pressed some input...
        if (GameOver && Input.GetMouseButtonDown(0))
        {
            //...reload the current scene.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Bird.IsDead = false;
        }*/
    }

    public void BirdScore()
    {
        //The bird can't score if the game is over.
        if (GameOver)
            return;
        //If the game is not over, increase the score...
        _score++;
        //...and adjust the score text.
        ScoreText.text = "Score: " + _score;
    }

    public void CoinsScore()
    {
        
        if (PlayerPrefs.GetInt("Coins") == 0)
        {
            _CoinsScore++;
            PlayerPrefs.SetInt("Coins", _CoinsScore);
            PlayerPrefs.Save();
            CoinsText.text = "Coins: " + _CoinsScore;
        }
        else
        {
            _CoinsScore = PlayerPrefs.GetInt("Coins");
            
            _CoinsScore++;
        
            CoinsText.text = "Coins: " + _CoinsScore;
            Debug.Log("Coins" + _CoinsScore);
            PlayerPrefs.SetInt("Coins", _CoinsScore);
            PlayerPrefs.Save();
        }
        
    }
//
    public void Reload()
    {
        //...reload the current scene.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Bird.IsDead = false;
    }

    public void LoadMenu()
    {

        SceneManager.LoadScene("Menu");
    }
    
    public void BirdDie()
    {
        Save();
       
        //Activate the game over text.
        GameOverText.SetActive(true);
        //Set the game to be over.
        GameOver = true;
    }

    private void Save()
    {
        if(PlayerPrefs.GetInt("BestScore") < _score)
            PlayerPrefs.SetInt("BestScore", _score);
        PlayerPrefs.SetInt("Coins", _CoinsScore);
        PlayerPrefs.Save();
    }
}