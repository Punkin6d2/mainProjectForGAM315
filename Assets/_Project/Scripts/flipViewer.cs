using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;



public class flipViewer : MonoBehaviour
{

    [SerializeField] movement flip;




    // Start is called before the first frame update
    void Start()
    {
        flip.showFlipWithEventArgs += goFlip;
    }

    void goFlip(object sender, movement.showFlipEventArgs e)
    {
        // true is up, false is down.
        if (e.currentGrav == false)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        } else
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
