using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class movement : MonoBehaviour
{
    [SerializeField] playerInput eventPublisher;

    [SerializeField] int type;
    // Start is called before the first frame update
    void Start()
    {
        //eventPublisher.OnWasdPressed += PrintWasd;
        eventPublisher.OnWasdPressedWithEventArgs += PrintWasd;
        eventPublisher.OnSpacePressed += PrintSpace;

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
            this.transform.Translate
        }
    }
}