using UnityEngine;

public class Bird : MonoBehaviour
{
    //how much it takes off
    public static float UpForce = 200f;

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
                //Play animation fly 
                _anim.SetTrigger("Flap");
                _rb2D.velocity = Vector2.zero;
                _rb2D.AddForce(new Vector2(0, UpForce));
                
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _rb2D.velocity = Vector2.zero;
        //Play animation die 
        _anim.SetTrigger("Die");

        _isDead = true;
        
        GameController.instance.BirdDie();
    }
}