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

    void Start()
    {

    }

    // Update is called once per frame
    public event EventHandler<OnWasdPressedEventArgs> OnWasdPressedWithEventArgs;
    void Update()
    {
        //all 3 "get keys" are here for animations in the fucture

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Debug.Log("space pressed");
            OnSpacePressed?.Invoke(this, EventArgs.Empty);
        }

    }
}