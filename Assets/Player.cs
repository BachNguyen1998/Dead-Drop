using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public GameObject player;
    public float movementSpeed = 2f;
    public float jumpForce = 5f;
    public float deathSpeed = 3f;
    Rigidbody2D rb;
    int horizontal = 0;
    int vertical = 0;
    int collided = 0;
    private Vector2 touchOrigin = -Vector2.one; //Used to store location of screen touch origin for mobile controls.
    float station_x;
    bool facingRight = true;

    Animator anim;

    void Start()
    {
        //Destroy(player);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void OnCollisionStay2D()
    {
        collided = 1;
    }
    void OnCollisionExit2D()
    {
        collided = 0;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        /*
        if ((collision.collider.gameObject.name == "bottom" || collision.collider.gameObject.name == "left" || collision.collider.gameObject.name == "right") && (collision.relativeVelocity.x>=deathSpeed || collision.relativeVelocity.y>=deathSpeed)) {
            Destroy(player);
        }
        if (collision.collider.gameObject.name == "bottom")
            Destroy(player);
            */
    }
    void Update()
    {
        //movement = Input.GetAxis("Horizontal"); 

        //Check if Input has registered more than zero touches && player is on collision
        if (Input.touchCount > 0 && collided == 1)
        {
            //Store the first touch detected.
            Touch myTouch = Input.touches[0];

            //Check if the phase of that touch equals Began
            if (myTouch.phase == TouchPhase.Began)
            {

                //If so, set touchOrigin to the position of that touch
                touchOrigin = myTouch.position;
            }

            //If the touch phase is not Began, and instead is equal to Ended and the x of touchOrigin is greater or equal to zero:
            else if (myTouch.phase == TouchPhase.Ended && touchOrigin.x >= 0)
            {
                anim.SetBool("Touched", false);
                //Set touchEnd to equal the position of this touch
                Vector2 touchEnd = myTouch.position;

                //Calculate the difference between the beginning and end of the touch on the x axis.
                float x = touchEnd.x - touchOrigin.x;

                //Calculate the difference between the beginning and end of the touch on the y axis.
                float y = touchEnd.y - touchOrigin.y;

                //Set touchOrigin.x to -1 so that our else if statement will evaluate false and not repeat immediately.
                touchOrigin.x = -1;
                horizontal = x > 0 ? 1 : -1;
                vertical = y > 0 ? 1 : -1;

                Vector2 velocity = rb.velocity;
                velocity.x = horizontal * movementSpeed;
                if (anim.GetBool("Collided") == false)
                {
                    if (velocity.x > 0 && !facingRight)
                        Flip();
                    if (velocity.x < 0 && facingRight)
                        Flip();
                }
                velocity.y = vertical * jumpForce;
                rb.velocity = velocity;
                //player.GetComponent<Rigidbody2D>().velocity = velocity;
            }

            // running by fixed touch
            else if (myTouch.phase == TouchPhase.Stationary)
            {
                anim.SetBool("Touched", true);
                Vector2 touchEnd = myTouch.position;
                station_x = touchEnd.x;
                if (station_x != 0)
                    station_x = touchEnd.x - Screen.width / 2;
                horizontal = station_x > 0 ? 1 : -1;
                Vector2 velocity = rb.velocity;
                velocity.x = horizontal * movementSpeed;
                if (velocity.x > 0 && !facingRight)
                    Flip();
                if (velocity.x < 0 && facingRight)
                    Flip();
                rb.velocity = velocity;
            }
        }
    }
    void FixedUpdate()
    {
        /*
        Vector2 velocity = rb.velocity;
        velocity.x = horizontal*movementSpeed;
        velocity.y = vertical*movementSpeed;
        rb.velocity = velocity;*/
        if (collided == 1)
            anim.SetBool("Collided", true);
        if (collided == 0)
            anim.SetBool("Collided", false);
        anim.SetFloat("Running Speed", Mathf.Abs(rb.velocity.x));
        anim.SetFloat("Vertical Speed", rb.velocity.y);
    }
    /*void OnGUI()
    {
        GUI.Label(new Rect(50, 0, 100, 100), anim.GetBool("Collided").ToString());
        GUI.Label(new Rect(50, 20, 100, 100), anim.GetBool("Touched").ToString());
    }*/
    void Flip() {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    void PlayAudio(string aud)
    {
        SoundManagerScript.PlaySound(aud);
    }

}
