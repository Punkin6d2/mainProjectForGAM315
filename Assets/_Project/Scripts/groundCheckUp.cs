using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class groundCheckUp : MonoBehaviour
{

    public event EventHandler touchUp;

    public class touchUpEventArgs : EventArgs
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            touchUp?.Invoke(this, EventArgs.Empty);
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
