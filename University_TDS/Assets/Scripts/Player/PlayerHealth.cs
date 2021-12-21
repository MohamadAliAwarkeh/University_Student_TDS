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

    private void Update() => DisplayHealth();

    private void DisplayHealth()
    {
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
        else if (health == 0)
        {
            health3.sprite = emptyHeart;
            health2.sprite = emptyHeart;
            health1.sprite = emptyHeart;
        }
    }
}
