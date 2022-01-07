using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessEnemyType : MonoBehaviour
{
    [Header("Prefab")]
    public GameObject enemyPrefab;

    [Header("Weights")]
    public int minSpawnWeight;
    public int maxSpawnWeight;
}
