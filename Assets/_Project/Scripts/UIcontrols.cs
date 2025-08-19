using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class UIcontrols : MonoBehaviour
{

    [SerializeField] movement player;
    // Start is called before the first frame update
    public event EventHandler UIChange;
    public class UIChangeEventArgs : EventArgs
    {
        //public bool currentGravUI;
        public int jumpsUI;
        public int flipsUI;
    }
    public event EventHandler<UIChangeEventArgs> UIChangeWithEventArgs;

    void Start()
    {
       // Component fullUI = GetComponentInChildren;
        player.UIWithEventArgs += UIUpdate;
    }



    // Update is called once per frame
    void Update()
    {
        
    }
    void UIUpdate(object sender, movement.UIEventArgs e)
    {
        UIChangeWithEventArgs?.Invoke(this, new UIChangeEventArgs { jumpsUI = e.jumpsUI, flipsUI = e.flipsUI });
    }
}
