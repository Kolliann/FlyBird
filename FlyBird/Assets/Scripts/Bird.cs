using UnityEngine;

public class Bird : MonoBehaviour
{
    //how much it takes off
    private static float UpForce = 200f;

    //it's die player or no
    private static bool _isDead;
    private static Rigidbody2D _rb2D;
    private static Animator _anim;

    // Start is called before the first frame update
    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (_isDead == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _rb2D.velocity = Vector2.zero;
                _rb2D.AddForce(new Vector2(100, UpForce));
                //Play animation fly 
                _anim.SetTrigger("Flap");
            }
        }
    }

    private void OnCollisionEnter2D()
    {
        _isDead = true;
        //Play animation die 
        _anim.SetTrigger("Die");
    }
}