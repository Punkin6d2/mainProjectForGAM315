using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class groundCheckUp : MonoBehaviour
{

    public event EventHandler touchUp;
    private springControls powerScript;
    public float power;

    public event EventHandler springUp;
    public class SpringUpEventArgs : EventArgs
    {
        public float springPower;
    }
    public event EventHandler<SpringUpEventArgs> SpringUpWithEventArgs;


    public class touchUpEventArgs : EventArgs
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            touchUp?.Invoke(this, EventArgs.Empty);
        }
        if (other.CompareTag("Spring"))
        {
            powerScript = other.GetComponent<springControls>();
            if (powerScript == null)
            {
                Debug.Log("spring hit but script not found");
            }
            else
            {
                Debug.Log("object script found");
                power = powerScript.springPower;
                Debug.Log("power is " + power);
                SpringUpWithEventArgs?.Invoke(this, new SpringUpEventArgs { springPower = power });
            }

        }
    }
        // Start is called before the first frame update
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
