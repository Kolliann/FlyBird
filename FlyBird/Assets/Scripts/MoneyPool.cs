using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MoneyPool : MonoBehaviour
{
    //How many Coins to keep on standby.
    [FormerlySerializedAs("CoinsPoolSize")] public int CoinsPoolSize = 5;

    //The column game object.
    public GameObject CoinsPrefab;

    //How quickly columns spawn.
    [FormerlySerializedAs("spawn rate")] 
    public float SpawnRate = 3f;

    //Minimum y value of the column position.
    [FormerlySerializedAs("CoinsMin")] [FormerlySerializedAs("Coins min")] 
    public float CoinsMin = -1f;

    //Maximum y value of the column position.
    [FormerlySerializedAs("CoinsMax")] [FormerlySerializedAs("Coins max")] 
    public float CoinsMax = 3.5f;

    //Collection of pooled columns.
    private GameObject[] _Coins;

    //A holding position for our unused columns offscreen.
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    private float _timeSinceLastSpawned;
    private float spawnXPosition = 10f;
    private int _currentColumn = 0;

    // Start is called before the first frame update
    void Start()
    {
        _Coins = new GameObject[CoinsPoolSize];
        //Loop through the collection.
        for (int i = 0; i < CoinsPoolSize; i++)
        {
            //...and create the individual columns.
            _Coins[i] = (GameObject) Instantiate(CoinsPrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    //This spawns columns as long as the game is not over.
    void Update()
    {
        _timeSinceLastSpawned += Time.deltaTime;

        if (GameController.Instance.GameOver == false && _timeSinceLastSpawned >= SpawnRate)
        {
            _timeSinceLastSpawned = 0;
            //Set a random y position for the column
            float spawnYPosition = Random.Range(CoinsMin, CoinsMax);
            //...then set the current column to that position.
            _Coins[_currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            //Increase the value of currentColumn. If the new size is too big, set it back to zero
            _currentColumn++;
            if (_currentColumn >= CoinsPoolSize)
            {
                _currentColumn = 0;
            }
        }
    }
}
