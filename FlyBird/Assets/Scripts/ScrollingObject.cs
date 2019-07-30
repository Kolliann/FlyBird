using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{

    private Rigidbody2D _rb2D;
    // Start is called before the first frame update
    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        //Start the object moving.
        _rb2D.velocity  = new Vector2(GameController.Instance.ScrollSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // If the game is over, stop scrolling.
        if (GameController.Instance.GameOver == true)
        {
            _rb2D.velocity = Vector2.zero;
            
        }
    }
}
