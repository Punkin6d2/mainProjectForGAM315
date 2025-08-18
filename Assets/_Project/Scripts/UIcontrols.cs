using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIcontrols : MonoBehaviour
{

    [SerializeField] movement player;
    // Start is called before the first frame update

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

    }
}
