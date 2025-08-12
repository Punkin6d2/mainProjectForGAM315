using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class playerInput : MonoBehaviour
{
    public event EventHandler OnSpacePressed;

    public class OnSpacePressedEventArgs : EventArgs
    {

    }

    public event EventHandler OnWasdPressed;

    public class OnWasdPressedEventArgs : EventArgs
    {

        public string PressedKey;

    }



    //main events being used
    public event EventHandler OnW;
    public event EventHandler OnA;
    public event EventHandler OnS;
    public event EventHandler OnD;
    public event EventHandler OnStop;
    public event EventHandler OnSpace;
    public bool GravityUp = false;
    public event EventHandler onR;
    void Start()
    {

    }

    // Update is called once per frame
    public event EventHandler<OnWasdPressedEventArgs> OnWasdPressedWithEventArgs;
    void Update()
    {
        //all 3 "get keys" are here for animations in the fucture
        /*
        //on press
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            // Debug.Log("wasd key pressed");
            OnWasdPressed?.Invoke(this, EventArgs.Empty);

            if (Input.GetKeyDown(KeyCode.W))
            {
                // OnWasdPressed?.Invoke(this, EventArgs.Empty);
                OnWasdPressedWithEventArgs?.Invoke(this, new OnWasdPressedEventArgs { PressedKey = "W" });
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                // OnWasdPressed?.Invoke(this, EventArgs.Empty);
                OnWasdPressedWithEventArgs?.Invoke(this, new OnWasdPressedEventArgs { PressedKey = "A" });
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                // OnWasdPressed?.Invoke(this, EventArgs.Empty);
                OnWasdPressedWithEventArgs?.Invoke(this, new OnWasdPressedEventArgs { PressedKey = "S" });
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                //  OnWasdPressed?.Invoke(this, EventArgs.Empty);
                OnWasdPressedWithEventArgs?.Invoke(this, new OnWasdPressedEventArgs { PressedKey = "D" });
            }

        }

        //on hold
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            // Debug.Log("wasd key pressed");
            OnWasdPressed?.Invoke(this, EventArgs.Empty);

            if (Input.GetKey(KeyCode.W))
            {
                // OnWasdPressed?.Invoke(this, EventArgs.Empty);
                OnWasdPressedWithEventArgs?.Invoke(this, new OnWasdPressedEventArgs { PressedKey = "Holding W" });
            }
            if (Input.GetKey(KeyCode.A))
            {
                // OnWasdPressed?.Invoke(this, EventArgs.Empty);
                OnWasdPressedWithEventArgs?.Invoke(this, new OnWasdPressedEventArgs { PressedKey = "Holding A" });
            }
            if (Input.GetKey(KeyCode.S))
            {
                // OnWasdPressed?.Invoke(this, EventArgs.Empty);
                OnWasdPressedWithEventArgs?.Invoke(this, new OnWasdPressedEventArgs { PressedKey = "Holding S" });
            }
            if (Input.GetKey(KeyCode.D))
            {
                //  OnWasdPressed?.Invoke(this, EventArgs.Empty);
                OnWasdPressedWithEventArgs?.Invoke(this, new OnWasdPressedEventArgs { PressedKey = "Holding D" });
            }

        }

        //on releace
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            // Debug.Log("wasd key pressed");
            OnWasdPressed?.Invoke(this, EventArgs.Empty);

            if (Input.GetKeyUp(KeyCode.W))
            {
                // OnWasdPressed?.Invoke(this, EventArgs.Empty);
                OnWasdPressedWithEventArgs?.Invoke(this, new OnWasdPressedEventArgs { PressedKey = "Not W" });
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                // OnWasdPressed?.Invoke(this, EventArgs.Empty);
                OnWasdPressedWithEventArgs?.Invoke(this, new OnWasdPressedEventArgs { PressedKey = "Not A" });
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                // OnWasdPressed?.Invoke(this, EventArgs.Empty);
                OnWasdPressedWithEventArgs?.Invoke(this, new OnWasdPressedEventArgs { PressedKey = "Not S" });
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                //  OnWasdPressed?.Invoke(this, EventArgs.Empty);
                OnWasdPressedWithEventArgs?.Invoke(this, new OnWasdPressedEventArgs { PressedKey = "Not D" });
            }

        }
        */
        //main game movement

        //jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Debug.Log("space pressed");
            OnSpacePressed?.Invoke(this, EventArgs.Empty);
            OnSpace?.Invoke(this, EventArgs.Empty);
            if (GravityUp == false) { 
            //normal gravity
            
            } else {
            //reversed gravity

            }
        }

        //Gravity up
        if (Input.GetKeyDown(KeyCode.W))
        {
            OnW?.Invoke(this, EventArgs.Empty);
           /* if (GravityUp == false) {
                //code
                GravityUp = true;
                OnW?.Invoke(this, EventArgs.Empty);
            } else {
            //do nothing
            } */
        }
        //Gravity down
        if (Input.GetKeyDown(KeyCode.S))
        {
            OnS?.Invoke(this, EventArgs.Empty);
          /*  if (GravityUp == false) {
            //do nothing
            } else {
                //code
                GravityUp = false;
                OnS?.Invoke(this, EventArgs.Empty);
            } */
        }

        //move left
        if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.A) && Input.GetKeyUp(KeyCode.D)) {
            //dont move
            }
            else
            {
                OnA?.Invoke(this, EventArgs.Empty);
            }
        }
        //move right
        if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.D) && Input.GetKeyUp(KeyCode.A))
            {
                //dont move
            }
            else
            {
                OnD?.Invoke(this, EventArgs.Empty);
            }
        }
        //stop moving
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            OnStop?.Invoke(this, EventArgs.Empty);
        }


    }
}