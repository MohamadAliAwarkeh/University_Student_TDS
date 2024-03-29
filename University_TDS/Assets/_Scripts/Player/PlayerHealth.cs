using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int health;

    [Header("UI")]
    public SpriteRenderer health1;
    public SpriteRenderer health2;
    public SpriteRenderer health3;
    [Space(10)]
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;

    //Private Variable
    private GameManager gameManager;
    [HideInInspector]public int maxHealth;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();   
    }

    private void Update()
    {
        //Call function
        DisplayHealth();
        MaxHealthDisplay();

        //Cap health
        if (health >= maxHealth)
            health = maxHealth;
    }

    public void PlayerDamaged(int damage)
    {
        //Remove health
        health -= damage;
    }

    private void DisplayHealth()
    {
        //Changes sprites based on health amount
        if (health == 6)
        {
            health3.sprite = fullHeart;
            health2.sprite = fullHeart;
            health1.sprite = fullHeart;
        }
        else if (health == 5)
        {
            health3.sprite = halfHeart;
            health2.sprite = fullHeart;
            health1.sprite = fullHeart;
        }
        else if (health == 4)
        {
            health3.sprite = emptyHeart;
            health2.sprite = fullHeart;
            health1.sprite = fullHeart;
        }
        else if (health == 3)
        {
            health3.sprite = emptyHeart;
            health2.sprite = halfHeart;
            health1.sprite = fullHeart;
        }
        else if (health == 2)
        {
            health3.sprite = emptyHeart;
            health2.sprite = emptyHeart;
            health1.sprite = fullHeart;
        }
        else if (health == 1)
        {
            health3.sprite = emptyHeart;
            health2.sprite = emptyHeart;
            health1.sprite = halfHeart;
        }
        else if (health <= 0)
        {
            health3.sprite = emptyHeart;
            health2.sprite = emptyHeart;
            health1.sprite = emptyHeart;
            //Call function
            PlayerDead();
        }
    }

    private void MaxHealthDisplay()
    {
        if (maxHealth == 6)
        {
            health3.gameObject.SetActive(true);
            health2.gameObject.SetActive(true);
            health1.gameObject.SetActive(true);
        }
        if (maxHealth == 4)
        {
            health3.gameObject.SetActive(false);
            health2.gameObject.SetActive(true);
            health1.gameObject.SetActive(true);
        }
        if (maxHealth == 2)
        {
            health3.gameObject.SetActive(false);
            health2.gameObject.SetActive(false);
            health1.gameObject.SetActive(true);
        }
    }

    private void PlayerDead()
    {

        if (gameManager.gameState == GameState.InProgress)
        {
            //Change game state
            if (gameManager.gameMode == GameMode.MainGame)
                gameManager.gameState = GameState.GameLoss;
            else if (gameManager.gameMode == GameMode.EndlessMode)
                gameManager.gameState = GameState.EndlessGameOver;
        }
    }
}
