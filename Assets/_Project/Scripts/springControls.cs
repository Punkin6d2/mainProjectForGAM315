using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class springControls : MonoBehaviour
{
    [SerializeField] public float springPower;
    [SerializeField] bool springDown;
    [SerializeField] groundCheckDown groundDown;
    [SerializeField] groundCheckUp groundUp;
    


    //    eventPublisher.springHitDown += springHit;
   // public event groundCheckDown springHitD;



    // Start is called before the first frame update
    void Start()
    {
       // GetComponent<"downGroundBox">;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public float myPower()
    {
        return springPower;
    }
    void springHitD()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("downSensor"))
        {

        }
        if (other.CompareTag("upSensor"))
        {

        }
    }
}
