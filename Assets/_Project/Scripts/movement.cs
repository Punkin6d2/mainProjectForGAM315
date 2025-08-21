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
    private float speed = 7;
    private float jumpPower = 9;
    private bool GravityUp = false;
    private int jumpCount = 2;
    private int flipCount = 2;
    private Rigidbody2D rb2d;
    private Vector2 respawnLocation;
    private bool respawnGravityUp = false;

    public event EventHandler showFlip;
    public class showFlipEventArgs : EventArgs
    { 
        public bool currentGrav;
    }
    public event EventHandler<showFlipEventArgs> showFlipWithEventArgs;
    // showFlipWithEventArgs?.Invoke(this, new showFlipEventArgs { currentGrav = GravityUp });

    public event EventHandler UI;
    public class UIEventArgs : EventArgs
    {
        public int jumpsUI;
        public int flipsUI;
    }
    public event EventHandler<UIEventArgs> UIWithEventArgs;
    // UIWithEventArgs?.Invoke(this, new UIEventArgs {jumpsUI = jumpCount, flipsUI = flipCount});

    // Start is called before the first frame update
    void Start()
    {  
        rb2d = GetComponent<Rigidbody2D>();
        eventPublisher.OnW += GravUp;
        eventPublisher.OnA += GoLeft;
        eventPublisher.OnS += GravDown;
        eventPublisher.OnD += GoRight;
        eventPublisher.OnSpace += JumpAction;
        eventPublisher.OnStop += noMove;
        eventPublisher.OnR += GoBack;
        groundDown.touchDown += onTouchDown;
        groundUp.touchUp += onTouchUp;
        groundDown.SpringDownWithEventArgs += springDownHit;
        groundUp.SpringUpWithEventArgs += springUpHit;

        UIWithEventArgs?.Invoke(this, new UIEventArgs { jumpsUI = jumpCount, flipsUI = flipCount });
    }

    // Update is called once per frame
    void Update()
    {

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
                showFlipWithEventArgs?.Invoke(this, new showFlipEventArgs { currentGrav = GravityUp });
            }
            UIWithEventArgs?.Invoke(this, new UIEventArgs { jumpsUI = jumpCount, flipsUI = flipCount });
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
                showFlipWithEventArgs?.Invoke(this, new showFlipEventArgs { currentGrav = GravityUp });
            }
            UIWithEventArgs?.Invoke(this, new UIEventArgs { jumpsUI = jumpCount, flipsUI = flipCount });
        }
    }
    void GoLeft(object sender, EventArgs e) {
        //A
        rb2d.velocity = new Vector2(-1 * speed, rb2d.velocity.y);
    }
    void GoRight(object sender, EventArgs e) {
        //D
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
            UIWithEventArgs?.Invoke(this, new UIEventArgs { jumpsUI = jumpCount, flipsUI = flipCount });
        }
    }

    void GoBack(object sender, EventArgs e)
    {
        Debug.Log("Player died! Teleport to " + respawnLocation);

        //correct gravity first
        if (respawnGravityUp == false)
        {
            GravityUp = false;
            rb2d.gravityScale = 1.7f;
            showFlipWithEventArgs?.Invoke(this, new showFlipEventArgs { currentGrav = GravityUp });
        }
        else
        {
            GravityUp = true;
            rb2d.gravityScale = -1.7f;
            showFlipWithEventArgs?.Invoke(this, new showFlipEventArgs { currentGrav = GravityUp });
        }
        //then teleport
        rb2d.transform.position = respawnLocation;
        rb2d.velocity = new Vector2(0, 0);
        jumpCount = 2;
        flipCount = 2;
        Debug.Log("movement restored by RESET DEATH");
        UIWithEventArgs?.Invoke(this, new UIEventArgs { jumpsUI = jumpCount, flipsUI = flipCount });
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
                showFlipWithEventArgs?.Invoke(this, new showFlipEventArgs { currentGrav = GravityUp });
            }
            else
            {
                GravityUp = true;
                rb2d.gravityScale = -1.7f;
                showFlipWithEventArgs?.Invoke(this, new showFlipEventArgs { currentGrav = GravityUp });
            }
            //then teleport
            rb2d.transform.position = respawnLocation;
            rb2d.velocity = new Vector2(0, 0);
            jumpCount = 2;
            flipCount = 2;
            Debug.Log("movement restored by DEATH");
            UIWithEventArgs?.Invoke(this, new UIEventArgs { jumpsUI = jumpCount, flipsUI = flipCount });
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
    //springs
    void springDownHit(object sender, groundCheckDown.SpringDownEventArgs e)
    {
        Debug.Log("spring value reveved is " + e.springPower);
        rb2d.velocity = new Vector2(rb2d.velocity.x, e.springPower);
        //set flips and jumps to at least 1
        if (flipCount <= 0)
        {
            Debug.Log("flipCount is 0, setting to 1");
            flipCount = 1;
        }
        if (jumpCount <= 0)
        {
            Debug.Log("jumpCount is 0, setting to 1");
            jumpCount = 1;
        }
        UIWithEventArgs?.Invoke(this, new UIEventArgs { jumpsUI = jumpCount, flipsUI = flipCount });
    }
    void springUpHit(object sender, groundCheckUp.SpringUpEventArgs e)
    {
        Debug.Log("spring value reveved is " + e.springPower);
        rb2d.velocity = new Vector2(rb2d.velocity.x, -e.springPower);
        //set flips and jumps to at least 1
        if (flipCount <= 0)
        {
            Debug.Log("flipCount is 0, setting to 1");
            flipCount = 1;
        }
        if (jumpCount <= 0)
        {
            Debug.Log("jumpCount is 0, setting to 1");
            jumpCount = 1;
        }
        UIWithEventArgs?.Invoke(this, new UIEventArgs { jumpsUI = jumpCount, flipsUI = flipCount });
    }
    //touch ground
    void onTouchDown(object sender, EventArgs e)
    {
        Debug.Log("colision on DOWN side");
        if (GravityUp == false) {
            jumpCount = 2;
            flipCount = 2;
            Debug.Log("movement restored by DOWN");
            UIWithEventArgs?.Invoke(this, new UIEventArgs { jumpsUI = jumpCount, flipsUI = flipCount });
        }
    }
    void onTouchUp(object sender, EventArgs e)
    {
        Debug.Log("colision on UP side");
        if (GravityUp == true) {
            jumpCount = 2;
            flipCount = 2;
            Debug.Log("movement restored by UP");
            UIWithEventArgs?.Invoke(this, new UIEventArgs { jumpsUI = jumpCount, flipsUI = flipCount });
        }
    }
}