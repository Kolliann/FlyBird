using UnityEngine;
using UnityEngine.Serialization;

public class Bird : MonoBehaviour
{
    //how much it takes off
    public float UpForce = 200f;

    //it's die player or no
    public static bool IsDead;
    [FormerlySerializedAs("_rb2D")] 
    public Rigidbody2D Rb2D;
    [FormerlySerializedAs("_anim")]
    public Animator Anim;

    // Update is called once per frame
    private void Update()
    {
        if (IsDead == false)
        {
            //Look for input to trigger a "flap".
            if (Input.GetMouseButtonDown(0))
            {
                //Play animation fly 
                Anim.SetTrigger("Flap");
                //...zero out the birds current y velocity before...
                Rb2D.velocity = Vector2.zero;
                //..giving the bird some upward force.
                Rb2D.AddForce(new Vector2(0, UpForce));
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        // Zero out the bird's velocity
        Rb2D.velocity = Vector2.zero;
        //Play animation die 
        Anim.SetTrigger("Die");
        // If the bird collides with something set it to dead...
        IsDead = true;
        //...and tell the game control about it.
        GameController.Instance.BirdDie();
    }
}