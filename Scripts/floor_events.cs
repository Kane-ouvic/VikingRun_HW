using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floor_events : MonoBehaviour
{
    private int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
  
            
        
    }

    private void OnCollisionExit(Collision collision)
    { 
        Destroy(gameObject);
    }
}
