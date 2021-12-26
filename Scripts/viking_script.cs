using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]

public class viking_script : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 MovingDirection;
    public float JumpingForce;
    public GameObject testMap;

    Rigidbody rb;
    Animator animator;
    bool onGround = false;
    bool run = false;

    MeshRenderer mr;
    [SerializeField]float movingSpeed = 10f;
    void Awake()
    {

    }
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        run = false;
        if (Input.GetKey(KeyCode.W))
        {
            transform.localPosition += movingSpeed * Time.deltaTime * Vector3.forward;
            run = true;
            //Instantiate(testMap, transform.position + new Vector3(0, -5, 0), transform.rotation);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.localPosition += movingSpeed * Time.deltaTime * Vector3.back;
            run = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition += movingSpeed * Time.deltaTime * Vector3.left;
            run = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition += movingSpeed * Time.deltaTime * Vector3.right;
            run = true;
        }

        animator.SetBool("Run", run);
    }
}
