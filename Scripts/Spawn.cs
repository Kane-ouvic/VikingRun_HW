using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject tileToSpawn;
    public GameObject tileToSpawn1;
    public GameObject tileToSpawn2;
    public GameObject tileToSpawn3;
    public GameObject coinSpawn;
    public GameObject blockSpawn;
    public GameObject blockSpawn1;
    public GameObject blockSpawn2;
    public GameObject blockSpawn3;
    public GameObject referenceObject;

    public float timeOffset = 0.4f;
    public float distanceBetweenTiles = 0.5f;

    public float randomValue;
    private float randomValue_floor;
    private float randomValue_coin;
    private float randomValue_block;

    private Vector3 previousTilePosition;
    private float startTime;
    private Vector3 direction = new Vector3(0, 0, 1);
    private Vector3 mainDirection = new Vector3(0, 0, 1);
    private Vector3 otherDirection = new Vector3(1, 0, 0);
    private int counter = 0;
    private int state = 0;
    private bool isEmpty = false;

    private Vector3 Direction0 = new Vector3(0, 0, 1);
    private Vector3 Direction1 = new Vector3(0, 0, -1);
    private Vector3 Direction2 = new Vector3(1, 0, 0);
    private Vector3 Direction3 = new Vector3(-1, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        previousTilePosition = referenceObject.transform.position + new Vector3(-0.5f,-2,0);
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        randomValue = Random.value;
        randomValue_block = Random.value;
        randomValue_floor = Random.value;
        randomValue_coin = Random.value;

        if (Time.time - startTime > timeOffset)
        {
            counter++;
            
            if(counter == 15)
            {
                counter = 0;

                if(state == 0)
                {
                    if(randomValue < 0.5)
                    {
                        state = 2;
                        direction = Direction2;
                    }
                    else
                    {
                        state = 3;
                        direction = Direction3;
                    }
                }
                else if(state == 1)
                {
                    if (randomValue < 0.5)
                    {
                        state = 2;
                        direction = Direction2;
                    }
                    else
                    {
                        state = 3;
                        direction = Direction3;
                    }
                }
                else if(state == 2)
                {
                    if (randomValue < 0.5)
                    {
                        state = 0;
                        direction = Direction0;
                    }
                    else
                    {
                        state = 1;
                        direction = Direction1;
                    }
                }
                else
                {
                    if (randomValue < 0.5)
                    {
                        state = 0;
                        direction = Direction0;
                    }
                    else
                    {
                        state = 1;
                        direction = Direction1;
                    }
                }
                /*
                if (randomValue < 0.33)
                {
                    direction = Direction0;
                }
                else if (randomValue >= 0.33 && randomValue < 0.66)
                {
                    direction = Direction1;
                }
                else
                {
                    direction = Direction2;
                }*/
            }
            

            Vector3 spawnPos = previousTilePosition + distanceBetweenTiles * direction;
            startTime = Time.time;
            if(randomValue > 0.1 || isEmpty == true) // 地板生成
            {
                /*if (randomValue_floor >= 0 && randomValue_floor < 0.25)
                {
                    Instantiate(tileToSpawn, spawnPos, Quaternion.Euler(0, 0, 0));
                    tileToSpawn.AddComponent<floor_events>();
                }
                else if (randomValue_floor >= 0.25 && randomValue_floor < 0.5)
                {
                    Instantiate(tileToSpawn1, spawnPos, Quaternion.Euler(0, 0, 0));
                    tileToSpawn.AddComponent<floor_events>();
                }
                else if (randomValue_floor >= 0.5 && randomValue_floor < 0.75)
                {
                    Instantiate(tileToSpawn2, spawnPos, Quaternion.Euler(0, 0, 0));
                    tileToSpawn.AddComponent<floor_events>();
                }
                else
                {
                    Instantiate(tileToSpawn3, spawnPos, Quaternion.Euler(0, 0, 0));
                    tileToSpawn.AddComponent<floor_events>();
                }*/
                Instantiate(tileToSpawn, spawnPos, Quaternion.Euler(0, 0, 0));
                tileToSpawn.AddComponent<floor_events>();
                isEmpty = false;
            }
            else
            {
                isEmpty = true;
            }

            if(randomValue < 0.3) //金幣生成
            {

                Instantiate(coinSpawn, spawnPos + new Vector3(0, 1, 0), Quaternion.identity);

            }
            if (randomValue > 0.3 && randomValue < 0.5) // 障礙物生成
            {
                

                if (randomValue_block >= 0 && randomValue_block < 0.25)
                {
                    Instantiate(blockSpawn, spawnPos, Quaternion.Euler(0, 0, 0));
                }
                else if(randomValue_block >= 0.25 && randomValue_block < 0.5)
                {
                    Instantiate(blockSpawn1, spawnPos, Quaternion.Euler(0, 0, 0));
                }
                else if (randomValue_block >= 0.5 && randomValue_block < 0.75)
                {
                    Instantiate(blockSpawn2, spawnPos, Quaternion.Euler(0, 0, 0));
                }
                else
                {
                    Instantiate(blockSpawn3, spawnPos + new Vector3(0,3,0), Quaternion.Euler(0, 0, 0));
                }
            }

            
            previousTilePosition = spawnPos;
        }
    }
}
