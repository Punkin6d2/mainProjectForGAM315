using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class groundCheckDown : MonoBehaviour
{

    public event EventHandler touchDown;
 
    private springControls powerScript;
    public float power;

    public event EventHandler springDown;
    public class SpringDownEventArgs : EventArgs
    {
        public float springPower;
    }
    public event EventHandler<SpringDownEventArgs> SpringDownWithEventArgs;

    public class touchDownEventArgs : EventArgs
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            touchDown?.Invoke(this, EventArgs.Empty);
        }
        if (other.CompareTag("Spring"))
        {
            
            powerScript = other.GetComponent<springControls>();
            if (powerScript == null)
            {
                Debug.Log("spring hit but script not found");
            } else
            {
                Debug.Log("object script found");
                power = powerScript.springPower;
                Debug.Log("power is " + power);
                SpringDownWithEventArgs?.Invoke(this, new SpringDownEventArgs { springPower = power });
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
