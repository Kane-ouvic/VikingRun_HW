using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class coin_events : MonoBehaviour
{
    // Start is called before the first frame update

    public Text Score;
    public static int scores;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.name == "viking")
        {
            scores += 1000;
            Score.text = Convert.ToString((int.Parse(Score.text) + 1000));
            Destroy(gameObject);
        }
    }
}
