using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class groundCheckDown : MonoBehaviour
{

    public event EventHandler touchDown;

    public class touchDownEventArgs : EventArgs
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            touchDown?.Invoke(this, EventArgs.Empty);
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
