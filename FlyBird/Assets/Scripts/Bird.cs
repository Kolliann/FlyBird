using UnityEngine;
using UnityEngine.Serialization;

public class Bird : MonoBehaviour
{
    //how much it takes off
    public float UpForce = 200f;

    //it's die player or no
    public static bool IsDead;
    [FormerlySerializedAs("_rb2D")] public Rigidbody2D Rb2D;
    [FormerlySerializedAs("_anim")] public Animator Anim;


    // Start is called before the first frame update
    private void Start()
    {
        //
        // _rb2D = GetComponent<Rigidbody2D>();
        // _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (IsDead == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Play animation fly 
                Anim.SetTrigger("Flap");
                Rb2D.velocity = Vector2.zero;
                Rb2D.AddForce(new Vector2(0, UpForce));
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        Rb2D.velocity = Vector2.zero;
        //Play animation die 
        Anim.SetTrigger("Die");

        IsDead = true;

        GameController.Instance.BirdDie();
    }
}