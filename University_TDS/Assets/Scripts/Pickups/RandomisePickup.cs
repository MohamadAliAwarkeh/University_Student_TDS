using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomisePickup : MonoBehaviour
{
    [Header("Obj Pickup")]
    public GameObject prefabObj01;
    public GameObject prefabObj02;
    public GameObject prefabObj03;
    public GameObject prefabObj04;
    public GameObject prefabObj05;
    [Space(10)]
    public float timeBetweenSpawns;

    //Private Variables
    private float timer;
    private GameManager gameManager;

    private void Start()
    {
        timer = timeBetweenSpawns;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();   
    }

    private void Update()
    {
        if (gameManager.gameState == GameState.InProgress)
        {
            //Simply checks if the object has a child or not! 
            if (transform.childCount > 0)
            {
                //Do nothing
            }
            else
            {
                //Counts down
                timer -= Time.deltaTime;
                //If timer reaches 0
                if (timer <= 0)
                {
                    //Reset
                    timer = timeBetweenSpawns;
                    //Calls function
                    RandomisePickupObj();
                }
            }
        }
    }

    private void RandomisePickupObj()
    {
        //Randomise number
        int randomValue = Random.Range(0, 4);
        //Randomise positions
        float x = Random.Range(-15f, 15f);
        float y = Random.Range(-8f, 8f);

        //Spawn object based on random value
        if (randomValue == 0)
        {
            GameObject newObj = Instantiate(prefabObj01, new Vector3(x, y, 0f), Quaternion.identity);
            newObj.transform.parent = this.transform;
        }
        if (randomValue == 1)
        {
            GameObject newObj = Instantiate(prefabObj02, new Vector3(x, y, 0f), Quaternion.identity);
            newObj.transform.parent = this.transform;
        }
        if (randomValue == 2)
        {
            GameObject newObj = Instantiate(prefabObj03, new Vector3(x, y, 0f), Quaternion.identity);
            newObj.transform.parent = this.transform;
        }
        if (randomValue == 3)
        {
            GameObject newObj = Instantiate(prefabObj04, new Vector3(x, y, 0f), Quaternion.identity);
            newObj.transform.parent = this.transform;
        }
        if (randomValue == 4)
        {
            GameObject newObj = Instantiate(prefabObj05, new Vector3(x, y, 0f), Quaternion.identity);
            newObj.transform.parent = this.transform;
        }
    }
}
