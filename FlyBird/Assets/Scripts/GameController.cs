using System.Security.Cryptography.X509Certificates;
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

    [FormerlySerializedAs("scoreText")] public Text ScoreText;

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

    // Update is called once per frame
    void Update()
    {
        //If the game is over and the player has pressed some input...
       if (GameOver && Input.GetMouseButtonDown(0))
        //if (GameOver && gameOverBtn.)
        {
            //...reload the current scene.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //SceneManager.LoadScene("Menu");
            Bird.IsDead = false;
        }
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

    public void BirdDie()
    {
        //Activate the game over text.
        GameOverText.SetActive(true);
        //Set the game to be over.
        GameOver = true;
    }
}