using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class viking_events : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 MovingDirection;
    MeshRenderer mr;
    float movingSpeed = 10f;
    void Awake()
    {
        
    }
    void Start()
    {
        mr = GetComponent<MeshRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.localPosition += movingSpeed * Time.deltaTime * Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.localPosition += movingSpeed * Time.deltaTime * Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition += movingSpeed * Time.deltaTime * Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition += movingSpeed * Time.deltaTime * Vector3.right;
        }
    }
}
