using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class viking_movement : MonoBehaviour
{
    private bool turnLeft;
    private bool turnRight;
    private bool jump;
    private bool isGround = false;
    private bool isGameEnd = false;
    private bool isMove = false;

    //public GameObject floor;
    public Text Score;
    Animator animator;
    private int state = 0;
    public float speed = 7.0f;
    public GameObject enemy;
    private CharacterController myCharacterController;

    // Start is called before the first frame update
    void Start()
    {
        myCharacterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        animator.SetBool("Run", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            isMove = true;
            animator.SetBool("Run", isMove);
        }
        if (!isMove)
        {
            return;
        }
        turnLeft = Input.GetKeyDown(KeyCode.A);
        turnRight = Input.GetKeyDown(KeyCode.D);
        jump = Input.GetKeyDown(KeyCode.Space);

        coin_events.scores++;
        Score.text = Convert.ToString((int.Parse(Score.text) + 1));

        if (turnLeft)
        {
            transform.Rotate(new Vector3(0f, -90f, 0f));
            state = (state + 3) % 4;
        } else if (turnRight)
        {
            transform.Rotate(new Vector3(0f, 90f, 0f));
            state = (state + 1) % 4;
        } else if (jump && isGround)
        {
            transform.localPosition += new Vector3(0, 3, 0);
        }
        //myCharacterController.SimpleMove(new Vector3(0f, 0f, 0f));

        switch (state)
        {
            case 0:
                transform.localPosition += speed * Time.deltaTime * Vector3.forward;
                break;

            case 1:
                transform.localPosition += speed * Time.deltaTime * Vector3.right;
                break;

            case 2:
                transform.localPosition += speed * Time.deltaTime * Vector3.back;
                break;

            case 3:
                transform.localPosition += speed * Time.deltaTime * Vector3.left;
                break;

        }

        //transform.localPosition += speed * Time.deltaTime * Vector3.forward;
        if (transform.localPosition.y < -270 || enemy.transform.localPosition.z > -2)
        {
            isGameEnd = true;
        }

        if(enemy.transform.localPosition.z > -5)
        {
            enemy.transform.localPosition -= new Vector3(0, 0, 0.01f);
        }

        if (isGameEnd)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(2);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "floor")
        {
            isGround = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            isGround = true;
        }

        if (collision.gameObject.tag == "fence")
        {
            enemy.transform.localPosition += new Vector3(0, 0, 0.3f);
        }


    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "fence")
        {
            enemy.transform.localPosition += new Vector3(0, 0, 0.05f);
        }
    }


}
