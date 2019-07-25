using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    [FormerlySerializedAs("_gameOverText")]
    public GameObject GameOverText;

    [FormerlySerializedAs("_gameOver")] public bool GameOver = false;

    public float ScrollSpeed = -1.5f;

    private int score = 0;

    public Text scoreText;

    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Bird.IsDead = false;
        }
    }

    public void BirdScore()
    {
        if (GameOver)
            return;

        score++;

        scoreText.text = "Score: " + score;
    }

    public void BirdDie()
    {
        GameOverText.SetActive(true);
        GameOver = true;
    }
}