using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class movement : MonoBehaviour
{
    [SerializeField] playerInput eventPublisher;
    [SerializeField] int type;
    private float speed = 3;
    private float jumpPower = 2;
    private bool GravityUp = false;
    private Rigidbody2D rb2d;


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
    }

    // Update is called once per frame
    void Update()
    {

    }
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
        rb2d.gravityScale = -1;
        GravityUp = true;
    }
    void GravDown(object sender, EventArgs e) {
        rb2d.gravityScale = 1;
        GravityUp = false;
    }
    void GoLeft(object sender, EventArgs e) {
        //A
        Debug.Log("going left");
        rb2d.velocity = new Vector2(-1 * speed, rb2d.velocity.y);
    }
    void GoRight(object sender, EventArgs e) {
        //D
        Debug.Log("going right");
        rb2d.velocity = new Vector2(1 * speed, rb2d.velocity.y);
    }
    void noMove(object sender, EventArgs e)
    {
        rb2d.velocity = new Vector2(0, rb2d.velocity.y);
    }
    void JumpAction(object sender, EventArgs e) { 
    
    }

}