using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class movement : MonoBehaviour
{
    [SerializeField] playerInput eventPublisher;
    [SerializeField] groundCheckDown groundDown;
    [SerializeField] groundCheckUp groundUp;
    [SerializeField] int type;
    private float speed = 8;
    private float jumpPower = 11;
    private bool GravityUp = false;
    private int jumpCount = 2;
    private int flipCount = 2;
    private Rigidbody2D rb2d;
    private Vector2 respawnLocation;
    private bool respawnGravityUp = false;

    // Start is called before the first frame update
    void Start()
    {
        //eventPublisher.OnWasdPressed += PrintWasd;
        eventPublisher.OnWasdPressedWithEventArgs += PrintWasd;
        eventPublisher.OnSpacePressed += PrintSpace;
       
        rb2d = GetComponent<Rigidbody2D>();
        eventPublisher.OnW += GravUp;
        eventPublisher.OnA += GoLeft;
        eventPublisher.OnS += GravDown;
        eventPublisher.OnD += GoRight;
        eventPublisher.OnSpace += JumpAction;
        eventPublisher.OnStop += noMove;
        groundDown.touchDown += onTouchDown;
        groundUp.touchUp += onTouchUp;
        groundDown.SpringDownWithEventArgs += springDownHit;
        groundUp.SpringUpWithEventArgs += springUpHit;

        // eventPublisher.Checkpoint += getCheckpoint;
        //   eventPublisher.Checkpoint += goCheckpoint;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //for testing
    void PrintWasd(object sender, playerInput.OnWasdPressedEventArgs e)
    {
        if (type == 0)
        {
            //   Debug.Log("proof wasd works");
            Debug.Log(e.PressedKey + " key pressed");

        }
    }
    void PrintSpace(object sender, EventArgs e)
    {
        if (type == 1)
        {
            Debug.Log("Jumping");
           // this.transform.Translate;
        }
    }

    //all of main movment
    void GravUp(object sender, EventArgs e) {
        if (flipCount >= 1)
        {
            flipCount -= 1;
            if (GravityUp == false)
            {

                rb2d.gravityScale = -1.7f;
                GravityUp = true;
                Debug.Log("grav set to up");
            }
        }
    }
    void GravDown(object sender, EventArgs e) {
        if (flipCount >= 1)
        {
            flipCount -= 1;
            if (GravityUp == true)
            {

                rb2d.gravityScale = 1.7f;
                GravityUp = false;
                Debug.Log("grav set to down");
            }
        }
    }
    void GoLeft(object sender, EventArgs e) {
        //A
        //Debug.Log("going left");
        rb2d.velocity = new Vector2(-1 * speed, rb2d.velocity.y);
    }
    void GoRight(object sender, EventArgs e) {
        //D
        //Debug.Log("going right");
        rb2d.velocity = new Vector2(1 * speed, rb2d.velocity.y);
    }
    void noMove(object sender, EventArgs e)
    {
        rb2d.velocity = new Vector2(0, rb2d.velocity.y);
    }
    void JumpAction(object sender, EventArgs e) {
        if (jumpCount >= 1)
        {
            jumpCount -= 1;
            if (GravityUp == false)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, 1 * jumpPower);
            }
            else
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, -1 * jumpPower);
            }
        }
    }



    //core triggers and coliders
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("KillBox"))
        {
            Debug.Log("Player died! Teleport to " + respawnLocation);

            //correct gravity first
            if (respawnGravityUp == false)
            {
                GravityUp = false;
                rb2d.gravityScale = 1.7f;
            }
            else
            {
                GravityUp = true;
                rb2d.gravityScale = -1.7f;
            }
            //then teleport
            rb2d.transform.position = respawnLocation;
            rb2d.velocity = new Vector2(0, 0);

        }
        if (other.CompareTag("Checkpoint"))
        {
           // Debug.Log("new checkpoint");
            respawnLocation = other.transform.position;
            Debug.Log("new checkpoint at " + respawnLocation);
            if (GravityUp == false)
            {
                respawnGravityUp = false;
            } else
            {
                respawnGravityUp = true;
            }
            Debug.Log("new checkpoint at " + respawnLocation + " with reversed gravity set to " + respawnGravityUp);
        }
    }
    void springDownHit(object sender, groundCheckDown.SpringDownEventArgs e)
    {
        Debug.Log("spring value reveved is " + e.springPower);
        rb2d.velocity = new Vector2(rb2d.velocity.x, e.springPower);
    }
    void springUpHit(object sender, groundCheckUp.SpringUpEventArgs e)
    {
        Debug.Log("spring value reveved is " + e.springPower);
        rb2d.velocity = new Vector2(rb2d.velocity.x, -e.springPower);
    }
    void onTouchDown(object sender, EventArgs e)
    {
        Debug.Log("colision on DOWN side");
        if (GravityUp == false) {
            jumpCount = 2;
            flipCount = 2;
            Debug.Log("movement restored by DOWN");
        }
    }
    void onTouchUp(object sender, EventArgs e)
    {
        Debug.Log("colision on UP side");
        if (GravityUp == true) {
            jumpCount = 2;
            flipCount = 2;
            Debug.Log("movement restored by UP");
        }
    }
}