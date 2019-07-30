using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Serialization;

public class ColumnPool : MonoBehaviour
{
    //How many columns to keep on standby.
    public int ColumnPoolSize = 5;

    //The column game object.
    public GameObject ColumnPrefab;

    //How quickly columns spawn.
    [FormerlySerializedAs("spawn rate")] 
    public float SpawnRate = 3f;

    //Minimum y value of the column position.
    [FormerlySerializedAs("column min")] 
    public float ColumnMin = -1f;

    //Maximum y value of the column position.
    [FormerlySerializedAs("column max")] 
    public float ColumnMax = 3.5f;

    //Collection of pooled columns.
    private GameObject[] _columns;

    //A holding position for our unused columns offscreen.
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    private float _timeSinceLastSpawned;
    private float spawnXPosition = 10f;
    private int _currentColumn = 0;

    // Start is called before the first frame update
    void Start()
    {
        _columns = new GameObject[ColumnPoolSize];
        //Loop through the collection.
        for (int i = 0; i < ColumnPoolSize; i++)
        {
            //...and create the individual columns.
            _columns[i] = (GameObject) Instantiate(ColumnPrefab, objectPoolPosition, Quaternion.identity);
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
            float spawnYPosition = Random.Range(ColumnMin, ColumnMax);
            //...then set the current column to that position.
            _columns[_currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            //Increase the value of currentColumn. If the new size is too big, set it back to zero
            _currentColumn++;
            if (_currentColumn >= ColumnPoolSize)
            {
                _currentColumn = 0;
            }
        }
    }
}