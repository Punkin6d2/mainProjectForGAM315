using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class UIcounters : MonoBehaviour
{
    [SerializeField] UIcontrols controler;
    [SerializeField] string type;
    [SerializeField] int value;
    private Material currentMat;
   
    // Start is called before the first frame update
    void Start()
    {
        currentMat = GetComponent<MeshRenderer>().material;
        controler.UIChangeWithEventArgs += change;
    }

    void change(object sender, UIcontrols.UIChangeEventArgs e)
    {
        Debug.Log("UI got message");
 
        if (type == "flip")
        {
            if (value <= e.flipsUI)
            {
                currentMat.color = Color.cyan;
            } else
            {
                currentMat.color = Color.magenta;
            }
        } 
        else if (type == "jump")
        {
            if (value <= e.jumpsUI)
            {
                currentMat.color = Color.green;
            }
            else
            {
                currentMat.color = Color.red;
            }
        }


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
