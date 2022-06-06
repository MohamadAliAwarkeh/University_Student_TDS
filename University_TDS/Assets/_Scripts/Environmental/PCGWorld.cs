using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCGWorld : MonoBehaviour
{
    [Header("Generation States")]
    public GenerationStates generationState;

    [Header("Worlds")]
    public GameObject worldOne;
    public GameObject worldTwo;
    public GameObject worldThree;
    public GameObject worldFour;

    [Header("Objects")]
    public GameObject treeOne;
    public GameObject treeTwo;
    public GameObject treeThree;
    public GameObject treeFour;
    public GameObject barricadeMetal;
    public GameObject barricadeWood;
    public GameObject fenceRed;
    public GameObject fenceYellow;
    public GameObject sandbag01;
    public GameObject sandbag02;


    [Header("Object Positions")]
    public float minXPos;
    public float maxXPos;
    public float minYPos;
    public float maxYPos;

    //Private Variables
    private int MaxNumOfObjects = 20;
    private int currentNumOfObjects = 0;

    private void Update()
    {
        //Handle states
        switch (generationState)
        {
            case GenerationStates.World:
                CreateWorld();
                generationState = GenerationStates.Objects;
                break;

            case GenerationStates.Objects:
                CreateObjects();
                //generationState = GenerationStates.Completed;
                break;
        }
    }

    #region World Generation
    private GameObject CreateWorld()
    {
        GameObject newObj = Instantiate(SelectRandomWorld(), transform.position, Quaternion.identity);
        newObj.transform.parent = this.transform;
        return newObj;
    }

    private GameObject SelectRandomWorld()
    {
        //Set random value
        int randomValue = Random.Range(1, 4);

        //Select obj
        if (randomValue == 1)
        {
            GameObject newObj = worldOne;
            return newObj;
        }
        if (randomValue == 2)
        {
            GameObject newObj = worldTwo;
            return newObj;
        }
        if (randomValue == 3)
        {
            GameObject newObj = worldThree;
            return newObj;
        }
        if (randomValue == 4)
        {
            GameObject newObj = worldFour;
            return newObj;
        }

        //Fail
        return null;
    }
    #endregion

    private GameObject CreateObjects()
    {
        if (currentNumOfObjects < MaxNumOfObjects)
        {
            GameObject newObj = Instantiate(SelectRandomObj(), RandomisePosition(), RandomiseRotation());
            newObj.transform.parent = this.transform;
            currentNumOfObjects++;
            return newObj;
        }

        return null;
    }

    private GameObject SelectRandomObj()
    {
        //Set random value
        int randomValue = Random.Range(1, 10);

        //Select obj
        if (randomValue == 1)
        {
            GameObject newObj = treeOne;
            return newObj;
        }
        if (randomValue == 2)
        {
            GameObject newObj = treeTwo;
            return newObj;
        }
        if (randomValue == 3)
        {
            GameObject newObj = treeThree;
            return newObj;
        }
        if (randomValue == 4)
        {
            GameObject newObj = treeFour;
            return newObj;
        }
        if (randomValue == 5)
        {
            GameObject newObj = barricadeMetal;
            return newObj;
        }
        if (randomValue == 6)
        {
            GameObject newObj = barricadeWood;
            return newObj;
        }
        if (randomValue == 7)
        {
            GameObject newObj = fenceRed;
            return newObj;
        }
        if (randomValue == 8)
        {
            GameObject newObj = fenceYellow;
            return newObj;
        }
        if (randomValue == 9)
        {
            GameObject newObj = sandbag01;
            return newObj;
        }
        if (randomValue == 10)
        {
            GameObject newObj = sandbag02;
            return newObj;
        }

        //Fail
        return null;
    }

    private Vector2 RandomisePosition()
    {
        return new Vector2(Random.Range(minXPos, maxXPos), Random.Range(minYPos, maxYPos));
    }

    private Quaternion RandomiseRotation()
    {
        return Quaternion.Euler(0, 0, Random.Range(0, 360));
    }
}

public enum GenerationStates
{
    World,
    Objects,
    Completed
}
