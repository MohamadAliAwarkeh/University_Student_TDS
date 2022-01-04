using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCGWorld : MonoBehaviour
{
    [Header("World Objects")]
    public GameObject worldOne;
    public GameObject worldTwo;
    public GameObject worldThree;
    public GameObject worldFour;

    //Private Variables
    private int randomValue;

    private void Awake()
    {
        //Sets them false on awake, so there are no double ups
        worldOne.SetActive(false);
        worldTwo.SetActive(false);
        worldThree.SetActive(false);
        worldFour.SetActive(false); 
    }

    private void Start() => RandomiseWorld();

    private void RandomiseWorld()
    {
        //Set random value
        randomValue = Random.Range(1, 4);
        //Based
        if (randomValue == 1)
            worldOne.SetActive(true);
        if (randomValue == 2)
            worldTwo.SetActive(true);
        if (randomValue == 3)
            worldThree.SetActive(true);
        if (randomValue == 4)
            worldFour.SetActive(true);
    }
}
