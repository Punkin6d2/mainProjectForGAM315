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
    // Start is called before the first frame update
    void Start()
    {
        controler.UIChangeWithEventArgs += change;
    }

    void change(object sender, EventArgs e)
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
