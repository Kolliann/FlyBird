using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{

    public int ColumnPoolSize = 5;

    public GameObject ColumnPrefab;
    
    private GameObject[] _columns;
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    private float timeSinceLastSpawned;

    // Start is called before the first frame update
    void Start()
    {
        _columns = new GameObject[ColumnPoolSize];
        for (int i = 0; i < ColumnPoolSize; i++)
        {
            _columns[i] = (GameObject) Instantiate(ColumnPrefab, objectPoolPosition, Quaternion.identity);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
