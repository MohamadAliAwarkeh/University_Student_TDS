using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCGTrees : MonoBehaviour
{
    [Header("Tree Prefabs")]
    public GameObject treeOne;
    public GameObject treeTwo;
    public GameObject treeThree;
    public GameObject treeFour;

    //Private Variables
    private int randomValue;

    private void Start()
    {
        //Set random value
        randomValue = Random.Range(1, 4);
        //Based on the value picked, spawn the respective tree
        if (randomValue == 1)
            Instantiate(treeOne, transform.position, Quaternion.identity);
        if (randomValue == 2)
            Instantiate(treeTwo, transform.position, Quaternion.identity);
        if (randomValue == 3)
            Instantiate(treeThree, transform.position, Quaternion.identity);
        if (randomValue == 4)
            Instantiate(treeFour, transform.position, Quaternion.identity);
    }
}
